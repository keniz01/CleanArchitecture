using AutoMapper;
using CleanArchitecture.Application.Continent;
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
            CreateMap<ContinentDto, Continent>();
            CreateMap<GetRegionCountriesRequestDto, GetRegionCountriesRequest>();
            CreateMap<GetContinentCountriesRequestDto, GetContinentCountriesRequest>();
            CreateMap<GetContinentCountriesResponse, GetContinentCountriesResponseDto>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.PagedResults.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PagedResults.PageSize))
                .ForMember(dest => dest.PagedResults, opt => opt.MapFrom(src => src.PagedResults.Data))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PagedResults.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.PagedResults.TotalPages));
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<CapitalCity, CapitalCityDto>().ReverseMap();
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();
            CreateMap<RegionDto, Region>()
                .ForMember(dest => dest.Continent, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<GetRegionCountriesResponse, GetRegionCountriesResponseDto>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.PagedResults.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PagedResults.PageSize))
                .ForMember(dest => dest.PagedResults, opt => opt.MapFrom(src => src.PagedResults.Data))
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