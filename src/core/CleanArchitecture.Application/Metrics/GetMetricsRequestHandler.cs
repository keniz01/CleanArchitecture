using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;

namespace CleanArchitecture.Application.Metrics
{
    public class GetMetricsRequestHandler : IRequestHandler<GetMetricsRequest, GetMetricsResponse>
    {
        private readonly IMetricsRepository _metricsRepository;

        public GetMetricsRequestHandler(IMetricsRepository metricsRepository) =>
            _metricsRepository = metricsRepository ?? throw new ArgumentNullException(nameof(metricsRepository));

        public async Task<GetMetricsResponse> Handle(GetMetricsRequest request, CancellationToken cancellationToken)
        {
            var response = await _metricsRepository.GetDataMetricsAsync(cancellationToken);
            return new GetMetricsResponse(response.ContinentCount, 
                response.CountryCount, response.CapitalCityCount, response.CountriesWithMultipleCapitalCitiesCount);
        }
    }
}