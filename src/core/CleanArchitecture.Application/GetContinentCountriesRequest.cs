using MediatR;
using System;

namespace CleanArchitecture.Application
{
    public class GetContinentCountriesRequest : IRequest<GetContinentCountriesResponse>
    {
        public GetContinentCountriesRequest(Guid continentId, int pageNumber, int pageSize)
        {
            ContinentId = continentId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public Guid ContinentId { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
