using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace G_H_WEB.Models
{
    public class SOLICITUD_CONSULTA_ViewModel
    {
        [Display(Name = "BuscarSolicitud")]
        public string BUSCARSOLICITUD { get; set; }

        public IEnumerable<SOLICITUD_ViewModel> SOLICITUDES;
        public string VISTA { get; set; }
        public string CONTROLER { get; set; }
        public ERROR_ViewModel ERROR;

    }

    public class SOLICITUD_ViewModel
    {
		public decimal COD_RETIRO { get; set; }
        public string NOMBRE { get; set; }

        public string USUARIO { get; set; }

        public string CAUSAL { get; set; }

        public string FECHA_SOLICITUD { get; set; }

        public string ESTADO { get; set; }

    }
   
}