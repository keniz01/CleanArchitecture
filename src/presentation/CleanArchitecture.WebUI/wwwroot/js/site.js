$(function () {
    'use strict';
    
    let selectedAlphabet;
    let selectedPageSize = 5;
    let selectedPageNumber = 1;
    let selectedRegionId;

    let resetPage = function() {
        selectedAlphabet = undefined;
        selectedPageSize = 5;
        selectedPageNumber = 1;
        selectedRegionId = undefined;
    }

    $('#spinner').hide();

    /**
     * Posts request and returns text data. Note: does not return Json data.
     * @param {any} url Url to post to.
     * @param {any} data Data to post to the server.
     */
    let postData = async function (url, data = {}) {
        // Default options are marked with *
        const response = await fetch(url, {
            method: 'POST', // *GET, POST, PUT, DELETE, etc.
            mode: 'cors', // no-cors, *cors, same-origin
            cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
            credentials: 'same-origin', // include, *same-origin, omit
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow', // manual, *follow, error
            referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
            body: JSON.stringify(data) // body data type must match "Content-Type" header
        });
        return response.text(); // parses text/JSON response into native JavaScript objects
    }

    /**
     * Marks an anchor like as clicked by disabling it.
     * @param {any} opts parameters.
     */
    let disableClickedLink = function(opts) {

        if (opts.clickedElement === undefined) {
            let elementIndex =
                [...$(opts.elements)].findIndex(element => $(element).data('value') === opts.elementValue);
            elementIndex = elementIndex === -1 ? 0 : elementIndex;
            opts.clickedElement = $(opts.elements)[elementIndex];
        }

        $(opts.elements).removeClass('disabled active').css({ 'pointer-events': '' });
        $(opts.clickedElement).closest('li').toggleClass('disabled active')
            .css({ 'pointer-events': 'none' }); //Bootstrap pe-none did ont work here!
    }

    let showCountriesTab = function () {
        $('#countries-link').on('click', function (e) {
            $('#continents-tab').addClass('d-none'); // Show continents tab.
            $('#countries-tab').removeClass('d-none'); // Hide countries tab.
            $('#capital-cities-tab').addClass('d-none'); // Hide countries tab.
            $('#results-area').empty();

            $('#country-alphabet-menu li').removeClass('disabled active').css({ 'pointer-events': '' });

            disableClickedLink({ elements: '#main-nav li', clickedElement: e.target });

            resetPage();
        });
    }

    let showCapitalCitiesTab = function () {
        $('#capital-cities-link').on('click', function (e) {
            $('#continents-tab').addClass('d-none'); // Show continents tab.
            $('#countries-tab').addClass('d-none'); // Hide countries tab.
            $('#capital-cities-tab').removeClass('d-none'); // Hide countries tab.
            $('#results-area').empty();

            $('#capital-city-alphabet-menu li').removeClass('disabled active').css({ 'pointer-events': '' });

            disableClickedLink({ elements: '#main-nav li', clickedElement: e.target });

            resetPage();
        });
    }

    let showContinentsTab = function () {
        $('#continents-link').on('click', function (e) {
            $('#continents-tab').removeClass('d-none'); // Show continents tab.
            $('#countries-tab').addClass('d-none'); // Hide countries tab.
            $('#capital-cities-tab').addClass('d-none'); // Hide countries tab.
            $('#results-area').empty();
            $('#regions-menu').empty(); // Clear regions menu, if any.

            $('#spinner').toggleClass('d-flex d-none');

            resetPage();

            disableClickedLink({ elements: '#main-nav li', clickedElement: e.target });
            
            postData('/home?handler=continents')
                .then(data => {
                    $('#continents-menu').empty().html(data);
                    $('#spinner').toggleClass('d-flex d-none');
                });
        });
    }

    let bindContinentMenu = function () {
        $($('#continents-menu')).on('click',
            'li',
            function (e) {

                $('#results-area').empty();
                let continentId = $(e.target).closest('li').data('value');

                disableClickedLink({ elements: '#continents-menu li', clickedElement: e.target });

                $('#spinner').toggleClass('d-flex d-none');
                postData('/home?handler=regions', continentId)
                    .then(data => {
                        $('#regions-menu').empty().html(data);
                        $('#spinner').toggleClass('d-flex d-none');
                    });
            });
    }

    /**
     * Binds click event to page numbers.
     * @param {any} opts parameters
     */
    let bindPageNumbers = function (opts) {

        disableClickedLink({ elements: '#page-menu li', elementValue: selectedPageNumber });

        $('#results-area').off().on('click',
            '#page-menu li',
            function (event) {

                $('#spinner').toggleClass('d-flex d-none');
                selectedPageNumber = Number($(event.target).closest('li').data('value'));
                opts.viewModel.pageSize = Number($('#page-size option:selected').val());
                opts.viewModel.pageNumber = selectedPageNumber;

                postData(opts.url, opts.viewModel)
                    .then(data => {
                        $('#results-area').empty().html(data);
                        disableClickedLink({ elements: '#page-menu li', elementValue: selectedPageNumber });
                        $('#spinner').toggleClass('d-flex d-none');
                    });
            });
    }

    /**
     * Binds change event to the Page size select control.
     * @param {any} opts parameters.
     */
    let bindPageSize = function (opts) {
        
        $('#results-area').on('change',
            '#page-size',
            function () {

                selectedPageSize = Number($('#page-size option:selected').val());
                
                opts.viewModel.pageSize = selectedPageSize;
                opts.viewModel.pageNumber = 1;

                postData(opts.url, opts.viewModel)
                    .then(data => {

                        $('#results-area').empty().html(data);
                        disableClickedLink({ elements: '#page-menu li', elementValue: selectedPageNumber });
                    });
            });
    }

    /**
     * Binds click event to region menu.
     */
    let bindRegionMenu = function () {
        $($('#regions-menu')).on('click',
            'li',
            function (e) {

                $('#results-area').empty();
                $('#spinner').toggleClass('d-flex d-none');

                disableClickedLink({ elements: '#regions-menu li', clickedElement: e.target });
                selectedRegionId = $(e.target).closest('li').data('value');

                let viewModel = {
                    PageNumber: 1,
                    PageSize: 5,
                    Condition: selectedRegionId
                };

                postData('/home?handler=CountriesByRegion', viewModel)
                    .then(data => {
                        $('#results-area').empty().html(data);

                        bindPageNumbers({
                            url: '/home?handler=CountriesByRegion',
                            viewModel: {
                                Condition: selectedRegionId
                            }
                        });
                        
                        bindPageSize({ url: '/home?handler=CountriesByRegion', viewModel: { Condition: selectedRegionId } });

                        $('#spinner').toggleClass('d-flex d-none');
                    });
            });
    }
    
    /**
    * Binds click event to A-Z menu.
    */
    let bindAlphabetMenu = function (opts) {
        $(opts.targetElement).on('click', function (menuLiElementEvent) {

            $('#spinner').toggleClass('d-flex d-none');

            disableClickedLink({ elements: opts.menu, clickedElement: menuLiElementEvent.target });

            selectedAlphabet = $(menuLiElementEvent.target).closest('li').data('value');

            let viewModel = {
                PageNumber: 1,
                PageSize: selectedPageSize,
                Condition: selectedAlphabet
            }
            postData(opts.url, viewModel)
                .then(data => {

                    $('#results-area').empty().html(data);

                    bindPageNumbers({
                        url: opts.url,
                        viewModel: {
                            Condition: selectedAlphabet
                        }
                    });

                    bindPageSize({ url: opts.url, viewModel: { Condition: selectedAlphabet } });

                    $('#spinner').toggleClass('d-flex d-none');
                });
        });
    }

    /**
    * Triggers search functionality when the Enter key is pressed with focus on the search box.
    */
    let bindSearchBox = function (opts) {
        $(opts.targetElement).on('keyup', function (e) {
            if (e.keyCode !== 13 || !$(e.target).val()) {
                return;
            }

            $('#spinner').toggleClass('d-flex d-none');

            let viewModel = {
                PageNumber: 1,
                PageSize: 5,
                Condition: $(e.target).val()
            }
            postData(opts.url, viewModel)
                .then(data => {
                    $('#results-area').empty().html(data);

                    bindPageNumbers({
                        url: opts.url,
                        viewModel: {
                            Condition: $(opts.targetElement).val()
                        }
                    });

                    bindPageSize({ url: opts.url, viewModel: { Condition: $(opts.targetElement).val() } });

                    $('#spinner').toggleClass('d-flex d-none');
                });
        });
    }

    bindAlphabetMenu({ targetElement: $('#capital-city-alphabet-menu li'), url: '/home?handler=CapitalCitiesByAlphabet', menu: '#capital-city-alphabet-menu li' });
    bindAlphabetMenu({ targetElement: $('#country-alphabet-menu li'), url: '/home?handler=CountriesByAlphabet', menu: '#country-alphabet-menu li'  });
    bindSearchBox({ targetElement: $('#country-search-area input'), url: '/home?handler=CountriesBySearchTerm' });
    bindSearchBox({ targetElement: $('#capital-city-search-area input'), url: '/home?handler=CapitalCitiesBySearchTerm' });
    showCountriesTab();
    showContinentsTab();
    showCapitalCitiesTab();
    bindContinentMenu();
    bindRegionMenu();

    $('#capital-cities-link').trigger('click');
})