$(document).ready(function () {
    $(".newSaleButton").click(function (event) {
        event.preventDefault();
        $(".newSale").show();
        $(".newSaleButton").hide();
    });
    $('.newSale').submit(function (event) {
        event.preventDefault();
        $('.newSaleButton').show();
        $('.newSale').hide();
    });
});