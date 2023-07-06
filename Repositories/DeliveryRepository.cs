using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Repository<DeliveryMethods> _repository;

        public DeliveryRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<DeliveryMethods> repository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _repository = repository;
        }
        public DeliveryMethods? Create(DeliveryMethods delivery)
        {
            var result = _repository.Create(delivery);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public DeliveryMethods? Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<DeliveryMethods>? GetAll()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public DeliveryMethods? GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public DeliveryMethods? Update(int id, DeliveryDto delivery)
        {
            throw new NotImplementedException();
        }
    }
}
