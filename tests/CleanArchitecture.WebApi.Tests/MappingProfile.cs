using AutoMapper;
using CleanArchitecture.Application;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebApi.Models;

namespace CleanArchitecture.WebApi.Tests
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
            CreateMap<GetContinentIdRequest, GetContinentIdRequestDto>().ReverseMap();
            CreateMap<GetContinentCountriesResponse, GetContinentCountriesResponseDto>()
                .ForMember(dest => dest.CountryCount, opt => opt.MapFrom(src => src.Countries.Count));
            CreateMap<Country, CountryDto>();
            CreateMap<CapitalCity, CapitalCityDto>();
            CreateMap<Coordinate, CoordinateDto>();
        }
    }
}