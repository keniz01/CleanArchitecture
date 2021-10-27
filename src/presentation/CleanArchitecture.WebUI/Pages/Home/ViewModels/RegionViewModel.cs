using System;
using System.Collections.Generic;
using CleanArchitecture.WebApi.Client;

namespace CleanArchitecture.WebUI.Pages.Home.ViewModels
{
    public class RegionViewModel
    {
        public Guid Id { get; set; }

        /// <summary>Region city name.</summary>
        public string Name { get; set; }

        /// <summary>Region area in Km².</summary>
        public double Area { get; set; }

        /// <summary>Region coordinates.</summary>
        public CoordinateDto Coordinates { get; set; }

        public IList<CountryDto> Countries { get; set; } = new List<CountryDto>();

        public Guid ContinentId { get; set; }
    }
}