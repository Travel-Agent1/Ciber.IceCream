﻿define(["Domain/currentUser", "knockout", "ordnung/ajax"], function(currentUser, ko, ajax) {

    function BuyIceCreamVM(onBought) {
        var self = this;

        this.selectedIceCream = ko.observable();
        this.buy = function () {
            var id = self.selectedIceCream().id;
            ajax("api/buyIceCream", { id: id, user: currentUser.id}, "POST", function(xhr) {
                onBought(id);
            });
        };
    }

    return BuyIceCreamVM;

});