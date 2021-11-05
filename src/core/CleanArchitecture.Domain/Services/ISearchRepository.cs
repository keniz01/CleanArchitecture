using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Domain.Services
{
    public interface ISearchRepository
    {
        Task<Pager<Country>> FindCountriesStartingWithAlphabetAsync(char alphabet, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Pager<Country>> FindCountriesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Pager<CapitalCity>> FindCapitalCitiesStartingWithAlphabetAsync(char alphabet, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Pager<CapitalCity>> FindCapitalCitiesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}