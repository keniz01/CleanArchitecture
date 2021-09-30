using CleanArchitecture.Application.Region.AddOrUpdateRegion;
using CleanArchitecture.Application.Region.GetRegionCountries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Services;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Region.GetRegion;

namespace CleanArchitecture.Application.Tests
{
    [TestFixture]
    public class AddOrUpdateRegionHandlerTests
    {
        private readonly IRegionRepository _regionRepository;

        public AddOrUpdateRegionHandlerTests()
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
        public async Task Unit_Test_Region_AddOrUpdateRegionRequestHandler_Should_return_added_region()
        {
            var repository = new Mock<IRegionRepository>();

            var regionId = Guid.NewGuid();
            var region = new Domain.Entities.Region(regionId, "Demo Region", 1223, new(-1900, 2300))
                .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Scotland", 110000,
                    new Coordinate(34.748383, -12.828839),
                    new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))))
                .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Wales", 110000,
                    new Coordinate(34.748383, -12.828839),
                    new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))))
                .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Republic of Ireland", 110000,
                    new Coordinate(34.748383, -12.828839),
                    new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839))));

            repository.Setup(repo =>
                    repo.AddOrUpdateRegionAsync(It.IsAny<Domain.Entities.Region>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => region);

            var handler = new AddOrUpdateRegionRequestHandler(repository.Object);
            var response = await handler.Handle(new AddOrUpdateRegionRequest(region), CancellationToken.None);

            Assert.IsTrue(response.Region.Id == regionId);
        }

        [Test]
        public async Task Integration_Test_Region_AddOrUpdateRegionRequestHandler_Should_return_added_region()
        {
            var getRegionRequestHandler = new GetRegionRequestHandler(_regionRepository);

            var getRegionRequest = await getRegionRequestHandler.Handle(new GetRegionRequest(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30")), CancellationToken.None);
            var addOrUpdateRegionRequestHandler = new AddOrUpdateRegionRequestHandler(_regionRepository);
            getRegionRequest.Region.UpdateName("South America Demo");
            var response = await addOrUpdateRegionRequestHandler.Handle(new AddOrUpdateRegionRequest(getRegionRequest.Region), CancellationToken.None);

            Assert.IsNotNull(response.Region);
        }
    }
}