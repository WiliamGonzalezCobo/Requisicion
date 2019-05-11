using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA.MODELO_LOGICA
{
    public class CORREO_CONFIGURACION_MODELO
    {
        public string DESTINO { get; set; }
        public string ASUNTO { get; set; }
        public string MESNSAJE { get; set; }
        public string SERVIDOR { get; set; }
        public string CUENTA_CORREO { get; set; }
        public byte[] SALT { get; set; }
        public byte[] TEXTO_SALTO { get; set; }
        public string CONTRASENA { get; set; }
        public decimal? PUERTO { get; set; }
        public bool ES_HTML { get; set; }
        public bool USA_SSL { get; set; }
        public decimal ESTADO { get; set; }
        public string SOCIEDAD { get; set; }
        public string CENTRO_COSTO { get; set; }
		public string NOMBRE_JEFE { get; set; }

		//public string ASUNTO { get; set; }
		public RETIRO_MODELO RETIRO { get; set; }
        public IEnumerable<CORREOS_DESTINOS_MODELO> DESTINOS { get; set; }
        public IEnumerable<PLANTILLAS_CORREOS_MODELO> PLANTILLAS { get; set; }

    }

    public class RETIRO_MODELO
    {
        public decimal COD_RETIRO { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public string NOMBRE { get; set; }
        public string USUARIO { get; set; }
        public decimal COD_CARGO { get; set; }
        public string NOMBRE_CARGO { get; set; }
        public decimal COD_CAUSA_RETIRO { get; set; }
        public string NOMBRE_CAUSA_RETIRO { get; set; }
        public DateTime FECHA_RETIRO { get; set; }
        public bool GENERA_VACANTE { get; set; }
        public string COMENTARIOS { get; set; }
        public bool APROBADO { get; set; }
        public decimal COD_ESTADO_RETIRO { get; set; }
        public decimal ESTADO { get; set; }
        public string COD_USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_USUARIO_MODIFICA { get; set; }
        public DateTime FECHA_MODIFICA { get; set; }

	
    }


    public class CORREOS_DESTINOS_MODELO
    {
        public decimal COD_COREEO_DESTINO { get; set; }
        public decimal COD_CORREO { get; set; }
        public string CORREO { get; set; }
        public decimal ESTADO { get; set; }
        public string COD_USUARIO_CREA { get; set; }

        public DateTime FECHA_CREA { get; set; }
        public string COD_USUARIO_MODIFICA { get; set; }
        public DateTime FECHA_MODIFICA { get; set; }

    }


    public  class PLANTILLAS_CORREOS_MODELO
    {
        public decimal COD_PLANTILLA { get; set; }
        public decimal COD_CORREO { get; set; }
        public string PLANTILLA { get; set; }
        public decimal ESTADO { get; set; }
        public string COD_USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_USUARIO_MODIFICA { get; set; }
        public DateTime FECHA_MODIFICA { get; set; }
    }

}
