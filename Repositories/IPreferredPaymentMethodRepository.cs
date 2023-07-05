using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IPreferredPaymentMethodRepository
    {
        public abstract List<PreferredPaymentMethod> GetAll();
        public abstract PreferredPaymentMethod GetById(int id);
        public abstract PreferredPaymentMethod Create(PreferredPaymentMethod customer);
        public abstract PreferredPaymentMethod Update(int id, PreferredPaymentMethodDto customer);
        public abstract PreferredPaymentMethod Delete(int id);
    }
}
