$(document).ready(function () {
    $('.new-item').submit(function (event) {
        event.preventDefault();
        console.log("js submit fired");
        $.ajax({
            url:  '/Inventory/NewItem',
            type: "POST",
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                var resultRow = '<tr id="itemRow-' + result.itemId + '">' +
                                    '<td>' + result.name + '</td>' +
                                    '<td>' + result.count + '</td>' +
                                    '<td>$ ' + result.cost + '</td>' +
                                    '<td>$ ' + result.margin + '</td>' +
                                    '<td>$ ' + result.salePrice + '</td></tr>';
                $('.itemTable').append(resultRow);
            }
        });
    });

    $('.deleteButton').click(function (event) {
        event.preventDefault();
        var itemId = $(this).attr("id");
        var urlString = '/Inventory/DeleteItem/' + itemId;
        console.log(itemId);
        $.ajax({
            url: urlString,
            type: "POST",
            success: function () {
                var rowString = '#itemRow-' + itemId;
                $(rowString).hide();
            }
        });
    });
    $('.editButton').click(function (event) {
        event.preventDefault();
        $('.edit-item').show();
        var rowString = '#itemRow-' + $(this).attr("id");
        $('#newName').val($(rowString).find("td").eq(0).html());
        $('#newQuantity').val($(rowString).find("td").eq(1).html());

        var itemCost = $(rowString).find("td").eq(2).html();
        var costArray = itemCost.split(' ');
        var itemMargin = $(rowString).find("td").eq(3).html();
        var marginArray = itemMargin.split(' ');

        $('#newCost').val(costArray[1]);
        $('#newMargin').val(marginArray[1]);
        $('#editFormItemId').val($(this).attr('id'));
    });
    $('.edit-item').submit(function (event) {
        event.preventDefault();
        $('.edit-item').hide();
        var itemId = $("#editFormItemId").val();
        var urlString = '/Inventory/EditItem/' + itemId;
        $.ajax({
            url: urlString,
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                var rowString = '#itemRow-' + itemId;
                var resultRow = '<tr id="itemRow-' + result.itemId + '">' +
                                    '<td>' + result.name + '</td>' +
                                    '<td>' + result.count + '</td>' +
                                    '<td>$ ' + result.cost + '</td>' +
                                    '<td>$ ' + result.margin + '</td>' +
                                    '<td>$ ' + result.salePrice + '</td></tr>';
                $(rowString).html(resultRow);
            }
        });
    })
    $('.edit-item input').keyup(function (event) {
        event.preventDefault();
        var itemId = $("#editFormItemId").val();
        var rowName;
        var modifier = "";
        if ($(this).attr("id") == "newName") {
            rowName = "#name-";
        }
        else if ($(this).attr("id") == "newQuantity") {
            rowName = "#count-";
        }
        else if ($(this).attr("id") == "newCost") {
            rowName = "#cost-";
            modifier += "$ ";
        }
        else if ($(this).attr("id") == "newMargin") {
            rowName = "#margin-";
            modifier += "$ ";
        }
        var selectorString = rowName + itemId;
        $(selectorString).text(modifier + $(this).val());
    });

});