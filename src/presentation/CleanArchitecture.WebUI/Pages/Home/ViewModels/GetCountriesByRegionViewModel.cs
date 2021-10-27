using System;

namespace CleanArchitecture.WebUI.Pages.Home.ViewModels
{
    public class GetCountriesByRegionViewModel
    {
        public int PageNumber { get; set; }
        public Guid RegionId { get; set; }
        public int PageSize { get; set; }
    }
}