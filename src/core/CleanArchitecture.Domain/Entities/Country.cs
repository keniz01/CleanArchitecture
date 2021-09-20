using System;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public class Country : Entity<Guid>
    {
        /// <summary>Country name.</summary>
        public string Name { get; }

        /// <summary>Country area in KM² format.</summary>
        public double Area { get; }

        /// <summary>Country GPS coordinates.</summary>
        public Coordinate Coordinates { get; }

        /// <summary>Country capital city.</summary>
        public CapitalCity CapitalCity { get; }

        public Country(Guid id, string name, double area, Coordinate coordinates, CapitalCity capitalCity) : base(id)
        {
            Name = name.Validate();
            Area = area.Validate();
            Coordinates = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
            CapitalCity = capitalCity ?? throw new CapitalCityViolationException(nameof(capitalCity));
        }
    }
}