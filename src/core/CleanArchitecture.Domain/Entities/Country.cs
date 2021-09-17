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
        public Coordinates Coordinates { get; private set; }

        /// <summary>Country capital city.</summary>
        public CapitalCity CapitalCity { get; private set; }

        public Country(Guid id, string name, double area, Coordinates coordinates, CapitalCity capitalCity) : base(id)
        {
            Name = name.Validate();
            Area = area.Validate();
            Coordinates = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
            CapitalCity = capitalCity ?? throw new CapitalCityViolationException(nameof(capitalCity));
        }
    }
}