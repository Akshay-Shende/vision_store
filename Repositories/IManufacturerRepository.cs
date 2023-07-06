using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IManufacturerRepository
    {
        public abstract List<Manufacturer> GetAll();
        public abstract Manufacturer GetById(int id);
        public abstract Manufacturer Create(Manufacturer userMaster);
        public abstract Manufacturer Update(int id, ManufacturerDto customer);
        public abstract Manufacturer Delete(int id);
    }
}
