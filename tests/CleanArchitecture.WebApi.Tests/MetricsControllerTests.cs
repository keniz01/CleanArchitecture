using AutoMapper;
using CleanArchitecture.WebApi.Controllers;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Metrics;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class MetricsControllerTests : TestBase
    {
        [Test]
        public async Task Unit_Test_Metrics_GetDataMetrics_returns_data_metrics()
        {
            // Arrange
            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<GetMetricsRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetMetricsResponse(10, 10, 10, 10));

            var controller = new MetricsController(GetService<ILogger<MetricsController>>(), mediator.Object, GetService<IMapper>());
            
            // Act
            var response = await controller.GetDataMetricsAsync(CancellationToken.None);
            
            // Assert
            Assert.IsTrue(response.Data.CountryCount == 10);
        }

        [Test]
        public async Task Integrated_Test_Metrics_GetDataMetrics_returns_data_metrics()
        {
            var controller = new MetricsController(GetService<ILogger<MetricsController>>(), GetService<IMediator>(), GetService<IMapper>());
            
            //Act
            var response = await controller.GetDataMetricsAsync(CancellationToken.None);

            //Assert
            Assert.IsTrue(response.Data.CountryCount > 0);
        }
    }
}