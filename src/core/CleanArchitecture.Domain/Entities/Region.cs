using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public class Region : Entity<Guid>
    {
        public Region(Guid id) : base(id)
        {
                
        }

        public Region(Guid id, string name, double area, Coordinate coordinates) : this(id)
        {
            Name = name.Validate();
            Area = area.Validate();
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
            _ = id.Validate();
            return Countries.SingleOrDefault(country => country.Id == id);
        }
    }
}