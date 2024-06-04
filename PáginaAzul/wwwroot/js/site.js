$(document).ready(function () {
    $('#form-evento').on('submit', (event) => {
        event.preventDefault()
        $.ajax({
            url: 'https://localhost:7294/EmpresaPersona/Consume/Nuevo',
            type: 'POST',
            dataType: 'JSON',
            data: {
                idPersona: 0,
                nombre: $("#Nombre").val(),
                telefono: $("#Telefono").val(),
                email: $("#Email").val(),
                empresa: $("#Empresa").val(),
            },
            success: function (result) { console.log(result) },
            error: function (error) { console.log(error) }
        })
    })
})