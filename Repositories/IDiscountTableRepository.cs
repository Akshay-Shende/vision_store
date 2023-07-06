using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IDiscountTableRepository
    {
        public abstract List<DiscountTable> GetAll();
        public abstract DiscountTable GetById(int id);
        public abstract DiscountTable Create(DiscountTable discountTable);
        public abstract DiscountTable Update(int id, DiscountTableDto customer);
        public abstract DiscountTable Delete(int id);
    }
}
