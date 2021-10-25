using CleanArchitecture.Application.Common;
using MediatR;

namespace CleanArchitecture.Application.Country.Search
{
    public class GetCountriesMatchingSearchTermRequest : RequestBase, IRequest<GetCountriesMatchingSearchTermResponse>
    {
        public GetCountriesMatchingSearchTermRequest(string searchTerm, int pageNumber, int pageSize)
            : base(pageNumber, pageSize) => SearchTerm = searchTerm;

        public string SearchTerm { get; }
    }
}