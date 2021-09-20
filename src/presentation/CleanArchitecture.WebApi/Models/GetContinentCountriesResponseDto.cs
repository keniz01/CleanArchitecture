using System.Collections.Generic;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.WebApi.Models
{
    public class GetContinentCountriesResponseDto
    {
        /// <summary> Countries on the continent. </summary>
        public IList<CountryDto> Countries { get; set; }

        /// <summary> Number of countries on the continent. </summary>
        public int CountryCount { get; set; }
    }
}