using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly DatabaseContext _context;

        public ContinentRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PagedList<Country>> GetContinentCountriesAsync(Guid continentId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            continentId.Validate();

            var response = await _context.Continents
                .Include(elem => elem.Regions)
                .ThenInclude(elem => elem.Countries)
                .ThenInclude(elem => elem.CapitalCity)
                .Where(elem => elem.Id == continentId)
                .SelectMany(elem => elem.Regions.SelectMany(region => region.Countries))
                .OrderBy(country => country.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);

            return response;
        }
    }
}
