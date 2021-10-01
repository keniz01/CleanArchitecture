using System;
using System.Collections.Generic;
using System.Reflection;
using CleanArchitecture.Application.Continent;
using CleanArchitecture.Domain.Services;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.Repositories;
using CleanArchitecture.WebApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.WebApi.Tests
{
    public class TestBase
    {
        private readonly IServiceProvider _serviceProvider;

        public TestBase()
        {
            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(typeof(GetContinentCountriesRequest).GetTypeInfo().Assembly)
                .AddScoped<IContinentRepository, ContinentRepository>()
                .AddScoped<IRegionRepository, RegionRepository>()
                .AddScoped<ICountryRepository, CountryRepository>()
                .AddDbContext<DatabaseContext>(context =>
                    context.UseSqlServer("Server=(local);Database=ContinentContext;Trusted_Connection=True;"))
                .BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public static RegionDto GetRegionTestData()
        {
            var region = new RegionDto
            {
                Coordinates = new CoordinateDto { Latitude = -1.319300, Longitude = 4.130322 },
                Area = 3450000,
                Name = "Demo Region",
                Countries = new List<CountryDto>
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Scotland",
                        Area = 110000,
                        Coordinates = new CoordinateDto
                        {

                            Latitude = -3.4748383, Longitude = 3.828839
                        },
                        CapitalCity = new CapitalCityDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Edinburgh",
                            Area = 264,
                            Coordinates = new CoordinateDto
                            {
                                Latitude = -1.748383,
                                Longitude = 2.828839
                            }
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Wales",
                        Area = 110000,
                        Coordinates = new CoordinateDto
                        {

                            Latitude = -3.4748383, Longitude = 3.828839
                        },
                        CapitalCity = new CapitalCityDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Cardiff",
                            Area = 264,
                            Coordinates = new CoordinateDto
                            {
                                Latitude = -1.748383,
                                Longitude = 2.828839
                            }
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Republic of Ireland",
                        Area = 110000,
                        Coordinates = new CoordinateDto
                        {

                            Latitude = -3.4748383, Longitude = 3.828839
                        },
                        CapitalCity = new CapitalCityDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Dublin",
                            Area = 264,
                            Coordinates = new CoordinateDto
                            {
                                Latitude = -1.748383,
                                Longitude = 2.828839
                            }
                        }
                    }
                }
            };

            return region;
        }
    }
}