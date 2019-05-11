using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODELO_DATOS
{
    public partial class SOPORTES
    {
        [NotMapped]
        public bool REQUERIDO { get; set; }
    }
}
