using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IProductRepository
    {
        public abstract List<Products> GetAll();
        public abstract Products GetById(int id);
        public abstract Products Create(Products customer);
        public abstract Products Update(int id, ProductsDto customer);
        public abstract Products Delete(int id);
    }
}
