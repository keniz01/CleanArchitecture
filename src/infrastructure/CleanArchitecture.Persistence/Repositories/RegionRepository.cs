using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;
using CleanArchitecture.Domain.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DatabaseContext _context;

        public RegionRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PagedList<Country>> GetRegionCountriesAsync(Guid regionId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            regionId.Validate();

            var response = await _context.Regions
                .Include(region => region.Countries)
                .ThenInclude(country => country.CapitalCity)
                .Where(region => region.Id == regionId)
                .SelectMany(region => region.Countries)
                .OrderBy(country => country.Name)
                .ToPagedListAsync(pageNumber, pageSize, cancellationToken);

            return response;
        }

        public async Task<Region> AddOrUpdateRegionAsync(Region region, CancellationToken cancellationToken)
        {
            _ = region ?? throw new ArgumentNullException(nameof(region));
            _context.Entry(region).State = region.Id == Guid.Empty ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return region;
        }

        public async Task<Region> GetRegionAsync(Guid regionId, CancellationToken cancellationToken)
        {
            return await _context.Regions
                .Include(region => region.Countries.OrderBy(country => country.Name))
                .SingleOrDefaultAsync(region => region.Id == regionId, cancellationToken);
        }
    }
}