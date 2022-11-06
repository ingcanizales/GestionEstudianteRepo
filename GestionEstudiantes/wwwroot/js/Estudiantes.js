$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});

var isEdition = true;
var EstudianteActual = null;


//Guarda y valida mi formulario
async function Salvar()
{
    try {

        var form = $("#FormEstudiante").dxForm("instance");
        var valido = form.validate().isValid;

        if (valido) {

            var dataformulario = form.option("formData");
            await $.ajax({ method: "POST", url: "/Estudiantes?handler=CrearEstudiante", data: dataformulario });
            await Swal.fire(
                'Atención',
                'Estudiante Guardado Correctamente',
                'success'
            )
            var form = $("#FormEstudiante").dxForm("instance").resetValues();
            $("#TableEstudiantes").dxDataGrid("instance").refresh();
        }

    }
    catch (error)
    {
        await Swal.fire(
            'Atención',
            'Ocurrió un error inesperado',
            'error'
        )

    }
    
}

//Valida que un documento sea unico
async function DocumentoUnico(e)
{
    try
    {
        if (isEdition)
        {
            return true;
        }

        var idTipoDocumento = $("#FormEstudiante").dxForm("instance").getEditor("TipoDocumento").option("value").Id;
        if (idTipoDocumento != 0)
        {
            var valido = await $.ajax({
                method: "GET", url: "/Estudiantes?handler=VerificarIdentificacionUnica",
                data: { IdTipodocumento : idTipoDocumento, identificacion: e.value }
            });
        }

        return valido;
    }
    catch (error)
    {
        return false;
    }
}

function VerificarMayorEdad(e)
{
    var valido = true;
    var Edad = e.value;
    if (Edad <= 18) {
        valido = false;
    }
    return valido;
}

function EsconderGrid() {
    $("#divgrid").hide();
    $("#divformulario").show();
    $("#FormEstudiante").dxForm("instance").resetValues();
    $("#FormEstudiante").dxForm("instance").option("formData", null);
}

function EsconderFormulario() {
    $("#divformulario").hide();
    $("#divgrid").show();
    $("#FormEstudiante").dxForm("instance").resetValues();
    $("#FormEstudiante").dxForm("instance").option("readOnly", false);
    /*$("#btnsalvar").dxButton("instance").option("disabled", false)*/
    $("#FormEstudiante").dxForm("instance").option("formData", null);
    $("#TableEstudiantes").dxDataGrid("instance").refresh();
}

async function EditarEstudianteFromGrid(e) {

    try {
        var idEstudiante = e.row.data.Id;

        var estudiante = await $.ajax({
            method: "GET",
            url: "/Estudiantes?handler=ObtenerEstudiante",
            data: { idEstudiante: idEstudiante }
        });

        if (estudiante == null) {
            await Swal.fire(
                'Atención',
                'Estudiante no encontrado',
                'info'
            )

            return;
        }
        else {
            $("#divgrid").hide();
            $("#divformulario").show();
            $("#FormEstudiante").dxForm("instance").resetValues();
            $("#FormEstudiante").dxForm("instance").option("formData", estudiante);
            $("#FormEstudiante").dxForm("instance").getEditor("TipoDocumento").option("readOnly", true);
            $("#FormEstudiante").dxForm("instance").getEditor("Documento").option("readOnly", true);
            isEdition = true;
        }
    }
    catch (error) {
        await Swal.fire(
            'Atención',
            'Ocurrió un error inesperado',
            'error'
        )
    }


}

async function VerEstudianteFromGrid(e) {
    EditarEstudianteFromGrid(e);
    $("#FormEstudiante").dxForm("instance").option("readOnly", true);
    $("#btnsalvar").dxButton("instance").option("disabled", true)
    isEdition = true;
}

function Expading(e) {
    //solo permite expandir una vez
    e.component.collapseAll(-1);
    EstudianteActual = e.key;
    
}

function MandarDataEstudiante(action, info) {
    
   
    if (action == "load") {
        if (EstudianteActual != null && EstudianteActual.Id > 0) {
            info.data.idEstudiante = EstudianteActual.Id;
        }
        

    }

}


