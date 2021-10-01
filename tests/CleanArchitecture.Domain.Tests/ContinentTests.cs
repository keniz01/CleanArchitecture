using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using NUnit.Framework;
using System;

namespace CleanArchitecture.Domain.Tests
{
    [TestFixture]
    public class ContinentTests
    {
        [Test]
        public void Create_Continent_Should_Throw_InputViolationException_When_Area_Is_Less_Than_0()
        {
            Assert.Throws<InputViolationException>(() => _ = new Continent(Guid.NewGuid(), "Edinburgh", -1, new Coordinate(55.953251, -3.188267)));
        }

        [Test]
        public void Create_Continent_Should_Throw_InputViolationException_When_Name_Is_Null_Or_Empty()
        {
            Assert.Throws<InputViolationException>(() => _ = new Continent(Guid.NewGuid(), default, 264, new Coordinate(55.953251, -3.188267)));
        }

        [Test]
        public void Unit_test_Continent_Create_Continent_Should_Throw_CoordinatesViolationException_When_Coordinates_Is_Null()
        {
            var continent = new Continent(Guid.NewGuid(), "Europe", 100264, new Coordinate(55.953251, -3.188267));
            Assert.Throws<CoordinatesViolationException>(() => _ = continent.UpdateCoordinates(null));
        }

        [Test]
        public void Create_Continent_Should_Throw_CoordinatesViolationException_When_Coordinates_Is_Null()
        {
            Assert.Throws<CoordinatesViolationException>(() => _ = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, default));
        }

        [Test]
        public void Create_Continent_Should_Create_New_Continent()
        {
            Assert.DoesNotThrow(() => _ = new Continent(Guid.NewGuid(), "Europe", 12000, new Coordinate(55.953251, -3.188267)));
        }

        [Test]
        public void Unit_Test_Continent_AddOrUpdateRegion_Should_Throw_RegionViolationException_when_region_is_null()
        {
            var continent = new Continent(Guid.NewGuid(), "Europe", 100264, new Coordinate(55.953251, -3.188267));
            Assert.Throws<RegionViolationException>(() => _ = continent.AddOrUpdateRegion(null));
        }

        [Test]
        public void Unit_Test_Continent_AddOrUpdateRegion_Should_Add_Or_Update_Region()
        {
            var continent = new Continent(Guid.NewGuid(), "Europe", 100264, new Coordinate(55.953251, -3.188267));

            var regionId = Guid.NewGuid();
            var region = new Region(regionId, "Eastern Europe", 120000, new Coordinate(55.010200, -1.777777));
            continent.AddOrUpdateRegion(region);

            Assert.IsTrue(string.Equals(continent.GetRegionById(regionId).Name, "Eastern Europe"));
        }
    }
}