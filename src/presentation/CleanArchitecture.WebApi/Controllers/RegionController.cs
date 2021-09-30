using AutoMapper;
using CleanArchitecture.Application.Region.AddOrUpdateRegion;
using CleanArchitecture.Application.Region.GetRegionCountries;
using CleanArchitecture.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Region.GetRegion;

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
        [ProducesErrorResponseType(typeof(ApiResponse<GetRegionCountriesResponseDto>))]
        [HttpPost("")]
        public async Task<ApiResponse<GetRegionResponseDto>> GetRegionAsync([FromBody] GetRegionRequestDto getRegionRequestDto, CancellationToken cancellationToken)
        {
            _ = getRegionRequestDto ?? throw new ArgumentNullException(nameof(getRegionRequestDto));

            _logger.LogInformation("Calling GetRegionCountriesAsync().");

            var request = _mapper.Map<GetRegionRequest>(getRegionRequestDto);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<GetRegionResponseDto>(response);

            return new ApiResponse<GetRegionResponseDto>(result);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<GetRegionCountriesResponseDto>))]
        [HttpPost("countries")]
        public async Task<ApiResponse<GetRegionCountriesResponseDto>> GetRegionCountriesAsync([FromBody] GetRegionCountriesRequestDto getRegionCountriesRequestDto, CancellationToken cancellationToken)
        {
            _ = getRegionCountriesRequestDto ?? throw new ArgumentNullException(nameof(getRegionCountriesRequestDto));

            _logger.LogInformation("Calling GetRegionCountriesAsync().");

            var request = _mapper.Map<GetRegionCountriesRequest>(getRegionCountriesRequestDto);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<GetRegionCountriesResponseDto>(response);

            return new ApiResponse<GetRegionCountriesResponseDto>(result);
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<AddOrUpdateRegionResponseDto>))]
        [HttpPost("add-or-update")]
        public async Task<ApiResponse<AddOrUpdateRegionResponseDto>> AddOrUpdateRegionAsync([FromBody] AddOrUpdateRegionRequestDto addOrUpdateRegionRequestDto, CancellationToken cancellationToken)
        {
            _ = addOrUpdateRegionRequestDto ?? throw new ArgumentNullException(nameof(addOrUpdateRegionRequestDto));

            _logger.LogInformation("Calling AddOrUpdateRegionAsync().");

            var request = _mapper.Map<AddOrUpdateRegionRequest>(addOrUpdateRegionRequestDto);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<AddOrUpdateRegionResponseDto>(response);

            return new ApiResponse<AddOrUpdateRegionResponseDto>(result);
        }
    }
}