//$(".E_SALARIO_FIJO").focusout(function () {
//    debugger;
//    var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
//    var SALARIO_TOTAL = parseFloat($(".S_TOTAL").val().replace(",", "."));
//    var calculo = ((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL).toString().replace(".", ",");
//    $(".P_SALARIO_FIJO").val(calculo);
//});

//$(".S_VARIABLE").focusout(function () {
//    var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val().replace(",", "."));
//    var SALARIO_TOTAL = parseFloat($(".S_TOTAL").val().replace(",", "."));
//    var calculo = ((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL).toString().replace(".", ",");
//    $(".P_VARIABLE").val(calculo);

//});

//$(".E_SOBREREMUNERACION").focusout(function () {
//    var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
//    var SALARIO_TOTAL = parseFloat($(".S_TOTAL").val().replace(",", "."));
//    var calculo = ((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL).toString().replace(".", ",");
//    $(".P_SOBREREMUNERACION").val(calculo);
//});

//$(".CALCULO_TOTAL").focusout(function () {
//    debugger;
//    var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
//    var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val().replace(",", "."));
//    var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
//    var VALOR_EXTRA_FIJA = parseFloat($(".E_EXTRA_FIJA").val().replace(",", "."));
//    var VALOR_RECARGO_NOCTURNO = parseFloat($(".E_RECARGO_NOCTURNO").val().replace(",", "."));
//    var calculo = (VALOR_SALARIO_FIJO + VALOR_SALARIO_VARIABLE + VALOR_SOBREREMUNERACION + VALOR_EXTRA_FIJA + VALOR_RECARGO_NOCTURNO).toString().replace(".", ",");;
//    $(".S_TOTAL").val(calculo);

//    // SALARIO FIJO
//    var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
//    var SALARIO_TOTAL = parseFloat($(".S_TOTAL").val().replace(",", "."));
//    var calculo = ((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL).toString().replace(".", ",");
//    $(".P_SALARIO_FIJO").val(calculo);

//    // SALARIO VARIABLE
//    var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val().replace(",", "."));
//    var SALARIO_TOTAL = parseFloat($(".S_TOTAL").val().replace(",", "."));
//    var calculo = ((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL).toString().replace(".", ",");
//    $(".P_VARIABLE").val(calculo);

//    // SOBREREMUNERACION
//    var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
//    var SALARIO_TOTAL = parseFloat($(".S_TOTAL").val().replace(",", "."));
//    var calculo = ((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL).toString().replace(".", ",");
//    $(".P_SOBREREMUNERACION").val(calculo);

//    var FACTOR_PRESTACIONAL = $(".E_FACTOR_PRESTACIONAL").val().replace(",", ".");
//    var valor_total = $(".S_TOTAL").val().replace(",", ".");
//    var calculo_mensual = (FACTOR_PRESTACIONAL * valor_total / 12).toString().replace(".", ",");
//    debugger;
//    $(".E_INGRESO_PROM_MENSUAL").val(calculo_mensual);

//    var calculo_pro_anual = (FACTOR_PRESTACIONAL * valor_total).toString().replace(".", ",");
//    $(".E_INGRESO_PROM_ANUAL").val(calculo_pro_anual);
//});


$(document).ready(function () {
    $(".E_SALARIO_FIJO").focusout(function () {
        debugger;
        var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_SALARIO_FIJO").val(calculo);
    });

    $(".S_VARIABLE").focusout(function () {
        var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_VARIABLE").val(calculo);

    });

    $(".E_SOBREREMUNERACION").focusout(function () {
        var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_SOBREREMUNERACION").val(calculo);
    });

    $(".CALCULO_TOTAL").focusout(function () {
        debugger;
        var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
        var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val().replace(",", "."));
        var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
        var VALOR_EXTRA_FIJA = parseFloat($(".E_EXTRA_FIJA").val().replace(",", "."));
        var VALOR_RECARGO_NOCTURNO = parseFloat($(".E_RECARGO_NOCTURNO").val().replace(",", "."));
        var calculo = (VALOR_SALARIO_FIJO + VALOR_SALARIO_VARIABLE + VALOR_SOBREREMUNERACION + VALOR_EXTRA_FIJA + VALOR_RECARGO_NOCTURNO).toString().replace(".", ",");;
        $(".S_TOTAL").text(calculo);

        // SALARIO FIJO
        var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_SALARIO_FIJO").val(calculo);

        // SALARIO VARIABLE
        var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_VARIABLE").val(calculo);

        // SOBREREMUNERACION
        var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_SOBREREMUNERACION").val(calculo);

        var FACTOR_PRESTACIONAL = $(".E_FACTOR_PRESTACIONAL").val().replace(",", ".");
        var valor_total = $(".S_TOTAL_UNICO").text().replace(",", ".");
        var calculo_mensual = (FACTOR_PRESTACIONAL * valor_total / 12).toString().replace(".", ",");
        debugger;
        $(".E_INGRESO_PROM_MENSUAL").text(parseFloat(calculo_mensual).toFixed(2));

        var calculo_pro_anual = (FACTOR_PRESTACIONAL * valor_total).toString().replace(".", ",");
        $(".E_INGRESO_PROM_ANUAL").text(parseFloat(calculo_pro_anual).toFixed(2));
    });

});