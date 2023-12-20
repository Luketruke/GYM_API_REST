using AutoMapper;
using GYM.Core.DTOs;
using GYM.Core.Entities;
using GYM.Core.Enumerators;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Dojo, DojoDto>()
    .ForMember(dest => dest.ShortAddress, opt => opt.MapFrom(src => src.Address))
    .ForMember(dest => dest.FullAddress, opt => opt.Ignore())
    .ForMember(dest => dest.LocalityName, opt => opt.MapFrom(src => src.Locality.Description))
    .ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.Province.Description))
    .ReverseMap();

        CreateMap<Security, SecurityDto>().ReverseMap();

        CreateMap<Province, ProvinceDto>().ReverseMap();

        CreateMap<Locality, LocalityDto>().ReverseMap();

        CreateMap<FighterDto, Fighter>().ReverseMap();

    }
}
