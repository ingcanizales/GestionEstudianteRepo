$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});

var selectedItem;


function LoadDatosById(Identificacion) {
    var form = $('#formTurno').dxForm('instance');
    var selectBoxDoc = $("#selectBoxTipoDocumento").dxSelectBox("instance");
    tipoDocumentoId = selectBoxDoc.option("value")/*.Id*/;
    var documentoBox = $("#cedulaId").dxTextBox("instance");
    documento = documentoBox.option("value");

    $.post("Turno?handler=LoadDatosById", { Identificacion: Identificacion, tipoDocumentoId: tipoDocumentoId},
        function success(data) {

            if (data == null) {
                $('#formTurno').dxForm('instance').resetValues();
                Swal.fire(
                    'Atención',
                    'No se encontró documento ' + Identificacion.toUpperCase() + ", ingrese el número de Documento si es primera vez que realiza un trámite en el organismo de tránsito, de lo contrario contacte con el administrador del aplicativo.",
                    'info'
                )

               
                form.getEditor("Nombre").option("readOnly", false);
                form.getEditor("Apellido").option("readOnly", false);
                

            }
            else if (data != null) {
                var TexCargo = form.getEditor("Cargo");
                var TexNombre = form.getEditor("Nombre");
                var TexApellido = form.getEditor("Apellido");
                TexCargo.option("value", data.Cargo.Nombre);
                /* form.getEditor("Cargo").option("readOnly", true);*/
                TexNombre.option("value", data.Nombre);
                form.getEditor("Nombre").option("readOnly", true);
                TexApellido.option("value", data.Apellido);
                form.getEditor("Apellido").option("readOnly", true);
            }
           
        });
                
    }

var Identificacionsincro;
var TipoIdentificacionsincro;

var PreTramite;
$("#nuevoProp").on("click", ShowPropPopUp);

var countDocuments = 0;

function CleanFormPopUp() {
    var form = $("#formProp").dxForm("instance");
    form.resetValues();
}

function ShowPropPopUp() {
    var popup = $("#addPropietarioPopUp").dxPopup("instance");
    popup.show();
    $("#buttonPropVent").dxButton("instance").option("disabled", false);

}

function LoadTramites(e) {
    document.getElementById('PropietarioPreTramites').hidden = true;
    var lista = $("#listTramites").dxTagBox('instance');

    var data = e.data;
    PreTramite = e.data;


    $.post("Ventanilla?handler=LoadTramites", { preTramite: data, __RequestVerificationToken: gettoken() })
        .done(
            function (data) {

                lista.option('dataSource', data);
                if (data.length > 0) {
                    $("#documentsButton").dxButton('option', 'visible', true);
                    lista.focus();
                    lista.open();

                } else {

                    $("#documentsButton").dxButton('option', 'visible', false);
                }
                lista.repaint();
            }
        ).fail(function (data) {
            Swal.fire(
                'Error',
                data,
                'error'
            );
        });
}

function GetPreTramiteSelected(e) {

}

function LoadPropietarios(e) {
    if (e.addedItems.length === 0 && e.removedItems.length === 0) {
        return;
    }
    var mostrarProp = false;
    var tramites = $("#listTramites").dxTagBox('instance').option('selectedItems');
    $.ajaxSetup({
        async: false
    });
    $.each(tramites, function (index, data) {
        if (!mostrarProp) {
            $.post("Ventanilla?handler=LoadPropietarios", { tramite: data, __RequestVerificationToken: gettoken() })
                .done(
                    function (data) {
                        if (data.CodigoErrorUsuario == "1") {
                            if (data.DescripcionError == "True") {
                                mostrarProp = true;
                            }
                        }
                        else {
                            Swal.fire({
                                title: "Atención",
                                type: data.Tipo,
                                text: data.DescripcionError
                            });
                        }
                    }
                ).fail(function (data) {
                    Swal.fire(
                        'Error',
                        data,
                        'error'
                    );
                });
        }
    });
    $.ajaxSetup({
        async: true
    });
    if (mostrarProp) {
        var grid = $("#gridPropPree").dxDataGrid('instance');
        document.getElementById('PropietarioPreTramites').hidden = false;
        grid.refresh();
    } else {
        document.getElementById('PropietarioPreTramites').hidden = true;
    }
}

