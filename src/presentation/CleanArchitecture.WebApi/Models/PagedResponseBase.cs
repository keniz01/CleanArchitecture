using System.Collections.Generic;

namespace CleanArchitecture.WebApi.Models
{
    public abstract class PagedResponseBase<T>
    {
        public List<T> PagedResults { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }
    }
}