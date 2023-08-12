using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IAddToCartRepository
    {
        public abstract List<Cart> GetAll();
        public abstract Cart GetById(int id);
        public abstract Cart Create(Cart cart);
        public abstract Cart Update(int id, CartDto cartDto);
        public abstract Cart Delete(int id);
        public abstract List<Cart> GetByUserId(int userId);
    }
}
