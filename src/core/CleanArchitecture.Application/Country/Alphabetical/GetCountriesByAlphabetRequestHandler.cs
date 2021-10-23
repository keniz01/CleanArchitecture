using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Country.Alphabetical
{
    public class GetCountriesByAlphabetRequestHandler : IRequestHandler<GetCountriesByAlphabetRequest, GetCountriesByAlphabetResponse>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<ICountryRepository> _logger;


        public GetCountriesByAlphabetRequestHandler(ILogger<ICountryRepository> logger, ICountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }

        public async Task<GetCountriesByAlphabetResponse> Handle(GetCountriesByAlphabetRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetCountriesByAlphabetRequestHandler class");
            var response = await _countryRepository.GetCountriesStartingWithAlphabetAsync(request.Alphabet, request.PageNumber, request.PageSize, cancellationToken);
            return new GetCountriesByAlphabetResponse(response);
        }
    }
}