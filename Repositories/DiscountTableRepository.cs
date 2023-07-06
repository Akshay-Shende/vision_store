using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class DiscountTableRepository : IDiscountTableRepository
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Repository<DiscountTable> _repository;
        public DiscountTableRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<DiscountTable> repository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _repository = repository;
        }
        public DiscountTable? Create(DiscountTable discountTable)
        {
            var result = _repository.Create(discountTable);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public DiscountTable? Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<DiscountTable>? GetAll()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public DiscountTable? GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return result;
            }
                return null;
        }

        public DiscountTable? Update(int id, DiscountTableDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
