﻿using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class CapitalCity : Entity<Guid>
    {
        public CapitalCity(Guid id, string name, double area, Coordinates coordinates) : base(id)
        {
            Name = name.Validate();
            Area = area.Validate();
            Coordinates = coordinates ?? throw new CoordinatesViolationException(nameof(coordinates));
        }

        /// <summary>Capital city name.</summary>
        public string Name { get; }

        /// <summary>Capital city area.</summary>
        public double Area { get; }

        /// <summary>Capital city coordinates.</summary>
        public Coordinates Coordinates { get; }
    }
}