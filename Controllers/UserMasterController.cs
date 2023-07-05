using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private readonly UserMasterRepository _userMasterRepository;
        private readonly IMapper _mapper;

        public UserMasterController(UserMasterRepository userMasterRepository, IMapper mapper)
        {
            _userMasterRepository = userMasterRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserMaster userMaster)
        {
            var result = _userMasterRepository.Create(userMaster);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userMasterRepository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userMasterRepository.GetById(id));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_userMasterRepository.Delete(id));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] UserMasterDto userMasterDto)
        {
            return Ok(_userMasterRepository.Update(id, userMasterDto));
        }
    }
}
