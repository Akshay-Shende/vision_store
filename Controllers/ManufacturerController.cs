using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly ManufacturerRepository _manufacturerRepo;

        public ManufacturerController(ManufacturerRepository manufacturerRepo)
        {
            _manufacturerRepo = manufacturerRepo;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(_manufacturerRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_manufacturerRepo.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Manufacturer model)
        {
            return Ok(_manufacturerRepo.Create(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_manufacturerRepo.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(ManufacturerDto model,int id) { 
        return Ok(_manufacturerRepo.Update(id,model));
        }
    }
}
