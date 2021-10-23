using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Application.Continent
{
    public class GetContinentCountriesResponse
    {
        protected GetContinentCountriesResponse()
        {

        }

        public GetContinentCountriesResponse(Pager<Domain.Entities.Country> pager) : this() => Pager = pager;

        public Pager<Domain.Entities.Country> Pager { get; }
    }
}