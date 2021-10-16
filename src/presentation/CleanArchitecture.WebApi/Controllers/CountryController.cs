using AutoMapper;
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
using CleanArchitecture.Application.Country.Alphabetical;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CountryController(ILogger<CountryController> logger, IMediator mediator, IMapper mapper)
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
        [HttpGet("search/search-term/{searchTerm}/page/{pageNumber}/size/{pageSize}/countries-by-search-term")]
        public async Task<ApiResponse<PagerDto<CountryDto>>> GetCountriesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new ApiResponse<PagerDto<CountryDto>>("Search parameter cannot be empty or null.");
            }

            _logger.LogInformation("Calling GetCountriesMatchingSearchTermAsync().");

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
        [HttpGet("search/alphabet/{alphabet}/page/{pageNumber}/size/{pageSize}/countries-starting-with-alphabet")]
        public async Task<ApiResponse<PagerDto<CountryDto>>> GetCountriesByAlphabetAsync(char alphabet, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (!char.IsLetter(alphabet))
            {
                return new ApiResponse<PagerDto<CountryDto>>($"{nameof(alphabet)} value is not a letter.");
            }

            _logger.LogInformation("Calling GetCountriesByAlphabetAsync().");

            var request = new GetCountriesByAlphabetRequest(alphabet, pageNumber, pageSize);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<PagerDto<CountryDto>>(response);

            return new ApiResponse<PagerDto<CountryDto>>(result);
        }
    }
}