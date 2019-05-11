using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G_H_WEB.Models;


namespace WebApplication1.Controllers
{
    public class TemplatesController : Controller
    {
        // GET: Templates
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(CUENTA_VALIDAR_ViewModel login)
        {
            string usuari = login.Usuario;
            string contra = login.Contraseña;

            return View();
        }


        public ActionResult mailing()
        {
            return View();
        }
        public ActionResult mailingOriginal()
        {
            return View();
        }
        public ActionResult retiros()
		{
			return View();
		}

        public ActionResult retiros_buscar()
        {
            return View();
        }

        public ActionResult retiros_detalle()
        {
            return View();
        }

        public ActionResult retiros_documentos_relacionados()
        {
            return View();
        }

        public ActionResult solicitudes()
        {
            return View();
        }

        public ActionResult Prueba()
        {
            return View();
        }
    }
}