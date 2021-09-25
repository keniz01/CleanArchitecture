using System.Collections.Generic;

namespace CleanArchitecture.Domain.Pagination
{
    public class PagedList<T>
    {
        public PagedList(List<T> data, int pageNumber, int pageSize, int totalPages, int totalRecords)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }

        public List<T> Data { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalRecords { get; }
    }
}
