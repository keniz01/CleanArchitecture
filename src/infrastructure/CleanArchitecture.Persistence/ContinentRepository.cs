using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.Persistence
{
    public class ContinentRepository : GenericRepository, IContinentRepository
    {
        public async Task<IList<Country>> GetContinentCountriesAsync(Guid id, CancellationToken cancellationToken)
        {
            return await GetAsync(id);
        }
    }
}
