using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
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
                    repo.GetContinentCountriesAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new PagedList<Country>(new List<Country>()
                {
                    new(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                }, 1, 10, 30, 100));

            var response = await repository.Object.GetContinentCountriesAsync(Guid.NewGuid(), 1, 10, CancellationToken.None);
            CollectionAssert.IsNotEmpty(response.Data);
        }
    }
}
