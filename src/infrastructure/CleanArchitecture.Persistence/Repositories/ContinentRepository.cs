using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Persistence.Repositories
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly DatabaseContext _context;

        public ContinentRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Pager<Country>> GetContinentCountriesAsync(Guid continentId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if (continentId == Guid.Empty)
            {
                throw new IdViolationException(nameof(continentId));
            }

            var response = await _context.Continents
                .Include(elem => elem.Regions)
                .ThenInclude(elem => elem.Countries)
                .ThenInclude(elem => elem.CapitalCities)
                .Where(elem => elem.Id == continentId)
                .SelectMany(elem => elem.Regions.SelectMany(region => region.Countries))
                .OrderBy(country => country.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);

            return response;
        }

        public async Task<Continent> AddOrUpdateContinentAsync(Continent continent, CancellationToken cancellationToken)
        {
            _ = continent ?? throw new ArgumentNullException(nameof(continent));
            _context.Entry(continent).State = continent.Id == Guid.Empty ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return continent;
        }

        public async Task<Continent> GetContinentAsync(Guid continentId, CancellationToken cancellationToken)
        {
            return await _context.Continents
                .Include(continent => continent.Regions)
                .ThenInclude(continent => continent.Countries)
                .SingleOrDefaultAsync(continent => continent.Id == continentId, cancellationToken);
        }
    }
}
