using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Dto;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index([FromQuery ] string filter = "default")
        {
            var products = _productRepository.GetAll();
            if (filter == "asc")
            {
                return Ok(products.Where(x => x.ProductInventoryLevel>0).OrderBy(e => e.ProductName));
            }
           else if(filter == "desc")
            {
                return Ok(products.Where(x => x.ProductInventoryLevel > 0).OrderByDescending(e => e.ProductName));
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Products model)
        {
            return Ok(_productRepository.Create(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_productRepository.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(ProductsDto model, int id)
        {
            return Ok(_productRepository.Update(id, model));
        }
    }
}
