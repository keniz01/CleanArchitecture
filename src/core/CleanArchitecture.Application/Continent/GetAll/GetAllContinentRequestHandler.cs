using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Services;
using MediatR;

namespace CleanArchitecture.Application.Continent.GetAll
{
    public class GetAllContinentRequestHandler : IRequestHandler<GetAllContinentRequest, GetAllContinentsResponse>
    {
        private readonly IContinentRepository _continentRepository;

        public GetAllContinentRequestHandler(IContinentRepository continentRepository) => _continentRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));
        
        public async Task<GetAllContinentsResponse> Handle(GetAllContinentRequest request, CancellationToken cancellationToken)
        {
            var continents = await _continentRepository.GetAllContinentsAsync(cancellationToken);
            return new GetAllContinentsResponse(continents);
        }
    }
}