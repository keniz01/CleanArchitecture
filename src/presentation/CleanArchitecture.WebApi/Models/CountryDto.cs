namespace CleanArchitecture.WebApi.Models
{
    public class CountryDto
    {
        /// <summary>Country name.</summary>
        public string Name { get; set; }

        /// <summary>Country area in KM² format.</summary>
        public double Area { get; set; }

        /// <summary>Country GPS coordinates.</summary>
        public CoordinateDto Coordinates { get; set; }

        /// <summary>Country capital city.</summary>
        public CapitalCityDto CapitalCity { get; set; }
    }
}