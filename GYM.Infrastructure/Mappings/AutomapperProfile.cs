using AutoMapper;
using GYM.Core.DTOs;
using GYM.Core.Entities;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Province, ProvinceDto>().ReverseMap();

        CreateMap<Locality, LocalityDto>().ReverseMap();

        CreateMap<Event, EventDto>().ReverseMap();
        
        CreateMap<Security, SecurityDto>().ReverseMap();

        CreateMap<Fight, FightDto>().ReverseMap();

        CreateMap<Dojo, DojoDto>()
             .ForMember(dest => dest.LocalityName, opt => opt.MapFrom(src => src.Locality != null ? src.Locality.Description : null))
             .ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.Province != null ? src.Province.Description : null))
             .ForMember(dest => dest.ShortAddress, opt => opt.MapFrom(src => src.Address))
             .ForMember(dest => dest.FullAddress, opt => opt.Ignore())
             .ReverseMap();

        CreateMap<Fighter, FighterDto>()
             .ForMember(dest => dest.DojoName, opt => opt.MapFrom(src => src.Dojo != null ? src.Dojo.Name : null))
             .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Event != null ? src.Event.Description : null))
             .ReverseMap();
    }
}
