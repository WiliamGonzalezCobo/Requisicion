using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_H_WEB.Models.Requisicion
{
    class DIAS_LABORALESViewModel
    {

        public int COD_DIAS_LABORALES { get; set; }
        public string DIA_SEMANA { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }

    }
}