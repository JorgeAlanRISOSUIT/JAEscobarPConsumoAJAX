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



$('#año').on('change', (event) => {
    $('#mes').prop('disabled', () => event.target.options[event.target.selectedIndex].value == 0)
    año = $('#mes').prop('disabled') ? 0 : event.target.options[event.target.selectedIndex].text
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
        let optionText = $('<option>', { value: index + 1, text: value })
        $('#mes').append(optionText)
    })
})

$('#año').ready(() => {
    $.each(años(), (index, value) => {
        let optionText = $('<option>', { value: index + 1, text: value })
        $('#año').append(optionText)
    })
})


$('#formulario-cafe').on('submit', (event) => {
    event.preventDefault()
})

function Estados() {

}