using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence
{
    public static class PaginationExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T>  records, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var totalRecords = await records.CountAsync(cancellationToken);
            var pagedResults = await records.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            return new PagedList<T>(pagedResults, pageNumber, pageSize, totalPages, totalRecords);
        }
    }
}