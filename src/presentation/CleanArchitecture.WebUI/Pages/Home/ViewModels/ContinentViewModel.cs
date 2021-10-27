using System;
using CleanArchitecture.WebApi.Client;

namespace CleanArchitecture.WebUI.Pages.Home.ViewModels
{
    public class ContinentViewModel
    {
        public Guid Id { get; set; }

        /// <summary>Continent name.</summary>
        public string Name { get; set; }

        /// <summary>Continent area in Km².</summary>
        public double Area { get; set; }

        /// <summary>Continent coordinates.</summary>
        public CoordinateDto Coordinates { get; set; }
    }
}