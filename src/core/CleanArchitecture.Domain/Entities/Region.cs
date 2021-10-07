using CleanArchitecture.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Domain.Entities
{
    public class Region : EntityBase
    {
        public Region(Guid id) : base(id)
        {

        }

        public Region(Guid id, string name, double area, Coordinate coordinates) : this(id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new NameViolationException(nameof(name));
            }

            if (area < 0)
            {
                throw new AreaViolationException(nameof(area));
            }

            Name = name;
            Area = area;
            Coordinates = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
        }

        /// <summary>Region city name.</summary>
        public string Name { get; protected set; }

        /// <summary>Region area in Km².</summary>
        public double Area { get; protected set; }

        /// <summary>Region coordinates.</summary>
        public Coordinate Coordinates { get; protected set; }

        public IList<Country> Countries { get; protected set; } = new List<Country>();

        public Guid ContinentId { get; protected set; }

        public Continent Continent { get; protected set; }

        public Region AddOrUpdateCountry(Country country)
        {
            _ = country ?? throw new CountryViolationException(nameof(country));
            Countries.Add(country);
            return this;
        }

        public Country GetCountryById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new IdViolationException(nameof(id));
            }

            return Countries.SingleOrDefault(country => country.Id == id);
        }

        public Region UpdateName(string regionName)
        {
            if (string.IsNullOrWhiteSpace(regionName))
            {
                throw new NameViolationException(nameof(regionName));
            }

            Name = regionName;
            return this;
        }

        public Region UpdateArea(double area)
        {
            if (area < 0)
            {
                throw new AreaViolationException(nameof(area));
            }

            Area = area;
            return this;
        }

        public Region UpdateCoordinates(double latitude, double longitude)
        {
            Coordinates = new Coordinate(latitude, longitude);
            return this;
        }
    }
}