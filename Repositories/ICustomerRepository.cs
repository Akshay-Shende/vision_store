using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface ICustomerRepository
    {
        public abstract List<Customer> GetAll();
        public abstract Customer GetById(int id);
        public abstract Customer Create(Customer customer);
        public abstract Customer Update(int id, CustomerDto customer);
        public abstract Customer Delete(int id);
    }
}
