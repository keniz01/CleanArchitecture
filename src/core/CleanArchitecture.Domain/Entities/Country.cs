using CleanArchitecture.Domain.Exceptions;
using System;

namespace CleanArchitecture.Domain.Entities
{
    public class Country : Entity<Guid>
    {
        private Country(Guid id) : base(id)
        {

        }

        public Country(Guid id, string name, double area, Coordinate coordinates, CapitalCity capitalCity) : this(id)
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
            CapitalCity = capitalCity ?? throw new CapitalCityViolationException(nameof(capitalCity));
        }

        /// <summary>Country name.</summary>
        public string Name { get; protected set; }

        /// <summary>Country area in KM² format.</summary>
        public double Area { get; protected set; }

        /// <summary>Country GPS coordinates.</summary>
        public Coordinate Coordinates { get; protected set; }

        /// <summary>Country capital city.</summary>
        public CapitalCity CapitalCity { get; protected set; }

        public Guid RegionId { get; protected set; }

        public Region Region { get; protected set; }

        public Guid CapitalCityId { get; protected set; }
    }
}