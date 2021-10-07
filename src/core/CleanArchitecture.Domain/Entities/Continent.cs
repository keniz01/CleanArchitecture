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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new NameViolationException(nameof(name));
            }

            if (area < 0)
            {
                throw new AreaViolationException(nameof(name));
            }

            Name = name;
            Area = area;
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
            if (id == Guid.Empty)
            {
                throw new AreaViolationException(nameof(id));
            }

            return Regions.SingleOrDefault(region => region.Id == id);
        }

        public Continent UpdateName(string continentName)
        {
            if (string.IsNullOrWhiteSpace(continentName))
            {
                throw new NameViolationException(nameof(continentName));
            }

            Name = continentName;
            return this;
        }

        public Continent UpdateArea(double area)
        {
            if (area < 0)
            {
                throw new AreaViolationException(nameof(area));
            }

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