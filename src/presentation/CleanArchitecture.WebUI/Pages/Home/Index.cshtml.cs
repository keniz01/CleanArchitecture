using AutoMapper;
using CleanArchitecture.WebApi.Client;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly IClient _client;
        private readonly ILogger<IndexModel> _logger;
        private readonly IMapper _mapper;

        public IndexModel(IClient client, ILogger<IndexModel> logger, IMapper mapper)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPostCountriesByAlphabetAsync([FromBody]GetCountriesStartingWithAlphabetViewModel viewModel)
        {
            _logger.LogInformation("Calling OnPostCountriesByAlphabetAsync()");

            if (!ModelState.IsValid)
            {
                throw new TooManyModelErrorsException(nameof(viewModel));
            }

            var countries =
                await _client.CountriesStartingWithAlphabetAsync(viewModel.Alphabet.ToString(), viewModel.PageNumber,
                    viewModel.PageSize);
            var pagedViewModel = _mapper.Map<PagedCountrySearchViewModel>(countries);
            return new JsonResult(pagedViewModel);
        }

        public async Task<ActionResult> OnPostCountriesBySearchTermAsync([FromBody]GetCountriesBySearchTermViewModel viewModel)
        {
            _logger.LogInformation("Calling OnPostCountriesBySearchTermAsync()");

            if (!ModelState.IsValid)
            {
                throw new TooManyModelErrorsException(nameof(viewModel));
            }

            var countries =
                await _client.CountriesBySearchTermAsync(viewModel.SearchTerm, viewModel.PageNumber,
                    viewModel.PageSize);
            var result = _mapper.Map<PagedCountrySearchViewModel>(countries);
            return new JsonResult(result);
        }
    }
}
