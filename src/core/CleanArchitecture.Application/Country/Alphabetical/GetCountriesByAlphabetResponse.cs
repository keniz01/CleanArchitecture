using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Country.Alphabetical
{
    public class GetCountriesByAlphabetResponse
    {
        public GetCountriesByAlphabetResponse(Pager<Domain.Entities.Country> pager) => Pager = pager;

        public Pager<Domain.Entities.Country> Pager { get; set; }
    }
}
