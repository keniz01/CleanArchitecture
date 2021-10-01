using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.Domain.Services;
using CleanArchitecture.Persistence;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Continent;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Tests
{
    [TestFixture]
    public class GetContinentCountriesHandlerTests
    {
        private readonly IContinentRepository _continentRepository;

        public GetContinentCountriesHandlerTests()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer("Server=(local);Database=ContinentContext;Trusted_Connection=True;")
                .EnableDetailedErrors()
                .Options;
            var context = new DatabaseContext(options);
            _continentRepository = new ContinentRepository(context);
        }

        [Test]
        public async Task Unit_Test_Continent_GetContinentCountriesRequestHandler_Should_return_continent_countries_by_continent_id()
        {
            var repository = new Mock<IContinentRepository>();
            repository.Setup(repo =>
                    repo.GetContinentCountriesAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new PagedList<Domain.Entities.Country>(new List<Domain.Entities.Country>()
                {
                    new Domain.Entities.Country(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new Domain.Entities.Country(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new Domain.Entities.Country(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                }, 1, 20, 100, 200));

            var handler = new GetContinentCountriesRequestHandler(repository.Object);
            var response = await handler.Handle(new GetContinentCountriesRequest(Guid.NewGuid(), 1, 20), CancellationToken.None);

            CollectionAssert.IsNotEmpty(response.PagedResults.Data);
        }

        [Test]
        public async Task Integration_Test_Continent_GetContinentCountriesRequestHandler_Should_return_continent_countries_by_continent_id()
        {
            var handler = new GetContinentCountriesRequestHandler(_continentRepository);
            var response = await handler.Handle(new GetContinentCountriesRequest(Guid.Parse("EDC63F66-3D33-4B3E-B44D-294CC49B1FCD"), 1, 20), CancellationToken.None);

            CollectionAssert.IsNotEmpty(response.PagedResults.Data);
        }
    }
}
