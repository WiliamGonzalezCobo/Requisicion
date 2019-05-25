using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO_DATOS.MODELO_REQUISICION.LISTAS_API
{
   public class EMPLEADOS{

        public Guid COD_EMPLEADO { get; set; }
        public decimal? COD_TIPO_DOCUMENTO { get; set; }
        public string DOCUMENTO_NUMERO { get; set; }
        public decimal? DOCUMENTO_COD_CIUDAD_DEPTO { get; set; }
        public string NOMBRES { get; set; }
        public string SEXO { get; set; }
        public string RH { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string NACIMIENTO_FECHA { get; set; }
        public decimal? NACIMIENTO_COD_CIUDAD { get; set; }
        public decimal? COD_EXTERNO { get; set; }
        public decimal? ESTADO { get; set; }
        public DateTime CREACION_FECHA { get; set; }
        public string CREACION_USUARIO { get; set; }
        public DateTime MODIFICACION_FECHA { get; set; }
        public string MODIFICACION_USUARIO { get; set; }
    }
}
