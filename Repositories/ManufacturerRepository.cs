using AutoMapper;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Repository<Manufacturer> _repository;
        public ManufacturerRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<Manufacturer> repository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _repository = repository;
        }
        public Manufacturer? Create(Manufacturer manufacturer)
        {
            var result = _repository.Create(manufacturer);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Manufacturer? Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<Manufacturer>? GetAll()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Manufacturer? GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Manufacturer? Update(int id, ManufacturerDto customer)
        {
            if (GetById(id) != null)
            {
                var output = _mapper.Map<Manufacturer>(customer);
                output.ManuId = id;
                var result = _dbContext.manufacturers.Update(output);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            return null;
        }

    }
}
    

