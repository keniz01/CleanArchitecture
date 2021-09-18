using AutoMapper;
using CleanArchitecture.Application;
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
            CreateMap<GetContinentIdRequestDto, GetContinentIdRequest>();
            CreateMap<GetContinentCountriesResponseDto, GetContinentCountriesResponse>();
            CreateMap<CountryDto, Country>();
        }
    }
}