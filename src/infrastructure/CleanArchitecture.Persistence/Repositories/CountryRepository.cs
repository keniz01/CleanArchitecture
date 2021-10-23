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
    public class CountryRepository : ICountryRepository
    {
        private readonly DatabaseContext _context;

        public CountryRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Pager<Country>> GetCountriesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return _context.Countries
                .Include(country => country.CapitalCities)
                .Where(country => EF.Functions.Like(country.Name, searchTerm)
                    || country.CapitalCities.Any(capitalCity => EF.Functions.Like(capitalCity.Name, searchTerm)))
                .OrderBy(country => country.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public Task<Pager<Country>> GetCountriesStartingWithAlphabetAsync(char alphabet, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return _context.Countries
                .Include(country => country.CapitalCities)
                .Where(country => EF.Functions.Like(country.Name, $"{alphabet}%"))
                .OrderBy(country => country.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }
    }
}