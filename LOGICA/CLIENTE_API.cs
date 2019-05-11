using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LOGICA.MODELO_LOGICA; 

namespace LOGICA
{
     public class CLIENTEAPI
    {
        public HttpClient client;

        public  CLIENTEAPI()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["URL_WEB_API"].ToString())
            };
            client.SetBasicAuthentication("1", "1");
            var CLIENT = client;
        }

       
    }
}
