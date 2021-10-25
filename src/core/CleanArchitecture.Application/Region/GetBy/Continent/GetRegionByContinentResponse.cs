using System.Collections.Generic;

namespace CleanArchitecture.Application.Region.GetBy.Continent
{
    public class GetRegionByContinentResponse
    {
        protected GetRegionByContinentResponse()
        {
        }

        public GetRegionByContinentResponse(IList<Domain.Entities.Region> regions) : this() => Regions = regions;

        public IList<Domain.Entities.Region> Regions { get; }
    }
}