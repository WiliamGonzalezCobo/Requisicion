using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_H_WEB.Models.Requisicion
{
    public class ROLViewModel
    {


        public int COD_ROL { get; set; }
        public int NOMBRE { get; set; }
        public int USUARIO_CREACION { get; set; }
        public int FECHA_CREACION { get; set; }
        public int USUARIO_MODIFICACION { get; set; }
        public int FECHA_MODIFICACION { get; set; }
    }
}