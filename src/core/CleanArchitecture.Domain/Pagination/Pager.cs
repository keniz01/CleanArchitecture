using System.Collections.Generic;

namespace CleanArchitecture.Domain.Pagination
{
    public class Pager<T> : List<T>
    {
        public Pager(List<T> data, int pageNumber, int pageSize, int totalPages, int totalRecords)
        {
            AddRange(data);
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }

        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalRecords { get; }
    }
}
