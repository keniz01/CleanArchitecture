using System;
using MediatR;

namespace CleanArchitecture.Application.Region.GetRegionCountries
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
