using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;

namespace CleanArchitecture.Application.Country.GetBy.Continent
{
    public class GetCountriesByContinentRequestHandler : IRequestHandler<GetCountriesByContinentRequest, GetCountriesByContinentResponse>
    {
        private readonly ICountryRepository _countryRepository;

        public GetCountriesByContinentRequestHandler(ICountryRepository continentRepository) => _countryRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));

        public async Task<GetCountriesByContinentResponse> Handle(GetCountriesByContinentRequest request, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetCountriesByContinentAsync(request.ContinentId,
                request.PageNumber, request.PageSize, cancellationToken);
            return new GetCountriesByContinentResponse(countries);
        }
    }
}