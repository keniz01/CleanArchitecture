using CleanArchitecture.Domain.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    /// <summary>
    /// Pagination extension/helper methods.
    /// </summary>
    public static class PaginationExtensions
    {
        /// <summary>
        /// Paginate a collection.
        /// </summary>
        /// <typeparam name="T">Collection to paginate.</typeparam>
        /// <param name="records">Collection total row count.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The number of items on the page.</param>
        /// <param name="cancellationToken">Indicates if operation should ve cancelled.</param>
        /// <returns>Paginated collection with meta data.</returns>
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> records, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var totalRecords = await records.CountAsync(cancellationToken);
            var pagedResults = await records.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            return new PagedList<T>(pagedResults, pageNumber, pageSize, totalPages, totalRecords);
        }
    }
}