using System.Collections.Generic;

namespace CleanArchitecture.WebApi.Models
{
    public class PagerDto<T> : List<T>
    {
        //public IList<CountryDto> PagedList { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}