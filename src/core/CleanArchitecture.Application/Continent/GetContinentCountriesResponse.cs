using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Continent
{
    public class GetContinentCountriesResponse
    {
        protected GetContinentCountriesResponse()
        {

        }

        public GetContinentCountriesResponse(PagedList<Country> pagedResults) : this() => PagedResults = pagedResults;

        public PagedList<Country> PagedResults { get; }
    }
}