using System.Collections.Generic;

namespace CleanArchitecture.Application.Continent.GetAll
{
    public class GetAllContinentsResponse
    {
        public GetAllContinentsResponse(IList<Domain.Entities.Continent> continents) => Continents = continents;
        public IList<Domain.Entities.Continent> Continents { get; set; }
    }
}