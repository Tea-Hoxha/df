var ViewModel = function () {
    var self = this;
    self.klient = ko.observableArray();
    self.error = ko.observable();

    var klientUri = '/api/Klient/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllK() {
        ajaxHelper(klientUri, 'getK').done(function (data) {
            self.klient(data);
        });
    }

    // Fetch the initial data.
    getAllK();
};

ko.applyBindings(new ViewModel());