function LoadDocuments() {

    if ($("#listTramites").dxTagBox('instance').option('selectedItems').length > 0) {

        var tramites = $("#listTramites").dxTagBox('instance').option('selectedItems');
        if ($("#listTramites").dxTagBox('instance').option('selectedItems').length > 0) {
            Swal.fire({
                title: 'Consultando documentos',
                html: 'Un momento por favor, no cierre la ventana del navegador',
                allowOutsideClick: false,
                allowEscapeKey: false,
                onBeforeOpen: () => {
                    Swal.showLoading();
                },
            });

            $.post("Ventanilla?handler=LoadDocumentos", { tramites: tramites, __RequestVerificationToken: gettoken() })
                .done(
                    function (data) {
                        swal.close();

                        if (typeof data != 'string') {
                            countDocuments = data.length;

                            if (countDocuments > 0) {

                                $("#documentos_popup").dxPopup('instance').show();
                                $("#listDocumentos").dxList('instance').option('dataSource', data);
                                $("#listDocumentos").dxList('instance').repaint();
                            }
                            else {
                                Swal.fire({
                                    title: 'Registrando la información',
                                    html: 'Un momento por favor, no cierre la ventana del navegador',
                                    allowOutsideClick: false,
                                    allowEscapeKey: false,
                                    onBeforeOpen: () => {
                                        Swal.showLoading();
                                    },
                                });

                                SetTramites();
                            }
                        }
                        else {
                            swal.close();
                            Swal.fire(
                                'Error',
                                data,
                                'error'
                            );
                        }
                    }
                ).fail(function (data) {
                    swal.close();
                    Swal.fire(
                        'Error',
                        data,
                        'error'
                    );
                });
        }

    } else {
        Swal.fire(
            'Error',
            'No hay trámites a asignar.',
            'error'
        );
    }
}

function SetTramites() {

    var preTramite = $("#gridPreTramites").dxDataGrid('instance').getSelectedRowsData();
    preTramite = preTramite[0];
    var tramites = $("#listTramites").dxTagBox('instance').option('selectedItems');
    var buttonTra = $("#tramiteButton").dxButton("instance");

    var documentos = $("#listDocumentos").dxList('instance').option("dataSource");
    var documentosCompletos = false;

    if (documentos !== null) {
        documentos.forEach(function (valor, indice, array) {

            if (documentos[indice].Obligatorio == true) {
                //Se comprueba que este seleccionado
                if ($("#listDocumentos").dxList('instance').option('selectedItems').some(x => x.Id == documentos[indice].Id)) {
                    documentosCompletos = true;
                } else {
                    documentosCompletos = false;
                    return false;
                }
            } else {
                documentosCompletos = true;
            }
        });
    } else {
        documentosCompletos = true;
    }

    if (documentosCompletos) {

        buttonTra.option("disabled", true);

        $.post("Ventanilla?handler=SetTramites", { preTramite: preTramite, tramites: tramites, __RequestVerificationToken: gettoken() })
            .done(
                function (data) {
                    swal.close();
                    if (data.CodigoErrorUsuario == "1") {

                        $("#gridPreTramites").dxDataGrid('instance').refresh();
                        $("#documentsButton").dxButton('option', 'visible', false);
                        $("#listTramites").dxTagBox('instance').repaint();
                        $("#documentos_popup").dxPopup('instance').hide();
                        $("#listTramites").dxTagBox('instance').reset();
                        $("#documentos_popup").dxPopup('instance').hide();

                        Swal.fire({
                            type: data.Tipo,
                            title: data.DescripcionError
                        }).then((result) => {
                            $.ajax({
                                url: "?handler=BorrarSesion",
                                type: "get",
                                success: function (data) {
                                    if (data == null) {
                                        location.reload();
                                    }
                                    else {
                                        document.location = "/Tramites/Liquidacion/Liquidacion?idPretramite=" + preTramite.Id;
                                    }
                                }
                            });
                        });
                    }
                    else {

                        $("#documentos_popup").dxPopup('instance').hide();

                        Swal.fire({
                            title: "Atención",
                            type: data.Tipo,
                            text: data.DescripcionError
                        });

                    }

                    buttonTra.option("disabled", false);

                }
            )
            .fail(function (data) {
                swal.close();
                Swal.fire(
                    'Error',
                    data,
                    'error'
                );
            });
    } else {
        swal.close();
        DevExpress.ui.notify("Tienen que estar los documentos obligatorios completos", "warning", 600);
    }
}

