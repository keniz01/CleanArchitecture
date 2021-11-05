using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Services
{
    public interface IContinentRepository
    {
        Task<Continent> AddOrUpdateContinentAsync(Continent continent, CancellationToken cancellationToken);
        Task<Continent> GetContinentAsync(Guid continentId, CancellationToken cancellationToken);
        Task<IList<Continent>> GetAllContinentsAsync(CancellationToken cancellationToken);
    }
}
