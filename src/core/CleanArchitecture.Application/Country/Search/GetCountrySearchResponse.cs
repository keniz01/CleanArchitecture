using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Country.Search
{
    public class GetCountrySearchResponse
    {
        public GetCountrySearchResponse(Pager<Domain.Entities.Country> countries) => Results = countries;

        public Pager<Domain.Entities.Country> Results { get; set; }
    }
}
