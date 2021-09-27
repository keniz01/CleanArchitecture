using MediatR;

namespace CleanArchitecture.Application.Region.AddOrUpdateRegion
{
    public class AddOrUpdateRegionRequest : IRequest<AddOrUpdateRegionResponse>
    {
        public AddOrUpdateRegionRequest(Domain.Entities.Region region)
        {
            Region = region;
        }

        public Domain.Entities.Region Region { get; }
    }
}
