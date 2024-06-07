$(document).ready(function () {
})

$('#form-evento').on('submit', (event) => {
    $(event.target).validate()
    if ($(event.target).valid()) {
        $('#modal-header #alert').toggleClass('alert-danger', !$(event.target).valid())
        $('#modal-header #alert').toggleClass('alert-success', $(event.target).valid()).text("Usuario validado")
        event.preventDefault()
        $.ajax({
            url: 'https://localhost:7294/EmpresaPersona/Consume/Nuevo',
            type: 'POST',
            dataType: 'JSON',
            crossDomain: true,
            contentType: 'application/json',
            headers:
            {
                "XSRF-TOKEN": $("input[name='__RequestVerificationToken']").val()
            },
            data: JSON.stringify({
                IdPersona: 0,
                Nombre: $("#Nombre").val(),
                Telefono: $("#Telefono").val(),
                Email: $("#Email").val(),
                Empresa: $("#Empresa").val()
            }),
            success: function (result) {
              
            },
            error: function (jq, error) { console.log(error) }
        })
    } else {
        $('#modal-header #alert').toggleClass('alert-danger', !$(event.target).valid()).text("Campos no validados")
        $('#modal-header #alert').toggleClass('alert-success', !$(event.target).valid())
    }
})