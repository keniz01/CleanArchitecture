using AutoMapper;
using CleanArchitecture.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArchitecture.Application
{
    public class GetContinentCountriesRequestHandler : IRequestHandler<GetContinentIdRequest, GetContinentCountriesResponse>
    {
        private readonly IContinentRepository _continentRepository;
        private readonly IMapper _mapper;

        public GetContinentCountriesRequestHandler(IContinentRepository continentRepository, IMapper mapper)
        {
            _continentRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));
            _mapper = mapper;
        }

        public async Task<GetContinentCountriesResponse> Handle(GetContinentIdRequest request, CancellationToken cancellationToken)
        {
            var countries = await _continentRepository.GetContinentCountriesAsync(request.Id, cancellationToken);
            return new GetContinentCountriesResponse(countries);
        }
    }
}