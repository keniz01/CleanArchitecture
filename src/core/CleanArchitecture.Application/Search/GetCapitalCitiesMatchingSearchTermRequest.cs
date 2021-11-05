using CleanArchitecture.Application.Common;
using MediatR;

namespace CleanArchitecture.Application.Search
{
    public class GetCapitalCitiesMatchingSearchTermRequest : RequestBase, IRequest<GetCapitalCitiesMatchingSearchTermResponse>
    {
        public GetCapitalCitiesMatchingSearchTermRequest(string searchTerm, int pageNumber, int pageSize)
            : base(pageNumber, pageSize) => SearchTerm = searchTerm;

        public string SearchTerm { get; }
    }
}
