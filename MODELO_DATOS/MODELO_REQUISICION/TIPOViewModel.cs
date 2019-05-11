using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODELO_DATOS.MODELO_REQUISICION
{
    public class TIPOViewModel
    {


        public int COD_TIPO_REQUISICION { get; set; }
        public int NOMBRE_REQUISICION { get; set; }
        public int DESCRIPCION { get; set; }
        public int ESTADO { get; set; }
        public int USUARIO_CREACION { get; set; }
        public int FECHA_CREACION { get; set; }
        public int USUARIO_MODIFICACION { get; set; }
        public int FECHA_MODIFICACION { get; set; }
    }
}