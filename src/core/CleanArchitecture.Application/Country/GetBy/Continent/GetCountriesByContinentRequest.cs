using System;
using CleanArchitecture.Application.Common;
using MediatR;

namespace CleanArchitecture.Application.Country.GetBy.Continent
{
    public class GetCountriesByContinentRequest : RequestBase, IRequest<GetCountriesByContinentResponse>
    {
        public GetCountriesByContinentRequest(Guid continentId, int pageNumber, int pageSize)
            : base(pageNumber, pageSize) => ContinentId = continentId;

        public Guid ContinentId { get; }
    }
}
