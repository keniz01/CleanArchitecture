using System.Collections.Generic;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.WebApi.Models
{
    public class GetContinentCountriesResponseDto
    {
        protected GetContinentCountriesResponseDto()
        {

        }

        public GetContinentCountriesResponseDto(IList<CountryDto> countries) : this()
        {
            Countries = countries;
            CountryCount = countries.Count;
        }

        /// <summary> Countries on the continent. </summary>
        public IList<CountryDto> Countries { get; }

        /// <summary> Number of countries on the continent. </summary>
        public int CountryCount { get; }
    }
}