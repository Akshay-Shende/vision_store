using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IDeliveryRepository
    {
        public abstract List<DeliveryMethods> GetAll();
        public abstract DeliveryMethods GetById(int id);
        public abstract DeliveryMethods Create(DeliveryMethods delivery);
        public abstract DeliveryMethods Update(int id, DeliveryDto delivery);
        public abstract DeliveryMethods Delete(int id);
    }
}
