using System;
using CleanArchitecture.Application.Common;
using MediatR;

namespace CleanArchitecture.Application.Region.GetRegionCountries
{
    public class GetRegionCountriesRequest : RequestBase, IRequest<GetRegionCountriesResponse>
    {
        public GetRegionCountriesRequest(Guid regionId, int pageNumber, int pageSize)
        {
            RegionId = regionId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public Guid RegionId { get; }
    }
}
