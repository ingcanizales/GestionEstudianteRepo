$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});

var isEdition = true;
var EstudianteActual = null;
var avanzar = true;


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

//Valida la edad
function VerificarMayorEdad(e)
{
    var valido = true;
    var Edad = e.value;
    if (Edad <= 18) {
        valido = false;
    }
    return valido;
}

//esconde la grilla
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

//para el método editar.
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

//manda valores del TapPanel.
function Expading(e) {
    //solo permite expandir una vez
    e.component.collapseAll(-1);
    EstudianteActual = e.key;
    
}

//Manda los datos en OnBeforeSent
function MandarDataEstudiante(action, info) {
    
   
    if (action == "load") {
        if (EstudianteActual != null && EstudianteActual.Id > 0) {
            info.data.idEstudiante = EstudianteActual.Id;
        }
        

    }

}

async function EliminarEstudiante(e) {

    try {
        var idEstudiante = e.row.data.Id;

        var estudiante = await $.ajax({
            method: "POST",
            url: "/Estudiantes?handler=CancelarEstudiante",
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
            await Swal.fire(
                'Atención',
                'Estudiante Eliminado Correctamente',
                'success'
            )
            $("#TableEstudiantes").dxDataGrid("instance").refresh();
            
            return;
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

    

    function SeleccionFila(e) {
        let habilitarBtn = true;
        if (e.selectedRowKeys.length > 0) {
            habilitarBtn = false;
        }
        $("#BtnCancelar").dxButton("instance").option("disabled", habilitarBtn);
        $("#BtnMatricular").dxButton("instance").option("disabled", habilitarBtn);
        $("#BtnEgresar").dxButton("instance").option("disabled", habilitarBtn);
    }

    function CancelarEstudiantes() {

        var gridCancelar = $("#TableEstudiantes").dxDataGrid("instance");
        var idestudiantes = gridCancelar.getSelectedRowKeys();

        if (idestudiantes.length > 0) {
            Swal.fire({
                title: '¿Está seguro de cancelar los Estudiantes seleccionados?',
                text: "Confirma los cambios",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sí',
                cancelButtonText: 'No'
            }).then((result) => {
                if (result.value) {

                    Swal.fire({
                        title: 'Eliminando Estudiantes....',
                        html: 'Un momento por favor, no cierre la ventana del navegador',
                        allowOutsideClick: false,
                        allowEscapeKey: false,
                        onBeforeOpen: () => {
                            Swal.showLoading();
                        },
                    });
                    $.post("?handler=CancelarVariosEstudiante", { idEstudiantes: idestudiantes },
                        function success(data) {
                        if (data.length > 0) {
                            Swal.fire(
                                'Atención',
                                'Estudiantes Eliminados Correctamente',
                                'success'
                            )
                            gridCancelar.refresh();

                            return;
                        }
                        else {
                            Swal.fire(
                                'Atención',
                                'Estudiante no encontrado',
                                'info'
                            );

                            return;
                        }
                        gridCancelar.refresh();
                    });
           
                    };
                }
            )
        }
        else {
            Swal.fire('¡Atención!', 'Por favor, seleccione al menos un Estudiante a cancelar', 'info');
        }
}

function MatricularEstudiantes() {

    
   /* SalvarDocumentos();*/
    var gridMatricular = $("#TableEstudiantes").dxDataGrid("instance");
    var idestudiantes = gridMatricular.getSelectedRowKeys();



    if (idestudiantes.length > 0) {
        Swal.fire({
            title: '¿Documentos Completos, Desea Continuar con el proceso de Matricula?',
            text: "Confirma los cambios",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.value) {

                Swal.fire({
                    title: 'Matriculando Estudiantes....',
                    html: 'Un momento por favor, no cierre la ventana del navegador',
                    allowOutsideClick: false,
                    allowEscapeKey: false,
                    onBeforeOpen: () => {
                        Swal.showLoading();
                    },
                });
                $.post("?handler=MatricularVariosEstudiante", { idEstudiantes: idestudiantes },
                    function success(data) {
                        if (data.length > 0) {
                            Swal.fire(
                                'Atención',
                                'Estudiantes Matriculado Correctamente',
                                'success'
                            )
                            gridCancelar.refresh();

                            return;
                        }
                        else {
                            Swal.fire(
                                'Atención',
                                'Estudiante no encontrado',
                                'info'
                            );

                            return;
                        }
                        gridCancelar.refresh();
                    });

            };
        }
        )
    }
    else {
        Swal.fire('¡Atención!', 'Por favor, seleccione al menos un Estudiante a Matricular', 'info');
    }
}

function EgresarEstudiantes() {

    var gridCancelar = $("#TableEstudiantes").dxDataGrid("instance");
    var idestudiantes = gridCancelar.getSelectedRowKeys();

    if (idestudiantes.length > 0) {
        Swal.fire({
            title: '¿Está seguro de Egresar el/los Estudiantes seleccionados?',
            text: "Confirma los cambios",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.value) {

                Swal.fire({
                    title: 'Egresando Estudiantes....',
                    html: 'Un momento por favor, no cierre la ventana del navegador',
                    allowOutsideClick: false,
                    allowEscapeKey: false,
                    onBeforeOpen: () => {
                        Swal.showLoading();
                    },
                });
                $.post("?handler=EgresarVariosEstudiante", { idEstudiantes: idestudiantes },
                    function success(data) {
                        if (data.length > 0) {
                            Swal.fire(
                                'Atención',
                                'Estudiantes Egresado Correctamente',
                                'success'
                            )
                            gridCancelar.refresh();

                            return;
                        }
                        else {
                            Swal.fire(
                                'Atención',
                                'Estudiante no encontrado',
                                'info'
                            );

                            return;
                        }
                        gridCancelar.refresh();
                    });

            };
        }
        )
    }
    else {
        Swal.fire('¡Atención!', 'Por favor, seleccione al menos un Estudiante a Egresar', 'info');
    }
}


   

async function SalvarDocumentos() {
   
    var form = $("#FormDocumentos").dxForm("instance").option("formData");
    if (form.Carpeta == true &&
    form.Foto == true &&
    form.PazySalvo == true &&
    form.TargetaIdentidad == true &&
    form.FotocopiaCedula == true &&
    form.CertificadoEstudio == true &&
    form.RegistroCivil ==true)
    {
        $("#documentos_popup").dxPopup('instance').hide();
        avanzar = true;

        $("#FormDocumentos").dxForm("instance").resetValues();
        Swal.fire(

            'Atención',
            'Documentos Completos',
            'success'
        )
        
    }

    else {
        avanzar = false;
        $("#documentos_popup").dxPopup('instance').hide();
        $("#FormDocumentos").dxForm("instance").resetValues();
        Swal.fire(
            'Atención',
            'Faltan Documentos',
            'info'
        )

        return;
    }
    MatricularEstudiantes();

    
}

function PermitirMatricular() {
    $("#documentos_popup").dxPopup('instance').show();
    
}
