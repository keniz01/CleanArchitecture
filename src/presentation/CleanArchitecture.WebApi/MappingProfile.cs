using AutoMapper;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Continent;
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
            CreateMap<GetContinentCountriesRequestDto, GetContinentCountriesRequest>();
            CreateMap<GetContinentCountriesResponse, GetContinentCountriesResponseDto>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.PagedResults.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PagedResults.PageSize))
                .ForMember(dest => dest.PagedResults, opt => opt.MapFrom(src => src.PagedResults.Data))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PagedResults.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.PagedResults.TotalPages));
            CreateMap<Country, CountryDto>();
            CreateMap<CapitalCity, CapitalCityDto>();
            CreateMap<Coordinate, CoordinateDto>();
        }
    }
}