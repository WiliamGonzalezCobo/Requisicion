
$(".E_SALARIO_FIJO").focusout(function () {
    validar(this.value, this.name);
    debugger;
    var VALOR_SALARIO_FIJO = RetornoVariable("E_SALARIO_FIJO",false);
    var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", false);
    var calculo = resultadoCalculos(((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL));
    $(".P_SALARIO_FIJO").val(intlRound(calculo));
    });

    $(".S_VARIABLE").focusout(function () {
        validar(this.value, this.name);
        var VALOR_SALARIO_VARIABLE = RetornoVariable("S_VARIABLE", false);
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", false);
        var calculo = resultadoCalculos(((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL));
        $(".P_VARIABLE").val(intlRound(calculo));

    });

    $(".E_SOBREREMUNERACION").focusout(function () {
        validar(this.value, this.name);
        var VALOR_SOBREREMUNERACION = RetornoVariable("E_SOBREREMUNERACION", false);
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", false);
        var calculo = resultadoCalculos(((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL));
        $(".P_SOBREREMUNERACION").val(intlRound(calculo));
    });

    $(".CALCULO_TOTAL").focusout(function () {     
        validar(this.value, this.name);
        var VALOR_SALARIO_FIJO = RetornoVariable("E_SALARIO_FIJO", false); 
        var VALOR_SALARIO_VARIABLE = RetornoVariable("S_VARIABLE", false); 
        var VALOR_SOBREREMUNERACION = RetornoVariable("E_SOBREREMUNERACION", false);
        var VALOR_EXTRA_FIJA = RetornoVariable("E_EXTRA_FIJA", false);
        var VALOR_RECARGO_NOCTURNO = RetornoVariable("E_RECARGO_NOCTURNO", false); 
        var calculo = resultadoCalculos((VALOR_SALARIO_FIJO + VALOR_SALARIO_VARIABLE + VALOR_SOBREREMUNERACION + VALOR_EXTRA_FIJA + VALOR_RECARGO_NOCTURNO));
        $(".S_TOTAL").text(intlRound(calculo));
        $(".S_TOTAL").val(intlRound(calculo));
        // SALARIO FIJO
        var VALOR_SALARIO_FIJO = RetornoVariable("E_SALARIO_FIJO", false);
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", false);
        var calculo = resultadoCalculos(((VALOR_SALARIO_FIJO * 100) / SALARIO_TOTAL));
        $(".P_SALARIO_FIJO").val(intlRound(calculo));


        // SALARIO VARIABLE
        var VALOR_SALARIO_VARIABLE = RetornoVariable("S_VARIABLE", false);
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", false);
        var calculo = resultadoCalculos(((VALOR_SALARIO_VARIABLE * 100) / SALARIO_TOTAL));
        $(".P_VARIABLE").val(intlRound(calculo));

        // SOBREREMUNERACION
        var VALOR_SOBREREMUNERACION = RetornoVariable("E_SOBREREMUNERACION", false);
        var SALARIO_TOTAL = RetornoVariable("S_TOTAL_UNICO", false);
        var calculo = resultadoCalculos(((VALOR_SOBREREMUNERACION * 100) / SALARIO_TOTAL));
        $(".P_SOBREREMUNERACION").val(intlRound(calculo));

        if ($(".E_INGRESO_PROM_MENSUAL")[0] || $(".E_INGRESO_PROM_ANUAL")[0] || $(".E_FACTOR_PRESTACIONAL")[0]) {

            var FACTOR_PRESTACIONAL = RetornoVariable("E_FACTOR_PRESTACIONAL", false);
            var valor_total = RetornoVariable("S_TOTAL_UNICO", false);
            var calculo_mensual = resultadoCalculos((FACTOR_PRESTACIONAL * valor_total / 12));

            $(".E_INGRESO_PROM_MENSUAL").val(intlRound(calculo_mensual));

            var calculo_pro_anual = resultadoCalculos((FACTOR_PRESTACIONAL * valor_total));
            $(".E_INGRESO_PROM_ANUAL").val(intlRound(calculo_pro_anual));
            enmascarar();
        } else {
            var currencyMask = IMask(
                document.getElementById('SALARIO_TOTAL'),
                {
                    mask: '$num',
                    blocks: {
                        num: {
                            mask: Number,
                            thousandsSeparator: '.',
                            min: 0
                        }
                    }
                });
        }

       

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

function enmascarar() {
   
    var listaEnmascarar = [];
    listaEnmascarar.push(document.getElementById('SALARIO_TOTAL'));
    listaEnmascarar.push(document.getElementById('INGRESO_PROM_MENSUAL'));
    listaEnmascarar.push(document.getElementById('INGRESO_PROM_ANUAL'));

    for (var i = 0; i < listaEnmascarar.length; i++) {
        var currencyMask = IMask(
            listaEnmascarar[i],
            {
                mask: '$num',
                blocks: {
                    num: {
                        mask: Number,
                        thousandsSeparator: '.',
                        min: 0
                    }
                }
            });
    }
}
