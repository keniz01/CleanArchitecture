using System.Collections.Generic;
using CleanArchitecture.WebApi.Client;

namespace CleanArchitecture.WebUI.Pages.Home
{
    public class PagedCountrySearchViewModel
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public IList<CountryDto> Data { get; set; }
    }
}