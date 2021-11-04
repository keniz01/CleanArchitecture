using AutoMapper;
using CleanArchitecture.Application.Country.Alphabetical;
using CleanArchitecture.Application.Country.GetBy.Region;
using CleanArchitecture.Application.Country.Search;
using CleanArchitecture.Application.Metrics;
using CleanArchitecture.Application.Region.AddOrUpdateRegion;
using CleanArchitecture.Application.Region.GetBy.Id;
using CleanArchitecture.Application.Region.GetRegionCountries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.WebApi.Models;

namespace CleanArchitecture.WebApi
{
    /// <summary>
    /// Mapping profile.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping profile.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<GetRegionByIdResponse, RegionDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Region.Area))
                .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => src.Region.Coordinates))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Region.Countries))
                .ForMember(dest => dest.ContinentId, opt => opt.MapFrom(src => src.Region.ContinentId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Region.Id));
            CreateMap<AddOrUpdateRegionRequest, RegionDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Region.Area))
                .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => src.Region.Coordinates))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Region.Countries))
                .ForMember(dest => dest.ContinentId, opt => opt.MapFrom(src => src.Region.ContinentId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Region.Id));
            CreateMap<CapitalCity, CapitalCityDto>().ReverseMap();
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Pager<Country>, PagerDto<CountryDto>>();
            CreateMap<GetRegionCountriesResponse, PagerDto<CountryDto>>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.Pager.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Pager.PageSize))
                .ForMember(dest => dest.PagedList, opt => opt.MapFrom(src => src.Pager.PagedList))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Pager.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.Pager.TotalPages));
            CreateMap<AddOrUpdateRegionResponse, RegionDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Region.Area))
                .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => src.Region.Coordinates))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Region.Countries))
                .ForMember(dest => dest.ContinentId, opt => opt.MapFrom(src => src.Region.ContinentId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Region.Id));
            CreateMap<GetCountriesMatchingSearchTermResponse, PagerDto<CountryDto>>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.Pager.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Pager.PageSize))
                .ForMember(dest => dest.PagedList, opt => opt.MapFrom(src => src.Pager.PagedList))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Pager.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.Pager.TotalPages));
            CreateMap<GetCountriesByAlphabetResponse, PagerDto<CountryDto>>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.Pager.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Pager.PageSize))
                .ForMember(dest => dest.PagedList, opt => opt.MapFrom(src => src.Pager.PagedList))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Pager.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.Pager.TotalPages));
            CreateMap<Continent, ContinentWithoutRegionsDto>().ReverseMap();
            CreateMap<GetCountriesByRegionResponse, PagerDto<CountryDto>>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.Pager.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Pager.PageSize))
                .ForMember(dest => dest.PagedList, opt => opt.MapFrom(src => src.Pager.PagedList))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Pager.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.Pager.TotalPages));
            CreateMap<GetMetricsResponse, MetricsResponseDto>();
        }
    }
}