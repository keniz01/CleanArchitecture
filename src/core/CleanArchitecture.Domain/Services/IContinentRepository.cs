using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Services
{
    public interface IContinentRepository
    {
        Task<IList<Country>> GetContinentCountriesAsync(Guid id, CancellationToken cancellationToken);
    }
}
