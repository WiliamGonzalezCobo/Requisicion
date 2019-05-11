using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LOGICA.MODELO_LOGICA;
using log4net;
using REPOSITORIOS.TRAZA_LOG;
using System.Threading;

namespace LOGICA
{
    public class CAUSA_RETIRO
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CAUSA_RETIRO_MODELO CONSULTAR(Decimal _CAUSA)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR CAUSA RETIRO PO CAUSA :" + _CAUSA);
                log.Info("CODIGO : CA2," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE2", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();

                CLIENTEAPI API = new CLIENTEAPI();
                //HttpResponseMessage respueta = API.client.GetAsync("CAUSA_RETIROS/" + _CAUSA.ToString().Replace(".0", "").Replace(",0", "")).Result;
                HttpResponseMessage respueta = API.client.GetAsync("CAUSAS_RETIRO/" + _CAUSA.ToString().Replace(".0", "").Replace(",0", "")).Result;
                respueta.EnsureSuccessStatusCode();
                if (respueta.IsSuccessStatusCode)
                {
                    string contenido = respueta.Content.ReadAsStringAsync().Result;
                    CAUSA_RETIRO_MODELO CAUSA_OBJ = JsonConvert.DeserializeObject<CAUSA_RETIRO_MODELO>(contenido);
                    return CAUSA_OBJ;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CA2  recuperando CONSULTAR CAUSA RETIRO  POR CAUSA : {0}, {1}", _CAUSA, ex.StackTrace);
                ex.HelpLink ="CA2";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }



		public IEnumerable< CAUSA_RETIRO_MODELO> CONSULTAR()
		{
            try
            {
                string INFO = ("Iniciando Método CONSULTAR CAUSA RETIRO:");
                log.Info("CODIGO : CA1," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CA1", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();



                CLIENTEAPI API = new CLIENTEAPI();
                HttpResponseMessage respueta = API.client.GetAsync("CAUSAS_RETIRO").Result;
                respueta.EnsureSuccessStatusCode();
                if (respueta.IsSuccessStatusCode)
                {
                    string contenido = respueta.Content.ReadAsStringAsync().Result;
                    List<CAUSA_RETIRO_MODELO> CAUSAS = JsonConvert.DeserializeObject<List<CAUSA_RETIRO_MODELO>>(contenido);
                    return CAUSAS;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CA1  recuperando CONSULTAR CAUSA RETIRO  : {0}", ex.StackTrace);
                ex.HelpLink = "CA1";

                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
			

		}
	}
}
