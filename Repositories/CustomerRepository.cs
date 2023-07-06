using AutoMapper;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Repository<Customer> _repository;
        public CustomerRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<Customer> repository)
        {
            _dbContext  = dbContext;
            _mapper     = mapper;
            _repository = repository;
        }
        public Customer? Create(Customer customer)
        {
            var result = _repository.Create(customer);
            if (result!=null)
            {
                return result;
            }
            return null;

        }

        public Customer? Delete(int id)
        {
           var result = _repository.Delete(id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Customer>? GetAll()
        {
           var result = _repository.GetAll();
            if (result!=null)
            {
                return result;
            }
                return null;
        }

        public Customer? GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public Customer? Update(int id, CustomerDto customer)
        {
            var data = _dbContext.customers.Find(id);
            if (data!=null)
            {   
               data  = _mapper.Map<CustomerDto, Customer>(customer);
                data.CustomerId = id;
                var result = _dbContext.customers.Update(data);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            return null;
        }

    }
}
