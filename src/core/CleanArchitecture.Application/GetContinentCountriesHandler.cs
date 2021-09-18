using AutoMapper;
using CleanArchitecture.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application
{
    public class GetContinentCountriesHandler : IRequestHandler<GetContinentIdRequest, GetContinentCountriesResponse>
    {
        private readonly IContinentRepository _continentRepository;
        private readonly IMapper _mapper;

        public GetContinentCountriesHandler(IContinentRepository continentRepository, IMapper mapper)
        {
            _continentRepository = continentRepository ?? throw new ArgumentNullException(nameof(continentRepository));
            _mapper = mapper;
        }

        public async Task<GetContinentCountriesResponse> Handle(GetContinentIdRequest request, CancellationToken cancellationToken)
        {
            var countries = await _continentRepository.GetContinentCountriesAsync(request.Id, cancellationToken);
            return _mapper.Map<GetContinentCountriesResponse>(countries);
        }
    }

    /// <summary>
    /// Mapping profile.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping profile.
        /// </summary>
        public MappingProfile()
        {

        }
    }
}