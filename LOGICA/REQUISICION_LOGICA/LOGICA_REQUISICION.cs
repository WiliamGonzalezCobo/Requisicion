using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION.ACCESS;
using REPOSITORIOS.REQUISICION_ENTITY;

namespace LOGICA.REQUISICION_LOGICA
{
    public class LOGICA_REQUISICION
    {


        public List<TIPO_NECESIDADViewModel> CONSULTAR_TIPOS_NECESIDAD(){
            return  new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS();
        }

        public List<ESTADOViewModel> CONSULTAR_ESTADOS() {
            return new ACCES_REQUISICION().CONSULTAR_ESTADOS_ACCESS();
        }
    }
}
