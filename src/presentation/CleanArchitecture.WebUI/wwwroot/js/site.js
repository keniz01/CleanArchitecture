$(function () {
    'use strict';

    //TODO: Refactor repetitive code.

    let selectedAlphabet;
    let selectedPageSize = 5;
    let selectedPageNumber = 1;

    $('#spinner').hide();

    let postData = async function (url, data) {
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

    let menuHighlight = function (allElements, clickedElement) {
        switch (arguments.length) {
            case 1:
                {
                    let elementIndex =
                        [...$('#page-menu li a')].findIndex(element => Number($(element).data('value')) ===
                            selectedPageNumber);
                    let target = $('#page-menu li')[elementIndex];
                    menuHighlight('#page-menu li', target);
                }
                break;
            case 2:
                $(allElements).removeClass('disabled active').css({ 'pointer-events': '' });
                $(clickedElement).closest('li').toggleClass('disabled active')
                    .css({ 'pointer-events': 'none' }); //Bootstrap pe-none did ont work here!
                break;
        }
    }

    let bindAlphabetPageNumbers = function () {
        $('#results-area').off().on('click',
            '#page-menu li',
            function (pageNumberElementEvent) {

                selectedPageNumber = Number($(pageNumberElementEvent.target).data('value'));

                let viewModel = {
                    PageNumber: selectedPageNumber,
                    PageSize: Number($('#page-size option:selected').val()),
                    Alphabet: selectedAlphabet
                };

                postData('/home?handler=CountriesByAlphabet', viewModel)
                    .then(data => {
                        //$('#spinner').toggleClass('d-flex').hide();
                        $('#results-area').empty().html(data);
                        menuHighlight('#page-menu li');
                    });
            });
    }

    let bindSearchPageNumbers = function () {
        $('#results-area').off().on('click',
            '#page-menu li',
            function (pageNumberElementEvent) {

                menuHighlight('#page-menu li', pageNumberElementEvent.target);

                selectedPageNumber = Number($(pageNumberElementEvent.target).data('value'));

                let viewModel = {
                    PageNumber: selectedPageNumber,
                    PageSize: Number($('#page-size option:selected').val()),
                    SearchTerm: $('#search-area input').val()
                };

                postData('/home?handler=CountriesBySearchTerm', viewModel)
                    .then(data => {
                        //$('#spinner').toggleClass('d-flex').hide();
                        $('#results-area').empty().html(data);
                        menuHighlight('#page-menu li');
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
                        //$('#spinner').toggleClass('d-flex').hide();
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

    let bindTopNavMenu = function () {
        $('#alphabet-menu li').on('click', function (menuLiElementEvent) {

            $('#spinner').toggleClass('d-flex').show();

            menuHighlight('#alphabet-menu li', menuLiElementEvent.target);

            selectedAlphabet = $(menuLiElementEvent.target).data('value');

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

                    $('#spinner').toggleClass('d-flex').hide();
                });
        });
    }

    let bindSearchBox = function () {
        $('#search-area input').on('keyup', function (e) {
            if (e.keyCode !== 13 || !$(e.target).val()) {
                return;
            }

            $('#spinner').toggleClass('d-flex').show();

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

                    $('#spinner').toggleClass('d-flex').hide();
                });
        });
    }

    bindTopNavMenu();
    bindSearchBox();
})