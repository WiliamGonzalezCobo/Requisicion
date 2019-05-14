using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.LICENCIA_INCAPACIDAD.ACCESS;
using REPOSITORIOS.REQUISICION_ENTITY;

namespace LOGICA.LICENCIA_INCAPACIDAD_LOGICA
{
    public class LOGICA_LICENCIA_INCAPACIDAD
    {
        public string INSERTAR_LICENCIA_INCAPACIDAD(REQUISICIONViewModel model)
        {
            return new ACCESS_LICENCIA_INCAPACIDAD().INSERTAR_LICENCIA_INCAPACIDAD(model);            
        }
    }
}
