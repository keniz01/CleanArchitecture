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
        public void Integration_Test_Country_Should_fail_when_on_creation_when_DbContext_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new CountryRepository(null));
        }

        [TestCase("ira")]
        [TestCase("south")]
        [TestCase("uga")]
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