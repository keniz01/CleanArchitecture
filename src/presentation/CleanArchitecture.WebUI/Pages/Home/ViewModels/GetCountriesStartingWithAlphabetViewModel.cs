namespace CleanArchitecture.WebUI.Pages.Home.ViewModels
{
    public class GetCountriesStartingWithAlphabetViewModel
    {
        public int PageNumber { get; set; }
        public char Alphabet { get; set; }
        public int PageSize { get; set; }
    }
}