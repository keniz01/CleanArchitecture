using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebApi.Controllers;
using CleanArchitecture.WebApi.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class ContinentControllerTests
    {
        private static IMapper _mapper;

        public ContinentControllerTests()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            _mapper = mappingConfig.CreateMapper();
        }

        [Test]
        public async Task GetContinentCountriesAsync_Should_return_countries_on_continent_by_continent_id()
        {
            var logger = new Mock<ILogger<ContinentController>>();

            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<GetContinentIdRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetContinentCountriesResponse(new List<Country>
                {
                    new(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                }));

            var continentController = new ContinentController(logger.Object, mediator.Object, _mapper);
            var continentCountries =
                await continentController.GetContinentCountriesAsync(new GetContinentIdRequestDto { Id = Guid.NewGuid() }, CancellationToken.None);

            Assert.IsTrue(continentCountries.Data.Countries.Count > 0);
        }
    }
}
