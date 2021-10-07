using System;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.WebApi.Models;
using NUnit.Framework;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class GetRegionCountriesRequestDtoTests
    {
        [Test]
        public void GetRegionCountriesRequestDto_Should_return_IdViolationException_when_ContinentId_is_empty()
        {
            Assert.Throws<IdViolationException>(() => _ = new GetRegionCountriesRequestDto
                { RegionId = Guid.Empty });
        }

        [Test]
        public void GetRegionCountriesRequestDto_Should_return_set_ContinentId()
        {
            var regionId = Guid.NewGuid();
            var continent = new GetRegionCountriesRequestDto { RegionId = regionId };

            Assert.IsTrue(regionId == continent.RegionId);
        }
    }

    [TestFixture]
    public class GetCountrySearchRequestDtoTests
    {
        [Test]
        public void GetCountrySearchRequestDto_Should_throw_IdViolationException_when_SearchTerm_is_empty_or_null()
        {
            Assert.Throws<SearchTermViolationException>(() => _ = new GetCountrySearchRequestDto
            { SearchTerm = string.Empty });
        }

        [Test]
        public void GetRegionCountriesRequestDto_Should_return_same_instance_result_as_set_at_initialization()
        {
            var searchTerm = "hello world";
            var searchRequest = new GetCountrySearchRequestDto { SearchTerm = searchTerm };

            Assert.IsTrue(Equals(searchTerm, searchRequest.SearchTerm));
        }
    }
}