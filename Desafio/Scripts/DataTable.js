function addRow(data) {
    var tabla = $("#tbl_Suscriptores").DataTable();
    for (var i = 0; i < data.lenght; i++) {
        tabla.fnAddData([data[i].IdSuscriptor, Data[i].Nombre, Data[i].Apellido, Data[i].NumDocumento, Data[i].FechaAlta])
    }
}

function sendDataAjax() {
    $.ajax({
        type:"POST",
        url:"Suscriptor.aspx/ListarSuscriptores",
        data: {},
        contentType:'application/json; charset-utf-8',
        error: function (xhr, ajaxOptions, thrownError) {

        },
        success: function (data) {
            addRow(data.d);
        }


    })
}