using LOGICA.REQUISICION_LOGICA;
using MODELO_DATOS.MODELO_REQUISICION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTILS.Settings;

namespace G_H_WEB.Controllers
{
    public class REQUISICION_NOPRESUPUESTADAController : Controller
    {
        // GET: REQUISICION_NOPRESUPUESTADA
        public ActionResult Index(int? _idReq)
        {
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            if (_idReq.HasValue)
            {
                model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value)?? new REQUISICIONViewModel();
            }

            List<SelectListItem> listaNecesidad = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            NO_PRESUPESTADA_CREACION fromPost = TempData["resultado"] as NO_PRESUPESTADA_CREACION;
            // este filtro se debe hacer sobre la lista NOMBRE_CARGO y no sobre necesidad 
            if (fromPost != null)
                fromPost.NOMBRE_COD_CARGO = listaNecesidad.Where(x => x.Value == fromPost.COD_CARGO.ToString()).First().Text;

            // vienen de la logica - base de datos
            ViewBag.Necesidad = listaNecesidad;
            ViewBag.Options = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            ViewBag.Cargo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();

            //Logica para el POP UP
            ViewBag.resultadoNojefe = fromPost != null ? fromPost.RESULTADO : false;
            ViewBag.resultadoPopUpNoJefe = fromPost;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel modelDatos) {
            try {
                Boolean _resultado = false;
                modelDatos.COD_TIPO_REQUISICION = 2;// viene de la web config
                _resultado = new LOGICA_REQUISICION().INSERTAR_REQUISICION_LOGICA(modelDatos, User.Identity.Name);

                //INICIO Esta logica es para el POP UP----------
                NO_PRESUPESTADA_CREACION npc = new NO_PRESUPESTADA_CREACION();
                npc.COD_CARGO = modelDatos.COD_CARGO;
                npc.RESULTADO = _resultado;
                TempData["resultado"] = npc;
                //FIN Esta logica es para el POP UP----------
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                NO_PRESUPESTADA_CREACION npc = new NO_PRESUPESTADA_CREACION();
                npc.RESULTADO = false;
                TempData["resultado"] = npc;
                return RedirectToAction("Index");
            }
        }
    }
}