namespace CleanArchitecture.Application.Metrics
{
    public class GetMetricsResponse
    {
        public int ContinentCount { get; }
        public int CountryCount { get; }
        public int CapitalCityCount { get; }
        public int CountriesWithMultipleCapitalCitiesCount { get; }

        public GetMetricsResponse(int continentCount, int countryCount, int capitalCityCount, int countriesWithMultipleCapitalCitiesCount)
        {
            ContinentCount = continentCount;
            CountryCount = countryCount;
            CapitalCityCount = capitalCityCount;
            CountriesWithMultipleCapitalCitiesCount = countriesWithMultipleCapitalCitiesCount;
        }
    }
}