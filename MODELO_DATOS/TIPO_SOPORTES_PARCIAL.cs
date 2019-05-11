using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO_DATOS
{
    public partial class TIPO_SOPORTES
    {
		[NotMapped]
		public bool REQUERIDO { get; set; }   
    }
}
