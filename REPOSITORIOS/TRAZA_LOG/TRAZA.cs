using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MODELO_DATOS;
using log4net;
using System.Data;
using log4net.Config;
using System.IO;
using System.Security.Cryptography;


namespace REPOSITORIOS.TRAZA_LOG
{
    public class TRAZA
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static void DEPURAR_TRAZA(string CODIGO_ERROR,string _NOMBRE_CLASE, string _NOMBRE_METODO ,string _INFO)
        {

            IDEPURACION_REP _REPOSITORIO_DEPURAR = new DEPURACION_REP(new CONTEXTO());
            DEPURARCION _DEPURAR = new DEPURARCION();
            bool VALIDA_LOG = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["Valida_Metodo_Depuracion_Log"]);
            //if (VALIDA_LOG)
            //{
            //Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE5", log.Logger.Name, "APROBAR_SOPORTE", INFO));
            //HILO.Start();
            //}
            try
            {
                if (VALIDA_LOG)
                {
                    string INFO = ("Iniciando Método DEPURAR_TRAZA por COD_RETIRO  " + CODIGO_ERROR);
                    log.Info("CODIGO : DPTR1," + INFO);
                    _DEPURAR.COD_ERROR = 1;//SI
                    _DEPURAR.CODIGO_ERROR = CODIGO_ERROR;//SI
                    _DEPURAR.FECHA = Convert.ToDateTime("18/02/2019");
                    _DEPURAR.NOMBRE_CLASE = _NOMBRE_CLASE;//SI
                    _DEPURAR.NOMBRE_METODO = _NOMBRE_METODO;//SI
                    _DEPURAR.DETALLE = _INFO;//SI
                    _REPOSITORIO_DEPURAR.GUARDA_DEPURARCION(_DEPURAR);
                    _REPOSITORIO_DEPURAR.GUARDAR();

                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : DPTR1  recuperando DEPURAR_TRAZA CON EL CODIGO_ERROR : {0} ,{1} ", CODIGO_ERROR, ex.StackTrace);
                ex.HelpLink = "DPTR1";
                throw ex;
            }
    
            }

        private static void INICIO(string CODIGO_ERROR, string _NOMBRE_CLASE, string _NOMBRE_METODO, string _INFO)
        {

        }
    }
}
