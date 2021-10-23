using System.Collections.Generic;

namespace CleanArchitecture.WebApi.Models
{
    public class ContinentDto : ModelBase
    {
        /// <summary>Continent name.</summary>
        public string Name { get; set; }

        /// <summary>Continent area in Km².</summary>
        public double Area { get; set; }

        /// <summary>Continent coordinates.</summary>
        public CoordinateDto Coordinates { get; set; }

        public IList<RegionDto> Regions { get; set; } = new List<RegionDto>();
    }
}