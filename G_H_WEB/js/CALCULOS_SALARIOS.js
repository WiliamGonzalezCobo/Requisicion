
$(".E_SALARIO_FIJO").focusout(function () {
    validar(this.value, this.name);
    debugger;
    var VALOR_SALARIO_FIJO = RetornoVariable("E_SALARIO_FIJO",false);
    var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", true);
    var calculo = resultadoCalculos(((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL));
    $(".P_SALARIO_FIJO").val(intlRound(calculo));
    });

    $(".S_VARIABLE").focusout(function () {
        validar(this.value, this.name);
        var VALOR_SALARIO_VARIABLE = RetornoVariable("S_VARIABLE", false);//parseFloat($(".S_VARIABLE").val().replace(",", "."));
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", true);// parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = resultadoCalculos(((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL));
        $(".P_VARIABLE").val(intlRound(calculo));

    });

    $(".E_SOBREREMUNERACION").focusout(function () {
        validar(this.value, this.name);
        var VALOR_SOBREREMUNERACION = RetornoVariable("E_SOBREREMUNERACION", false);//parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", true);// parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = resultadoCalculos(((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL));
        $(".P_SOBREREMUNERACION").val(intlRound(calculo));
    });

    $(".CALCULO_TOTAL").focusout(function () {     
        validar(this.value, this.name);
        var VALOR_SALARIO_FIJO = RetornoVariable("E_SALARIO_FIJO", false); //parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
        var VALOR_SALARIO_VARIABLE = RetornoVariable("S_VARIABLE", false); //parseFloat($(".S_VARIABLE").val().replace(",", "."));
        var VALOR_SOBREREMUNERACION = RetornoVariable("E_SOBREREMUNERACION", false);//parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
        var VALOR_EXTRA_FIJA = RetornoVariable("E_EXTRA_FIJA", false);//parseFloat($(".E_EXTRA_FIJA").val().replace(",", "."));
        var VALOR_RECARGO_NOCTURNO = RetornoVariable("E_RECARGO_NOCTURNO", false); //parseFloat($(".E_RECARGO_NOCTURNO").val().replace(",", "."));
        var calculo = resultadoCalculos((VALOR_SALARIO_FIJO + VALOR_SALARIO_VARIABLE + VALOR_SOBREREMUNERACION + VALOR_EXTRA_FIJA + VALOR_RECARGO_NOCTURNO)); //(VALOR_SALARIO_FIJO + VALOR_SALARIO_VARIABLE + VALOR_SOBREREMUNERACION + VALOR_EXTRA_FIJA + VALOR_RECARGO_NOCTURNO).toString().replace(".", ",");;
        $(".S_TOTAL").text(intlRound(calculo));
        $(".S_TOTAL").val(intlRound(calculo));
        // SALARIO FIJO
        var VALOR_SALARIO_FIJO = RetornoVariable("E_SALARIO_FIJO", false);//parseFloat($(".E_SALARIO_FIJO").val().replace(",", "."));
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", true);//parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = resultadoCalculos(((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL));
        $(".P_SALARIO_FIJO").val(intlRound(calculo));


        // SALARIO VARIABLE
        var VALOR_SALARIO_VARIABLE = RetornoVariable("S_VARIABLE", false); //parseFloat($(".S_VARIABLE").val().replace(",", "."));
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", true);//parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = resultadoCalculos(((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL));
        $(".P_VARIABLE").val(intlRound(calculo));

        // SOBREREMUNERACION
        var VALOR_SOBREREMUNERACION = RetornoVariable("E_SOBREREMUNERACION", false); //parseFloat($(".E_SOBREREMUNERACION").val().replace(",", "."));
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", true);//parseFloat($(".S_TOTAL_UNICO").text().replace(",", "."));
        var calculo = resultadoCalculos(((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL));
        $(".P_SOBREREMUNERACION").val(intlRound(calculo));

        var FACTOR_PRESTACIONAL = RetornoVariable("E_FACTOR_PRESTACIONAL", false);//$(".E_FACTOR_PRESTACIONAL").val().replace(",", ".");
        var valor_total = RetornoVariable("S_TOTAL_UNICO", true);//$(".S_TOTAL_UNICO").text().replace(",", ".");
        var calculo_mensual = resultadoCalculos((FACTOR_PRESTACIONAL * valor_total / 12));
        $(".E_INGRESO_PROM_MENSUAL").text(intlRound(calculo_mensual));
        $(".E_INGRESO_PROM_MENSUAL").val(intlRound(calculo_mensual));

        var calculo_pro_anual = resultadoCalculos((FACTOR_PRESTACIONAL * valor_total));
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

function RetornoVariable(entrada, label) {
    var variable = 0;
    if (label) {
        variable = $("." + entrada).text();
    } else {
        variable = $("." + entrada).val();
       
    }
    var VariableRetorno = variable.replace("$", "").replace(/\./g, '').replace(",", ".");
    return parseFloat(VariableRetorno);
}

function resultadoCalculos(resultado) {
    return resultado.toString().replace(".", ",");
}
