using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryController(DeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

       
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_deliveryRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_deliveryRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] DeliveryMethods model)
        {
            return Ok(_deliveryRepository.Create(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_deliveryRepository.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(DeliveryDto model, int id)
        {
            return Ok(_deliveryRepository.Update(id, model));
        }
    }
}
