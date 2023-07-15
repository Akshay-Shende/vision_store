using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Helper;
using VisionStore.Models;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IConfiguration _config;
        private object _user;

        public LoginController(IConfiguration config, VisionStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _config = config;
        }


        private LoginDto? AuthenticateUser([FromBody]Login login)
        {
             LoginDto _user = null;
            var data = _dbContext.userMasters.Include(x => x.Role).ToList();

            var result = data.Find(x => x.Id == login.userId);
            if (result==null)
            {
                return null;
            }
           var output =  PasswordHasher.VerifyPassword(login.password, result.Password);

            if (output)
            {
                _user = new LoginDto()
                {
                    userId = login.userId,
                    password = login.password,
                    Role = result.Role.RoleName,
                    UserMaster = result
                };
                return _user;
            }
            return null;  
        }

        private string GenerateToken(LoginDto login)
        {
            var securityToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityToken,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, login.userId.ToString()),
                new Claim(ClaimTypes.GivenName, login.password),
                new Claim(ClaimTypes.Role,login.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                             _config["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(30),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token) ;
        }

        
        [HttpPost]
        public IActionResult Post([FromBody]Login login)
        {
            var result = AuthenticateUser(login);
           
            if (result!=null)
            {
                var token = GenerateToken(result);

                var model = new
                {
                    _token = token,
                    _result = result
                };
                return Ok(model);
            }

            return null;

            
        }
    }
}
