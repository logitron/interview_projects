function formatCurrency(value) {
    return "$" + value.toFixed(2);
}

function OrderViewModel(items) {
    var self = this;
    self.items = items;
    self.itemsToOrder = ko.observableArray();

    self.addItem = function (formElement) {
        $.ajax({
            type: 'POST',
            url: '/Order/AddToOrder',
            data: $(formElement).serialize(),
            success: function (data) {
                self.itemsToOrder.push(data);
            },
            dataType: 'json'
        });
    };
};

$(document).ready(function () {
    $.get('/Order/GetProducts', function (data) {
        ko.applyBindings(new OrderViewModel(data));
    });
});