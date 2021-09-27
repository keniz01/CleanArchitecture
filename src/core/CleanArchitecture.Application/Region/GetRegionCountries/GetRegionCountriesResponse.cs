using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Region
{
    public class GetRegionCountriesResponse
    {
        protected GetRegionCountriesResponse()
        {

        }

        public GetRegionCountriesResponse(PagedList<Country> pagedResults) : this() => PagedResults = pagedResults;

        public PagedList<Country> PagedResults { get; }
    }
}