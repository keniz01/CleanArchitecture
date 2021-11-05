using CleanArchitecture.WebApi.Client;

namespace CleanArchitecture.WebUI.Pages.Home.ViewModels
{
    public class CapitalCityViewModel
    {
        public string Name { get; set; }

        /// <summary>Capital city area.</summary>
        public double Area { get; set; }

        /// <summary>Capital city coordinates.</summary>
        public CoordinateDto Coordinates { get; set; }

        public string Country { get; set; }
    }
}