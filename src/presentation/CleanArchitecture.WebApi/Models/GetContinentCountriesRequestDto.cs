using System;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.WebApi.Models
{
    public class GetContinentCountriesRequestDto : RequestBase
    {
        private Guid _continentId;

        [Required]
        public Guid ContinentId
        {
            get => _continentId;
            set => _continentId = Validate(value);
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
