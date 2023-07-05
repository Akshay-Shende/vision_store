using AutoMapper;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class PreferredPaymentMethodRepository : IPreferredPaymentMethodRepository
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Repository<PreferredPaymentMethod> _repository;
        public PreferredPaymentMethodRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<PreferredPaymentMethod> repository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _repository = repository;

        }
        public PreferredPaymentMethod? Create(PreferredPaymentMethod preferredPaymentMethod)
        {
            var result = _repository.Create(preferredPaymentMethod);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public PreferredPaymentMethod? Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<PreferredPaymentMethod>? GetAll()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }
    

        public PreferredPaymentMethod? GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public PreferredPaymentMethod? Update(int id, PreferredPaymentMethodDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
