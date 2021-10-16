using CleanArchitecture.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Domain.Entities
{
    public class Country : EntityBase
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
            capitalCity = capitalCity ?? throw new CapitalCityViolationException(nameof(capitalCity));
            CapitalCities.Add(capitalCity);
        }

        /// <summary>Country name.</summary>
        public string Name { get; protected set; }

        /// <summary>Country area in KM² format.</summary>
        public double Area { get; protected set; }

        /// <summary>Country GPS coordinates.</summary>
        public Coordinate Coordinates { get; protected set; }

        /// <summary>Country capital city.</summary>
        public IList<CapitalCity> CapitalCities { get; protected set; } = new List<CapitalCity>();

        public Guid RegionId { get; protected set; }

        public Region Region { get; protected set; }

        public Country AddOrUpdateCapitalCity(CapitalCity capitalCity)
        {
            capitalCity = capitalCity ?? throw new CapitalCityViolationException(nameof(capitalCity));

            var city = CapitalCities.SingleOrDefault(city => city.Id == capitalCity.Id);

            if (city == null)
            {
                CapitalCities.Add(capitalCity);
            }
            else
            {
                var index = CapitalCities.IndexOf(city);
                CapitalCities[index] = capitalCity;
            }
            
            return this;
        }
    }
}