using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Country.Search
{
    public class GetCountrySearchRequestHandler : IRequestHandler<GetCountrySearchRequest, GetCountrySearchResponse>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<ICountryRepository> _logger;


        public GetCountrySearchRequestHandler(ILogger<ICountryRepository> logger, ICountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }

        public async Task<GetCountrySearchResponse> Handle(GetCountrySearchRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetCountrySearchRequestHandler class");
            var response = await _countryRepository.GetCountrySearchAsync(request.SearchTerm, request.PageNumber, request.PageSize, cancellationToken);
            return new GetCountrySearchResponse(response);
        }
    }
}