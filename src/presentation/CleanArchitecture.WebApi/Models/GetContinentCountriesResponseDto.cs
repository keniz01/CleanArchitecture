using System.Collections.Generic;

namespace CleanArchitecture.WebApi.Models
{
    public class GetContinentCountriesResponseDto : PagedResponseBase
    {
        public IList<CountryDto> Countries { get; set; }
    }
}