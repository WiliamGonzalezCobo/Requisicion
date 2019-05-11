using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_H_WEB.Models.Requisicion
{
    public class MENU_ROLViewModel
    {

        public int COD_MENU_ROL { get; set; }
      public int COD_ROL { get; set; }
      public int COD_OPCIONES_MENU { get; set; }
      public Byte ESTADO { get; set; }
      public string USUARIO_CREACION { get; set; }
      public DateTime FECHA_CREACION { get; set; }
      public string USUARIO_MODIFICACION { get; set; }
      public DateTime FECHA_MODIFICACION { get; set; }
    }
}