using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Domain.Services
{
    public interface IContinentRepository
    {
        Task<PagedList<Country>> GetContinentCountriesAsync(Guid continentId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
