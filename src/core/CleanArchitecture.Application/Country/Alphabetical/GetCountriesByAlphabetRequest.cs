using CleanArchitecture.Application.Common;
using MediatR;

namespace CleanArchitecture.Application.Country.Alphabetical
{
    public class GetCountriesByAlphabetRequest : RequestBase, IRequest<GetCountriesByAlphabetResponse>
    {
        public char Alphabet { get; }

        public GetCountriesByAlphabetRequest(char alphabet, int pageNumber, int pageSize)
            : base(pageNumber, pageSize) => Alphabet = alphabet;
    }
}