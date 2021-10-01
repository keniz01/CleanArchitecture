using CleanArchitecture.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Domain.Entities
{
    public class Continent : Entity<Guid>
    {
        private Continent(Guid id) : base(id)
        {

        }

        public Continent(Guid id, string name, double area, Coordinate coordinates) : this(id)
        {
            Name = name.Validate();
            Area = area.Validate();
            Coordinates = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
        }

        /// <summary>Continent name.</summary>
        public string Name { get; protected set; }

        /// <summary>Continent area in Km².</summary>
        public double Area { get; protected set; }

        /// <summary>Continent coordinates.</summary>
        public Coordinate Coordinates { get; protected set; }

        public IList<Region> Regions { get; protected set; } = new List<Region>();

        public Continent AddOrUpdateRegion(Region region)
        {
            _ = region ?? throw new RegionViolationException(nameof(region));
            Regions.Add(region);
            return this;
        }

        public Region GetRegionById(Guid id)
        {
            _ = id.Validate();
            return Regions.SingleOrDefault(region => region.Id == id);
        }

        public Continent UpdateName(string continentName)
        {
            continentName.Validate();
            Name = continentName;
            return this;
        }

        public Continent UpdateArea(double area)
        {
            area.Validate();
            Area = area;
            return this;
        }

        public Continent UpdateCoordinates(Coordinate coordinates)
        {
            _ = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
            Coordinates = coordinates;
            return this;
        }
    }
}