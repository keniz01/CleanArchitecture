using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Search
{
    public class GetCapitalCitiesMatchingSearchTermRequestHandler : IRequestHandler<
        GetCapitalCitiesMatchingSearchTermRequest, GetCapitalCitiesMatchingSearchTermResponse>
    {
        private readonly ISearchRepository _searchRepository;
        private readonly ILogger<ISearchRepository> _logger;

        public GetCapitalCitiesMatchingSearchTermRequestHandler(ISearchRepository searchRepository, ILogger<ISearchRepository> logger)
        {
            _searchRepository = searchRepository ?? throw new ArgumentNullException(nameof(searchRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetCapitalCitiesMatchingSearchTermResponse> Handle(GetCapitalCitiesMatchingSearchTermRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Calling GetCapitalCitiesMatchingSearchTermRequestHandler");
            var result = await _searchRepository.FindCapitalCitiesMatchingSearchTermAsync(request.SearchTerm, request.PageNumber, request.PageSize, cancellationToken);
            return new GetCapitalCitiesMatchingSearchTermResponse(result);
        }
    }
}