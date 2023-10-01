using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IUserMasterRepository
    {
        public abstract List<UserMaster> GetAll();
        public abstract UserMaster GetById(int id);
        public abstract UserMaster Create(UserMaster userMaster);
        public abstract UserMaster Update(int id, UserMasterDto customer);
        public abstract UserMaster Delete(int id);
        public abstract UserMaster FindByEmailAsync(string email);
    }
}
