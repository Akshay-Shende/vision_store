using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Repository<Purchase> _repository;
        public PurchaseRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<Purchase> repository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _repository = repository;
        }
        public Purchase? Create(Purchase customer)
        {
            var result = _repository.Create(customer);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Purchase? Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<Purchase>? GetAll()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Purchase? GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Purchase Update(int id, PurchaseDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
