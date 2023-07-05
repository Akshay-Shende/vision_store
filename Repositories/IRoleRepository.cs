using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Repositories
{
    public interface IRoleRepository
    {
        public abstract Roles CreateRole(Roles roleDto);
    }
}
