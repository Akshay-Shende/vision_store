using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using VisionStore.Data;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public class AddToCartRepository : IAddToCartRepository
    {
        private readonly VisionStoreDbContext _dbContext;
        private readonly IMapper              _mapper;
        private readonly Repository<Cart>     _repository;
        public AddToCartRepository(VisionStoreDbContext dbContext, IMapper mapper, Repository<Cart> repository)
        {
            _dbContext  = dbContext;
            _mapper     = mapper;
            _repository = repository;
        }
        public Cart Create(Cart cart)
        {
            var result = _repository.Create(cart);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Cart Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<Cart> GetAll()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Cart GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<Cart>? GetByUserId(int userId)
        {
            var result = _dbContext.carts.Include(x => x.Products).Include(x=>x.UserMaster).ToList().Where(x => x.UserMasterId == userId);
            if (result!=null)
            {
                return result.ToList();
            }
            return null;
        }

        public Cart Update(int id, CartDto cartDto)
        {
            var data = _dbContext.carts.Find(id);
            if (data != null)
            {
                data = _mapper.Map<CartDto, Cart>(cartDto);
                data.Id = id;
                var result = _dbContext.carts.Update(data);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            return null;
        }
    }
}
