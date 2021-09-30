namespace CleanArchitecture.WebApi.Models
{
    public class CapitalCityDto : ModelBase
    {
        public string Name { get; set; }

        /// <summary>Capital city area.</summary>
        public double Area { get; set; }

        /// <summary>Capital city coordinates.</summary>
        public CoordinateDto Coordinates { get; set; }
    }
}