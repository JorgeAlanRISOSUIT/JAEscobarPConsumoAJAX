let mes = 0
let año = 0
let meses = [
    'enero',
    'febrero',
    'marzo',
    'abril',
    'mayo',
    'junio',
    'julio',
    'agosto',
    'septiembre',
    'octubre',
    'noviembre',
    'diciembre',
]
let años = () => {
    let array = []
    for (let start = 1910; start < 2100; start++) {
        array.push(start)
    }
    return array;
}

let dias = (mes, año) => {
    if ((año % 4 == 0 && año % 100 != 0 || año % 100 == 0 && año % 400 == 0) && (mes == 2)) {
        for (let dia = 1, index = 1; dia < 30; dia++, index++) {
            $('#dia').append($('<option>', { text: dia, value: index }))
        }
    } else if (mes == 2) {
        for (let dia = 1, index = 1; dia < 29; dia++, index++) {
            $('#dia').append($('<option>', { text: dia, value: index }))
        }
    } else {
        if (mes % 2 != 0) {
            for (let dia = 1, index = 1; dia <= 31; dia++, index++) {
                $('#dia').append($('<option>', { text: dia, value: index }))
            }
        } else {
            for (let dia = 1, index = 1; dia < 31; dia++, index++) {
                $('#dia').append($('<option>', { text: dia, value: index }))
            }
        }
    }
}

function proofUndefined(value) {
    return value != undefined || mes != 0
}

$('#año').on('change', (event) => {
    $('#mes').prop('disabled', () => event.target.options[event.target.selectedIndex].value == 0)
    año = $('#mes').prop('disabled') ? 0 : event.target.options[event.target.selectedIndex].text
    if (proofUndefined(mes)) {
        $('#dia').empty().append($('<option>', { value: 0, text: "Día" }))
        $.each(dias(mes, año), (index, value) => {
            $('#dia').append($('<option>', { value: index + 1, text: value }))
        })
    }
})

$('#mes').on('change', (event) => {
    $('#dia').empty().append($('<option>', { value: 0, text: "Día" }))
    $('#dia').prop('disabled', () => event.target.options[event.target.selectedIndex].value == 0)
    mes = event.target.options[event.target.selectedIndex].value
    $.each(dias(mes, año), (index, value) => {
        $('#dia').append($('<option>', { value: index + 1, text: value }))
    })
})

$('#mes').ready(() => {
    meses.forEach((value, index) => {
        let optionText = $('<option>', { value: index , text: value })
        $('#mes').append(optionText)
    })
})

$('#año').ready(() => {
    $.each(años(), (index, value) => {
        let optionText = $('<option>', { value: index + 1, text: value })
        $('#año').append(optionText)
    })
})

$('#Entidad').ready(() => {
    $.ajax({
        url: "https://localhost:7294/api/Entidades/TodoEstado",
        crossDomain: true,
        contentType: 'application/json',
        dataType: 'JSON',
        type: 'GET',
        success: function (result) {
            if (result.success) {
                $.each(result.objects, (index, value) => {
                    $('#Entidad').append($('<option>', { value: value.idEntidad, text: value.nombre }))
                })
            } else {
                $('#Entidad').prop('disabled', () => !result.success)
            }
        },
        error: function (error) {
            console.log(error)
        }
    })
})

$('#IndexForm').on("submit", (event) => {
    event.preventDefault()
    let info = {
        nombre: $('#Nombre').val(),
        apellidoPaterno: $('#ApellidoPaterno').val(),
        apellidoMaterno: $('#ApellidoMaterno').val(),
        estadoCivil: $('#EstadoCivil option:selected').val(),
        genero: $('#Genero option:selected').prop('value'),
        fechaNacimiento: () => {
            let date = new Date(parseInt($('#año option:selected').prop('text')), parseInt($('#mes option:selected').prop('value')), parseInt($('#dia option:selected').prop('value')))
            if (date instanceof Date && !isNaN(date))
                return date.toISOString()
            else {
                return new Date().toISOString()
            }
        },
        entidad: {
            idEntidad: parseInt($('#Entidad option:selected').prop('value')),
            nombre: $('#Entidad option:selected').prop('text')
        },
        curp: $('#CURP').val(),
        rfc: $('#RFC').val(),
        telefono: $('#Telefono').val(),
        correo: $('#Email').val(),
    }
    console.log(JSON.stringify(info))
    $.ajax({
        url: 'https://localhost:7294/api/AseguradoraPersona/NuevoRegistro',
        type: 'POST',
        crossDomain: true,
        contentType: 'application/json',
        dataType: 'JSON',
        data: JSON.stringify(info),
        success: function (result) {
            $('#modalBody').empty().append($('<div>').addClass('alert alert-success col-md-12').text('Se ha insertado el usuario correctamente'))
        },
        error: function (error) {
            $('#modalBody').empty()
            $('#modalBody').append($('<div>').addClass('d-flex col-md-12 flex-column').prop('id', 'info-message'))
            for (let [name, value] of Object.entries(error.responseJSON.errors)) {
                $('#info-message').text(name + ":" + value)
            }
        }
    })
})