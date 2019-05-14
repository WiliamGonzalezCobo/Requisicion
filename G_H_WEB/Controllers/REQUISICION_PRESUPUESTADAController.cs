using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOGICA.REQUISICION_LOGICA;
using MODELO_DATOS.MODELO_REQUISICION;

namespace G_H_WEB.Controllers
{
    [Authorize]
    public class REQUISICION_PRESUPUESTADAController : Controller
    {
        // GET: REQUISICION_PRESUPUESTADA
        public ActionResult Index()
        {
            ViewBag.Necesidad = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            ViewBag.Cargo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD(); ;
            return View();
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel model, string submitButton)
        {
            try
            {
                switch (submitButton)
                {
                    case "Crear Requisición":
                        return RedirectToAction("Crear", "REQUISICION_PRESUPUESTADA", model);
                    case "Aprobar":
                        return RedirectToAction("Aprobar", "REQUISICION_PRESUPUESTADA", model);
                    case "Rechazar":
                        return RedirectToAction("Rechazar", "REQUISICION_PRESUPUESTADA", model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Crear(REQUISICIONViewModel model)
        {
            //insertamos la requisicion 
            ViewBag.Necesidad = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            ViewBag.Cargo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            return RedirectToAction("Index");
        }
        public ActionResult Aprobar(REQUISICIONViewModel model)
        {
            //insertamos la requisicion 
            ViewBag.Necesidad = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            ViewBag.Cargo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            return RedirectToAction("Index");
        }
        public ActionResult Rechazar(REQUISICIONViewModel model)
        {
            //insertamos la requisicion 
            ViewBag.Necesidad = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            ViewBag.Cargo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            return RedirectToAction("Index");
        }



    }
}