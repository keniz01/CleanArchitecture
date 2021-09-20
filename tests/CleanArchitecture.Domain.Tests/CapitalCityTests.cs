﻿using CleanArchitecture.Domain.Entities;
using NUnit.Framework;
using System;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Tests
{
    [TestFixture]
    public class CapitalCityTests
    {
        [Test]
        public void Create_CapitalCity_Should_Throw_InputViolationException_When_Area_Is_Less_Than_1()
        {
            Assert.Throws<InputViolationException>(() => _ = new CapitalCity(Guid.NewGuid(), "Edinburgh", default, new Coordinate(55.953251, -3.188267)));
        }

        [Test]
        public void Create_CapitalCity_Should_Throw_InputViolationException_When_Name_Is_Null_Or_Empty()
        {
            Assert.Throws<InputViolationException>(() => _ = new CapitalCity(Guid.NewGuid(), default, 264, new Coordinate(55.953251, -3.188267)));
        }

        [Test]
        public void Create_CapitalCity_Should_Throw_IdViolationException_When_Id_Is_Null_Or_Empty()
        {
            Assert.Throws<InputViolationException>(() => _ = new CapitalCity(default, "Edinburgh", 264, new Coordinate(55.953251, -3.188267)));
        }

        [Test]
        public void Create_CapitalCity_Should_Throw_CoordinatesViolationException_When_Coordinates_Is_Null()
        {
            Assert.Throws<CoordinatesViolationException>(() => _ = new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, default));
        }

        [Test]
        public void Create_CapitalCity_Should_Create_New_CapitalCity()
        {
            var capitalCityId = Guid.NewGuid();
            Assert.DoesNotThrow(() => _ = new CapitalCity(capitalCityId, "Edinburgh", 264, new Coordinate(55.953251, -3.188267)));
        }
    }
}