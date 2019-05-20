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
            if (_idReq.HasValue) {
                model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value)?? new REQUISICIONViewModel();
            }
            if (Session["objetoListas"] != null){
                model = new LOGICA_REQUISICION().LLENAR_CONTROLES_SESSSION(model, Session["objetoListas"] as REQUISICIONViewModel);
            }
            else {
                return RedirectToAction("Index", "REQUISICION");
            }


            List<SelectListItem> listacargos = model.LIST_NOMBRE_CARGO;
            NO_PRESUPESTADA_CREACION fromPost = TempData["resultado"] as NO_PRESUPESTADA_CREACION;
            // este filtro se debe hacer sobre la lista NOMBRE_CARGO y no sobre necesidad 
            if (fromPost != null)
                fromPost.NOMBRE_COD_CARGO = listacargos.Where(x => x.Value == fromPost.COD_CARGO.ToString()).First().Text;
            //Logica para el POP UP
            ViewBag.resultadoNojefe = fromPost != null ? fromPost.RESULTADO : false;
            ViewBag.resultadoPopUpNoJefe = fromPost;

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel modelDatos) {
            try {
                Boolean _resultado = false;
                modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqNoPresupuestada;
                REQUISICIONViewModel listas = new REQUISICIONViewModel();
                if (Session["objetoListas"] != null){
                    listas = new LOGICA_REQUISICION().LLENAR_CONTROLES_SESSSION(listas, Session["objetoListas"] as REQUISICIONViewModel);
                }
                else{
                    return RedirectToAction("Index", "REQUISICION");
                }

                modelDatos.NOMBRE_CARGO = listas.LIST_NOMBRE_CARGO.Where(x => x.Value == modelDatos.COD_CARGO.ToString()).First().Text;
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