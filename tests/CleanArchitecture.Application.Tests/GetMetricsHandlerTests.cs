using CleanArchitecture.Domain.Services;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Metrics;
using CleanArchitecture.Persistence.Repositories;

namespace CleanArchitecture.Application.Tests
{
    [TestFixture]
    public class GetMetricsHandlerTests : TestBase
    {
        private readonly IMetricsRepository _metricsRepository;

        public GetMetricsHandlerTests() => _metricsRepository = new MetricsRepository(Context);
        
        [Test]
        public async Task Integration_Test_Region_GetDataMetricsHandler_Should_return_data_metrics()
        {
            var handler = new GetMetricsRequestHandler(_metricsRepository);
            var response = await handler.Handle(new GetMetricsRequest(), CancellationToken.None);

            Assert.IsTrue(response.CountryCount > 0);
        }
    }
}