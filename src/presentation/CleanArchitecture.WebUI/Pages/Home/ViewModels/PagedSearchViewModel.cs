using System.Collections.Generic;

namespace CleanArchitecture.WebUI.Pages.Home.ViewModels
{
    public class PagedSearchViewModel<T>
    {
        public PagedSearchViewModel()
        {
            PagedList = new List<T>();
        }
        public ICollection<T> PagedList { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }
    }
}