namespace CleanArchitecture.WebApi.Models
{
    public class MetricsResponseDto
    {
        public int CapitalCityCount { get; set; }
        public int CountryCount { get; set; }
        public int ContinentCount { get; set; }
        public int CountriesWithMultipleCapitalCitiesCount { get; set; }
    }
}