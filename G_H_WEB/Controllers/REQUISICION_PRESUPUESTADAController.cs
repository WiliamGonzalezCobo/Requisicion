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
        public ActionResult Index(int? _idReq)
        {
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            try
            {
                if (_idReq.HasValue)
                {
                    model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value);
                }

                ViewBag.Necesidad = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
                ViewBag.Cargo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel model, string submitButton)
        {
            try
            {
                switch (submitButton)
                {
                    case "Crear Requisición":
                        Crear(model);
                        break;
                    case "Aprobar":
                        Aprobar(model);
                        break;
                    case "Rechazar":
                        Rechazar(model);
                        break;
                    case "Enviar":
                        Enviar(model);
                        break;
                    case "Modificar":
                        Modificar(model);
                        break;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void Crear(REQUISICIONViewModel model)
        {
        }
        public void Aprobar(REQUISICIONViewModel model)
        {
        }
        public void Rechazar(REQUISICIONViewModel model)
        {
        }
        public void Enviar(REQUISICIONViewModel model)
        {
        }
        public void Modificar(REQUISICIONViewModel model)
        {
        }



    }
}