namespace CleanArchitecture.WebApi.Models
{
    public class GetCountrySearchRequestDto : RequestModelBase
    {
        public string SearchTerm { get; set; }
    }
}