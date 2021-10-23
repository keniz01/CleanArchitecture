using AutoMapper;
using CleanArchitecture.Application.Continent;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.WebApi.Controllers;
using CleanArchitecture.WebApi.Models;
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
    public class ContinentControllerTests : TestBase
    {
        [Test]
        public async Task Unit_Test_GetContinentCountriesAsync_Should_return_countries_on_continent_by_continent_id()
        {
            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<GetContinentCountriesRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetContinentCountriesResponse(new Pager<Country>(new List<Country>
                {
                    new(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                }, 1, 20, 20, 105)));

            var continentController = new ContinentController(GetService<ILogger<ContinentController>>(), mediator.Object, GetService<IMapper>());
            var continentCountries =
                await continentController.GetContinentCountriesAsync(Guid.NewGuid(), 1, 20, CancellationToken.None);

            Assert.IsTrue(continentCountries.Data.Count > 0);
        }

        [Test]
        public async Task Integration_Test_GetContinentCountriesAsync_Should_return_countries_on_continent_by_continent_id()
        {
            var controller = new ContinentController(GetService<ILogger<ContinentController>>(), GetService<IMediator>(), GetService<IMapper>());

            var countries = await controller.GetContinentCountriesAsync(Guid.Parse("EDC63F66-3D33-4B3E-B44D-294CC49B1FCD"), 1, 20, CancellationToken.None);

            Assert.IsTrue(countries.Data.Count > 0);
        }
    }
}
