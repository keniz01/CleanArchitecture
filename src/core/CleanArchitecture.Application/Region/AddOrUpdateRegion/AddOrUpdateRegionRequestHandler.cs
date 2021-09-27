using CleanArchitecture.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArchitecture.Application.Region.AddOrUpdateRegion
{
    public class AddOrUpdateRegionRequestHandler : IRequestHandler<AddOrUpdateRegionRequest, AddOrUpdateRegionResponse>
    {
        private readonly IRegionRepository _regionRepository;

        public AddOrUpdateRegionRequestHandler(IRegionRepository continentRepository) => _regionRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));

        public async Task<AddOrUpdateRegionResponse> Handle(AddOrUpdateRegionRequest request, CancellationToken cancellationToken)
        {
            var region = await _regionRepository.AddOrUpdateRegionAsync(request.Region, cancellationToken);
            return new AddOrUpdateRegionResponse(region);
        }
    }
}