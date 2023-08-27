using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using VisionStore.Data;
using VisionStore.Helper;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasswordController : ControllerBase
    {
        private readonly UserMasterRepository _userMasterRepository;
        private readonly VisionStoreDbContext _dbContext;
        private readonly EmailSenderRepository _emailSender;
        private readonly Repository<UserMaster> _repository;

        public ForgetPasswordController(VisionStoreDbContext dbContext,
                                        EmailSenderRepository emailSender, 
                                        UserMasterRepository userMasterRepository,
                                        Repository<UserMaster> repository
                                        )
        {
            _dbContext            = dbContext;
            _emailSender          = emailSender;
            _userMasterRepository = userMasterRepository;
            _repository           = repository;
        }

        [HttpGet]
        [Route("{email}")]
        public IActionResult Get(string email)
        {
            var user = _userMasterRepository.FindByEmailAsync(email);
            if (user == null)
            {
                return Ok();
            }
            //var resetToken = GeneratePasswordResetToken(user);
            _emailSender.SendEmailSec("akshayshende2700@gmail.com", "TestMail", "http://localhost:3000/resetcomponent");

            return Ok(new{ message= "Reset Link Successfuly Sent to your Email", id= user.Id });
        }

        [HttpPost]
        public IActionResult Post(PasswordResetModel resetModel)
        {
            var user = _userMasterRepository.GetById(resetModel.Id);
            if (user == null)
            {
                return Ok();
            }
            var hashPassword = PasswordHasher.HashPassword(resetModel.Password);
            user.Password = hashPassword;
            _dbContext.userMasters.Update(user);
            _dbContext.SaveChanges();
            return Ok("Password Successfully Reset");
        }
    }
}
