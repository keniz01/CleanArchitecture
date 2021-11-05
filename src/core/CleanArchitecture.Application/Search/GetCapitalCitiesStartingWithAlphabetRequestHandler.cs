using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Search
{
    public class GetCapitalCitiesStartingWithAlphabetRequestHandler : IRequestHandler<
        GetCapitalCitiesStartingWithAlphabetRequest, GetCapitalCitiesStartingWithAlphabetResponse>
    {
        private readonly ISearchRepository _searchRepository;
        private readonly ILogger<ISearchRepository> _logger;

        public GetCapitalCitiesStartingWithAlphabetRequestHandler(ISearchRepository searchRepository, ILogger<ISearchRepository> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _searchRepository = searchRepository ?? throw new ArgumentNullException(nameof(searchRepository));
        }

        public async Task<GetCapitalCitiesStartingWithAlphabetResponse> Handle(GetCapitalCitiesStartingWithAlphabetRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Calling GetCapitalCitiesStartingWithAlphabetRequestHandler");
            var result = await _searchRepository.FindCapitalCitiesStartingWithAlphabetAsync(request.Alphabet,
                request.PageNumber, request.PageSize, cancellationToken);

            return new GetCapitalCitiesStartingWithAlphabetResponse(result);
        }
    }
}