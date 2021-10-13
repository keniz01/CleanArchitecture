using AutoMapper;
using CleanArchitecture.Application.Region.AddOrUpdateRegion;
using CleanArchitecture.Application.Region.GetRegion;
using CleanArchitecture.Application.Region.GetRegionCountries;
using CleanArchitecture.Domain.Entities;
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
    public class RegionController : ControllerBase
    {
        private readonly ILogger<RegionController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RegionController(ILogger<RegionController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<RegionDto>))]
        [HttpGet("{regionId}")]
        public async Task<ApiResponse<RegionDto>> GetRegionAsync(Guid regionId, CancellationToken cancellationToken)
        {
            if (regionId == Guid.Empty)
            {
                return new ApiResponse<RegionDto>("Region id violation.");
            }

            _logger.LogInformation("Calling GetRegionCountriesAsync().");

            var request = new GetRegionRequest(regionId);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<RegionDto>(response);

            return new ApiResponse<RegionDto>(result);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<PagerDto<CountryDto>>))]
        [HttpGet("{regionId}/page/{pageNumber}/size/{pageSize}/countries-by-region")]
        public async Task<ApiResponse<PagerDto<CountryDto>>> GetRegionCountriesAsync(Guid regionId, int pageNumber,
            int pageSize, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Calling GetRegionCountriesAsync().");

            var request = new GetRegionCountriesRequest(regionId, pageNumber, pageSize);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<PagerDto<CountryDto>>(response);
            return new ApiResponse<PagerDto<CountryDto>>(result);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<RegionDto>))]
        [HttpPost("")]
        public async Task<ApiResponse<RegionDto>> AddOrUpdateRegionAsync(RegionDto region, CancellationToken cancellationToken)
        {
            _ = region ?? throw new ArgumentNullException(nameof(region));

            _logger.LogInformation("Calling AddOrUpdateRegionAsync().");

            var request = new AddOrUpdateRegionRequest(_mapper.Map<Region>(region));
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<RegionDto>(response);

            return new ApiResponse<RegionDto>(result);
        }
    }
}