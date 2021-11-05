using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly DatabaseContext _context;

        public SearchRepository(DatabaseContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<Pager<Country>> FindCountriesStartingWithAlphabetAsync(char alphabet, int pageNumber, int pageSize,
            CancellationToken cancellationToken)
        {
            return await _context.Countries
                .Include(country => country.CapitalCities)
                .Where(country => EF.Functions.Like(country.Name, $"{alphabet}%"))
                .OrderBy(country => country.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<Pager<Country>> FindCountriesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize,
            CancellationToken cancellationToken)
        {
            return await _context.Countries
                .Include(country => country.CapitalCities)
                .Where(country => EF.Functions.Like(country.Name, $"%{searchTerm}%"))
                .OrderBy(country => country.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<Pager<CapitalCity>> FindCapitalCitiesStartingWithAlphabetAsync(char alphabet, int pageNumber, int pageSize,
            CancellationToken cancellationToken)
        {
            return await _context.CapitalCities
                .Include(capitalCity => capitalCity.Country)
                .Where(capitalCity => EF.Functions.Like(capitalCity.Name, $"{alphabet}%"))
                .OrderBy(capitalCity => capitalCity.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<Pager<CapitalCity>> FindCapitalCitiesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize,
            CancellationToken cancellationToken)
        {
            return await _context.CapitalCities
                .Include(capitalCity => capitalCity.Country)
                .Where(capitalCity => EF.Functions.Like(capitalCity.Name, $"%{searchTerm}%"))
                .OrderBy(capitalCity => capitalCity.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}