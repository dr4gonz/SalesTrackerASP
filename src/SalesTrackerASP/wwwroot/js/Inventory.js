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
                var resultRow = '<tr>' +
                                    '<td>' + result.name + '</td>' +
                                    '<td>' + result.count + '</td>' +
                                    '<td>$ ' + result.cost + '</td>' +
                                    '<td>$ ' + result.margin + '</td>' +
                                    '<td>$ ' + result.salePrice + '</td></tr>';
                $('.itemTable').append(resultRow);
            }

        });
    });
});