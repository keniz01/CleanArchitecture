using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Country.GetBy.Continent
{
    public class GetCountriesByContinentResponse
    {
        protected GetCountriesByContinentResponse()
        {

        }

        public GetCountriesByContinentResponse(Pager<Domain.Entities.Country> pager) : this() => Pager = pager;

        public Pager<Domain.Entities.Country> Pager { get; }
    }
}