using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using G_H_WEB.Models;
using System.Security.Cryptography;
using System.Text;
//using System.Net.Mail.MailMessage;
using System.Web.Http;
using log4net;




namespace G_H_WEB.Controllers
{
    public class HomeController : Controller

    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /*INSTANCIAR PARA USAR LOS METODOS QUE TIENE LA LOGICA */
        private LOGICA.SOPORTE logicasoporte = new LOGICA.SOPORTE();
        private LOGICA.CORREO LogicaCorreo = new LOGICA.CORREO();
        private LOGICA.CLIENTE_CORREO ENVIA_COREO = new LOGICA.CLIENTE_CORREO();
        private LOGICA.NOTIFICACION CORREO_NOTIFICA = new LOGICA.NOTIFICACION();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }


        public ActionResult SubirArchivo()
        {
            try
            {
                //            LOGICA.RETIRO LOGICA1 = new LOGICA.RETIRO();

                //LOGICA1.CONSULTAR(4);

            }
            catch (Exception ex)
            {
                //var a= ex.HelpLink;
                //ViewBag.MENSAJE_ERROR = ex.HelpLink;
                return View();
            }


            //log.Info("Ingreso correcto info!!!");
            //log.Error("error prueba");
            return View();
        }

        /*METODO PARA GUARDAR ARCHIVO*/
        [System.Web.Mvc.HttpPost]
        public ActionResult SubirArchivo(ARCHIVO _ARCHIVO)
        {
            //NombreArchivo_var = IdFlow.ToString() + "_" + HashSHA1(postedFile.FileName) + Extencion;

            foreach (var file in _ARCHIVO.Files)
            {

                if (file.ContentLength > 0)
                {
                    var _NOMBRE_SOPORTE = Path.GetFileName(file.FileName);
                    logicasoporte.CREAR(16, 1, _NOMBRE_SOPORTE, "SYSYTEM", file);
                }
            }
            return RedirectToAction("SubirArchivo");
        }

        /// <summary>
        /// serializa el nombre del archivo que se cargará
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        //private static string HashSHA(string value)
        //{
        //    var sha1 = SHA1.Create();
        //    var inputBytes = System.Text.Encoding.ASCII.GetBytes(value);
        //    var hash = sha1.ComputeHash(inputBytes);
        //    var sb = new StringBuilder();
        //    for (var i = 0; i < hash.Length; i++)
        //    {
        //        sb.Append(hash[i].ToString("X2"));
        //    }
        //    return sb.ToString();
        //}





        /*TRAE EL ARCHIVO*/
        [System.Web.Mvc.HttpGet]
        public FileResult TraerArchivo(decimal _COD_SOPORTE)
        {
            try
            {
                LOGICA.MODELO_LOGICA.SOPORTE_MODELO SOPORTE = logicasoporte.CONSULTA_ARCHIVO(_COD_SOPORTE);
                return File(SOPORTE.ARCHIVO, System.Net.Mime.MediaTypeNames.Application.Octet, SOPORTE.NOMBRE);
            }
            catch (Exception ex)
            {
                var res = ex.Message;

                return null;
            }
        }









        /*VISTA PARA ENVIAR CORREOS*/
        public ActionResult Correo()
        {
            return View();
        }



        [System.Web.Mvc.HttpPost]
        public ActionResult Correo(LOGICA.MODELO_LOGICA.CORREO_CONFIGURACION_MODELO _DATOS_FORMULARIO)//recibe una entidad de tipo formulario para que capture los datos que vienen de la vista
        {
            LogicaCorreo.ENVIO_CORREO(_DATOS_FORMULARIO);
            //ENVIA_COREO.ENVIO_CORREO(1, "julfue@eltiempo.com");
          //  CORREO_NOTIFICA.NOTIFICAR(195);


            return RedirectToAction("Correo");
        }


        /*CLASE PARA SUBIR ARCHIVOS*/
        public class ARCHIVO
        {
            public IEnumerable<HttpPostedFileBase> Files { get; set; }
        }
    }

}