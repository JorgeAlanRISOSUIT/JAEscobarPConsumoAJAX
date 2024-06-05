$(document).ready(function () {
})

$('#form-evento').on('submit', (event) => {
    event.preventDefault()
    $.ajax({
        url: 'https://localhost:7294/EmpresaPersona/Consume/Nuevo',
        type: 'POST',
        dataType: 'JSON',
        crossDomain: true,
        contentType: 'application/json',
        data: JSON.stringify({
            IdPersona: 0,
            Nombre: $("#Nombre").val(),
            Telefono: $("#Telefono").val(),
            Email: $("#Email").val(),
            Empresa: $("#Empresa").val()
        }),
        success: function (result) { console.log(result) },
        error: function (jq, error) { console.log(error) }
    })
})