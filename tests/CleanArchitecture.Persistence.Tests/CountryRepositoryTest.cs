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

        [Test]
        public async Task Integrated_Test_GetCountrySearchAsync_Should_Return_A_List_Of_Countries_On_matching_search_term()
        {
            var response =
                await _countryRepository.GetCountrySearchAsync("uga", 1, 10, CancellationToken.None);
            CollectionAssert.IsNotEmpty(response);
        }

    }
}