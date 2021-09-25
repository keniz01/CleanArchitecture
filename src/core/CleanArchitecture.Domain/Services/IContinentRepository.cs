using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Services
{
    public interface IContinentRepository
    {
        Task<PagedList<Country>> GetContinentCountriesAsync(Guid continentId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
