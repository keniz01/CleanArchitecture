using CleanArchitecture.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArchitecture.Application.Region.GetRegion
{
    public class GetRegionRequestHandler : IRequestHandler<GetRegionRequest, GetRegionResponse>
    {
        private readonly IRegionRepository _regionRepository;

        public GetRegionRequestHandler(IRegionRepository continentRepository) => _regionRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));

        public async Task<GetRegionResponse> Handle(GetRegionRequest request, CancellationToken cancellationToken)
        {
            var region = await _regionRepository.GetRegionAsync(request.RegionId, cancellationToken);
            return new GetRegionResponse(region);
        }
    }
}