function AgregarPropietario() {

    formPropietario.tipoDocumento = tipoDocumentoForm;
    formPropietario.Identificacion = documentoForm;

    var gridPrope = $("#gridPropPree").dxDataGrid("instance");
    var popup = $("#addPropietarioPopUp").dxPopup("instance");
    form = formPropietario;
    $("#buttonPropVent").dxButton("instance").option("disabled", true);
    var preTramite = $("#gridPreTramites").dxDataGrid('instance').getSelectedRowKeys();
    var token = $('input[name="__RequestVerificationToken"]').val();
    form["idPreTramite"] = preTramite[0];

    form["__RequestVerificationToken"] = token;
    $.post("Ventanilla?handler=AddPropietario", form, function success(data) {
        Swal.fire({
            type: data.Tipo,
            title: data.DescripcionError
        });
        gridPrope.refresh();
        popup.hide();
    }
    );
}
var tipoDocumentoForm = null;
var documentoForm = null;

function AddPropietario(e) {

    var form = $('#formProp').dxForm('instance').option('formData');
    formPropietario = form;
    tipoDocumentoForm = form.tipoDocumento;
    documentoForm = form.Identificacion;
    if (e.validationGroup.validate().isValid) {
        if (!existePropietario()) {
            jQuery.ajax({
                url: "?handler=SincronizarPersona",
                type: "post",
                async: false,
                success: function (data) {
                    if (data) {
                        Identificacionsincro = form.Identificacion;
                        TipoIdentificacionsincro = form.tipoDocumento;
                        AutenticarSincronizar(form);
                    } else {
                        AgregarPropietario();
                    }
                }
            });
        } else {
            var popup = $("#addPropietarioPopUp").dxPopup("instance");
            popup.hide();
            Swal.fire({
                title: 'El propietario ya existe',
                html: 'Agregue otro diferente',
                type: 'warning',
                onClose: () => {
                    popup.show();
                }
            });
        }
    }
}

function existePropietario() {

    var gridPropietarios = $("#gridPropPree").dxDataGrid('instance');
    var listaPropietarios = gridPropietarios.getDataSource().items();
    var cedulaConsultar = $("#cedulaId").dxTextBox('option', 'value');
    var tipoDoc = $("#selectBoxTipoDocumento").dxSelectBox('option', 'selectedItem');

    var queryGridPropietarios = encuentraPropietario(cedulaConsultar, tipoDoc, listaPropietarios);
    return queryGridPropietarios != undefined ? true : false;


}

function encuentraPropietario(id, tipoDoc, dataItems) {

    var item = dataItems.find(item => item.Identificacion === id && item.TipoDocumento.Id == tipoDoc.Id);


    return item;
}



function Imprimir() {

    $.ajax({
        url: "/Tramites/Recibo/Documentos",
        type: "get",
        async: false,
        success: function (data) {
            window.location = '/Tramites/Recibo/Documentos?handler=Download&file='
                + data.handle + '&fileName=' + data.fileName;
        }
    });

}


function desabilitartramites(data) {




    var tramites = $("#listTramites").dxTagBox('instance').option('selectedItems');

    $.post("Ventanilla?handler=TramitesSeleccionados", { TramitesList: tramites })
        .done(
            function success(data) {

                if (data.length == 0) {

                } else {
                    Swal.fire(
                        'Error',
                        'No se pueden combinar los trámites ' + data.Item1.NombreTramite + ' - ' + data.Item2.NombreTramite,
                        'error'
                    );
                    $("#listTramites").dxTagBox('instance').reset();
                }

            }

        )
        .fail(function (data) {
            Swal.fire(
                'Error',
                data,
                'error'
            );
        });


}



