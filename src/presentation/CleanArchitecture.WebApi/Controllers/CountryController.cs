using AutoMapper;
using CleanArchitecture.Application.Country.GetBy.Region;
using CleanArchitecture.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

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
        [HttpGet("region/{regionId}/page/{pageNumber}/size/{pageSize}/countries-by-region")]
        public async Task<ApiResponse<PagerDto<CountryDto>>> GetCountriesByRegionAsync(Guid regionId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (regionId == Guid.Empty)
            {
                return new ApiResponse<PagerDto<CountryDto>>($"{nameof(regionId)} is not valid.");
            }

            _logger.LogInformation("Calling GetCountriesByRegionAsync().");

            var request = new GetCountriesByRegionRequest(regionId, pageNumber, pageSize);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<PagerDto<CountryDto>>(response);

            return new ApiResponse<PagerDto<CountryDto>>(result);
        }
    }
}