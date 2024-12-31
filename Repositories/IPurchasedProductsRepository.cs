using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IPurchasedProductsRepository
    {
        public abstract List<PurchasedProducts> Create(List<PurchasedProductsDto> purchasedProductsDto);
    }
}
