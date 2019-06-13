
   $(".E_SALARIO_FIJO").focusout(function () {
        debugger;
        var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_SALARIO_FIJO").val(intlRound(calculo));
    });

    $(".S_VARIABLE").focusout(function () {
        var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_VARIABLE").val(intlRound(calculo));

    });

    $(".E_SOBREREMUNERACION").focusout(function () {
        var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_SOBREREMUNERACION").val(intlRound(calculo));
    });

    $(".CALCULO_TOTAL").focusout(function () {
        debugger;
        var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
        var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val().replace(",", "."));
        var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
        var VALOR_EXTRA_FIJA = parseFloat($(".E_EXTRA_FIJA").val().replace(",", "."));
        var VALOR_RECARGO_NOCTURNO = parseFloat($(".E_RECARGO_NOCTURNO").val().replace(",", "."));
        var calculo = (VALOR_SALARIO_FIJO + VALOR_SALARIO_VARIABLE + VALOR_SOBREREMUNERACION + VALOR_EXTRA_FIJA + VALOR_RECARGO_NOCTURNO).toString().replace(".", ",");;
        $(".S_TOTAL").text(intlRound(calculo));
        $(".S_TOTAL").val(intlRound(calculo));
        // SALARIO FIJO
        var VALOR_SALARIO_FIJO = parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_SALARIO_FIJO").val(intlRound(calculo));


        // SALARIO VARIABLE
        var VALOR_SALARIO_VARIABLE = parseFloat($(".S_VARIABLE").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_VARIABLE").val(intlRound(calculo));

        // SOBREREMUNERACION
        var VALOR_SOBREREMUNERACION = parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
        var SALARIO_TOTAL = parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = ((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL).toString().replace(".", ",");
        $(".P_SOBREREMUNERACION").val(intlRound(calculo));

        var FACTOR_PRESTACIONAL = $(".E_FACTOR_PRESTACIONAL").val().replace(",", ".");
        var valor_total = $(".S_TOTAL_UNICO").text().replace(",", ".");
        var calculo_mensual = (FACTOR_PRESTACIONAL * valor_total / 12).toString().replace(".", ",");
        debugger;
        $(".E_INGRESO_PROM_MENSUAL").text(intlRound(calculo_mensual));
        $(".E_INGRESO_PROM_MENSUAL").val(intlRound(calculo_mensual));

        var calculo_pro_anual = (FACTOR_PRESTACIONAL * valor_total).toString().replace(".", ",");
        $(".E_INGRESO_PROM_ANUAL").text(intlRound(calculo_pro_anual));
        $(".E_INGRESO_PROM_ANUAL").val(intlRound(calculo_pro_anual));
});


function intlRound(numero) {
    var opciones = {
        maximumFractionDigits: 2,
        useGrouping: false
    };
    numero = numero.replace(",", ".");
    usarComa = "es";
    return new Intl.NumberFormat(usarComa, opciones).format(numero);
}

