using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO_DATOS.MODELO_REQUISICION;

namespace LOGICA.REQUISICION_LOGICA
{
    public class REQUISICION
    {
        public REQUISICIONViewModel AgregarRequisicion(REQUISICIONViewModel requisitionModel)
        {
            try
            {
                return requisitionModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
