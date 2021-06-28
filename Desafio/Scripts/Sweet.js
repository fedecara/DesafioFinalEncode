function msj_producto() {
    swal({
        title: "Esta seguro que desea eliminar esta publicacion",
        text: "",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "rgb(140, 212, 245)",
        confirmButtonText: "Eliminar",
        closeOnConfirm: true,
    })
        .then((isConfirm) => {
            if (isConfirm) {
                Window.Location="NuevoSuscriptor.aspx"
                    }
            else { }
        });
}