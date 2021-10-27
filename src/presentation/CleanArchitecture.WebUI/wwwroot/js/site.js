$(function () {
    'use strict';

    //TODO: Refactor repetitive code.

    let selectedAlphabet;
    let selectedPageSize = 5;
    let selectedPageNumber = 1;
    let selectedRegionId;

    $('#spinner').hide();

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

    let disableClickedLink = function(opts) {

        if (opts.clickedElement === undefined) {
            let elementIndex =
                [...$(opts.elements)].findIndex(element => $(element).data('value') === opts.elementValue);
            opts.clickedElement = $(opts.elements)[elementIndex];
        }

        $(opts.elements).removeClass('disabled active').css({ 'pointer-events': '' });
        $(opts.clickedElement).closest('li').toggleClass('disabled active')
            .css({ 'pointer-events': 'none' }); //Bootstrap pe-none did ont work here!
    }

    let showCountriesTab = function () {
        $('#countries-link').on('click', function (e) {
            $('#countries-tab').removeClass('d-none');
            $('#continents-tab').addClass('d-none');
            $('#results-area').empty();
            disableClickedLink({ elements: '#main-nav li', clickedElement: e.target });
        });
    }

    let showContinentTab = function () {
        $('#continents-link').on('click', function (e) {
            $('#continents-tab').removeClass('d-none'); // Show continents tab.
            $('#countries-tab').addClass('d-none'); // Hide countries tab.
            $('#results-area').empty();
            $('#regions-menu').empty(); // Clear regions menu, if any.

            $('#spinner').toggleClass('d-flex d-none');
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

    let bindContinentPageNumbers = function () {
        $('#results-area').off().on('click',
            '#page-menu li',
            function (pageNumberElementEvent) {

                $('#spinner').toggleClass('d-flex d-none');

                selectedPageNumber = Number($(pageNumberElementEvent.target).closest('li').data('value'));

                let viewModel = {
                    PageNumber: selectedPageNumber,
                    PageSize: Number($('#page-size option:selected').val()),
                    RegionId: selectedRegionId
                };

                postData('/home?handler=CountriesByRegion', viewModel)
                    .then(data => {
                        $('#results-area').empty().html(data);
                        disableClickedLink({ elements: '#page-menu li', elementValue: selectedPageNumber });
                        $('#spinner').toggleClass('d-flex d-none');
                    });
            });
    }

    let bindAlphabetPageNumbers = function () {
        $('#results-area').off().on('click',
            '#page-menu li',
            function (pageNumberElementEvent) {

                $('#spinner').toggleClass('d-flex d-none');
                selectedPageNumber = Number($(pageNumberElementEvent.target).closest('li').data('value'));

                let viewModel = {
                    PageNumber: selectedPageNumber,
                    PageSize: Number($('#page-size option:selected').val()),
                    Alphabet: selectedAlphabet
                };

                postData('/home?handler=CountriesByAlphabet', viewModel)
                    .then(data => {
                        $('#results-area').empty().html(data);
                        disableClickedLink({ elements: '#page-menu li', elementValue: selectedPageNumber });
                        $('#spinner').toggleClass('d-flex d-none');
                    });
            });
    }

    let bindSearchPageNumbers = function () {
        $('#results-area').off().on('click',
            '#page-menu li',
            function (pageNumberElementEvent) {

                disableClickedLink({ elements: '#page-menu li', clickedElement: pageNumberElementEvent.target });

                selectedPageNumber = Number($(pageNumberElementEvent.target).closest('li').data('value'));

                let viewModel = {
                    PageNumber: selectedPageNumber,
                    PageSize: Number($('#page-size option:selected').val()),
                    SearchTerm: $('#search-area input').val()
                };

                postData('/home?handler=CountriesBySearchTerm', viewModel)
                    .then(data => {
                        $('#results-area').empty().html(data);
                        disableClickedLink({ elements: '#page-menu li', elementValue: selectedPageNumber });
                    });
            });
    }

    let bindSearchPageSize = function () {
        $('#results-area').on('change',
            '#page-size',
            function () {
                selectedPageSize = Number($('#page-size option:selected').val());

                let viewModel = {
                    PageNumber: 1,
                    PageSize: selectedPageSize,
                    SearchTerm: $('#search-area input').val()
                };

                postData('/home?handler=CountriesBySearchTerm', viewModel)
                    .then(data => {
                        $('#results-area').empty().html(data);
                    });
            });
    }

    let bindContinentsPageSize = function () {
        $('#results-area').on('change',
            '#page-size',
            function () {

                selectedPageSize = Number($('#page-size option:selected').val());

                let viewModel = {
                    PageNumber: 1,
                    PageSize: selectedPageSize,
                    RegionId: selectedRegionId
                };

                postData('/home?handler=CountriesByRegion', viewModel)
                    .then(data => {

                        $('#results-area').empty().html(data);
                    });
            });
    }

    let bindAlphabetPageSize = function () {
        $('#results-area').on('change',
            '#page-size',
            function () {

                selectedPageSize = Number($('#page-size option:selected').val());

                let viewModel = {
                    PageNumber: 1,
                    PageSize: selectedPageSize,
                    Alphabet: selectedAlphabet
                };

                postData('/home?handler=CountriesByAlphabet', viewModel)
                    .then(data => {

                        $('#results-area').empty().html(data);
                    });
            });
    }


    let bindRegionMenu = function () {
        $($('#regions-menu')).on('click',
            'li',
            function (e) {
                $('#spinner').toggleClass('d-flex d-none');

                disableClickedLink({ elements: '#regions-menu li', clickedElement: e.target });
                selectedRegionId = $(e.target).closest('li').data('value');
                let viewModel = {
                    PageNumber: 1,
                    PageSize: 5,
                    RegionId: selectedRegionId
                };

                postData('/home?handler=CountriesByRegion', viewModel)
                    .then(data => {
                        $('#results-area').empty().html(data);
                        bindContinentPageNumbers();
                        bindContinentsPageSize();

                        $('#spinner').toggleClass('d-flex d-none');
                    });
            });
    }

    let bindAlphabetNavMenu = function () {
        $('#alphabet-menu li').on('click', function (menuLiElementEvent) {

            $('#spinner').toggleClass('d-flex d-none');

            disableClickedLink({ elements: '#alphabet-menu li', clickedElement: menuLiElementEvent.target });

            selectedAlphabet = $(menuLiElementEvent.target).closest('li').data('value');

            let viewModel = {
                PageNumber: 1,
                PageSize: selectedPageSize,
                Alphabet: selectedAlphabet
            }
            postData('/home?handler=CountriesByAlphabet', viewModel)
                .then(data => {

                    $('#results-area').empty().html(data);

                    bindAlphabetPageNumbers();
                    bindAlphabetPageSize();

                    $('#spinner').toggleClass('d-flex d-none');
                });
        });
    }

    let bindSearchBox = function () {
        $('#search-area input').on('keyup', function (e) {
            if (e.keyCode !== 13 || !$(e.target).val()) {
                return;
            }

            $('#spinner').toggleClass('d-flex d-none');

            let viewModel = {
                PageNumber: selectedPageNumber,
                PageSize: selectedPageSize,
                SearchTerm: $(e.target).val()
            }
            postData('/home?handler=CountriesBySearchTerm', viewModel)
                .then(data => {
                    $('#results-area').empty().html(data);

                    bindSearchPageNumbers();
                    bindSearchPageSize();

                    $('#spinner').toggleClass('d-flex d-none');
                });
        });
    }

    bindAlphabetNavMenu();
    bindSearchBox();
    showCountriesTab();
    showContinentTab();
    bindContinentMenu();
    bindRegionMenu();

    $('#countries-link').trigger('click');
})