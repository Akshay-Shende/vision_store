using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IPurchaseProductRepository
    {
        public abstract List<PurchaseProducts> GetAll();
        public abstract PurchaseProducts GetById(int id);
        public abstract PurchaseProducts Create(PurchaseProducts purchaseProducts);
        public abstract PurchaseProducts Update(int id, PurchaseProductsDto purchaseProductsDto);
        public abstract PurchaseProducts Delete(int id);
    }
}
