using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace REPOSITORIOS.TRAZA_LOG
{
    public static class LOG_CENTRALIZADO
    {
        public static  ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static void INICIANDO_LOG(string _codigo, string _metodo)
        {
            string info = string.Format("Iniciando Método  {0}", _metodo);
            log.Info(string.Format("CODIGO : {0}, {1}", _codigo, info));
            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA(_codigo, log.Logger.Name, _metodo, info));
            HILO.Start();
        }

        public static void FINALIZANDO_LOG(string _codigo, string _metodo)
        {
            log.Info(string.Format("CODIGO : {0}, Finalizado con éxito Método {1}", _codigo, _metodo));
        }

        public static void CAPTURA_EXCEPCION(string _codigo, string _metodo, Exception ex)
        {
            log.ErrorFormat("CODIGO : {0},  Método {1}, {2}  ", _codigo, _metodo, ex.StackTrace);
            ex.HelpLink = _codigo;
            Thread HILOERROR = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, string.Format("{0}, {1}", ex.StackTrace, ex.Message)));
            HILOERROR.Start();
        }
    }
}
