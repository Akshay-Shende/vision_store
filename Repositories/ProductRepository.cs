using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Repository<Products> _repository;
        public ProductRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<Products> repository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _repository = repository;
        }
        public Products? Create(Products products)
        {
            var result = _repository.Create(products);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Products? Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<Products>? GetAll()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Products? GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Products Update(int id, ProductsDto product)
        {
            throw new NotImplementedException();
        }
    }
}
