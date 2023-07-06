using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountTableController : ControllerBase
    {
        private readonly IDiscountTableRepository _discountTableRepository;

        public DiscountTableController(DiscountTableRepository discountTableRepository)
        {
            _discountTableRepository = discountTableRepository;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(_discountTableRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_discountTableRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] DiscountTable model)
        {
            return Ok(_discountTableRepository.Create(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_discountTableRepository.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(DiscountTableDto model, int id)
        {
            return Ok(_discountTableRepository.Update(id, model));
        }
    }
}
