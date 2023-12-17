﻿using AutoMapper;
using GYM.Core.DTOs;
using GYM.Core.Entities;
using GYM.Core.Enumerators;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Dojo, DojoDto>()
           .ForMember(dest => dest.ShortAddress, opt => opt.MapFrom(src => src.Address))
           .ForMember(dest => dest.FullAddress, opt => opt.Ignore());

        CreateMap<DojoDto, Dojo>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ShortAddress));

        CreateMap<Security, SecurityDto>();

        CreateMap<SecurityDto, Security>();

        CreateMap<Province, ProvinceDto>();

        CreateMap<ProvinceDto, Province>();

        CreateMap<Locality, LocalityDto>();

        CreateMap<LocalityDto, Locality>();
    }
}
