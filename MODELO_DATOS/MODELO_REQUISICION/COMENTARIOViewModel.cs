using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_H_WEB.Models.Requisicion
{
    public class COMENTARIOViewModel
    {
       

      public int COD_COMENTARIO { get; set; }
      public int COD_REQUISICION { get; set; }
      public int COD_ESTADO_REQUISICION { get; set; }
      public string COMENTARIO_AUTORIZACION { get; set; }
      public string OBSERVACIONES { get; set; }
      public int COD_ROL { get; set; }
      public int COD_USUARIO { get; set; }
      public string USARIO_CREACION { get; set; }
      public DateTime FECHA_CREACION { get; set; }
    }
}