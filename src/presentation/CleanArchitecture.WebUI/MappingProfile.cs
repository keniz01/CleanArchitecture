using AutoMapper;
using CleanArchitecture.WebApi.Client;
using CleanArchitecture.WebUI.Pages.Home.ViewModels;

namespace CleanArchitecture.WebUI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CapitalCityDtoPagerDtoApiResponse, PagedSearchViewModel<CapitalCityDto>>()
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Data.PageNumber))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Data.PageSize))
                .ForMember(dest => dest.PagedList, opt => opt.MapFrom(src => src.Data.PagedList))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.Data.TotalPages))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.Data.TotalRecords));
            CreateMap<CountryDtoPagerDtoApiResponse, PagedSearchViewModel<CountryDto>>()
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Data.PageNumber))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Data.PageSize))
                .ForMember(dest => dest.PagedList, opt => opt.MapFrom(src => src.Data.PagedList))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.Data.TotalPages))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.Data.TotalRecords));
            CreateMap<RegionViewModel, RegionDto>().ReverseMap();
            //CreateMap<CapitalCityViewModel, CapitalCityDto>();
            CreateMap<ContinentViewModel, ContinentWithoutRegionsDto>().ReverseMap();
        }
    }
}