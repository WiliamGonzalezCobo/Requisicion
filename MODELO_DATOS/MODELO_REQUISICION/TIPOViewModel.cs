using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODELO_DATOS.MODELO_REQUISICION
{
    public class TIPOViewModel
    {


        public int COD_TIPO_REQUISICION { get; set; }
        public string NOMBRE_REQUISICION { get; set; }
        public string DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
    }
}