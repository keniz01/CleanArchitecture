using CleanArchitecture.Domain.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebApi.Models
{
    public class GetRegionRequestDto
    {
        private Guid _regionId;

        [Required]
        public Guid RegionId
        {
            get => _regionId;
            set => _regionId = Validate(value);
        }

        private static Guid Validate(Guid input)
        {
            if (input == Guid.Empty)
            {
                throw new IdViolationException(nameof(input));
            }

            return input;
        }
    }
}