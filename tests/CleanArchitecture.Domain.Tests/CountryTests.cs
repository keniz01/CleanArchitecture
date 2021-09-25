using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using NUnit.Framework;
using System;

namespace CleanArchitecture.Domain.Tests
{
    [TestFixture]
    public class CountryTests
    {
        [Test]
        public void Create_Country_Should_Throw_InputViolationException_When_Area_Is_Less_Than_0()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(55.953251, -3.188267));
            Assert.Throws<InputViolationException>(() => _ = new Country(Guid.NewGuid(), "Scotland", -1, new Coordinate(55.953251, -3.188267), capitalCity));
        }

        [Test]
        public void Create_Country_Should_Throw_InputViolationException_When_Name_Is_Null_Or_Empty()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(55.953251, -3.188267));
            Assert.Throws<InputViolationException>(() => _ = new Country(Guid.NewGuid(), default, 77933, new Coordinate(55.953251, -3.188267), capitalCity));
        }

        [Test]
        public void Create_Country_Should_Throw_IdViolationException_When_Id_Is_Null_Or_Empty()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(55.953251, -3.188267));
            Assert.Throws<InputViolationException>(() => _ = new Country(default, "Scotland", 77933, new Coordinate(55.953251, -3.188267), capitalCity));
        }

        [Test]
        public void Create_Country_Should_Throw_CoordinatesViolationException_When_Coordinates_Is_Null()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(55.953251, -3.188267));
            Assert.Throws<CoordinatesViolationException>(() => _ = new Country(Guid.NewGuid(), "Scotland", 77933, default, capitalCity));
        }

        [Test]
        public void Create_Country_Should_Throw_CoordinatesViolationException_When_CapitalCity_Is_Null()
        {
            Assert.Throws<CoordinatesViolationException>(() => _ = new Country(Guid.NewGuid(), "Scotland", 77933, default, default));
        }

        [Test]
        public void Create_Country_Should_Create_New_Country()
        {
            var capitalCity = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(55.953251, -3.188267));
            Assert.DoesNotThrow(() => _ = new Country(Guid.NewGuid(), "Scotland", 77933, new Coordinate(55.953251, -3.188267), capitalCity));
        }
    }
}