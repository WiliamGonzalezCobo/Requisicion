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
            ViewBag.RequisicionNombre = "Requsicion No Presupuestada";
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
            RESPUESTA_POP_UP fromPost = TempData["resultado"] as RESPUESTA_POP_UP;
            // este filtro se debe hacer sobre la lista NOMBRE_CARGO y no sobre necesidad 
            if (fromPost != null)
                fromPost.NOMBRE_COD_CARGO = listacargos.Where(x => x.Value == fromPost.COD_REQUISICION_CREADA.ToString()).First().Text;
            //Logica para el POP UP
            ViewBag.resultadoNojefe = fromPost != null ? !fromPost.RESULTADO.Equals(0) : false;
            ViewBag.resultadoPopUpNoJefe = fromPost;

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel modelDatos) {
            try {
                int _resultadoIdReguisicion = 0;
                modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqNoPresupuestada;
                REQUISICIONViewModel listas = new REQUISICIONViewModel();
                if (Session["objetoListas"] != null){
                    listas = new LOGICA_REQUISICION().LLENAR_CONTROLES_SESSSION(listas, Session["objetoListas"] as REQUISICIONViewModel);
                }
                else{
                    return RedirectToAction("Index", "REQUISICION");
                }

                modelDatos.NOMBRE_CARGO = listas.LIST_NOMBRE_CARGO.Where(x => x.Value == modelDatos.COD_CARGO.ToString()).First().Text;
                _resultadoIdReguisicion = new LOGICA_REQUISICION().INSERTAR_REQUISICION_LOGICA(modelDatos, User.Identity.Name);
                

                //INICIO Esta logica es para el POP UP----------
                RESPUESTA_POP_UP npc = new RESPUESTA_POP_UP();
                npc.COD_REQUISICION_CREADA = _resultadoIdReguisicion;
                npc.RESULTADO = !_resultadoIdReguisicion.Equals(0);
                TempData["resultado"] = npc;
                //FIN Esta logica es para el POP UP----------
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                RESPUESTA_POP_UP npc = new RESPUESTA_POP_UP();
                npc.RESULTADO = false;
                TempData["resultado"] = npc;
                return RedirectToAction("Index");
            }
        }
    }
}