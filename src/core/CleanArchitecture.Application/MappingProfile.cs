using System.Collections.Generic;
using AutoMapper;
using CleanArchitecture.Application;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application
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
            CreateMap<IEnumerable<Country>, GetContinentCountriesResponse>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src));
        }
    }
}