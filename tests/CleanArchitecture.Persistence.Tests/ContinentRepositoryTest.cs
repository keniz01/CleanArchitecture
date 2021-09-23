using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Services;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Persistence.Tests
{
    [TestFixture]
    public class ContinentRepositoryTest
    {
        [Test]
        public async Task Continent_GetContinentCountries_Should_Return_A_ListOf_Countries_On_The_Continent_By_ContinentId()
        {
            var repository = new Mock<IContinentRepository>();
            repository.Setup(repo =>
                    repo.GetContinentCountriesAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new List<Country>()
                {
                    new(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                });

            var countries = await repository.Object.GetContinentCountriesAsync(Guid.NewGuid(), CancellationToken.None);
            CollectionAssert.IsNotEmpty(countries);
        }
    }
}
