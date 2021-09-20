using System;
using System.Collections;
using System.Text.Json.Serialization;

namespace CleanArchitecture.WebApi.Models
{
    public class GetContinentIdRequestDto
    {
        /// <summary> The continent id. </summary>
        public Guid Id { get; set; }
    }
}
