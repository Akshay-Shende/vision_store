using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class RoleRepository 
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Repository<Roles> _repository;


        public RoleRepository(VisionStoreDbContext dbContext,IMapper mapper, Repository<Roles> repository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _repository = repository;
        }

        public Roles Update(int id, RolesDto roleDto)
        {
            var data = _dbContext.Roles.Find(id);

            if (data != null)
            {
                data.RoleName = roleDto.RoleName;
                var result = _dbContext.Roles.Update(data);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            return null;
        }
        
        public List<Roles>? GetAll()
        {
            var result = _repository.GetAll();
            if (result!=null)
            {
                return result.ToList();
            }
            return null;
        }
    }
}
