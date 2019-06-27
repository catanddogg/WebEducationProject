$(document).ready(function () {
    $('#Test').click(function () {
        var typeTable = 2;
        $.post({
            url: "/home/index",
            data: { typeTable: typeTable },
            success: function () {
            },
            error: function () {

            }
        });
    })
});