using CleanArchitecture.Application.Region.GetRegionCountries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.Domain.Services;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Tests
{
    [TestFixture]
    public class GetRegionCountriesHandlerTests
    {
        private readonly IRegionRepository _regionRepository;

        public GetRegionCountriesHandlerTests()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer("Server=(local);Database=ContinentContext;Trusted_Connection=True;")
                .EnableDetailedErrors()
                .Options;
            var context = new DatabaseContext(options);

            //TODO: Dependency injection.
            _regionRepository = new RegionRepository(context);
        }

        [Test]
        public async Task Unit_Test_Region_GetRegionCountriesRequestHandler_Should_return_region_countries_by_region_id()
        {
            var repository = new Mock<IRegionRepository>();
            repository.Setup(repo =>
                    repo.GetRegionCountriesAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new Pager<Domain.Entities.Country>(new List<Domain.Entities.Country>()
                {
                    new Domain.Entities.Country(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new Domain.Entities.Country(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new Domain.Entities.Country(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                }, 1, 20, 100, 200));

            var handler = new GetRegionCountriesRequestHandler(repository.Object);
            var response = await handler.Handle(new GetRegionCountriesRequest(Guid.NewGuid(), 1, 20), CancellationToken.None);

            CollectionAssert.IsNotEmpty(response.Pager.PagedList);
        }

        [Test]
        public async Task Integration_Test_Region_GetRegionCountriesRequestHandler_Should_return_region_countries_by_region_id()
        {
            var handler = new GetRegionCountriesRequestHandler(_regionRepository);
            var response = await handler.Handle(new GetRegionCountriesRequest(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30"), 1, 20), CancellationToken.None);

            CollectionAssert.IsNotEmpty(response.Pager.PagedList);
        }
    }
}