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
            ViewBag.RequisicionNombre = "Requsicion No Presupuestada";
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            if (_idReq.HasValue) {
                model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value)?? new REQUISICIONViewModel();
            }

           model = new LOGICA_REQUISICION().LLENAR_CONTROLES_SESSSION(model, Session["objetoListas"] as REQUISICIONViewModel);

            // Esto es para el POP UP
            List<SelectListItem> listacargos = model.LIST_NOMBRE_CARGO;
            RESPUESTA_POP_UP fromPost = TempData["resultado"] as RESPUESTA_POP_UP;
            // este filtro se debe hacer sobre la lista NOMBRE_CARGO y no sobre necesidad 
            if (fromPost != null)
                fromPost.NOMBRE_COD_CARGO = listacargos.Where(x => x.Value == fromPost.COD_CARGO.ToString()).First().Text;
            //Logica para el POP UP
            ViewBag.resultadoNojefe = fromPost != null ? !fromPost.RESULTADO.Equals(0) : false;
            ViewBag.resultadoPopUpNoJefe = fromPost;

            //FIN POP UP

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel modelDatos, string submitButton) {
            try {
                int _resultadoIdReguisicion = 0;
                modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqNoPresupuestada;
                modelDatos.USUARIO_CREACION = User.Identity.Name;
                REQUISICIONViewModel listas = new REQUISICIONViewModel();
                // llena los combos
                modelDatos = new LOGICA_REQUISICION().LLENAR_CONTROLES_SESSSION(modelDatos, Session["objetoListas"] as REQUISICIONViewModel);
                // saca los valores de los combos
                modelDatos = new LOGICA_REQUISICION().CONSULTAR_VALORES_LISTAS_POR_CODIGO(modelDatos);
              

                switch (submitButton)
                {
                    case "Crear Requisición":
                        _resultadoIdReguisicion = new LOGICA_REQUISICION().INSERTAR_REQUISICION_LOGICA(modelDatos);
                        break;
                    case "Aprobar":
                        //Aprobar(model);
                        break;
                    case "Rechazar":
                        //Rechazar(model);
                        break;
                    case "Enviar":
                        _resultadoIdReguisicion = Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZARREQUISICION(modelDatos));
                        break;
                    case "Modificar":
                        //Modificar(model);
                        break;
                }


                //INICIO Esta logica es para el POP UP----------
                RESPUESTA_POP_UP npc = new RESPUESTA_POP_UP();
                npc.COD_REQUISICION_CREADA = _resultadoIdReguisicion;
                npc.COD_CARGO = modelDatos.COD_CARGO;
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