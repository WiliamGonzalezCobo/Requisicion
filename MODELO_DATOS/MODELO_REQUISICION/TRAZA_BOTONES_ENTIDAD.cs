using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO_DATOS.MODELO_REQUISICION
{
   public class TRAZA_BOTONES_ENTIDAD
    {
        public int COD_HISTORICO_REQUISICION { get; set; }
        public int COD_REQUISICION { get; set; }
        public string COD_ROL { get; set; }
        public Nullable<int> COD_NIVEL_RIESGO_ARL { get; set; }
        public string NOMBRE_CATEGORIA_ED { get; set; }
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
        public string CATRGORIA { get; set; }
        public Nullable<decimal> PUNTO_MEDIO_80 { get; set; }
        public Nullable<decimal> PUNTO_MEDIO_100 { get; set; }
        public Nullable<decimal> PUNTO_MEDIO_120 { get; set; }
        public string POSICIONAMIENTO { get; set; }
        public string USUARIO_REGISTRO { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public int COD_ESTADO { get; set; }
        public Nullable<int> COD_HORARIO_LABORAL_DESDE { get; set; }
        public Nullable<int> COD_HORARIO_LABORAL_HASTA { get; set; }
        public Nullable<int> COD_MERCADO { get; set; }
        public string DIA_LABORAL_DESDE { get; set; }
        public string DIA_LABORAL_HASTA { get; set; }
        public string NOMBRE_JORNADA_LABORAL { get; set; }
        public string NOMBRE_ARL { get; set; }
        public string NOMBRE_ESTADOS_REQUISICION { get; set; }
        public string NOMBRE_TIPO_SALARIO { get; set; }
    }
}
