using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebApi.Models
{
    public class GetRegionCountriesRequestDto : RequestModelBase
    {
        /// <summary> The region id. </summary>
        [Required]
        public Guid RegionId { get; set; }
    }
}