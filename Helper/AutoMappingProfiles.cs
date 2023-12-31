﻿using AutoMapper;
using VisionStore.Dto;
using VisionStore.Models;

namespace VisionStore.Helper
{
    public class AutoMappingProfiles:Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<RolesDto,Roles>().ReverseMap();
            CreateMap<ManufacturerDto, Manufacturer>().ReverseMap();
            CreateMap<UserMasterDto, UserMaster>().ReverseMap();
            CreateMap<DiscountTableDto, DiscountTable>().ReverseMap();
            CreateMap<DeliveryDto, DeliveryMethods>().ReverseMap();
            CreateMap<ProductsDto, Products>().ReverseMap();
            CreateMap<CartDto, Cart>().ReverseMap();
        }    
    }
}
