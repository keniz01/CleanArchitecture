using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.WebApi.Controllers;
using CleanArchitecture.WebApi.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class ContinentControllerTests
    {
        [Test]
        public async Task Continent_Get_Countries_On_Continent()
        {
            var logger = new Mock<ILogger<ContinentController>>();
            var mediator = new Mock<IMediator>();
            var mapper = new Mock<IMapper>();

            var continentController = new ContinentController(logger.Object, mediator.Object, mapper.Object);
            var continentCountries = await continentController.GetCountriesOnContinent(new GetContinentIdRequestDto(Guid.NewGuid()), CancellationToken.None);

            Assert.IsTrue(continentCountries.Data.Countries.Count > 0);
        }
    }
}
