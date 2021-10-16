using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Country.Search
{
    public class GetCountriesMatchingSearchTermRequestHandler : IRequestHandler<GetCountriesMatchingSearchTermRequest, GetCountriesMatchingSearchTermResponse>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<ICountryRepository> _logger;


        public GetCountriesMatchingSearchTermRequestHandler(ILogger<ICountryRepository> logger, ICountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }

        public async Task<GetCountriesMatchingSearchTermResponse> Handle(GetCountriesMatchingSearchTermRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetCountrySearchRequestHandler class");
            var response = await _countryRepository.GetCountriesMatchingSearchTermAsync(request.SearchTerm, request.PageNumber, request.PageSize, cancellationToken);
            return new GetCountriesMatchingSearchTermResponse(response);
        }
    }
}