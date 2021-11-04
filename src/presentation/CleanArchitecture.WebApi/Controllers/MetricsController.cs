using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Continent.GetAll;
using CleanArchitecture.Application.Metrics;
using CleanArchitecture.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class MetricsController : ControllerBase
    {
        private readonly ILogger<MetricsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MetricsController(ILogger<MetricsController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<MetricsResponseDto>))]
        [HttpGet("data-metrics")]
        public async Task<ApiResponse<MetricsResponseDto>> GetDataMetricsAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Calling GetDataMetricsAsync().");

            var request = new GetMetricsRequest();
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<MetricsResponseDto>(response);

            return new ApiResponse<MetricsResponseDto>(result);
        }
    }
}