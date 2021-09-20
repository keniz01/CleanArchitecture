using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public class Region : Entity<Guid>
    {
        private IDictionary<Guid, Country> _countries;

        public Region(Guid id, string name, double area, Coordinate coordinates) : base(id)
        {
            Name = name.Validate();
            Area = area.Validate();
            Coordinates = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
            _countries = new Dictionary<Guid, Country>();
        }

        /// <summary>Region city name.</summary>
        public string Name { get; }

        /// <summary>Region area in Km².</summary>
        public double Area { get; }

        /// <summary>Region coordinates.</summary>
        public Coordinate Coordinates { get; }

        public void AddOrUpdateCountry(Country country)
        {
            _ = country ?? throw new CountryViolationException(nameof(country));
            _countries.Add(country.Id, country);
        }

        public Country GetCountryById(Guid id)
        {
            _ = id.Validate();
            return _countries.ContainsKey(id) ? _countries[id] : default;
        }
    }
}