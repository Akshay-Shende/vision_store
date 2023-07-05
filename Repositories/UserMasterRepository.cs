using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class UserMasterRepository: IUserMasterRepository
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Repository<UserMaster> _repository;
        public UserMasterRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<UserMaster> repository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _repository = repository;
        }

        public UserMaster Create(UserMaster userMaster)
        {
            var result = _repository.Create(userMaster);          
                return result;        
        }

        public UserMaster Delete(int id)
        {
            var result = _repository.Delete(id);          
                return result;
        }

        public List<UserMaster> GetAll()
        {
            var result = _repository.GetAll();      
                return result;
        }

        public UserMaster GetById(int id)
        {
            var result = _repository.GetById(id);      
                return result;
        }

        public UserMaster Update(int id, UserMasterDto userMasterDto)
        {
            var data = _dbContext.userMasters.Find(id);
            if (data != null)
            {
                data = _mapper.Map<UserMasterDto, UserMaster>(userMasterDto);
                data.Id = id;
                var result = _dbContext.userMasters.Update(data);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            return null;
        }
    }
}
