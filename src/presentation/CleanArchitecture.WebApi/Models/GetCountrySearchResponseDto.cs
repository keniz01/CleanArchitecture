using System.Collections.Generic;

namespace CleanArchitecture.WebApi.Models
{
    public class GetCountrySearchResponseDto : PagedResponseBase
    {
        public List<CountryDto> Countries { get; set; }
    }
}