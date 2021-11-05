using CleanArchitecture.Application.Common;
using MediatR;

namespace CleanArchitecture.Application.Search
{
    public class GetCapitalCitiesStartingWithAlphabetRequest : RequestBase, IRequest<GetCapitalCitiesStartingWithAlphabetResponse>
    {
        public GetCapitalCitiesStartingWithAlphabetRequest(char alphabet, int pageNumber, int pageSize)
            : base(pageNumber, pageSize) => Alphabet = alphabet;

        public char Alphabet { get; }
    }
}