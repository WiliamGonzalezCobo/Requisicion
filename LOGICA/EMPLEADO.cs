using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LOGICA.MODELO_LOGICA;
using System.Dynamic;
using log4net;
using System.Threading;
using REPOSITORIOS.TRAZA_LOG;

namespace LOGICA
{
    public class EMPLEADO
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public EMPLEADO_MODELO CONSULTA_EMPLEADO(string _NUMERO_DOCUMENTO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTA_EMPLEADO _NUMERO_DOCUMENTO : " + _NUMERO_DOCUMENTO);
                log.Info("CODIGO : EM1," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("EM1", log.Logger.Name, "CONSULTA_EMPLEADO", INFO));
                HILO.Start(); 

                CLIENTEAPI API = new CLIENTEAPI();
				
				HttpResponseMessage respueta = API.client.GetAsync("EMPLEADOS?NUMERO_DOCUMENTO=" + _NUMERO_DOCUMENTO).Result;
                respueta.EnsureSuccessStatusCode();
                if (respueta.IsSuccessStatusCode)
                {
                    string contenido = respueta.Content.ReadAsStringAsync().Result;
                    EMPLEADO_MODELO EMPLEADO_OBJ = JsonConvert.DeserializeObject<EMPLEADO_MODELO>(contenido);
                    return EMPLEADO_OBJ;
                }
                else
                {//valor_buscado
                    return null;
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : EM1  recuperando CONSULTA_EMPLEADO _NUMERO_DOCUMENTO : {0}, {1}", _NUMERO_DOCUMENTO, ex.StackTrace);
                ex.HelpLink = "EM1";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

        public List<EMPLEADO_MODELO> CONSULTA_EMPLEADO_VALOR_BUSCADO(string _VALOR_BUSCADO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTA_EMPLEADO_VALOR_BUSCADO  _VALOR_BUSCADO : " + _VALOR_BUSCADO);
                log.Info("CODIGO : EM2," + INFO);

                //Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("EM1", log.Logger.Name, "CONSULTA_EMPLEADO_VALOR_BUSCADO", INFO));
                //HILO.Start();

                //throw new Exception();

                CLIENTEAPI API = new CLIENTEAPI();

                HttpResponseMessage respueta = API.client.GetAsync("EMPLEADOS?VALOR_BUSCADO=" + _VALOR_BUSCADO).Result;
			
				respueta.EnsureSuccessStatusCode();
                if (respueta.IsSuccessStatusCode)
                {
                    string contenido = respueta.Content.ReadAsStringAsync().Result;
                    List<EMPLEADO_MODELO> CAUSA_OBJ = JsonConvert.DeserializeObject<List<EMPLEADO_MODELO>>(contenido);

                    return CAUSA_OBJ;
                }
                else
                {//valor_buscado
                    return null;
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : EM2  recuperando CONSULTA_EMPLEADO_VALOR_BUSCADO _VALOR_BUSCADO : {0}, {1}", _VALOR_BUSCADO, ex.StackTrace);
                ex.HelpLink = "EM2";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }
         



    }
}
