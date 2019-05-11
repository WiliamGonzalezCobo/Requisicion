using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.HttpPostedFileWrapper;

namespace LOGICA.MODELO_LOGICA
{
   public class ARCHIVO_SOPORTE
    {
        public IEnumerable<System.Web.HttpPostedFileBase> ARCHIVOS { get; set; }
        public System.Web.HttpPostedFileBase ARCHIVO { get; set; }


        public string CONFIRMACION { get; set; }
        public Exception error { get; set; }

        /*METODO PARA GUARDAR EL ARCHIVO*/
        public void SUBIRARCHIVO(string RUTA, System.Web.HttpPostedFileBase _ARCHIVO)
        {
            try
            {//nombre archivo , ruta
                _ARCHIVO.SaveAs(RUTA );
                this.CONFIRMACION = "fichero guardado";
            }
            catch (Exception ex)
            {
                this.error = ex;
            }
        }
    }
}
