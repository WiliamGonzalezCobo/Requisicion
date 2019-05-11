using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA.MODELO_LOGICA
{
    public  class AUTENTICAR_USUARIO_MODELO
    {
        public string Login { get; set; }
        public int IdUser { get; set; }
        public int IdProfile { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime? DateSession { get; set; }
    }
}
