using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleanArchitecture.WebApi.Models
{
    public class GetContinentIdRequestDto
    {
        /// <summary> The continent id. </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
