using System;
using MediatR;

namespace CleanArchitecture.Application.Region.GetBy.Continent
{
    public class GetRegionsByContinentRequest : IRequest<GetRegionByContinentResponse>
    {
        public GetRegionsByContinentRequest(Guid continentId) => ContinentId = continentId;

        public Guid ContinentId { get; }
    }
}
