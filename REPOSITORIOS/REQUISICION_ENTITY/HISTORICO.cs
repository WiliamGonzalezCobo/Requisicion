//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace REPOSITORIOS.REQUISICION_ENTITY
{
    using System;
    using System.Collections.Generic;
    
    public partial class HISTORICO
    {
        public int COD_HISTORICO_REQUISICION { get; set; }
        public int COD_REQUISICION { get; set; }
        public Nullable<int> COD_ROL { get; set; }
        public Nullable<int> COD_NIVEL_RIESGO_ARL { get; set; }
        public Nullable<int> COD_CATEGORIA_ED { get; set; }
        public Nullable<bool> CARGO_CRITICO { get; set; }
        public Nullable<int> COD_JORNADA_LABORAL { get; set; }
        public string HORARIO_LABORAL_DESDE { get; set; }
        public string HORARIO_LABORAL_HASTA { get; set; }
        public Nullable<int> COD_DIA_LABORAL_DESDE { get; set; }
        public Nullable<int> COD_DIA_LABORAL_HASTA { get; set; }
        public Nullable<decimal> SALARIO_FIJO { get; set; }
        public Nullable<decimal> PORCENTAJE_SALARIO_FIJO { get; set; }
        public Nullable<decimal> SALARIO_VARIABLE { get; set; }
        public Nullable<decimal> PORCENTAJE_SALARIO_VARIABLE { get; set; }
        public Nullable<decimal> SOBREREMUNERACION { get; set; }
        public Nullable<decimal> PORCENTAJE_SOBREREMUNERACION { get; set; }
        public Nullable<decimal> EXTRA_FIJA { get; set; }
        public Nullable<decimal> RECARGO_NOCTURNO { get; set; }
        public string MEDIO_TRANSPORTE { get; set; }
        public Nullable<decimal> SALARIO_TOTAL { get; set; }
        public Nullable<decimal> BONO_ANUAL { get; set; }
        public Nullable<int> NUMERO_SALARIOS { get; set; }
        public Nullable<int> MESES_GARANTIZADOS { get; set; }
        public Nullable<int> COD_TIPO_SALARIO { get; set; }
        public string FACTOR_PRESTACIONAL { get; set; }
        public Nullable<decimal> INGRESO_PROM_MENSUAL { get; set; }
        public Nullable<decimal> INGRESO_PROM_ANUAL { get; set; }
        public string MERCADO { get; set; }
        public Nullable<int> COD_CATEGORIA { get; set; }
        public Nullable<decimal> PUNTO_MEDIO_80 { get; set; }
        public Nullable<decimal> PUNTO_MEDIO_100 { get; set; }
        public Nullable<decimal> PUNTO_MEDIO_120 { get; set; }
        public string POSICIONAMIENTO { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public System.DateTime FECHA_REGISTRO { get; set; }
        public int COD_ESTADO { get; set; }
    
        public virtual ESTADO ESTADO { get; set; }
        public virtual REQUISICION REQUISICION { get; set; }
    }
}
