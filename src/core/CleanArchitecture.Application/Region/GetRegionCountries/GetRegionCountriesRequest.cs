using System;
using CleanArchitecture.Application.Common;
using MediatR;

namespace CleanArchitecture.Application.Region.GetRegionCountries
{
    public class GetRegionCountriesRequest : RequestBase, IRequest<GetRegionCountriesResponse>
    {
        public GetRegionCountriesRequest(Guid regionId, int pageNumber, int pageSize) : 
            base(pageNumber, pageSize) => RegionId = regionId;

        public Guid RegionId { get; }
    }
}
