using System.Collections.Generic;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application
{
    public class GetContinentCountriesResponse
    {
        private GetContinentCountriesResponse()
        {

        }

        public GetContinentCountriesResponse(IList<Country> countries) : this() => Countries = countries;
        
        public IList<Country> Countries { get; }
    }
}