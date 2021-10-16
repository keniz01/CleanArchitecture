using CleanArchitecture.Domain.Exceptions;
using System;

namespace CleanArchitecture.Domain.Entities
{
    public class CapitalCity : EntityBase
    {
        private CapitalCity(Guid id) : base(id)
        {

        }

        public CapitalCity(Guid id, string name, double area, Coordinate coordinates) : this(id)
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

        /// <summary>Capital city name.</summary>
        public string Name { get; protected set; }

        /// <summary>Capital city area.</summary>
        public double Area { get; protected set; }

        /// <summary>Capital city coordinates.</summary>
        public Coordinate Coordinates { get; protected set; }

        public Country Country { get; protected set; }

        public Guid CountryId { get; protected set; }
    }
}