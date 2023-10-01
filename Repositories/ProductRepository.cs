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
            var result = _dbContext.products.ToList();
            if (result != null)
            {
                foreach (var product in result)
                {
                    var manufacturer = _dbContext.manufacturers.Find(product.ManuId);
                    product.Manufacturer = manufacturer;
                }
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

        public Products? Update(int id, ProductsDto product)
        {
            var data = _dbContext.products.Find(id);
            if (data != null)
            {
                var output = _mapper.Map<Products>(product);
                output.ProductId = id;
                var result = _dbContext.products.Update(output);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            return null;
        }
    }
}
