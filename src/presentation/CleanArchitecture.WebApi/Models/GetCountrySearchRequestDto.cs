using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.WebApi.Models
{
    public class GetCountrySearchRequestDto : RequestBase
    {
        private string _searchTerm;

        [Required]
        public string SearchTerm
        {
            get => _searchTerm;
            set => _searchTerm = Validate(value);
        }

        private static string Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new SearchTermViolationException(nameof(input));
            }

            return input;
        }
    }
}