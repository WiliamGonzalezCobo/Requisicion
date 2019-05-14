using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODELO_DATOS.MODELO_REQUISICION
{
    public class ESTADOViewModel
    {
      

      public int COD_ESTADO_REQUISICION { get; set; }
      public string NOMBRE_ESTADO { get; set; }
      public string USUARIO_CREACION { get; set; }
      public DateTime FECHA_CREACION { get; set; }
      public string USARIO_MODIFICACION { get; set; }
      public DateTime FECHA_MODIFICACION { get; set; }
    }
}