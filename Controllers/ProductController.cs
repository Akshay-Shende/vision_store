using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly Repository<Products> _repository;
        private readonly FileServiceRepository _fileServiceRepository;

        public ProductController(ProductRepository productRepository, IMapper mapper, Repository<Products> repository, FileServiceRepository fileServiceRepository)
        {
            _productRepository = productRepository;
            _mapper            = mapper;
            _repository        = repository;
            _fileServiceRepository = fileServiceRepository;
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
            var result = _productRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post( [FromForm] ProductsDto products)
        {
            if (products.ProductImageUrl == null || products.ProductImageUrl.Length == 0)
                return null;
            string base64String;
            using (var memoryStream = new MemoryStream())
            {
                products.ProductImageUrl.CopyTo(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();

                // Convert byte array to Base64 string
                 base64String = Convert.ToBase64String(fileBytes);
               
            }
            var output = _mapper.Map<Products>(products);
            output.ProductImageUrl = base64String;
            var product = _repository.Create(output);
            return Ok(product);
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
