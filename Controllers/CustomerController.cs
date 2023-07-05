using AutoMapper;
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
    public class CustomerController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly CustomerRepository _customerRepository;
        private readonly VisionStoreDbContext _dbContext;

        public CustomerController(CustomerRepository customerRepository, IMapper mapper, VisionStoreDbContext dbContext)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerRepository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_customerRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var data = _dbContext.customers.Add(customer);
            _dbContext.SaveChanges();
            return Ok(data);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_customerRepository.Delete(id));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDto customerDto)
        {
            return Ok(_customerRepository.Update(id, customerDto));
        }
    }
}
