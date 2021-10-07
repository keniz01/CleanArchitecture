using AutoMapper;
using CleanArchitecture.Application.Continent;
using CleanArchitecture.Application.Country.Search;
using CleanArchitecture.Application.Region.AddOrUpdateRegion;
using CleanArchitecture.Application.Region.GetRegion;
using CleanArchitecture.Application.Region.GetRegionCountries;
using CleanArchitecture.Domain.Entities;
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
            CreateMap<GetCountrySearchResponse, GetCountrySearchResponseDto>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.Results.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Results.PageSize))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Results))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Results.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.Results.TotalPages))
                .ReverseMap();
            CreateMap<GetCountrySearchRequest, GetCountrySearchRequestDto>()
                .ReverseMap();
            CreateMap<ContinentDto, Continent>()
                .ForMember(dest => dest.AuditDates, opt => opt.Ignore());
            CreateMap<GetRegionCountriesRequestDto, GetRegionCountriesRequest>();
            CreateMap<GetContinentCountriesRequestDto, GetContinentCountriesRequest>();
            CreateMap<GetContinentCountriesResponse, GetContinentCountriesResponseDto>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.PagedResults.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PagedResults.PageSize))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.PagedResults))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PagedResults.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.PagedResults.TotalPages));
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<CapitalCity, CapitalCityDto>().ReverseMap();
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();
            CreateMap<RegionDto, Region>()
                .ForMember(dest => dest.AuditDates, opt => opt.Ignore())
                .ForMember(dest => dest.Continent, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<GetRegionCountriesResponse, GetRegionCountriesResponseDto>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.PagedResults.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PagedResults.PageSize))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.PagedResults))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PagedResults.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.PagedResults.TotalPages))
                .ReverseMap();
            CreateMap<GetRegionRequest, GetRegionRequestDto>().ReverseMap();
            CreateMap<GetRegionResponseDto, GetRegionResponse>()
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
                .ReverseMap();
            CreateMap<AddOrUpdateRegionRequest, AddOrUpdateRegionRequestDto>().ReverseMap();
            CreateMap<AddOrUpdateRegionResponse, AddOrUpdateRegionResponseDto>();
        }
    }
}