function renovargridProp() {
    var grid = $("#gridPropPree").dxDataGrid('instance');
    if (grid == undefined) {
        grid.hide();
    }

}
function renovarTags() {
    var tag = $("#listTramites").dxTagBox('instance');
    if (tag != undefined) {
        tag.reset();
    }
}

function BorrarSesion() {
    $.ajax({
        url: "?handler=BorrarSesion",
        type: "get",
        success: function (data) {

        }
    });
}
var formPropietario = null;
function AutenticarSincronizar() {
    AutenticarFuncionario(null, ConsultarPersonaRUNT);
}


function ConsultarPersonaRUNT() {

    if (isEmpty(Identificacionsincro) !== true && isEmpty(TipoIdentificacionsincro) !== true) {

        Swal.fire({
            title: 'Consultando la persona: ' + TipoIdentificacionsincro.Valor1.toUpperCase() + " " + Identificacionsincro.toUpperCase(),
            html: 'Un momento por favor, no cierre la ventana del navegador',
            allowOutsideClick: false,
            allowEscapeKey: false,

            onBeforeOpen: () => {
                Swal.showLoading();
            },
        });

        $.ajax({
            url: "?handler=ConsultarPersonaRUNT",
            type: "post",
            data: { Identificacion: Identificacionsincro, TipoIdentificacion: TipoIdentificacionsincro, __RequestVerificationToken: gettoken() },
            async: false
        }).done(function (data) {
            Swal.fire({
                title: 'Se encontraró el registro en el RUNT',
                text: data,
                type: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancelar',
                confirmButtonText: 'Si, actualizar'
            }).then((result) => {
                if (result.value) {
                    Swal.fire({
                        title: 'Sincronizando la información entre el RUNT y el OT',
                        html: 'Un momento por favor, no cierre la ventana del navegador',
                        allowOutsideClick: false,
                        allowEscapeKey: false,
                        onBeforeOpen: () => {
                            Swal.showLoading();
                        },
                    });
                    ActualizarYInsertarInformacionPersona(Identificacionsincro, TipoIdentificacionsincro);
                    AgregarPropietario();
                }
            })

        }).fail(function (data) {
            Swal.fire(
                'Información',
                data.responseText,
                'info'
            )
        });
    }
}

function ActualizarYInsertarInformacionPersona(Identificacion, TipoIdentificacion) {
    jQuery.ajax({
        url: "?handler=ActualizarYInsertarInformacionPersona",
        type: "post",
        data: { Identificacion: Identificacion, TipoIdentificacion: TipoIdentificacion, __RequestVerificationToken: gettoken() },
    }).done(function (data) {
        if (data) {
            Swal.fire(
                'Sincronización exitosa',
                'Verifique los datos de la persona' + "\n" + data.NombreCompletoIdentificacion,
                'success'
            )
        } else {
            Swal.fire(
                'Sincronización fallida',
                'Fallo la sincronizacion del automotor en el RUNT',
                'info'
            )
        }
    }).fail(function (data) {

        Swal.fire(
            'Fallo al actualizar persona',
            'Consulte al administrador: ' + data.responseText,
            'warning'
        );

    });
}

function MandarIdPretramite(action, data) {


    if (action == "load" || action == "insert" || action == "delete") {
        data.data.idPretramite = $("#PreTramitePrecargadoId").val();
    }
}

function isEmpty(val) {
    return (val === undefined || val === null || val.length <= 0) ? true : false;
}

