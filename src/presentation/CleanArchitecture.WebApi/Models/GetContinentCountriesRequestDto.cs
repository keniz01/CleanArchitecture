using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebApi.Models
{
    public class GetContinentCountriesRequestDto
    {
        /// <summary> The continent id. </summary>
        [Required]
        public Guid ContinentId { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
