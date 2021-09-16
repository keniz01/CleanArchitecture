using CleanArchitecture.Domain.Common;
using System;

namespace CleanArchitecture.Domain.Entities
{
    public class Country : Entity<Guid>
    {
        public string Name { get; }
        public double Area { get; }
        public Coordinates Coordinates { get; private set; }
        public CapitalCity CapitalCity { get; private set; }
        
        public Country(Guid id, string name, double area, Coordinates coordinates, CapitalCity capitalCity) : base(id)
        {
            Name = name.Validate();
            Area = area.Validate();
            Coordinates = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
            CapitalCity = capitalCity ?? throw new CapitalCityViolationException(nameof(capitalCity));
        }

        public void UpdateCoordinates(Coordinates coordinates) => Coordinates = coordinates;

        public void UpdateCapitalCity(CapitalCity capitalCity) => CapitalCity = capitalCity;
    }
}
