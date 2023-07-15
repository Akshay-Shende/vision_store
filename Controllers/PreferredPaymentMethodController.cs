using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferredPaymentMethodController : ControllerBase
    {
        private readonly PreferredPaymentMethodRepository _preferredPaymentMethod;

        public PreferredPaymentMethodController(PreferredPaymentMethodRepository preferredPaymentMethod)
        {
            _preferredPaymentMethod = preferredPaymentMethod;
        }

        [HttpPost]
        public ActionResult Post([FromBody] PreferredPaymentMethod preferredPaymentMethod) {
            return Ok(_preferredPaymentMethod.Create(preferredPaymentMethod));
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_preferredPaymentMethod.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_preferredPaymentMethod.GetById(id));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PreferredPaymentMethodDto ppm)
        {
            return Ok(_preferredPaymentMethod.Update((id),ppm));
        }
    }
}
