using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Continent
{
    public class GetContinentCountriesResponse
    {
        protected GetContinentCountriesResponse()
        {

        }

        public GetContinentCountriesResponse(Pager<Domain.Entities.Country> pagedResults) : this() => PagedResults = pagedResults;

        public Pager<Domain.Entities.Country> PagedResults { get; }
    }
}