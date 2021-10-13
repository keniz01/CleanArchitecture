using AutoMapper;
using CleanArchitecture.Application.Region.AddOrUpdateRegion;
using CleanArchitecture.Application.Region.GetRegionCountries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.WebApi.Controllers;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class RegionControllerTests : TestBase
    {
        [Test]
        public async Task Unit_Test_GetRegionCountriesAsync_Should_return_countries_on_Region_by_Region_id()
        {
            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<GetRegionCountriesRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetRegionCountriesResponse(new Pager<Country>(new List<Country>
                {
                    new(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                }, 1, 20, 20, 105)));

            var controller = new RegionController(GetService<ILogger<RegionController>>(), mediator.Object,
                GetService<IMapper>());
            var response = await controller.GetRegionCountriesAsync(Guid.NewGuid(), 1, 20, CancellationToken.None);
            Assert.IsTrue(response.Data.Count > 0);
        }

        [Test]
        public async Task Unit_Test_AddOrUpdateAsync_Should_add_or_update_region_and_return_changed_region()
        {
            var regionId = Guid.NewGuid();
            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<AddOrUpdateRegionRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AddOrUpdateRegionResponse(
                    new Region(regionId, "South America Demo", 333000, new Coordinate(1, 1))
                        .AddOrUpdateCountry(
                            new(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                                new CapitalCity(Guid.NewGuid(), "Edinburgh", 264,
                                    new Coordinate(34.748383, -12.828839))))
                        .AddOrUpdateCountry(new(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                            new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))))
                        .AddOrUpdateCountry(
                            new(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                                new CapitalCity(Guid.NewGuid(), "Dublin", 264,
                                    new Coordinate(34.748383, -12.828839))))));

            var controller = new RegionController(GetService<ILogger<RegionController>>(), mediator.Object,
                GetService<IMapper>());

            var region = GetRegionTestData();
            region.Id = Guid.NewGuid();
            var result = await controller.AddOrUpdateRegionAsync(region, CancellationToken.None);

            Assert.IsFalse(result is null);
        }

        [Test]
        public async Task
            Integration_Test_GetContinentCountriesAsync_Should_return_countries_on_continent_by_continent_id()
        {
            var controller = new RegionController(GetService<ILogger<RegionController>>(), GetService<IMediator>(),
                GetService<IMapper>());

            var response = await controller.GetRegionCountriesAsync(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30"), 1, 20, CancellationToken.None);

            Assert.IsTrue(response.Data.Count > 0);
        }

        [Test]
        public async Task Integration_Test_AddOrUpdateAsync_Should_add_or_update_region_and_return_changed_region()
        {
            var controller = new RegionController(GetService<ILogger<RegionController>>(), GetService<IMediator>(),
                GetService<IMapper>());

            var getRegionResponse = await controller.GetRegionAsync(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30"), CancellationToken.None);
            getRegionResponse.Data.Name = "South America Test 01";

            var response = await controller.AddOrUpdateRegionAsync(getRegionResponse.Data, CancellationToken.None);

            Assert.IsTrue(Equals(response.Data.Name, "South America Test 01"));
        }
    }
}