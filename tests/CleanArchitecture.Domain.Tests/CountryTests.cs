using CleanArchitecture.Domain.Entities;
using NUnit.Framework;
using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Tests
{
    [TestFixture]
    public class CountryTests
    {
        [Test]
        public void Create_Country_Should_Throw_InputViolationException_When_Area_Is_Less_Than_1()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinates(55.953251, -3.188267));

            Assert.Throws<InputViolationException>(() => _ = new Country(Guid.NewGuid(), "Scotland", 0, new Coordinates(55.953251, -3.188267), capitalCity));
        }

        [Test]
        public void Create_Country_Should_Throw_InputViolationException_When_Name_Is_Null_Or_Empty()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinates(55.953251, -3.188267));

            Assert.Throws<InputViolationException>(() => _ = new Country(Guid.NewGuid(), default, 77933, new Coordinates(55.953251, -3.188267), capitalCity));
        }

        [Test]
        public void Create_Country_Should_Throw_IdViolationException_When_Id_Is_Null_Or_Empty()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinates(55.953251, -3.188267));

            Assert.Throws<InputViolationException>(() => _ = new Country(default, "Scotland", 77933, new Coordinates(55.953251, -3.188267), capitalCity));
        }

        [Test]
        public void Create_Country_Should_Throw_CoordinatesViolationException_When_Coordinates_Is_Null()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinates(55.953251, -3.188267));

            Assert.Throws<CoordinatesViolationException>(() => _ = new Country(Guid.NewGuid(), "Scotland", 77933, default, capitalCity));
        }

                [Test]
        public void Create_Country_Should_Throw_CoordinatesViolationException_When_CapitalCity_Is_Null()
        {
            Assert.Throws<CoordinatesViolationException>(() => _ = new Country(Guid.NewGuid(), "Scotland", 77933, default, default));
        }

        [Test]
        public void Create_Country_Should_Create_Valid_Country()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinates(55.953251, -3.188267));
            var country = new Country(Guid.NewGuid(), "Scotland", 77933, new Coordinates(55.953251, -3.188267), capitalCity);

            Assert.IsTrue(country.Id != Guid.Empty && Equals(country.Name, "Scotland"));
        }

        [Test]
        public void Update_Country_Should_Update_Coordinates()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinates(55.953251, -3.188267));
            var country = new Country(Guid.NewGuid(), "Scotland", 77933, new Coordinates(55.953251, -3.188267), capitalCity);

            var countryCoordinates = new Coordinates(55.010200, -1.777777);
            country.UpdateCoordinates(countryCoordinates);

            Assert.IsTrue(Math.Abs(country.Coordinates.Latitude - countryCoordinates.Latitude) == 0 
                          && Math.Abs(country.Coordinates.Longitude - countryCoordinates.Longitude) == 0);
        }

        [Test]
        public void Update_Country_Should_Update_CapitalCity()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinates(55.953251, -3.188267));
            var country = new Country(Guid.NewGuid(), "Scotland", 77933, new Coordinates(55.953251, -3.188267), capitalCity);

            capitalCity = new CapitalCity(capitalCity.Id, "Edinburgh City", 300, new Coordinates(55.953251, -3.188267));
            country.UpdateCapitalCity(capitalCity);

            Assert.IsTrue(Equals("Edinburgh City", country.CapitalCity.Name) && Math.Abs(country.CapitalCity.Area - 300) == 0);
        }
    }
}
