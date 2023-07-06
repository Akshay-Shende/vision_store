using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseProductController : ControllerBase
    {
        private readonly PurchaseProductRepository _purchaseProductRepository;

        public PurchaseProductController(PurchaseProductRepository purchaseProductRepository)
        {
            _purchaseProductRepository = purchaseProductRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_purchaseProductRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_purchaseProductRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PurchaseProducts model)
        {
            return Ok(_purchaseProductRepository.Create(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_purchaseProductRepository.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(PurchaseProductsDto model, int id)
        {
            return Ok(_purchaseProductRepository.Update(id, model));
        }
    }
}
