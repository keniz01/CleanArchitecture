using AutoMapper;
using CleanArchitecture.Application;
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
    public class ContinentController : Controller
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
        [ProducesErrorResponseType(typeof(ApiResponse<>))]
        [HttpPost("continent-countries")]
        public async Task<ApiResponse<GetContinentCountriesResponseDto>> GetContinentCountriesAsync(GetContinentCountriesRequestDto getContinentCountriesDto, CancellationToken cancellationToken)
        {
            _ = getContinentCountriesDto ?? throw new ArgumentNullException(nameof(getContinentCountriesDto));

            _logger.LogInformation("Calling GetContinentCountriesAsync().");

            var request = _mapper.Map<GetContinentCountriesRequest>(getContinentCountriesDto);
            var response = await _mediator.Send(request, cancellationToken);
            var result = _mapper.Map<GetContinentCountriesResponseDto>(response);

            return new ApiResponse<GetContinentCountriesResponseDto>(result);
        }
    }
}