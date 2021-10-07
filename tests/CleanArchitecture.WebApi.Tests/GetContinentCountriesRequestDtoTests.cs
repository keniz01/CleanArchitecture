using System;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.WebApi.Models;
using NUnit.Framework;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class GetContinentCountriesRequestDtoTests
    {
        [Test]
        public void GetContinentCountriesRequestDto_Should_return_IdViolationException_when_ContinentId_is_empty()
        {
            Assert.Throws<IdViolationException>(() => _ = new GetContinentCountriesRequestDto
                { ContinentId = Guid.Empty });
        }

        [Test]
        public void GetContinentCountriesRequestDto_Should_return_set_ContinentId()
        {
            var continentId = Guid.NewGuid();
            var continent = new GetContinentCountriesRequestDto { ContinentId = continentId };

            Assert.IsTrue(continentId == continent.ContinentId);
        }
    }
}