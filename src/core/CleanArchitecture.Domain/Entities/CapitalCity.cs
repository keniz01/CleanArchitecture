using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class CapitalCity : Entity<Guid>
    {
        public CapitalCity(Guid id, string name, double area, Coordinates coordinates) : base(id)
        {
            Name = name.Validate();
            Area = area.Validate();
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates)); ;
        }

        public string Name { get; }
        public double Area { get; }
        public Coordinates Coordinates { get; }
    }
}