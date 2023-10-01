using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddToCartController : ControllerBase
    {
        private readonly AddToCartRepository _addToCart;

        public AddToCartController(AddToCartRepository addToCart)
        {
            _addToCart = addToCart;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_addToCart.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var records = _addToCart.GetByUserId(id);
            var cartCount = records.Count();
            var result = new { records, cartCount };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cart model)
        {
            return Ok(_addToCart.Create(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_addToCart.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(CartDto model, int id)
        {
            return Ok(_addToCart.Update(id, model));
        }
    }
}
