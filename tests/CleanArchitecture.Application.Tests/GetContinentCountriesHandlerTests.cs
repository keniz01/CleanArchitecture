using CleanArchitecture.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Entities;
using NUnit.Framework;

namespace CleanArchitecture.Application.Tests
{
    [TestFixture]
    public class GetContinentCountriesHandlerTests
    {
        [Test]
        public async Task Continent_GetContinentCountriesRequestHandler_Should_return_continent_countries_by_continent_id()
        {
            var repository = new Mock<IContinentRepository>();
            repository.Setup(repo =>
                    repo.GetContinentCountriesAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new List<Country>()
                {
                    new Country(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new Country(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new Country(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                });

            var mapper = new Mock<IMapper>();
            var handler = new GetContinentCountriesRequestHandler(repository.Object, mapper.Object);
            var response = await handler.Handle(new GetContinentIdRequest(Guid.NewGuid()), CancellationToken.None);

            CollectionAssert.IsNotEmpty(response.Countries);
        }
    }
}
