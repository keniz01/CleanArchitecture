using AutoMapper;
using CleanArchitecture.Application.Country.Alphabetical;
using CleanArchitecture.Application.Country.Search;
using CleanArchitecture.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Search;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<ContinentController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SearchController(ILogger<ContinentController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<PagerDto<CountryDto>>))]
        [HttpGet("search-term/{searchTerm}/page/{pageNumber}/size/{pageSize}/countries-by-search-term")]
        public async Task<ApiResponse<PagerDto<CountryDto>>> FindCountriesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new ApiResponse<PagerDto<CountryDto>>("Search parameter cannot be empty or null.");
            }

            _logger.LogInformation("Calling FindCountriesMatchingSearchTermAsync().");

            var request = new GetCountriesMatchingSearchTermRequest(searchTerm, pageNumber, pageSize);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<PagerDto<CountryDto>>(response);

            return new ApiResponse<PagerDto<CountryDto>>(result);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<PagerDto<CountryDto>>))]
        [HttpGet("alphabet/{alphabet}/page/{pageNumber}/size/{pageSize}/countries-starting-with-alphabet")]
        public async Task<ApiResponse<PagerDto<CountryDto>>> FindCountriesStartingWithAlphabetAsync(char alphabet, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (!char.IsLetter(alphabet))
            {
                return new ApiResponse<PagerDto<CountryDto>>($"{nameof(alphabet)} value is not a letter.");
            }

            _logger.LogInformation("Calling FindCountriesStartingWithAlphabetAsync().");

            var request = new GetCountriesByAlphabetRequest(alphabet, pageNumber, pageSize);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<PagerDto<CountryDto>>(response);

            return new ApiResponse<PagerDto<CountryDto>>(result);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<PagerDto<CapitalCityDto>>))]
        [HttpGet("alphabet/{alphabet}/page/{pageNumber}/size/{pageSize}/capital-cities-starting-with-alphabet")]
        public async Task<ApiResponse<PagerDto<CapitalCityDto>>> FindCapitalCitiesStartingWithAlphabetAsync(char alphabet, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (!char.IsLetter(alphabet))
            {
                return new ApiResponse<PagerDto<CapitalCityDto>>($"{nameof(alphabet)} value is not a letter.");
            }

            _logger.LogInformation("Calling FindCapitalCitiesStartingWithAlphabetAsync().");

            var request = new GetCapitalCitiesStartingWithAlphabetRequest(alphabet, pageNumber, pageSize);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<PagerDto<CapitalCityDto>>(response);

            return new ApiResponse<PagerDto<CapitalCityDto>>(result);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<PagerDto<CapitalCityDto>>))]
        [HttpGet("search-term/{searchTerm}/page/{pageNumber}/size/{pageSize}/capital-cities-by-search-term")]
        public async Task<ApiResponse<PagerDto<CapitalCityDto>>> FindCapitalCitiesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new ApiResponse<PagerDto<CapitalCityDto>>("Search parameter cannot be empty or null.");
            }

            _logger.LogInformation("Calling FindCapitalCitiesMatchingSearchTermAsync().");

            var request = new GetCapitalCitiesMatchingSearchTermRequest(searchTerm, pageNumber, pageSize);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<PagerDto<CapitalCityDto>>(response);

            return new ApiResponse<PagerDto<CapitalCityDto>>(result);
        }
    }
}