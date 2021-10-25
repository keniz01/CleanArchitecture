using System;
using MediatR;

namespace CleanArchitecture.Application.Region.GetBy.Id
{
    public class GetRegionByIdRequest : IRequest<GetRegionByIdResponse>
    {
        public GetRegionByIdRequest(Guid regionId)
        {
            RegionId = regionId;
        }

        public Guid RegionId { get; }
    }
}
