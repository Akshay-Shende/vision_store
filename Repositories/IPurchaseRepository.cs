using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IPurchaseRepository
    {
        public abstract List<Purchase> GetAll();
        public abstract Purchase GetById(int id);
        public abstract Purchase Create(Purchase customer);
        public abstract Purchase Update(int id, PurchaseDto customer);
        public abstract Purchase Delete(int id);
    }
}
