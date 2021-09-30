using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebApi.Models
{
    public class GetRegionCountriesRequestDto
    {
        /// <summary> The region id. </summary>
        [Required]
        public Guid RegionId { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}