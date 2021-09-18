using System;
using System.Collections;

namespace CleanArchitecture.WebApi.Models
{
    public class GetContinentIdRequestDto
    {
        private GetContinentIdRequestDto()
        {
                
        }

        public GetContinentIdRequestDto(Guid id) : this() => Id = id;

        /// <summary> The continent id. </summary>
        public Guid Id { get; }
    }
}
