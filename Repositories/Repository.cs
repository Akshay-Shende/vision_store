using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System.Reflection.Metadata.Ecma335;
using VisionStore.Data;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class Repository<T>  : IRepository<T> where T : class
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private readonly IMapper _mapper;

        public Repository(VisionStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _dbSet =_dbContext.Set<T>();
            _mapper = mapper;
        }
        public T? GetById(int id) { 
        var result = _dbSet.Find(id);
            if (result!=null)
            {
              return result;
            }
            return null;
        }

        public T? Create(T entity)
        {
          var result = _dbSet.Add(entity);
            _dbContext.SaveChanges();
            if (result != null)
            {
                return result.Entity;
            }
            return null;
        }

        public T? Delete(int id)
        {
            var data = GetById(id);
          
            if (data != null)
            {
                var result = _dbSet.Remove(data);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            return null;
        }

        public List<T>? GetAll()
        {
            var result =  _dbSet.ToList();

            if (result != null)
            {
                return result;
            }
            return null;
        }
      

    }
}
