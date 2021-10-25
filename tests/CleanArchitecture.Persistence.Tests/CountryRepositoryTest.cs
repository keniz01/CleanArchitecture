using CleanArchitecture.Domain.Services;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Tests
{
    [TestFixture]
    public class CountryRepositoryTest
    {
        private readonly ICountryRepository _countryRepository;

        public CountryRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer("Server=(local);Database=ContinentContext;Trusted_Connection=True;")
                .EnableDetailedErrors()
                .Options;
            var context = new DatabaseContext(options);
            _countryRepository = new CountryRepository(context);
        }

        [Test]
        public async Task Continent_GetCountriesByRegion_Should_Return_A_ListOf_Countries_By_RegionId()
        {
            var response =
                await _countryRepository.GetCountriesByRegionAsync(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30"),
                    1, 10, CancellationToken.None);
            CollectionAssert.IsNotEmpty(response.PagedList);
        }

        [Test]
        public async Task Continent_GetContinentCountries_Should_Return_A_ListOf_Countries_On_The_Continent_By_ContinentId()
        {
            var response =
                await _countryRepository.GetCountriesByContinentAsync(Guid.Parse("EDC63F66-3D33-4B3E-B44D-294CC49B1FCD"),
                    1, 10, CancellationToken.None);
            CollectionAssert.IsNotEmpty(response.PagedList);
        }

        [Test]
        public void Integration_Test_Country_Should_fail_when_on_creation_when_DbContext_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new CountryRepository(null));
        }

        [TestCase("%ira%")]
        [TestCase("south%")]
        [TestCase("uga%")]
        public async Task Integrated_Test_GetCountriesMatchingSearchTermAsync_Should_Return_Countries_matching_search_term(string searchTerm)
        {
            var response =
                await _countryRepository.GetCountriesMatchingSearchTermAsync(searchTerm, 1, 10, CancellationToken.None);
            CollectionAssert.IsNotEmpty(response.PagedList);
        }

        [TestCase('a')]
        [TestCase('s')]
        [TestCase('y')]
        public async Task Integrated_Test_GetCountriesMatchingSearchTermAsync_Should_Return_Countries_starting_with_alphabet(char alphabet)
        {
            var response =
                await _countryRepository.GetCountriesStartingWithAlphabetAsync(alphabet, 1, 10, CancellationToken.None);
            CollectionAssert.IsNotEmpty(response.PagedList);
        }
    }
}