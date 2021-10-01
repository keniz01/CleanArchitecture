using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Country.Search
{
    public class GetCountrySearchResponse
    {
        public GetCountrySearchResponse(PagedList<Domain.Entities.Country> countries) => Results = countries;

        public PagedList<Domain.Entities.Country> Results { get; set; }
    }
}
