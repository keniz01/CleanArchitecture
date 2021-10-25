using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;

namespace CleanArchitecture.Application.Region.GetBy.Continent
{
    public class GetRegionByContinentRequestHandler : IRequestHandler<GetRegionsByContinentRequest, GetRegionByContinentResponse>
    {
        private readonly IRegionRepository _regionRepository;

        public GetRegionByContinentRequestHandler(IRegionRepository continentRepository) => _regionRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));

        public async Task<GetRegionByContinentResponse> Handle(GetRegionsByContinentRequest request, CancellationToken cancellationToken)
        {
            var regions = await _regionRepository.GetRegionsByContinentAsync(request.ContinentId, cancellationToken);
            return new GetRegionByContinentResponse(regions);
        }
    }
}