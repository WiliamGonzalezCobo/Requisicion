using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_H_WEB.Models
{
    public class SOPORTE_RETIRO_ViewModel
    {

        public string NOMBRE_TIPO_SOPORTE { get; set; }

        public string RUTA { get; set; }

        public string NOMBRE_ARCHIVO { get; set; }

        public string TAMANO { get; set; }

        public Boolean APROBADO { get; set; }

        public IEnumerable<SOPORTE_RETIRO_ViewModel> SOPORTES;

    }
}