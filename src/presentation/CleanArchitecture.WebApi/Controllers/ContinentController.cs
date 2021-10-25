using AutoMapper;
using CleanArchitecture.Application.Continent.GetAll;
using CleanArchitecture.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ContinentController : ControllerBase
    {
        private readonly ILogger<ContinentController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContinentController(ILogger<ContinentController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponse<IList<ContinentWithoutRegionsDto>>))]
        [HttpGet("world-continents")]
        public async Task<ApiResponse<IList<ContinentWithoutRegionsDto>>> GetAllContinentsAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Calling GetAllContinentsAsync().");

            var request = new GetAllContinentRequest();
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<IList<ContinentWithoutRegionsDto>>(response.Continents);

            return new ApiResponse<IList<ContinentWithoutRegionsDto>>(result);
        }

        // Get continents to list in menu

        // Get continent region by continent id

        // Get region countries by region id
    }
}