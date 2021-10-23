using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;

namespace CleanArchitecture.Application.Region.GetRegionCountries
{
    public class GetRegionCountriesRequestHandler : IRequestHandler<GetRegionCountriesRequest, GetRegionCountriesResponse>
    {
        private readonly IRegionRepository _regionRepository;

        public GetRegionCountriesRequestHandler(IRegionRepository continentRepository) => _regionRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));

        public async Task<GetRegionCountriesResponse> Handle(GetRegionCountriesRequest request, CancellationToken cancellationToken)
        {
            var countries = await _regionRepository.GetRegionCountriesAsync(request.RegionId,
                request.PageNumber, request.PageSize, cancellationToken);
            return new GetRegionCountriesResponse(countries);
        }
    }
}