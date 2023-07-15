using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleRepository _roleRepository;
        private readonly Repository<Roles> _repository;
      
        private readonly IMapper _mapper;

        public RolesController(RoleRepository roleRepository, Repository<Roles> repository,IMapper mapper)
        {

            _roleRepository = roleRepository;
            _repository    = repository;
            
            _mapper        = mapper;
            //_dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Roles ppm)
        {
            
            var result = _repository.Create(ppm);
            return Ok(result);

        }

        
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) { 
        var result= _repository.GetById(id);
            return Ok(result);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]int id)
        {
            var result = _repository.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody]RolesDto roleDto)
        {
            var result = _roleRepository.Update(id, roleDto);
            if (result != null)
            {
                return Ok(result);
            }
            return null;
        }
    }
}
