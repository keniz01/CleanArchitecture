namespace CleanArchitecture.Application.Region.GetRegion
{
    public class GetRegionResponse
    {
        protected GetRegionResponse()
        {

        }

        public GetRegionResponse(Domain.Entities.Region region) : this() => Region = region;

        public Domain.Entities.Region Region { get; }
    }
}