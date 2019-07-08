$(document).ready(function () {
    $('#RefreshTable').click(function () {
        $.post({
            url: "/home/RefreshTable",
            data: { typeTable: $('#typeTable').val() },
            dataType: "html",
            success: function (response) {
                $('#Tables').html(response);
            },
            error: function () {
            }
        });
    })
    $('#SendComment').click(function () {
        $.post({
            url: "/home/SaveComment",
            data: { comment: $('#Comment').val() },
            dataType: "html",
            success: function (response) {
                $('#Comments').html(response);
            },
            error: function () {
            }
        });
    })
});