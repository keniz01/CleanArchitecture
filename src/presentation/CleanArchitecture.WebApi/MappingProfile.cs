using AutoMapper;
using CleanArchitecture.Application.Country.Search;
using CleanArchitecture.Application.Region.AddOrUpdateRegion;
using CleanArchitecture.Application.Region.GetRegion;
using CleanArchitecture.Application.Region.GetRegionCountries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.WebApi.Models;
using System.Linq;

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
            CreateMap<GetRegionResponse, RegionDto>()
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
                .ForMember(dest => dest.Capacity, opt => opt.Ignore())
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Pager.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.Pager.TotalPages))
                .AfterMap((src, dest) =>
                {
                    var countries = src.Pager.Select(country =>
                        new CountryDto
                        {
                            Area = country.Area,
                            CapitalCity = new CapitalCityDto
                            {
                                Area = country.CapitalCity.Area,
                                Coordinates = new CoordinateDto
                                {
                                    Latitude = country.CapitalCity.Coordinates.Latitude,
                                    Longitude = country.CapitalCity.Coordinates.Longitude
                                },
                                Id = country.CapitalCity.Id,
                                Name = country.CapitalCity.Name
                            },
                            Id = country.Id,
                            Name = country.Name,
                            Coordinates = new CoordinateDto
                            {
                                Latitude = country.Coordinates.Latitude,
                                Longitude = country.Coordinates.Longitude
                            }
                        });
                    dest.AddRange(countries);
                });
            CreateMap<AddOrUpdateRegionResponse, RegionDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Region.Area))
                .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => src.Region.Coordinates))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Region.Countries))
                .ForMember(dest => dest.ContinentId, opt => opt.MapFrom(src => src.Region.ContinentId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Region.Id));
            CreateMap<GetCountrySearchResponse, PagerDto<CountryDto>>()
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.Pager.TotalRecords))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Pager.PageSize))
                .ForMember(dest => dest.Capacity, opt => opt.Ignore())
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Pager.PageNumber))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.Pager.TotalPages))
                .AfterMap((src, dest) =>
                {
                    var countries = src.Pager.Select(country =>
                        new CountryDto
                        {
                            Area = country.Area,
                            CapitalCity = new CapitalCityDto
                            {
                                Area = country.CapitalCity.Area,
                                Coordinates = new CoordinateDto
                                {
                                    Latitude = country.CapitalCity.Coordinates.Latitude,
                                    Longitude = country.CapitalCity.Coordinates.Longitude
                                },
                                Id = country.CapitalCity.Id,
                                Name = country.CapitalCity.Name
                            },
                            Id = country.Id,
                            Name = country.Name,
                            Coordinates = new CoordinateDto
                            {
                                Latitude = country.Coordinates.Latitude,
                                Longitude = country.Coordinates.Longitude
                            }
                        });
                    dest.AddRange(countries);
                });
        }
    }
}