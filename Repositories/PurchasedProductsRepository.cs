using AutoMapper;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class PurchasedProductsRepository : IPurchasedProductsRepository
    {
        private readonly VisionStoreDbContext          _dbContext;
        private readonly IMapper                       _mapper;
        private readonly Repository<PurchasedProducts> _repository;
        public PurchasedProductsRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<PurchasedProducts> repository)
        {
            _dbContext  = dbContext;
            _mapper     = mapper;
            _repository = repository;
        }
        public List<PurchasedProducts>? Create(List<PurchasedProductsDto> purchasedProductsDto)
        {
            List<PurchasedProducts> entity = new List<PurchasedProducts>();

            if (purchasedProductsDto !=null || purchasedProductsDto.Count == 0)
            {
                foreach (var purchasedProducts in purchasedProductsDto)
                {
                    var data = _dbContext.products.Find(purchasedProducts.ProductId);
                    var products = new PurchasedProducts()
                    {
                        UserMasterId = purchasedProducts.UserMasterId,
                        ProductId = purchasedProducts.ProductId,
                        ProductCount = purchasedProducts.ProductCount,
                        TotalValue = (purchasedProducts.ProductCount * data.ProductUnitPrice)
                    };
                    entity.Add(products);
                }
                var returnData = _repository.CreateBulk(entity);

                return returnData;
            }

            return null;
           
        }
    }
}
