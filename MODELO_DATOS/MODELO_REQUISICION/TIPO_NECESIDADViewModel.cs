using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODELO_DATOS.MODELO_REQUISICION
{
    public class TIPO_NECESIDADViewModel
    {
        public int MyProperty { get; set; }
         public int COD_TIPO_NECESIDAD { get; set; }
       public string NOMBRE_NECESIDAD { get; set; }
       public int ESTADO { get; set; }
       public int USUARIO_CREACION { get; set; }
       public int FECHA_CREACION { get; set; }
       public int USUARIO_MODIFICACION { get; set; }
       public int FECHA_MODIFICACION { get; set; }

    }
}