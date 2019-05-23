using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MODELO_DATOS;

namespace REPOSITORIOS.TRAZA_LOG
{

    public class ERROR
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void ERROR_TRAZA(string CODIGO_ERROR, string _NOMBRE_CLASE, string _NOMBRE_METODO, string _INFO)
    {
           IERRORES_REP _REPOSITORIO_ERROR = new ERRORES_REP(new CONTEXTO());
           ERRORES _ERROR = new ERRORES();

            bool VALIDA_LOG = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["Valida_Metodo_Depuracion_Log"]);

            try
            {
                if (VALIDA_LOG)
                {
                    string INFO = ("Iniciando Método ERROR_TRAZA CON EL CODIGO ERROR :" + CODIGO_ERROR);
                    log.Info("CODIGO : ER1," + INFO);

                    _ERROR.COD_ERROR = 1;
                    _ERROR.CODIGO_ERROR = CODIGO_ERROR;
                    _ERROR.FECHA = Convert.ToDateTime("2019/3/3");
                    _ERROR.NOMBRE_CLASE = _NOMBRE_CLASE;
                    _ERROR.NOMBRE_METODO = _NOMBRE_METODO;
                    _ERROR.DETALLE = _INFO;
                    _REPOSITORIO_ERROR.GUARDA_ERROR(_ERROR);
                    _REPOSITORIO_ERROR.GUARDAR();
                }

            }
            catch (Exception ex)
            {

                log.ErrorFormat("CODIGO : ER1  recuperando ERROR_TRAZA  CON EL CODIGO ERROR: {0},{1}  ", CODIGO_ERROR,  ex.StackTrace);
                ex.HelpLink = "ER1";

                throw ex;
            }
       
     }
    }
}
