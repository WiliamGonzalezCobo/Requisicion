using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LOGICA.MODELO_LOGICA;
using UTILS.Settings;

namespace LOGICA
{
     public class CLIENTEAPI
    {
        public HttpClient client;

        public  CLIENTEAPI()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(SettingsManager.Urlapi)
            };
            client.SetBasicAuthentication(SettingsManager.ApiUsuario,SettingsManager.ApiPassword);
            var CLIENT = client;
        }

       
    }
}
