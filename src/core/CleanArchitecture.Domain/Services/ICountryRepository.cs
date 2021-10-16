using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Domain.Services
{
    public interface ICountryRepository
    {
        Task<Pager<Country>> GetCountriesStartingWithAlphabetAsync(char alphabet, int pageNumber, int pageSize,
            CancellationToken cancellationToken);

        Task<Pager<Country>> GetCountriesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize,
            CancellationToken cancellationToken);
    }
}