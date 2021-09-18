using MediatR;
using System;

namespace CleanArchitecture.Application
{
    public class GetContinentIdRequest : IRequest<GetContinentCountriesResponse>
    {
        public GetContinentIdRequest(Guid id) => Id = id;

        public Guid Id { get; }
    }
}
