﻿using System.Collections.Generic;

namespace CleanArchitecture.WebApi.Models
{
    public class GetRegionCountriesResponseDto : PagedResponseBase
    {
        public List<CountryDto> Countries { get; set; }
    }
}