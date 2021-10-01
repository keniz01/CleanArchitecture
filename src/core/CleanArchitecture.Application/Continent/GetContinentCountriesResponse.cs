using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Continent
{
    public class GetContinentCountriesResponse
    {
        protected GetContinentCountriesResponse()
        {

        }

        public GetContinentCountriesResponse(PagedList<Domain.Entities.Country> pagedResults) : this() => PagedResults = pagedResults;

        public PagedList<Domain.Entities.Country> PagedResults { get; }
    }
}