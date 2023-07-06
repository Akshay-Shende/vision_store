using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseRepository _purchaseRepository;

        public PurchaseController(PurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_purchaseRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_purchaseRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Purchase model)
        {
            return Ok(_purchaseRepository.Create(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_purchaseRepository.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(PurchaseDto model, int id)
        {
            return Ok(_purchaseRepository.Update(id, model));
        }
    }
}
