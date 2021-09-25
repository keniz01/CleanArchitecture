using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
                    repo.GetContinentCountriesAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new PagedList<Country>(new List<Country>()
                {
                    new Country(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new Country(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new Country(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                }, 1, 20, 100, 200));

            var handler = new GetContinentCountriesRequestHandler(repository.Object);
            var response = await handler.Handle(new GetContinentCountriesRequest(Guid.NewGuid(), 1, 20), CancellationToken.None);

            CollectionAssert.IsNotEmpty(response.PagedResults.Data);
        }
    }
}
