using System;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.WebApi.Models;
using NUnit.Framework;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class GetRegionRequestDtoTests
    {
        [Test]
        public void GetRegionRequestDto_Should_return_IdViolationException_when_ContinentId_is_empty()
        {
            Assert.Throws<IdViolationException>(() => _ = new GetRegionRequestDto
                { RegionId = Guid.Empty });
        }

        [Test]
        public void GetRegionRequestDto_Should_return_set_ContinentId()
        {
            var regionId = Guid.NewGuid();
            var continent = new GetRegionRequestDto { RegionId = regionId };

            Assert.IsTrue(regionId == continent.RegionId);
        }
    }
}