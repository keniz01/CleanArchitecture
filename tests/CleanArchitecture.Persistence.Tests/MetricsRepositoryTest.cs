using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using CleanArchitecture.Persistence.Repositories;
using NUnit.Framework;

namespace CleanArchitecture.Persistence.Tests
{
    [TestFixture]
    public class MetricsRepositoryTest : TestBase
    {
        private readonly IMetricsRepository _metricsRepository;

        public MetricsRepositoryTest() => _metricsRepository = new MetricsRepository(Context);

        [Test]
        public async Task Integration_Test_DataMetrics_GetDataMetrics_Should_Return_data_metrics()
        {
            (int continentCount, int countryCount, int capitalCityCount, int _) = await _metricsRepository.GetDataMetricsAsync(CancellationToken.None);
            Assert.IsTrue(countryCount > 0 && continentCount > 0 && capitalCityCount > 0);
        }
    }
}