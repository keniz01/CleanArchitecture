using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;

namespace CleanArchitecture.Application.Country.GetBy.Region
{
    public class GetCountriesByRegionRequestHandler : IRequestHandler<GetCountriesByRegionRequest, GetCountriesByRegionResponse>
    {
        private readonly ICountryRepository _countryRepository;

        public GetCountriesByRegionRequestHandler(ICountryRepository continentRepository) => _countryRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));

        public async Task<GetCountriesByRegionResponse> Handle(GetCountriesByRegionRequest request, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetCountriesByRegionAsync(request.RegionId,
                request.PageNumber, request.PageSize, cancellationToken);
            return new GetCountriesByRegionResponse(countries);
        }
    }
}