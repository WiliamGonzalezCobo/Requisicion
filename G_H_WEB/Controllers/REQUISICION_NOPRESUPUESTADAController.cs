using G_H_WEB.Logica_Session;
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
    [CustAuthFilter]
    public class REQUISICION_NOPRESUPUESTADAController : Controller
    {
        // GET: REQUISICION_NOPRESUPUESTADA
        public ActionResult Index(int? _idReq)
        {
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            if (_idReq.HasValue) {
                model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value)?? new REQUISICIONViewModel();
            }

           model = new LOGICA_REQUISICION().LLENAR_CONTROLES_SESSSION(model, Session["objetoListas"] as REQUISICIONViewModel);

            // Esto es para el POP UP
            List<SelectListItem> listacargos = model.LIST_NOMBRE_CARGO;
            NO_PRESUPESTADA_CREACION fromPost = TempData["resultado"] as NO_PRESUPESTADA_CREACION;
            if (fromPost != null && fromPost.RESULTADO==true)
                fromPost.NOMBRE_COD_CARGO = listacargos.Where(x => x.Value == fromPost.COD_CARGO.ToString()).First().Text;
            ViewBag.resultadoNojefe = fromPost != null ? fromPost.RESULTADO : false;
            ViewBag.resultadoPopUpNoJefe = fromPost;

            //FIN POP UP

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel modelDatos) {
            try {
                
                Boolean _resultado = false;
                modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqNoPresupuestada;
                modelDatos.USUARIO_CREACION = User.Identity.Name;
                REQUISICIONViewModel listas = new REQUISICIONViewModel();
                // llena los combos
                modelDatos = new LOGICA_REQUISICION().LLENAR_CONTROLES_SESSSION(modelDatos, Session["objetoListas"] as REQUISICIONViewModel);
                // saca los valores de los combos
                modelDatos = new LOGICA_REQUISICION().CONSULTAR_VALORES_LISTAS_POR_CODIGO(modelDatos);
                if (User.IsInRole(SettingsManager.PerfilJefe)) {
                    _resultado = new LOGICA_REQUISICION().INSERTAR_REQUISICION_LOGICA(modelDatos);
                } else {
                    _resultado = new LOGICA_REQUISICION().ACTUALIZARREQUISICION(modelDatos);
                }
                

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

        public JsonResult APROBAR_REQUISICION() {
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}