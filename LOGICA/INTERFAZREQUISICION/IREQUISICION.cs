using MODELO_DATOS.MODELO_REQUISICION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA.INTERFAZREQUISICION
{
    public interface IREQUISICION
    {
        void Crear(REQUISICIONViewModel model);
        List<REQUISICIONViewModel> ConsultarTodos();
    }
}
