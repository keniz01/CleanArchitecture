using CleanArchitecture.Domain.Services;
using CleanArchitecture.Persistence.Repositories;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Tests
{
    [TestFixture]
    public class RegionRepositoryTest : TestBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionRepositoryTest() => _regionRepository = new RegionRepository(Context);

        [Test]
        public async Task Integration_Test_Region_GetRegion_Should_Return_Region_By_region_Id()
        {
            var region = await _regionRepository.GetRegionAsync(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30"),
                CancellationToken.None);
            Assert.IsFalse(region.Id == Guid.Empty);
        }

        [Test]
        public async Task Integration_Test_Region_GetRegionsByContinent_Should_Return_Regions_By_continent_Id()
        {
            var regions =
                await _regionRepository.GetRegionsByContinentAsync(Guid.Parse("EDC63F66-3D33-4B3E-B44D-294CC49B1FCD"),
                    CancellationToken.None);
            Assert.IsNotEmpty(regions);
        }

        [Test]
        public void Integration_Test_Region_Should_fail_when_on_creation_when_DbContext_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new RegionRepository(null));
        }

        [Test]
        public async Task Integration_Test_Region_AddOrUpdateRegion_Should_Update_region_by_region_id()
        {
            var region = await _regionRepository.GetRegionAsync(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30"),
                CancellationToken.None);
            region
                .UpdateName("South America")
                .UpdateArea(17840000)
                .UpdateCoordinates(-8.7832, 55.4915);

            region = await _regionRepository.AddOrUpdateRegionAsync(region, CancellationToken.None);

            Assert.IsTrue(Equals(region.Name, "South America"));
        }
    }
}