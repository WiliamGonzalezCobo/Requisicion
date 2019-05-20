using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO_DATOS.MODELO_REQUISICION
{
  public class FILTROREQUISICION
    {
        public string idUsuario  { get; set; }
        public Nullable<int> cod_estado_requisicion { get; set; }
        public string estado_requisicion { get; set; }
        public string porUsuario { get; set; }
    }
}
