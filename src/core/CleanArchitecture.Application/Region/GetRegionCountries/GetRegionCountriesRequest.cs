using MediatR;
using System;

namespace CleanArchitecture.Application.Region
{
    public class GetRegionCountriesRequest : IRequest<GetRegionCountriesResponse>
    {
        public GetRegionCountriesRequest(Guid regionId, int pageNumber, int pageSize)
        {
            RegionId = regionId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public Guid RegionId { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
