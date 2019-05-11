using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA.MODELO_LOGICA
{
     public class EMPLEADO_MODELO
    {
        public string COD_EMPLEADO { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public string NOMBRE { get; set; }
        public decimal? ESTADO { get; set; }
        public string USUARIO { get; set; }
        public decimal COD_CARGO{ get; set; }
        public string NOMBRE_CARGO { get; set; }
        public string SOCIEDAD { get; set; }
        public string CENTRO_COSTO { get; set; }
        public string AREA { get; set; }
		public string NOMBRE_JEFE { get; set; }
	}
}
