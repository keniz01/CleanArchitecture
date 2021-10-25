using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;

namespace CleanArchitecture.Application.Region.GetBy.Id
{
    public class GetRegionByIdRequestHandler : IRequestHandler<GetRegionByIdRequest, GetRegionByIdResponse>
    {
        private readonly IRegionRepository _regionRepository;

        public GetRegionByIdRequestHandler(IRegionRepository continentRepository) => _regionRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));

        public async Task<GetRegionByIdResponse> Handle(GetRegionByIdRequest request, CancellationToken cancellationToken)
        {
            var region = await _regionRepository.GetRegionAsync(request.RegionId, cancellationToken);
            return new GetRegionByIdResponse(region);
        }
    }
}