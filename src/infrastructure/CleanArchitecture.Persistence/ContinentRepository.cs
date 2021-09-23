using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Persistence
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly DatabaseContext _context;

        public ContinentRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IList<Country>> GetContinentCountriesAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
            {
                throw new IdViolationException(nameof(id));
            }

            var continent = await _context.Continents
                .Include(elem => elem.Regions)
                .ThenInclude(elem => elem.Countries)
                .ThenInclude(elem => elem.CapitalCity)
                .SingleOrDefaultAsync(elem => elem.Id == id, cancellationToken);

            return continent.Regions.SelectMany(elem => elem.Countries).ToList();
        }
    }
}
