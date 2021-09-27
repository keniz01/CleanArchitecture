namespace CleanArchitecture.Application.Region.AddOrUpdateRegion
{
    public class AddOrUpdateRegionResponse
    {
        protected AddOrUpdateRegionResponse()
        {

        }

        public AddOrUpdateRegionResponse(Domain.Entities.Region region) : this() => Region = region;

        public Domain.Entities.Region Region { get; }
    }
}