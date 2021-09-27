using CleanArchitecture.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArchitecture.Application.Continent
{
    public class GetContinentCountriesRequestHandler : IRequestHandler<GetContinentCountriesRequest, GetContinentCountriesResponse>
    {
        private readonly IContinentRepository _continentRepository;

        public GetContinentCountriesRequestHandler(IContinentRepository continentRepository) => _continentRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));

        public async Task<GetContinentCountriesResponse> Handle(GetContinentCountriesRequest request, CancellationToken cancellationToken)
        {
            var countries = await _continentRepository.GetContinentCountriesAsync(request.ContinentId,
                request.PageNumber, request.PageSize, cancellationToken);
            return new GetContinentCountriesResponse(countries);
        }
    }
}