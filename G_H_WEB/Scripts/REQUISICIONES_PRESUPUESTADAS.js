$(document).ready(function () {
    debugger;
    if ("@User.IsInRole(SettingsManager.PerfilJefe)" == "True") {
        if (@Model.COD_REQUISICION!= 0) {
    $("#submitButtonCrear").text("Modificar Requisición");
}
        }
$("._metodoCrear").css("display", "none");
$(".__metodoAprobar").css("display", "none");
$(".__metodoModificar").css("display", "none");
$(".__metodoRechazar").css("display", "none");
$(".__metodoEnviar").css("display", "none");



var resultado = "@ViewBag.resultadoInsertExitosoOno";


if (resultado == "True") {
    debugger;
    var _metodo = "@paraModel.METODO";
    if (_metodo == "Crear") {
        CREAR_REQUISICION();
        $("._metodoDefecto").css("display", "none");

    }
    else if (_metodo == "Aprobar") {
        APROBAR_REQUISICION();
        $("._metodoDefecto").css("display", "none");
    }
    else if (_metodo == "Modificar") {
        MODIFICAR_REQUISICION();
        $("._metodoDefecto").css("display", "none");
    }

    else if (_metodo == "Rechazar") {
        RECHAZAR_REQUISICION();
        $("._metodoDefecto").css("display", "none");
    }
    else if (_metodo == "Enviar") {
        ENVIAR_REQUISICION();
        $("._metodoDefecto").css("display", "none");
    }

    $('#ModalCreacionNoJefe').modal("show");
}

       
    });


function CREAR_REQUISICION() {
    var CargoText = "@paraModel.NOMBRE_COD_CARGO";
    var CargoCod = "@paraModel.COD_REQUISICION_CREADA";
    $("#mensaje1").text(CargoText);
    $("#mensaje2").text(CargoCod);
    $("._metodoCrear").css("display", "block");
}


function APROBAR_REQUISICION() {
    var CargoCod = "@paraModel.COD_REQUISICION_CREADA";
    $(".__metodoAprobar").css("display", "block");
    $("#mensaje_aprobar").text(CargoCod);

}
function MODIFICAR_REQUISICION() {
    var CargoCod = "@paraModel.COD_REQUISICION_CREADA";
    $(".__metodoModificar").css("display", "block");
    $("#mensaje_modificar").text(CargoCod);
}

function RECHAZAR_REQUISICION() {
    var CargoCod = "@paraModel.COD_REQUISICION_CREADA";
    $(".__metodoRechazar").css("display", "block");
    $("#mensaje_rechazar").text(CargoCod);
}

function ENVIAR_REQUISICION() {
    var CargoCod = "@paraModel.COD_REQUISICION_CREADA";
    $(".__metodoEnviar").css("display", "block");
    $("#mensaje_Enviar").text(CargoCod);
}


$("#btnCancelarNoJefe").on("click", function () {
    $('#ModalCancelNoJefe').modal('show');
});

function SiCancelarJefe() {
    $('#ModalCancel').modal('hide');
    window.location.href = '@Url.Action("Index", "REQUISICION")';
};
function NoCancelarJefe() {
    $('#ModalCancel').modal('hide');
};

$(function () {
    $('.datepicker').datepicker();
});

$(".E_SALARIO_FIJO").focusout(function () {
    debugger;
    var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val());
    var SALARIO_TOTAL = parseFloat($(".S_TOTAL").val());
    var calculo = (VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL
    $(".P_SALARIO_FIJO").val(calculo);
});

$(".S_VARIABLE").focusout(function () {
    var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val());
    var SALARIO_TOTAL = parseFloat($(".S_TOTAL").val());
    var calculo = (VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL
    $(".P_VARIABLE").val(calculo);

});

$(".E_SOBREREMUNERACION").focusout(function () {
    var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val());
    var SALARIO_TOTAL = parseFloat($(".S_TOTAL").val());
    var calculo = (VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL
    $(".P_SOBREREMUNERACION").val(calculo);
});

$(".CALCULO_TOTAL").focusout(function () {
    debugger;
    var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val());
    var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val());
    var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val());
    var VALOR_EXTRA_FIJA = parseFloat($(".E_EXTRA_FIJA").val());
    var VALOR_RECARGO_NOCTURNO = parseFloat($(".E_RECARGO_NOCTURNO").val());
    var calculo = VALOR_SALARIO_FIJO + VALOR_SALARIO_VARIABLE + VALOR_SOBREREMUNERACION + VALOR_EXTRA_FIJA + VALOR_RECARGO_NOCTURNO;
    $(".S_TOTAL").val(calculo);
});