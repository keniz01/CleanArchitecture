using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Search
{
    public class GetCapitalCitiesMatchingSearchTermResponse
    {
        public GetCapitalCitiesMatchingSearchTermResponse(Pager<Domain.Entities.CapitalCity> pager) => Pager = pager;

        public Pager<Domain.Entities.CapitalCity> Pager { get; set; }
    }
}