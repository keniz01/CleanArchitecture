using System.Collections.Generic;

namespace CleanArchitecture.Domain.Pagination
{
    public class Pager<T> : List<T>
    {
        public Pager(List<T> pagedList, int pageNumber, int pageSize, int totalPages, int totalRecords)
        {
            //PagedList = pagedList;
            AddRange(pagedList);
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }

        ///// <summary>
        ///// The list after paging.
        ///// </summary>
        //public IList<T> PagedList { get; }

        /// <summary>
        /// The current page number.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The total number of items on a page.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// The total number of pages from the paged list.
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// The total number of records before pagination.
        /// </summary>
        public int TotalRecords { get; }
    }
}
