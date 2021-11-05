using AutoMapper;
using CleanArchitecture.Application.Country.Search;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.WebApi.Controllers;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Country.Alphabetical;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class CountryControllerTests : TestBase
    {
        //[Test]
        //public async Task
        //    Unit_Test_Country_GetCountriesBySearchTermAsync_Should_return_countries_on_matching_search_term()
        //{
        //    var mediator = new Mock<IMediator>();
        //    mediator.Setup(m => m.Send(It.IsAny<GetCountriesMatchingSearchTermRequest>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(new GetCountriesMatchingSearchTermResponse(new Pager<Country>(new List<Country>
        //        {
        //            new(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
        //                new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
        //            new(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
        //                new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
        //            new(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
        //                new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
        //        }, 1, 20, 20, 105)));

        //    var controller = new CountryController(GetService<ILogger<CountryController>>(), mediator.Object,
        //        GetService<IMapper>());
        //    var response = await controller.GetCountriesMatchingSearchTermAsync("uga", 1, 10, CancellationToken.None);
        //    Assert.IsTrue(response.Data.PagedList.Count > 0);
        //}

        //[Test]
        //public async Task
        //    Integration_Test_Country_GetCountriesBySearchTermAsync_Should_return_countries_on_matching_search_term()
        //{
        //    var controller = new CountryController(GetService<ILogger<CountryController>>(), GetService<IMediator>(),
        //        GetService<IMapper>());

        //    var response = await controller.GetCountriesMatchingSearchTermAsync("uga%", 1, 10, CancellationToken.None);

        //    Assert.IsTrue(response.Data.PagedList.Count > 0);
        //}

        //[Test]
        //public async Task Unit_Test_Country_GetCountriesByAlphabetAsync_Should_return_countries_by_alphabet_letter()
        //{
        //    var mediator = new Mock<IMediator>();
        //    mediator.Setup(m => m.Send(It.IsAny<GetCountriesByAlphabetRequest>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(new GetCountriesByAlphabetResponse(new Pager<Country>(new List<Country>
        //        {
        //            new(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
        //                new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
        //        }, 1, 10, 1, 1)));

        //    var controller = new CountryController(GetService<ILogger<CountryController>>(), mediator.Object,
        //        GetService<IMapper>());
        //    var response = await controller.GetCountriesByAlphabetAsync('r', 1, 10, CancellationToken.None);
        //    Assert.IsTrue(response.Data.PagedList.Count > 0);
        //}

        //[Test]
        //public async Task Integration_Test_Country_GetCountriesByAlphabetAsync_Should_return_countries_by_alphabet_letter()
        //{
        //    var controller = new CountryController(GetService<ILogger<CountryController>>(), GetService<IMediator>(),
        //        GetService<IMapper>());

        //    var response = await controller.GetCountriesByAlphabetAsync('a', 1, 10, CancellationToken.None);

        //    Assert.IsTrue(response.Data.PagedList.Count > 0);
        //}

        [Test]
        public async Task Integration_Test_Country_GetCountriesByRegionAsync_Should_return_countries_by_region_id()
        {
            var controller = new CountryController(GetService<ILogger<CountryController>>(), GetService<IMediator>(),
                GetService<IMapper>());

            var response = await controller.GetCountriesByRegionAsync(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30"), 1, 10, CancellationToken.None);

            Assert.IsTrue(response.Data.PagedList.Count > 0);
        }
    }
}