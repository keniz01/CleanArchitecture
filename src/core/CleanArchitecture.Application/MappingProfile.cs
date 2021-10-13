using AutoMapper;
using CleanArchitecture.Application.Continent;
using CleanArchitecture.Domain.Pagination;

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
            //CreateMap<Pager<Domain.Entities.Country>, GetContinentCountriesResponse>()
            //    .ForMember(dest => dest.PagedResults.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords))
            //    .ForMember(dest => dest.PagedResults.PageSize, opt => opt.MapFrom(src => src.PageSize))
            //    .ForMember(dest => dest.PagedResults, opt => opt.MapFrom(src => src))
            //    .ForMember(dest => dest.PagedResults.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
            //    .ForMember(dest => dest.PagedResults.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
        }
    }
}