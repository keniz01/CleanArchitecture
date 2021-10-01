using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebApi.Models
{
    public class GetContinentCountriesRequestDto : RequestModelBase
    {
        /// <summary> The continent id. </summary>
        [Required]
        public Guid ContinentId { get; set; }
    }
}
