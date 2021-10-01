using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Domain.Services
{
    public interface ICountryRepository
    {
        Task<PagedList<Country>> GetCountrySearchAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}