$(document).ready(function () {
    var newSale = {
        Buyer: "",
        Comments: "",
        Items: {}
    };
    $(".newSaleButton").click(function (event) {
        event.preventDefault();
        $(".newSale").show();
        $(".newSaleButton").hide();
    });
    $('.newSale').submit(function (event) {
        event.preventDefault();
        $('.newSaleButton').show();
        $('.newSale').hide();
        newSale.Buyer = $("#buyer").val();
        newSale.Comments = $("#comments").val();
        $("#buyerName").html(newSale.Buyer);
        $("#saleComments").html(newSale.Comments);
    });
    $(".addItemToSaleForm").submit(function (event) {
        event.preventDefault();
        newSale.Items[parseInt($('#itemSelector').val())] = parseInt($("#quantity").val());
        console.log(newSale.Items);
        var selectItemId = "#selectItem-" + $("#itemSelector").val();
        var listItem = "<tr><td>" + $(selectItemId).text() + "</td><td>" + $("#quantity").val() + "</td></tr>";
        $("#itemList").append(listItem);
    });
    $("#saleSubmit").click(function (event) {
        event.preventDefault();
        console.log(newSale);
        $.ajax({
            url: '/Sales/NewSale',
            type: "POST",
            dataType: 'json',
            data: newSale,
            success: function (result) {
                console.log(result);
            }
        });
    });

});