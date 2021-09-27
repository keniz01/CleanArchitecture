using MediatR;
using System;

namespace CleanArchitecture.Application.Region.GetRegion
{
    public class GetRegionRequest : IRequest<GetRegionResponse>
    {
        public GetRegionRequest(Guid regionId)
        {
            RegionId = regionId;
        }

        public Guid RegionId { get; }
    }
}
