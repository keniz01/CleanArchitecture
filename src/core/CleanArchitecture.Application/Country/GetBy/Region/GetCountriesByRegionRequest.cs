using System;
using CleanArchitecture.Application.Common;
using MediatR;

namespace CleanArchitecture.Application.Country.GetBy.Region
{
    public class GetCountriesByRegionRequest : RequestBase, IRequest<GetCountriesByRegionResponse>
    {
        public GetCountriesByRegionRequest(Guid regionId, int pageNumber, int pageSize)
            : base(pageNumber, pageSize) => RegionId = regionId;

        public Guid RegionId { get; }
    }
}