function CreatePreTramite(e) {

    var form = $('#formTurno').dxForm('instance').option('formData');
    /*var isValidTipoTramiteTipoServicio = ValidateTipoTramiteTipoServicio();*/
    //var sinPretramitesActivos = ValidarPretramitesActivoByPlacaMotor(form["placa"], form["NumeroMotor"]); validación de tramites multiples
    //var sinPretramitesActivos = true;
    //var TienePlacaoMotor = ObligatorioPlacaOMotor();
    //var VehiculoTieneCartera = ValidarVehiculoTieneCartera();
    //var EstadoVehiculoParqueadero = ValidarEstadoVehiculoParqueadero();
    //var FechaMinimaSalidaParqueaderoVehiculo = ValidarFechaMinimaSalidaVehiculoParqueadero();
    //vehiculoActivo = ValidarEstadoVehiculoActivo();
    //var VehiculoVinculado = ValidarVehiculoVinculadoEmpresa();
    //var NoTieneDeduasDerechoMunicipal = ValidarNoDeudaDerechosMunicipales();
    //var radioAccionValido = ValidarRadioAccionVehiculo();


    /*if (e.validationGroup.validate().isValid && sinPretramitesActivos && TienePlacaoMotor && isValidTipoTramiteTipoServicio 
     * && VehiculoTieneCartera && EstadoVehiculoParqueadero && FechaMinimaSalidaParqueadero**//*//*Vehiculo *//*&& verificarPagarComparendo*/ /*
     * && vehiculoActivo*/ /*&& VehiculoVinculado && radioAccionValido && NoTieneDeduasDerechoMunicipal) {*/

   /* if (selectedItem.TramitesParqueaderos) {*/
        var Documento = $('#formTurno').dxForm('instance').getEditor("Documento").option("value");
        jQuery.ajax({
            url: "?handler=ValidarPagarComparendoTramiteParqueadero",
            type: "get",
            async: false,
            data: { Documento: Documento }
        })
            .done(function (data) {
                if (data.Item1 && data.Item2 != null) {
                    swal.fire({
                        title: 'Atención',
                        html: '<b>¿Desea liquidar el comparendo con el parqueadero?</b>' +
                            '</br> Es obligatorio pagar el comparendo No. ' + data.Item2.Numero,
                        type: 'warning',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        cancelButtonText: 'No',
                        confirmButtonText: 'Si, liquidar'
                    }).then((result) => {
                        if (!result.value) {
                            validar = false;
                        }
                        else {
                            $('#formTurno').dxForm('instance').option({ 'formData.IdComparendo': data.Item2.Id, 'formData.LiquidarConComparendo': true });
                            AgregarTurno(form);
                        }
                    })
                }
                else if (data.Item1 && data.Item2 == null) {
                    Swal.fire(
                        'Atención',
                        'No se ha digitado el comparendo relacionado en la inmovilización, ' + data.Item3,
                        'warning'
                    );
                }
                else {
                    AgregarTurno(form);
                }
            })
            .fail(function (data) {
                Swal.fire(
                    'Error no controlado',
                    'Por favor, contacte al administrador del aplicativo.',
                    'warning'
                );
            })
    /*}*/
}
//        else {
//            if (tramitesAdicionales != null && tramitesAdicionales.length > 0) {
//                let tramiteDerechos = tramitesAdicionales.some(s => ciEquals(s.NombreEntidad, 'CarteraDerechoPretramite'));
//                if (tramiteDerechos) {
//                    var placa = $('#formTurno').dxForm('instance').getEditor("placa").option("value");
//                    $.ajax({
//                        url: "?handler=VerificarNoDeudaDerechosMunicipales",
//                        type: "get",
//                        async: false,
//                        data: { placa: placa }
//                    })
//                        .done(function (data) {
//                            if (data != null) {
//                                if (data === false) {
//                                    swal.fire({
//                                        title: 'Atención',
//                                        html: '<b>¿Desea agregar la liquidación de los impuestos municipales del vehículo?</b>',
//                                        type: 'warning',
//                                        showCancelButton: true,
//                                        confirmButtonColor: '#3085d6',
//                                        cancelButtonColor: '#d33',
//                                        cancelButtonText: 'No',
//                                        confirmButtonText: 'Si, liquidar'
//                                    }).then((result) => {
//                                        if (result.value) {
//                                            $('#formTurno').dxForm('instance').option({ 'formData.LiquidarImpuestos': true });
//                                            AgregarTurno(form);
//                                        }
//                                        else {
//                                            AgregarTurno(form);
//                                        }
//                                    })
//                                }
//                                else {
//                                    AgregarTurno(form);
//                                }
//                            }
//                            else {
//                                AgregarTurno(form);
//                            }
//                        })
//                        .fail(function (data) {
//                            Swal.fire(
//                                'Error no controlado',
//                                'Por favor, contacte al administrador del aplicativo.',
//                                'warning'
//                            );
//                        })
//                }
//                else {
//                    AgregarTurno(form);
//                }
//            }
//            else {
//                AgregarTurno(form);
//            }
//        }

