using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.Persistence
{
    public class ContinentRepository : IContinentRepository
    {
        public Task<IList<Country>> GetContinentCountriesAsync(Guid id, CancellationToken cancellationToken)
        {
            var countries = new List<Country>
            {
                new Country(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
                    new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
                new Country(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
                    new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
                new Country(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
                    new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
            };

            return Task.FromResult<IList<Country>>(countries);
        }
    }
}
