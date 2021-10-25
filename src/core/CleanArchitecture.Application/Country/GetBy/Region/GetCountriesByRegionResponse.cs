using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Country.GetBy.Region
{
    public class GetCountriesByRegionResponse
    {
        protected GetCountriesByRegionResponse()
        {
        }

        public GetCountriesByRegionResponse(Pager<Domain.Entities.Country> pager) : this() => Pager = pager;

        public Pager<Domain.Entities.Country> Pager { get; }
    }
}