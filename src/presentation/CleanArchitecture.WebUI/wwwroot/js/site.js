$(function () {

    $.each($('#navigation-area li'),
        function(i, v) {
            $(v).on('click',
                function (e) {
                    let viewModel = {
                        PageNumber: 1,
                        PageSize: 30,
                        Alphabet: $(e.target).data('value')
                    }
                    postData('/home?handler=CountriesByAlphabet', viewModel)
                        .then(data => {
                            $('#results-area').empty().html(data);
                        });
                });
        });

    $(document).on('keyup', '#search-area input',
        function (e) {
            if (e.keyCode !== 13) {
                return;
            }

            let viewModel = {
                PageNumber: 1,
                PageSize: 30,
                SearchTerm: $(e.target).val()
            }
            postData('/home?handler=CountriesBySearchTerm', viewModel)
                .then(data => {
                    $('#results-area').empty().html(data);
                });
        });

    async function postData(url, data) {
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
})