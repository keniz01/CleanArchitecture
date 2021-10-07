using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Region.GetRegionCountries
{
    public class GetRegionCountriesResponse
    {
        protected GetRegionCountriesResponse()
        {

        }

        public GetRegionCountriesResponse(Pager<Domain.Entities.Country> pagedResults) : this() => PagedResults = pagedResults;

        public Pager<Domain.Entities.Country> PagedResults { get; }
    }
}