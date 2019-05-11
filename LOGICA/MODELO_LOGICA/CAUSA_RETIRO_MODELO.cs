using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA.MODELO_LOGICA
{
   public  class CAUSA_RETIRO_MODELO
    {
        public decimal COD_CAUSA_RETIRO { get; set; }
        public string NOMBRE { get; set; }
        public decimal? ESTADO { get; set; }
        public DateTime CREACION_FECHA { get; set; }
        public string CREACION_USUARIO { get; set; }
        public DateTime MODIFICACION_FECHA { get; set; }
        public string MODIFICACION_USUARIO { get; set; }
        //public virtual ICollection<CONTRATOS> CONTRATOS { get; set; }
    }
}
