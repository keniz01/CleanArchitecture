using System;
using System.Collections.Generic;

namespace CleanArchitecture.WebApi.Models
{
    public class RegionDto : ModelBase
    {
        /// <summary>Region city name.</summary>
        public string Name { get; set; }

        /// <summary>Region area in Km².</summary>
        public double Area { get; set; }

        /// <summary>Region coordinates.</summary>
        public CoordinateDto Coordinates { get; set; }

        public IList<CountryDto> Countries { get; set; } = new List<CountryDto>();

        public Guid ContinentId { get; set; }
    }
}