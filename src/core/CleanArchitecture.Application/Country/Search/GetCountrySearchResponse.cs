using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Country.Search
{
    public class GetCountrySearchResponse
    {
        public GetCountrySearchResponse(Pager<Domain.Entities.Country> pager) => Pager = pager;

        public Pager<Domain.Entities.Country> Pager { get; set; }
    }
}
