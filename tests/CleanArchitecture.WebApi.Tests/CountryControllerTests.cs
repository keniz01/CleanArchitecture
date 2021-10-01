using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Country.Search;
using CleanArchitecture.WebApi.Controllers;
using CleanArchitecture.WebApi.Models;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class CountryControllerTests : TestBase
    {
        [Test]
        public async Task Unit_Test_Country_GetCountriesBySearchTermAsync_Should_return_countries_on_matching_search_term()
        {
            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<GetCountrySearchRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetCountrySearchResponse(new PagedList<Country>(new List<Country>
                {
                    new(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                    new(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                        new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
                }, 1, 20, 20, 105)));

            var controller = new CountryController(GetService<ILogger<CountryController>>(), mediator.Object,
                GetService<IMapper>());
            var response = await controller.GetCountrySearchAsync(new GetCountrySearchRequestDto { SearchTerm = "uga" }, CancellationToken.None);
            Assert.IsTrue(response.Data.Countries.Count > 0);
        }

        [Test]
        public async Task Integration_Test_Country_GetCountriesBySearchTermAsync_Should_return_countries_on_matching_search_term()
        {
            var controller = new CountryController(GetService<ILogger<CountryController>>(), GetService<IMediator>(),
                GetService<IMapper>());

            var request = new GetCountrySearchRequestDto
            {
                PageNumber = 1,
                PageSize = 20,
                SearchTerm = "uga"
            };

            var response = await controller.GetCountrySearchAsync(request, CancellationToken.None);

            Assert.IsTrue(response.Data.Countries.Count > 0);
        }
    }
}