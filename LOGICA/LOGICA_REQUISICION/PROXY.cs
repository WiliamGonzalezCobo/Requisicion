using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA.LOGICA_REQUISICION
{
   public class PROXY{
      string  urlApi = ConfigurationManager.AppSettings["Urlapi"];

        public object DatosApi() {
            return null;
        }

    }
}
