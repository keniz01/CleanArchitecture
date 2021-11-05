using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
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

        //TODO: Move to search controller.
        public Task<Pager<CapitalCity>> GetCapitalCitiesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return _context.CapitalCities
                .Include(country => country.Country)
                .Where(capitalCity => EF.Functions.Like(capitalCity.Name, $"%{searchTerm}%"))
                .OrderBy(capitalCity => capitalCity.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public Task<Pager<Country>> GetCountriesMatchingSearchTermAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return _context.Countries
                .Include(country => country.CapitalCities)
                .Where(country => EF.Functions.Like(country.Name, $"%{searchTerm}%"))
                .OrderBy(country => country.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<Pager<Country>> GetCountriesByContinentAsync(Guid continentId, int pageNumber, int pageSize,
            CancellationToken cancellationToken)
        {
            if (continentId == Guid.Empty)
            {
                throw new IdViolationException(nameof(continentId));
            }

            return await _context.Continents
                .Include(elem => elem.Regions)
                .ThenInclude(elem => elem.Countries)
                .ThenInclude(elem => elem.CapitalCities)
                .Where(elem => elem.Id == continentId)
                .SelectMany(elem => elem.Regions.SelectMany(region => region.Countries))
                .OrderBy(country => country.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<Pager<Country>> GetCountriesByRegionAsync(Guid regionId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Countries
                .Include(country => country.CapitalCities)
                .Where(country => country.RegionId == regionId)
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