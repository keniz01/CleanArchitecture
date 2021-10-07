using MediatR;
using System;
using CleanArchitecture.Application.Common;

namespace CleanArchitecture.Application.Continent
{
    public class GetContinentCountriesRequest : RequestBase, IRequest<GetContinentCountriesResponse>
    {
        public GetContinentCountriesRequest(Guid continentId, int pageNumber, int pageSize)
        {
            ContinentId = continentId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public Guid ContinentId { get; }
    }
}
