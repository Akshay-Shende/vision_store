using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class PurchaseProductRepository : IPurchaseProductRepository
    {
        private readonly VisionStoreDbContext         _dbContext;
        private readonly IMapper                      _mapper;
        private readonly Repository<PurchaseProducts> _repository;

        public PurchaseProductRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<PurchaseProducts> repository)
        {
            _dbContext  =  dbContext;
            _mapper     =  mapper;
            _repository =  repository;

        }
        public PurchaseProducts? Create(PurchaseProducts purchaseProducts)
        {
            var result = _repository.Create(purchaseProducts);
            if (result != null)
            {
                return result;
            }
            return null;

        }

        public PurchaseProducts? Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<PurchaseProducts>? GetAll()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public PurchaseProducts? GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public PurchaseProducts Update(int id, PurchaseProductsDto purchaseProductsDto)
        {
            throw new NotImplementedException();
        }
    }
}
