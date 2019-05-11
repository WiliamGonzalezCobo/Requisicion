using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_H_WEB.Models.Requisicion
{
    public class HISTORICOViewModel
    {
        public int COD_HISTORICO_REQUISICION { get; set; }
        public int COD_REQUISICION { get; set; }
        public int COD_ROL { get; set; }
        public int COD_USUARIO { get; set; }
        public int COD_NIVEL_RIESGO_ARL { get; set; }
        public int COD_CATEGORIA_ED { get; set; }
        public bool CARGO_CRITICO { get; set; }
        public int COD_JORNADA_LABORAL { get; set; }
        public string HORARIO_LABORAL_DESDE { get; set; }
        public string HORARIO_LABORAL_HASTA { get; set; }
        public int COD_DIA_LABORAL_DESDE { get; set; }
        public int COD_DIA_LABORAL_HASTA { get; set; }
        public decimal SALARIO_FIJO { get; set; }
        public decimal PORCENTAJE_SALARIO_FIJO { get; set; }
        public decimal SALARIO_VARIABLE { get; set; }
        public decimal PORCENTAJE_SALARIO_VARIABLE { get; set; }
        public decimal SOBREREMUNERACION { get; set; }
        public decimal PORCENTAJE_SOBREREMUNERACION { get; set; }
        public decimal EXTRA_FIJA { get; set; }
        public decimal RECARGO_NOCTURNO { get; set; }
        public decimal MEDIO_TRANSPORTE { get; set; }
        public decimal SALARIO_TOTAL { get; set; }
        public decimal BONO_ANUAL { get; set; }
        public int NUMERO_SALARIOS { get; set; }
        public int MESES_GARANTIZADOS { get; set; }
        public int COD_TIPO_SALARIO { get; set; }
        public decimal FACTOR_PRESTACIONAL { get; set; }
        public decimal INGRESO_PROM_MENSUAL { get; set; }
        public decimal INGRESO_PROM_ANUAL { get; set; }
        public string MERCADO { get; set; }
        public int COD_CATEGORIA { get; set; }
        public decimal PUNTO_MEDIO_80 { get; set; }
        public decimal PUNTO_MEDIO_100 { get; set; }
        public decimal PUNTO_MEDIO_120 { get; set; }
        public decimal POSICIONAMIENTO { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
    }
}