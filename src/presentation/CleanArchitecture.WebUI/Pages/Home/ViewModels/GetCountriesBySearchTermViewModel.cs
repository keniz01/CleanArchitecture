namespace CleanArchitecture.WebUI.Pages.Home.ViewModels
{
    public class GetCountriesBySearchTermViewModel
    {
        public int PageNumber { get; set; }
        public string SearchTerm { get; set; }
        public int PageSize { get; set; }
    }

    public class GetCountriesByConditionViewModel<T>
    {
        public int PageNumber { get; set; }
        public T Condition { get; set; }
        public int PageSize { get; set; }
    }
}
