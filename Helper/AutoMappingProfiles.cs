using AutoMapper;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Helper
{
    public class AutoMappingProfiles:Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<RolesDto,Roles>().ReverseMap();
        }    
    }
}
