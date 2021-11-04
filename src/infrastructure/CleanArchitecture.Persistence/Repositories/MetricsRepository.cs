using System;
using System.Linq;
using CleanArchitecture.Domain.Services;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class MetricsRepository : IMetricsRepository
    {
        private readonly DatabaseContext _context;

        public MetricsRepository(DatabaseContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<(int ContinentCount, int CountryCount, int CapitalCityCount, int CountriesWithMultipleCapitalCitiesCount)> GetDataMetricsAsync(CancellationToken cancellationToken)
        {
            var continentCount = await _context.Continents.CountAsync(cancellationToken);
            var countryCount = await _context.Countries.CountAsync(cancellationToken);
            var capitalCityCount = await _context.CapitalCities.CountAsync(cancellationToken);
            var countriesWithMultipleCapitalCitiesCount = await _context.Countries.Where(country => country.CapitalCities.Count > 1).CountAsync(cancellationToken);

            return (continentCount, countryCount, capitalCityCount, countriesWithMultipleCapitalCitiesCount);
        }
    }
}