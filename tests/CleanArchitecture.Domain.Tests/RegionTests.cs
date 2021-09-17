using CleanArchitecture.Domain.Entities;
using NUnit.Framework;
using System;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Tests
{
    [TestFixture]
    public class RegionTests
    {
        [Test]
        public void Create_Region_Should_Throw_InputViolationException_When_Area_Is_Less_Than_1()
        {
            Assert.Throws<InputViolationException>(() => _ = new CapitalCity(Guid.NewGuid(), "Eastern Europe", default, new Coordinates(55.953251, -3.188267)));
        }

        [Test]
        public void Create_Region_Should_Throw_InputViolationException_When_Name_Is_Null_Or_Empty()
        {
            Assert.Throws<InputViolationException>(() => _ = new CapitalCity(Guid.NewGuid(), default, 12000, new Coordinates(55.953251, -3.188267)));
        }

        [Test]
        public void Create_Region_Should_Throw_IdViolationException_When_Id_Is_Null_Or_Empty()
        {
            Assert.Throws<InputViolationException>(() => _ = new CapitalCity(default, "Eastern Europe", 12000, new Coordinates(55.953251, -3.188267)));
        }

        [Test]
        public void Create_Region_Should_Throw_CoordinatesViolationException_When_Coordinates_Is_Null()
        {
            Assert.Throws<CoordinatesViolationException>(() => _ = new CapitalCity(Guid.NewGuid(), "Eastern Europe", 12000, default));
        }

        [Test]
        public void Create_Region_Should_Create_New_Region()
        {
            Assert.DoesNotThrow(() => _ = new Region(Guid.NewGuid(), "Eastern Europe", 12000, new Coordinates(55.953251, -3.188267)));
        }

        [Test]
        public void Update_Region_Should_Add_Or_Update_Country()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Kiev", 264, new Coordinates(55.953251, -3.188267));

            var countryId = Guid.NewGuid();
            var country = new Country(countryId, "Ukraine", 77933, new Coordinates(55.953251, -3.188267), capitalCity);

            var region = new Region(Guid.NewGuid(), "Eastern Europe", 12000, new Coordinates(55.953251, -3.188267));

            region.AddOrUpdateCountry(country);

            Assert.IsTrue(string.Equals(region.GetCountryById(countryId).Name, "Ukraine"));
        }
    }
}