//    }
//    else {
//        if (selectedItem.TramitesDerechos && !VehiculoTieneCartera) {
//            Swal.fire(
//                'Error',
//                'No existe ninguna cartera vigente para la placa ingresada',
//                'error'
//            );
//        } else if (selectedItem.TramitesParqueaderos && !EstadoVehiculoParqueadero) {
//            Swal.fire(
//                'Atención',
//                'El vehículo no se encuentra ingresado en el parqueadero',
//                'info'
//            );
//        }
//        else if (selectedItem.TramitesParqueaderos && !FechaMinimaSalidaParqueaderoVehiculo) {
//            Swal.fire(
//                'Atención',
//                'El vehículo no ha cumplido el mínimo número de días en el parqueadero establecido por la infracción cometida.',
//                'info'
//            );
//        }
//        else if (selectedItem.TramitesPublicoVehiculo) {
//            if (!vehiculoActivo) {
//                Swal.fire(
//                    'Atención',
//                    'El vehículo no se encuentra activo en el transito.',
//                    'info'
//                );
//            } else if (!VehiculoVinculado) {
//                Swal.fire(
//                    'Atención',
//                    'El vehículo no tiene una empresa de transporte público vinculada.',
//                    'info'
//                );
//            } else if (!NoTieneDeduasDerechoMunicipal) {
//                Swal.fire(
//                    'Atención',
//                    'Debe realizar el pago de los derechos municipales.',
//                    'info'
//                );
//            } else if (!radioAccionValido) {
//                Swal.fire(
//                    'Atención',
//                    'El radio de acción del vehículo no corresponde con el del transito.',
//                    'info'
//                );
//            }
//        }

//    }
//}

function EsconderGrid() {
    $("#divForm").hide();
    $("#divLiquidacion").show();
    Salvar();
    //$("#grid_pretramites_liquidacion").dxDataGrid("instance").refresh();
    //$("#formTurno").dxForm("instance").resetValues();
    /*$("#formTurno").dxForm("instance").option("formData", null);*/
   /* $("#grid_pretramites_liquidacion").dxDataGrid("instance").option("formData", null);*/
}

function actualizarPagina() {


    //if (itemsTabTotales !== null) {

    //    inicializarVariables();
    //    $("#listapretamitesliquidacion").show();
    //    $("#pretramiteactual").hide();
    //    $("#datosliquidacion").hide();
    //    $("#btnlistartramites").hide();


    //    /*var tabpanelLiquidacion = $("#PanelDatosLiquidacion").dxTabPanel("instance");
    //    tabpanelLiquidacion.repaint();*/

    //    var tabPanel = $("#PanelDatosLiquidacion").dxTabPanel("instance");
    //    tabPanel.option("items[1].disabled", true);
    //    tabPanel.option("items[2].disabled", true);
    //    tabPanel.option("selectedIndex", 0);

    //    Swal.close();
    //}
    //else {
    //    inicializarVariables();
    //    $("#listapretamitesliquidacion").show();
    //    var popupContribuyente = $("#popup_RegistroContribuyentes").dxPopup("instance");
    //    popupContribuyente.hide();

    //    Swal.close();
    //}
}

function MandarPretramite(action, info) {


    if (action == "load") {
        if (PreTramite != null && PreTramite.Id > 0) {
            info.data.idPretramite = PreTramite.Id;
        }


    }

}

