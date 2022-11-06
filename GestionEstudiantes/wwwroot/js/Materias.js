$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});

var isEdition = false;
//Contiene la funcion AddRow que agrega una fila vacia y la coloca en estado de adición.
function AddModeGrid() {
    isEdition = false;
    $("#TableMateria").dxDataGrid("instance").addRow();
    $("#TableMateria").dxDataGrid("instance").columnOption("Code", "allowEditing", true);
    $("#TableMateria").dxDataGrid("instance").columnOption("Estado.Id", "allowEditing", false);
}

async function CodigoUnico(e) {
    var valido = true;

    if (!isEdition) {
        var codigo = e.value;

        if (codigo != null && codigo != "") {
            valido = await $.ajax({
                method: "GET",
                url: "/Materias?handler=VerificarCodigoUnico",
                data: { materiaCode: codigo }
            });
        }
    }

    return valido;
}

//viene de OnEditingStart se ejecuta cuando se empieza la edición, antes que una fila cambie a modo de edición.
function SetEditmode() {
    isEdition = true;
    $("#TableMateria").dxDataGrid("instance").columnOption("Code", "allowEditing", false);
    $("#TableMateria").dxDataGrid("instance").columnOption("Estado.Id", "allowEditing", true);
}

//Es para Mandar un dato por defecto a una columna cuando se esta agragando y asi no tener que irlo a buscar.
function EditorPreparado(e) {
    if (e.dataField === "Estado.Id" && e.parentType === "dataRow") {
        if (!isEdition) {
            e.editorOptions.value = 1;
            e.row.data.Estado = { Id: 1 };
        }

    }
}