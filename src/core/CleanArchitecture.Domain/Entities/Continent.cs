using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Continent : Entity<Guid>
    {
        private IDictionary<Guid, Region> _regions;

        public Continent(Guid id, string name, double area, Coordinates coordinates) : base(id)
        {
            Name = name.Validate();
            Area = area.Validate();
            Coordinates = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
            _regions = new Dictionary<Guid, Region>();
        }

        /// <summary>Continent name.</summary>
        public string Name { get; }

        /// <summary>Continent area in Km².</summary>
        public double Area { get; }

        /// <summary>Continent coordinates.</summary>
        public Coordinates Coordinates { get; }

        public void AddOrUpdateRegion(Region region)
        {
            _ = region ?? throw new RegionViolationException(nameof(region));
            _regions.Add(region.Id, region);
        }

        public Region GetRegionById(Guid id)
        {
            _ = id.Validate();
            return _regions.ContainsKey(id) ? _regions[id] : default;
        }
    }
}