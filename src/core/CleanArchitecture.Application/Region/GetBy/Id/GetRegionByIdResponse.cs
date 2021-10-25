namespace CleanArchitecture.Application.Region.GetBy.Id
{
    public class GetRegionByIdResponse
    {
        protected GetRegionByIdResponse()
        {

        }

        public GetRegionByIdResponse(Domain.Entities.Region region) : this() => Region = region;

        public Domain.Entities.Region Region { get; }
    }
}