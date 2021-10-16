using CleanArchitecture.WebApi.Client;
using System.Collections.Generic;

namespace CleanArchitecture.WebUI.Pages.Home
{
    public class PagedCountrySearchViewModel
    {
        public ICollection<CountryDto> PagedList { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }
    }
}