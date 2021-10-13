using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Pages.Home
{
    public class GetCountrySearchRequestViewModel
    {
        public int PageNumber { get; set; }
        public string SearchTerm { get; set; }
        public int PageSize { get; set; }
    }
}
