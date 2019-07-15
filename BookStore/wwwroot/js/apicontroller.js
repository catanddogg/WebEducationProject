$(document).ready(function () {
    $('#RefreshTable').click(function () {
        $.post({
            url: "/home/RefreshTable",
            data: { typeTable: $('#typeTable').val() },
            dataType: "html",
            success: function (response)
            {
                $('#Tables').html(response);
            },
            error: function (ex)
            {
                console.error(ex)
            }
        });
    })

    $('#SendComment').click(function () {
        $.post({
            url: "/home/SaveComment",
            data: { comment: $('#Comment').val() },
            dataType: "html",
            success: function (response)
            {
                $('#Comments').html(response);
            },
            error: function (ex)
            {
                console.error(ex)
            }
        });
    })

    $('#Swagger').click(function () {
        $.post({
            url: "/home/swagger",
            dataType: "html",
            success: function (response)
            {
                window.location.href = "/Home/Swagger";
            },
            error: function (ex) {
                console.error(ex)
            }
        });
    })

    $('#Login').click(function () {
        $.post({
            url: "/home/login",
            data: {
                Email: $('#Email').val(),
                Password: $('#Password').val()
            },
            dataType: "html",
            success: function (data)
            {
                window.location.href = "/Home/Index";
                //ChangeTextLoginModel(data);              
            },
            error: function (ex)
            {
                console.error(ex)
            }
        });
    })

    function ChangeTextLoginModel(data)
    {
        if (data != "")
        {          
            window.location.href = "/Home/Index";
        }
        if (data == "")
        {
            $('#loginModal').modal('show')
            $('#loginModalTitle').html('Alert');
            $('#loginModalBody').html('Login or password not correct!');
        }   
    }

    $('#RegistrationPage').click(function () {
        $.post({
            url: "/Home/Registration",          
            dataType: "html",
            success: function (data)
            {
                window.location = "/Home/Registration";
            },
            error: function (ex)
            {
                console.error(ex)
            }
        });
    })

    $('#RegisterUser').click(function () {
        $.post({
            url: "/Home/Registration",
            data: {
                Email: $('#Email').val(),
                Password: $('#Password').val(),
                PasswordConfirm: $('#PasswordConfirm').val()
            },
            dataType: "html",
            success: function (data)
            {
                window.location = "/Home/Login";
                //ChangeTextRegistrationModel(data);
            },
            error: function (ex)
            {
                console.error(ex)
            }
        });
    })

    function ChangeTextRegistrationModel(data)
    {
        if (data == "Data not correct!" || data == "Age not correct!")
        {
            $('#registerModal').modal('show')
            $('#registerModalTitle').html('Alert');
            $('#registerModalBody').html(data);
            return
        }
        window.location = "/Home/Login";
    }
    
    $('#RegisterBack').click(function () {
        $.post({
            url: "/Home/Login",
            dataType: "html",
            success: function (data)
            {
                window.location = "/Home/Login";
            },
            error: function (ex)
            {
                console.error(ex)
            }
        });
    })

    $('#CreateBook').click(function () {
        $.post({
            url: "/Home/Book",
            dataType: "html",
            success: function (data)
            {
                window.location = "/Home/Book";
            },
            error: function (ex)
            {
                console.error(ex)
            }
        });
    })

    $('#NavigationToIndex').click(function () {
        $.post({
            url: "/Home/NavigationToIndex",
            dataType: "html",
            success: function (data)
            {
                window.location = "/Home/Index";
            },
            error: function (ex)
            {
                console.error(ex)
            }
        });
    })

    $('#SaveFile').click(function () {
        var fileupload = $("#file").get(0);
        var files = fileupload.files;
        var formData = new FormData();
        formData.append('file', files[0]);
        formData.append('Name', $('#Name').val());
        formData.append('Avtor', $('#Avtor').val());
        formData.append('Publisher', $('#Publisher').val());
        formData.append('Genre1', $('#Genre1').val());
        formData.append('Genre2', $('#Genre2').val());
        $.post({
            url: "/Home/AddFile",
            data: formData,
            processData: false,
            contentType: false,
            dataType: "html",
            success: function (data)
            {
                ChangeTextBookModel(data);
            },
            error: function (ex)
            {
                console.error(ex)
            }
        });
    })

    function ChangeTextBookModel(data)
    {
        if (data == "Index")
        {
            window.location = "/Home/Index";
            return
        }
        if(data != "Index")
        {
            $('#bookModal').modal('show')
            $('#bookModalTitle').html('Alert');
            $('#bookModalBody').html(data);
        }
    }
});