async function Salvar() {
    try {

        var form = $("#formTurno").dxForm("instance");
        var valido = form.validate().isValid;

        if (valido) {

            var dataformulario = form.option("formData");
            await $.ajax({ method: "POST", url: "/Turno?handler=CrearPretramite", data: dataformulario });
            await Swal.fire(
                'Atención',
                'Pretramite Guardado Correctamente',
                'success'
            )

            /*$("#formTurno").dxForm("instance").resetValues();*/
            $("#TableMateria").dxDataGrid("instance").refresh();

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

function Obtener_Grid_Pretramites_Liquidacion(e) {
    Swal.fire({
        title: 'Cargando información....',
        html: 'Un momento por favor, no cierre la ventana del navegador',
        allowOutsideClick: false,
        allowEscapeKey: false,
        onBeforeOpen: () => {
            Swal.showLoading();
        },
    });
    valor = e;
    IdPretramite = e.data.Id;
    $("#divLiquidacion").hide();
    $("#pretramiteactual").show();

    //token = $('input[name="__RequestVerificationToken"]').val();

    //$.ajax({
    //    url: '/Tramites/Liquidacion/Liquidacion?handler=ContribuyenteRegistrado',
    //    method: "GET",
    //    data: {
    //        __RequestVerificationToken: gettoken(),
    //        IdPretramite: IdPretramite
    //    }
    //}).done(function (data) {
    //    if (data !== null) {
    //        if (data.isPersona) {
    //            ObtenerDatosPretramite(IdPretramite);
    //        }
    //        else {

    //            ObtenerDatosPretramite(IdPretramite);

    //    var popupContribuyente = $("#popup_RegistroContribuyentes").dxPopup("instance");
    //    popupContribuyente.show();
    //    $("#listapretamitesliquidacion").hide();
    //    tDocumento = e.data.TipoDocumentoPropietarioPrincipal;
    //    identificacionPersona = e.data.IdentificacionPropietarioPrincipal;

    //    $("#btnRegistrarContribuyente").show();
    //    $("#btnlistartramitesContribuyente").show();
    var form = $("#PretramiteActualLiquidacion").dxForm("instance");
        /*form.getEditor("TipoDocumento.Id").option("value", tDocumento.Id);*/
    form.getEditor("NombreTramite").option("value", e.data.NombreTramite);
        form.getEditor("Fecha").option("value", e.data.Fecha);
        form.getEditor("TipoDocumento").option("value", e.data.TipoDocumento.Nombre);
    form.getEditor("Documento").option("value", e.data.Documento);
        /*form.getEditor("SegundoApellido").option("value", data.segundoApellido);*/

    //    if (tDocumento.Valor1 === "NIT") {
    //        $('#FormContribuyentes').dxForm('instance').itemOption("RazonSocial", "visible", true);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("RepresentanteLegal", "visible", true);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("PrimerNombre", "visible", false);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("SegundoNombre", "visible", false);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("PrimerApellido", "visible", false);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("SegundoApellido", "visible", false);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("btnRepLegal", "visible", true);

    //    }
    //    else {

    //        $('#FormContribuyentes').dxForm('instance').itemOption("RazonSocial", "visible", false);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("RepresentanteLegal", "visible", false);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("PrimerNombre", "visible", true);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("SegundoNombre", "visible", true);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("PrimerApellido", "visible", true);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("SegundoApellido", "visible", true);
    //        $('#FormContribuyentes').dxForm('instance').itemOption("btnRepLegal", "visible", false);
    //    }
    //    swal.close();
    //}

    //    else {
    //        Swal.fire(
    //            'Error',
    //            'Error al comunicarse con el servidor.',
    //            'error'
    //        );
    //    }
    //}).fail(function () {
    //    retorno = false;
    //    Swal.fire(
    //        'Error',
    //        'Error al comunicarse con el servidor.',
    //        'error'
    //    );
    //});
}
    function labelingles(item) {
        if (item.validationRules !== undefined) {
            for (var i = 0; i < item.validationRules.length; i++) {
                if (item.validationRules[i].type === "required") {
                    item.validationRules[i].message = "El campo" + " \'" + item.label.text + "\' " + "es requerido";
                }
            }

        }
    }

