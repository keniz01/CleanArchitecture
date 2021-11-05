using AutoMapper;
using CleanArchitecture.WebApi.Client;
using CleanArchitecture.WebUI.Pages.Home.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly IClient _client;
        private readonly ILogger<IndexModel> _logger;
        private readonly IMapper _mapper;
        
        public MetricsResponseDto Metrics { get; set; }

        public IndexModel(IClient client, ILogger<IndexModel> logger, IMapper mapper)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task OnGet()
        {
            Metrics = (await _client.DataMetricsAsync()).Data;
        }

        public async Task<ActionResult> OnPostCountriesByAlphabetAsync(
            [FromBody] GetCountriesByConditionViewModel<char> viewModel)
        {
            _logger.LogInformation("Calling OnPostCountriesByAlphabetAsync()");

            if (!ModelState.IsValid)
            {
                throw new TooManyModelErrorsException(nameof(viewModel));
            }

            var countries =
                await _client.CountriesStartingWithAlphabetAsync(viewModel.Condition.ToString(), viewModel.PageNumber,
                    viewModel.PageSize);
            var result = _mapper.Map<PagedSearchViewModel<CountryDto>>(countries);

            return new PartialViewResult
            {
                ViewName = "~/Pages/Home/Partials/_CountryGrid.cshtml",
                ViewData = new ViewDataDictionary<PagedSearchViewModel<CountryDto>>(ViewData, result)
            };
        }

        public async Task<ActionResult> OnPostCapitalCitiesByAlphabetAsync(
            [FromBody] GetCountriesByConditionViewModel<char> viewModel)
        {
            _logger.LogInformation("Calling OnPostCapitalCitiesByAlphabetAsync()");

            if (!ModelState.IsValid)
            {
                throw new TooManyModelErrorsException(nameof(viewModel));
            }

            var capitalCities =
                await _client.CapitalCitiesStartingWithAlphabetAsync(viewModel.Condition.ToString(), viewModel.PageNumber,
                    viewModel.PageSize);
            var result = _mapper.Map<PagedSearchViewModel<CapitalCityDto>>(capitalCities);

            return new PartialViewResult
            {
                ViewName = "~/Pages/Home/Partials/_CapitalCityGrid.cshtml",
                ViewData = new ViewDataDictionary<PagedSearchViewModel<CapitalCityDto>>(ViewData, result)
            };
        }

        public async Task<ActionResult> OnPostCapitalCitiesBySearchTermAsync([FromBody] GetCountriesByConditionViewModel<string> viewModel)
        {
            _logger.LogInformation("Calling OnPostCapitalCitiesBySearchTermAsync()");

            if (!ModelState.IsValid)
            {
                throw new TooManyModelErrorsException(nameof(viewModel));
            }

            var capitalCities =
                await _client.CapitalCitiesBySearchTermAsync(viewModel.Condition, viewModel.PageNumber,
                    viewModel.PageSize);
            var result = _mapper.Map<PagedSearchViewModel<CapitalCityDto>>(capitalCities);

            return new PartialViewResult
            {
                ViewName = "~/Pages/Home/Partials/_CapitalCityGrid.cshtml",
                ViewData = new ViewDataDictionary<PagedSearchViewModel<CapitalCityDto>>(ViewData, result)
            };
        }

        public async Task<ActionResult> OnPostCountriesBySearchTermAsync([FromBody] GetCountriesByConditionViewModel<string> viewModel)
        {
            _logger.LogInformation("Calling OnPostCountriesBySearchTermAsync()");

            if (!ModelState.IsValid)
            {
                throw new TooManyModelErrorsException(nameof(viewModel));
            }

            var countries =
                await _client.CountriesBySearchTermAsync(viewModel.Condition, viewModel.PageNumber,
                    viewModel.PageSize);
            var result = _mapper.Map<PagedSearchViewModel<CountryDto>>(countries);

            return new PartialViewResult
            {
                ViewName = "~/Pages/Home/Partials/_CountryGrid.cshtml",
                ViewData = new ViewDataDictionary<PagedSearchViewModel<CountryDto>>(ViewData, result)
            };
        }

        public async Task<ActionResult> OnPostContinentsAsync()
        {
            _logger.LogInformation("Calling OnPostContinentsAsync()");

            var response = await _client.WorldContinentsAsync();
            var result = _mapper.Map<IList<ContinentViewModel>>(response.Data);

            return new PartialViewResult
            {
                ViewName = "~/Pages/Home/Partials/_ContinentsPartialView.cshtml",
                ViewData = new ViewDataDictionary<IList<ContinentViewModel>>(ViewData, result)
            };
        }

        public async Task<ActionResult> OnPostRegionsAsync([FromBody] Guid continentId)
        {
            _logger.LogInformation("Calling OnPostRegionsAsync()");

            if (!ModelState.IsValid)
            {
                throw new TooManyModelErrorsException(nameof(continentId));
            }

            var response = await _client.RegionsByContinentAsync(continentId);
            var result = _mapper.Map<IList<RegionViewModel>>(response.Data);

            return new PartialViewResult
            {
                ViewName = "~/Pages/Home/Partials/_RegionsPartialView.cshtml",
                ViewData = new ViewDataDictionary<IList<RegionViewModel>>(ViewData, result)
            };
        }

        public async Task<ActionResult> OnPostCountriesByRegionAsync([FromBody] GetCountriesByConditionViewModel<Guid> viewModel)
        {
            _logger.LogInformation("Calling OnPostCountriesByRegionAsync()");

            if (!ModelState.IsValid)
            {
                throw new TooManyModelErrorsException(nameof(viewModel));
            }

            var countries = await _client.CountriesByRegionAsync(viewModel.Condition, viewModel.PageNumber, viewModel.PageSize);
            var result = _mapper.Map<PagedSearchViewModel<CountryDto>>(countries);

            return new PartialViewResult
            {
                ViewName = "~/Pages/Home/Partials/_CountryGrid.cshtml",
                ViewData = new ViewDataDictionary<PagedSearchViewModel<CountryDto>>(ViewData, result)
            };
        }
    }
}
