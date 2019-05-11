using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_H_WEB.Models.Requisicion
{
    public class OPCIONES_MENUViewModel
    {
       
        public int COD_OPCIONES_MENU { get; set; }
        public string NOMBRE_OPCION { get; set; }
      public string DESCRIPCION { get; set; }
      public byte ESTADO { get; set; }
      public int COD_ROL { get; set; }
      public string USUARIO_CREACION { get; set; }
      public DateTime FECHA_CREACION { get; set; }
      public string USUARIO_MODIFICACION { get; set; }
      public DateTime FECHA_MODIFICACION { get; set; }
    }
}