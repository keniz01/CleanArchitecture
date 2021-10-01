using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Pagination;

namespace CleanArchitecture.Domain.Services
{
    public interface IRegionRepository
    {
        Task<PagedList<Country>> GetRegionCountriesAsync(Guid regionId, int pageNumber, int pageSize,
            CancellationToken cancellationToken);

        Task<Region> AddOrUpdateRegionAsync(Region region, CancellationToken cancellationToken);
        Task<Region> GetRegionAsync(Guid regionId, CancellationToken cancellationToken);
    }
}