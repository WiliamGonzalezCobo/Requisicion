using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPOSITORIOS;
using MODELO_DATOS;
using LOGICA.MODELO_LOGICA;
using Newtonsoft.Json.Linq;
using log4net;
using REPOSITORIOS.TRAZA_LOG;
using System.Threading;

namespace LOGICA
{
    public class TIPO_SOPORTE
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private ITIPO_SOPORTES_REP _REPOSITORIO ;
		public TIPO_SOPORTE()
		{
			_REPOSITORIO =  new REPOSITORIOS.TIPO_SOPORTES_REP(new CONTEXTO());
		}
		//ESTA SOBRECARGA PERMITE PRUBAS AUTOMATICAS POR PROBLEMAS CON MANEJO DE 
		public TIPO_SOPORTE(String CADENA_CONEXION)
		{
			_REPOSITORIO = new REPOSITORIOS.TIPO_SOPORTES_REP(new CONTEXTO(CADENA_CONEXION));
		}

		public IEnumerable<TIPO_SOPORTES> CONSULTAR(decimal _COD_CAUSA_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR por COD_RETIRO con el COD_CAUSA_RETIRO : " + _COD_CAUSA_RETIRO);
                log.Info("CODIGO : LGTP1," + INFO);
              
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGTP1", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();

                return _REPOSITORIO.CONSULTA_TIPO_RETIRO(_COD_CAUSA_RETIRO);
            }
            catch (Exception ex)
            {

                log.ErrorFormat("CODIGO : LGTP1  recuperando CONSULTAR  con el COD_CAUSA_RETIRO : {0} , {1} ", _COD_CAUSA_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGTP1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }


        }
    }
}
