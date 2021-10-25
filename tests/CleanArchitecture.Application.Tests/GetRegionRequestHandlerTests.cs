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
using CleanArchitecture.Application.Region.GetBy.Id;

namespace CleanArchitecture.Application.Tests
{
    [TestFixture]
    public class GetRegionRequestHandlerTests
    {
        private readonly IRegionRepository _regionRepository;

        public GetRegionRequestHandlerTests()
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
        public async Task Unit_Test_Region_GetRegionRequestHandler_Should_return_region_by_region_id()
        {
            var repository = new Mock<IRegionRepository>();
            var regionId = Guid.NewGuid();

            repository.Setup(repo =>
                    repo.GetRegionAsync(regionId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new Domain.Entities.Region(regionId, "Demo Region", 1223, new(-1900, 2300))
                    .AddOrUpdateCountry(new Domain.Entities.Country(Guid.NewGuid(), "Scotland", 110000,
                        new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))))
                    .AddOrUpdateCountry(new Domain.Entities.Country(Guid.NewGuid(), "Wales", 110000,
                        new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))))
                    .AddOrUpdateCountry(new Domain.Entities.Country(Guid.NewGuid(), "Republic of Ireland", 110000,
                        new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))));

            var handler = new GetRegionByIdRequestHandler(repository.Object);
            var response = await handler.Handle(new GetRegionByIdRequest(regionId), CancellationToken.None);

            Assert.IsTrue(response.Region.Id == regionId);
        }

        [Test]
        public async Task Integration_Test_Region_GetRegionRequestHandler_Should_return_region_by_region_id()
        {
            var handler = new GetRegionByIdRequestHandler(_regionRepository);
            var response = await handler.Handle(new GetRegionByIdRequest(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30")), CancellationToken.None);

            Assert.IsTrue(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30") == response.Region.Id);
        }

        [Test]
        public void Integration_Test_Region_GetRegionRequestHandler_Should_throw_ArgumentNullException_when_RegionRepository_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new GetRegionByIdRequestHandler(default));
        }
    }
}