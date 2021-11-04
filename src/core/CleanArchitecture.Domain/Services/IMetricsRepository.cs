using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Services
{
    public interface IMetricsRepository
    {
        Task<(int ContinentCount, int CountryCount, int CapitalCityCount, int CountriesWithMultipleCapitalCitiesCount)> GetDataMetricsAsync(CancellationToken cancellationToken);
    }
}