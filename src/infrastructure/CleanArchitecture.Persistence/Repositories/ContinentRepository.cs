using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IList<Continent>> GetAllContinentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Continents.ToListAsync(cancellationToken);
        }
    }
}
