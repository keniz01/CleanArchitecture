namespace CleanArchitecture.WebApi.Models
{
    public class ContinentWithoutRegionsDto : ModelBase
    {
        /// <summary>Continent name.</summary>
        public string Name { get; set; }

        /// <summary>Continent area in Km².</summary>
        public double Area { get; set; }

        /// <summary>Continent coordinates.</summary>
        public CoordinateDto Coordinates { get; set; }
    }
}