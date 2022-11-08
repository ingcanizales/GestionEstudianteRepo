$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName("__RequestVerificationToken")[0].value
    }
});

var form;
var pretramiteId;
var dataAcuerdo = [];
var dataComparendo = [];
var dataPretramite = [];
var dataCartera = [];

//escoge el editor visible.
function RadioValueEnableFields(estado, fechaInicio, fechaFin, materia, documento) {
    $("#formConsultaEstudiantes").dxForm("instance").itemOption("Estado", "visible", estado);
    $("#formConsultaEstudiantes").dxForm("instance").itemOption("FechaInicio", "visible", fechaInicio);
    $("#formConsultaEstudiantes").dxForm("instance").itemOption("FechaFin", "visible", fechaFin);
    $("#formConsultaEstudiantes").dxForm("instance").itemOption("Materia", "visible", materia);
    $("#formConsultaEstudiantes").dxForm("instance").itemOption("Documento", "visible", documento);
}


//se activa cuando se da Click en los Radiobuton.
function RadioValue(e) {
    if (e.value == "Fecha") {
        RadioValueEnableFields(false, true, true, false, false);
    }
    else if (e.value == "Estado") {
        RadioValueEnableFields(true, false, false, false, false);
    }
    else if (e.value == "Documento") {
        RadioValueEnableFields(false, false, false, false, true);
    }
    else {
        RadioValueEnableFields(false, false, false, true, false);
    }
}

function ConsultarPretramites() {
    form = $("#formConsultaEstudiantes").dxForm("instance");

    if (form.validate().isValid) {

        form = $("#formConsultaEstudiantes").dxForm("instance").option("formData");

        $("#TableDetalle").dxDataGrid("instance").refresh();

    }
}

//manda los parametros de la consulta
function MandarParametrosBusqueda(action, e) {
    if (form != undefined && form != null) {
        if (action == "load") {
            if (form.TipoBusqueda == "Fecha") {
                e.data.fechaInicio = $("#formConsultaEstudiantes").dxForm("instance").getEditor("FechaInicio").option("value");
                e.data.fechaFin = $("#formConsultaEstudiantes").dxForm("instance").getEditor("FechaFin").option("value");
            }
            else if (form.TipoBusqueda == "Materia") {
                e.data.materia = $("#formConsultaEstudiantes").dxForm("instance").getEditor("Materia").option("value").Id;
            }
            else if (form.TipoBusqueda == "Documento") {
                e.data.identificacion = $("#formConsultaEstudiantes").dxForm("instance").getEditor("Documento").option("value");
            }
            else {
                e.data.estado = $("#formConsultaEstudiantes").dxForm("instance").getEditor("Estado").option("value").Id;
            }


        }
    }
}

function SetMinFechaHasta(e) {
    var fechaDesde = e.value;
    $("#formConsultaEstudiantes").dxForm("instance").getEditor("FechaFin").option("min", fechaDesde);
}

function SetMaxFechaDesde(e) {
    var fechaHasta = e.value;
    $("#formConsultaEstudiantes").dxForm("instance").getEditor("FechaInicio").option("max", fechaHasta);
}



///RUNT

function AprobacionesCargadas() {

    if (rowKey === 0) {

    } else {
        $("#grid_pretramites_aprobaciontramite").dxDataGrid("instance").expandRow(rowKey);
    }
}

function ExpansionFila(e) {

    rowKey = e.key;
    e.component.collapseAll(-1);
    CargarDatosPretramite(rowKey);

}


$(document).ready(function () {
    $(window).resize(anchoContainerScreen);
});


function anchoContainerScreen() {
    var containerwidth = $(".siteContainer").width();
    $(".dx-multiview.dx-tabpanel").width(containerwidth - 23);
}



    var containerwidth = $(".siteContainer").width();
    $(".dx-multiview.dx-tabpanel").width(containerwidth - 23);



///Auditotía

var EventId;



//#region


var dataSource = [];













//#endregion