using CleanArchitecture.Domain.Services;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistence.Tests
{
    [TestFixture]
    public class ContinentRepositoryTest
    {
        private readonly IContinentRepository _continentRepository;

        public ContinentRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer("Server=(local);Database=ContinentContext;Trusted_Connection=True;")
                .EnableDetailedErrors()
                .Options;
            var context = new DatabaseContext(options);
            _continentRepository = new ContinentRepository(context);
        }

        [Test]
        public void Integration_Test_Continent_Should_fail_when_on_creation_when_DbContext_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new ContinentRepository(null));
        }

        [Test]
        public async Task IntegrationTest_Continent_GetAllContinents_Should_return_all_continents()
        {
            var response = await _continentRepository.GetAllContinentsAsync(CancellationToken.None);
            CollectionAssert.IsNotEmpty(response);
        }

        [Test]
        public async Task Continent_GetContinentAsync_Should_Return_continent_by_continent_id()
        {
            var continent = await _continentRepository.GetContinentAsync(Guid.Parse("EDC63F66-3D33-4B3E-B44D-294CC49B1FCD"), CancellationToken.None);
            Assert.IsFalse(continent.Id == Guid.Empty);
        }

        [Test]
        public async Task Continent_AddOrUpdateContinent_Should_Update_continent_by_continent_id()
        {
            var continent = await _continentRepository.GetContinentAsync(Guid.Parse("EDC63F66-3D33-4B3E-B44D-294CC49B1FCD"), CancellationToken.None);
            continent
                .UpdateName("Asia")
                .UpdateArea(44580000)
                .UpdateCoordinates(new Coordinate(34.0479, 100.6197));

            continent = await _continentRepository.AddOrUpdateContinentAsync(continent, CancellationToken.None);

            Assert.IsTrue(Equals(continent.Name, "Asia"));
        }
    }
}
