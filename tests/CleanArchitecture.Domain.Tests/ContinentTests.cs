using CleanArchitecture.Domain.Entities;
using NUnit.Framework;
using System;
using CleanArchitecture.Domain.Exceptions;

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
        public void Create_Continent_Should_Throw_IdViolationException_When_Id_Is_Null_Or_Empty()
        {
            Assert.Throws<InputViolationException>(() => _ = new Continent(default, "Edinburgh", 264, new Coordinate(55.953251, -3.188267)));
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
        public void Update_Continent_Should_Add_Or_Update_Region()
        {
            var continent = new Continent(Guid.NewGuid(), "Europe", 100264, new Coordinate(55.953251, -3.188267));

            var regionId = Guid.NewGuid();
            var region = new Region(regionId, "Eastern Europe", 120000, new Coordinate(55.010200, -1.777777));
            continent.AddOrUpdateRegion(region);

            Assert.IsTrue(string.Equals(continent.GetRegionById(regionId).Name, "Eastern Europe"));
        }
    }
}