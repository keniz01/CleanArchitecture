using MediatR;

namespace CleanArchitecture.Application.Country.Search
{
    public class GetCountrySearchRequest : IRequest<GetCountrySearchResponse>
    {
        public GetCountrySearchRequest(string searchTerm, int pageNumber, int pageSize)
        {
            SearchTerm = searchTerm;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; }

        public int PageSize { get; }

        public string SearchTerm { get; }
    }
}