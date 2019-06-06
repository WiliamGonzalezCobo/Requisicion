using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO_DATOS.MODELO_REQUISICION.LISTAS_API
{

  public  class PUESTO
    {

        public string DOCUMENTO_NUMERO { get; set; }
        public string NOMBRES_EMPLEADO { get; set; }
        public decimal? COD_CARGO { get; set; }
        public string NOMBRE_CARGO { get; set; }
        public decimal? COD_TIPO_CONTRATO { get; set; }
        public string NOMBRE_TIPO_CONTRATO { get; set; }
        public decimal? COD_EMPRESA_TEMPORAL { get; set; }
        public string NOMBRE_EMPRESA_TEMPORAL { get; set; }
        public Guid? COD_EMPLEADO_JEFE { get; set; }
        public string DOCUMENTO_NUMERO_JEFE { get; set; }//TIPO OJO
        public string NOMBRE_JEFE { get; set; }
        public decimal? COD_GERENCIA { get; set; }
        public string NOMBRE_GERENCIA { get; set; }
        public decimal? COD_CENTRO_COSTO { get; set; }
        public string COD_ALTERNO_CENTRO_COSTO { get; set; }
        public string NOMBRE_CENTRO_COSTO { get; set; }
        public decimal? COD_SOCIEDAD { get; set; }
        public string NOMBRE_SOCIEDAD { get; set; }
        public decimal? COD_EQUIPO_VENTA { get; set; }
        public string NOMBRE_EQUIPO_VENTA { get; set; }
        public decimal? COD_UBICACION_FISICA { get; set; }
        public string NOMBRE_UBICACION_FIFICA { get; set; }
        public decimal? COD_NIVEL_RIESGO { get; set; }
        public double? NIVEL_RIESGO { get; set; }
        public decimal? COD_CATEGORIA_EVALUACION_DESEMPENO { get; set; }
        public string NOMBRE_CATEGORIA_EVALUACION_DESEMPENO { get; set; }
        public decimal? COD_CIUDAD_DEPTO { get; set; }
        public string COD_DANE_CIUDAD { get; set; }
        public string NOMBRE_CIUDAD { get; set; }
        public string CARGO_CRITICO { get; set; }
        public decimal? COD_JORNADA_TRABAJO { get; set; }
        public string NOMBRE_JORNADA_TRABAJO { get; set; }
        public decimal? COD_HORARIO_TRABAJO { get; set; }
        public string NOMBRE_HORARIO_TRABAJO { get; set; }
        public decimal? COD_DIA_LABORAL { get; set; }
        public string NOMBRE_DIA_LABORAL { get; set; }
        public double? SALARIO_FIJO { get; set; }
        public double? PORCENTAJE_SALARIO_FIJO { get; set; }
        public double? SALARIO_VARIABLE { get; set; }
        public double? PORCENTAJE_SALARIO_VARIABLE { get; set; }
        public double? SOBREREMUNERACION { get; set; }
        public double? PORCENTAJE_SOBREREMUNERACION { get; set; }
        public double? EXTRA_FIJA { get; set; }
        public double? RECARGO_NOCTURNO_FIJO { get; set; }
        public double? MEDIOS_TRANSPORTE { get; set; }
        public double? SALARIO_TOTAL { get; set; }
        public double? BONO_ANUAL { get; set; }
        public int? MESES_GARANTIZADO { get; set; }
        public decimal? COD_TIPO_SALARIO { get; set; }
        public string NOMBRE_TIPO_SALARIO { get; set; }
        public decimal? PROMEDIO_MES { get; set; }
        public decimal? COD_MERCADO { get; set; }
        public string NOMBRE_MERCADO { get; set; }
        public int? NUMERO_SALARIO { get; set; }
        public decimal? FP { get; set; }
        public decimal? PROMEDIO_ANO { get; set; }
        public decimal? COD_CATEGORIA_SALARIALES { get; set; }
        public string NOMBRE_CATEGORIA_SALARIO { get; set; }
        public decimal? PUNTO_MEDIO_80_PORCIENTO { get; set; }
        public decimal? PUNTO_MEDIO_100_PORCIENTO { get; set; }
        public decimal? PUNTO_MEDIO_120_PORCIENTO { get; set; }
        public decimal? POSICIONAMIENTO { get; set; }
        public String diaS_LABORALES_DESDE { get; set; }
        public String diaS_LABORALES_HASTA { get; set; }
        public String horariO_DESDE { get; set; }
        public String horariO_HASTA { get; set; }
    }
}
