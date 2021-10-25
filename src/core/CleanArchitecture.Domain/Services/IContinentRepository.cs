using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Services
{
    public interface IContinentRepository
    {
        //Task<Pager<Country>> GetContinentCountriesAsync(Guid continentId, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Continent> AddOrUpdateContinentAsync(Continent continent, CancellationToken cancellationToken);
        Task<Continent> GetContinentAsync(Guid continentId, CancellationToken cancellationToken);
        Task<IList<Continent>> GetAllContinentsAsync(CancellationToken cancellationToken);
    }
}
