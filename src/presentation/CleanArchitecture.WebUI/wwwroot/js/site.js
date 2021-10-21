$(function () {

    let selectedAlphabet;

    let postData = async function (url, data) {
        // Default options are marked with *
        const response = await fetch(url, {
            method: 'POST', // *GET, POST, PUT, DELETE, etc.
            mode: 'cors', // no-cors, *cors, same-origin
            cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
            credentials: 'same-origin', // include, *same-origin, omit
            headers: {
                'Content-Type': 'application/json'
                // 'Content-Type': 'application/x-www-form-urlencoded',
            },
            redirect: 'follow', // manual, *follow, error
            referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
            body: JSON.stringify(data) // body data type must match "Content-Type" header
        });
        return response.text(); // parses JSON response into native JavaScript objects
    }

    let bindTopNavMenu = function () {
        $('.nav-menu-top li').on('click', function (menuLiElementEvent) {
        selectedAlphabet = $(menuLiElementEvent.target).data('value');

        let viewModel = {
            PageNumber: 1,
            PageSize: 3,
            Alphabet: selectedAlphabet
        }
        postData('/home?handler=CountriesByAlphabet', viewModel)
            .then(data => {
                $('#results-area').empty().html(data);
            });
    });
    }

    let bindPagination = function () {
        $('#results-area').on('click', '.nav-menu-bottom li', function (pageNumberElementEvent) {
        let viewModel = {
            PageNumber: $(pageNumberElementEvent.target).data('value'),
            PageSize: 3,
            Alphabet: selectedAlphabet
        }
        postData('/home?handler=CountriesByAlphabet', viewModel)
            .then(data => {
                $('#results-area').empty().html(data);
            });
    });
    }

    let bindSearchBox = function () {
        $(document).on('keyup', '#search-area input',
        function (e) {
            if (e.keyCode !== 13) {
                return;
            }

            let viewModel = {
                PageNumber: 1,
                PageSize: 10,
                SearchTerm: $(e.target).val()
            }
            postData('/home?handler=CountriesBySearchTerm', viewModel)
                .then(data => {
                    $('#results-area').empty().html(data);
                });
        });
    }

    bindTopNavMenu();
    bindSearchBox();
    bindPagination();
})