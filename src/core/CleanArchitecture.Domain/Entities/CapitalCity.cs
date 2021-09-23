using System;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public class CapitalCity : Entity<Guid>
    {
        private CapitalCity(Guid id): base(id)
        {
                
        }

        public CapitalCity(Guid id, string name, double area, Coordinate coordinates) : this(id)
        {
            Name = name.Validate();
            Area = area.Validate();
            Coordinates = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
        }

        /// <summary>Capital city name.</summary>
        public string Name { get; protected set; }

        /// <summary>Capital city area.</summary>
        public double Area { get; protected set; }

        /// <summary>Capital city coordinates.</summary>
        public Coordinate Coordinates { get; protected set; }

        public Guid CountryId { get; protected set; }

        public Country Country { get; protected set; }
    }
}