using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Region.GetRegionCountries
{
    public class GetRegionCountriesResponse
    {
        protected GetRegionCountriesResponse()
        {

        }

        public GetRegionCountriesResponse(Pager<Domain.Entities.Country> pager) : this() => Pager = pager;

        public Pager<Domain.Entities.Country> Pager { get; }
    }
}