using G_H_WEB.Logica_Session;
using LOGICA.REQUISICION_LOGICA;
using Microsoft.AspNet.Identity;
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
        public ActionResult Index(int? _idReq, int? _idTipo)
        {
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            if (_idReq.HasValue){
                model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value) ?? new REQUISICIONViewModel();
                if (User.IsInRole(SettingsManager.PerfilBp)){
                    model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONESBP(model) ?? new REQUISICIONViewModel();
                }
            }
           model = new LOGICA_REQUISICION().LLENAR_CONTROLES_SESSSION(model, Session["objetoListas"] as REQUISICIONViewModel);

            // Esto es para el POP UP
            List<SelectListItem> listacargos = model.LIST_NOMBRE_CARGO;
            RESPUESTA_POP_UP fromPost = TempData["resultado"] as RESPUESTA_POP_UP;
            // este filtro se debe hacer sobre la lista NOMBRE_CARGO y no sobre necesidad 
            if (fromPost != null && fromPost.RESULTADO == true && fromPost.COD_CARGO != 0)
                fromPost.NOMBRE_COD_CARGO = listacargos.Where(x => x.Value == fromPost.COD_CARGO.ToString()).First().Text;
            //Logica para el POP UP
            ViewBag.resultadoInsertExitosoOno = fromPost != null ? !fromPost.RESULTADO.Equals(0) : false;
            ViewBag.resultadoPopUpNoJefe = fromPost;

            //FIN POP UP
            ViewBag.Busca_USUARIOS = new LOGICA_REQUISICION().CONSULTAR_EMPLEADOS_LOGICA();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel modelDatos, string submitButton, int? _idTipo) {
            try {
                int _resultadoIdReguisicion = 0;
                modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqNoPresupuestada;
                modelDatos.USUARIO_CREACION = User.Identity.Name;
                modelDatos.USUARIO_MODIFICACION = User.Identity.Name;//      martinezluir esto es para test toca hacer la logica
                REQUISICIONViewModel listas = new REQUISICIONViewModel();
                // llena los combos
                modelDatos = new LOGICA_REQUISICION().LLENAR_CONTROLES_SESSSION(modelDatos, Session["objetoListas"] as REQUISICIONViewModel);
                // saca los valores de los combos
                modelDatos = new LOGICA_REQUISICION().CONSULTAR_VALORES_LISTAS_POR_CODIGO(modelDatos);

                //INICIO Esta logica es para el POP UP----------
                RESPUESTA_POP_UP npc = new RESPUESTA_POP_UP();
                // FIN

                switch (submitButton)
                {
                    case "CREAR REQUISICIÓN":
                        _resultadoIdReguisicion = new LOGICA_REQUISICION().INSERTAR_REQUISICION_LOGICA(modelDatos);
                        if (modelDatos.COD_REQUISICION == 0)
                            npc.METODO = "Crear";
                        else
                            npc.METODO = "Modificar";

                        break;
                    case "APROBAR REQUISICIÓN":
                        if (User.IsInRole(SettingsManager.PerfilRRHH) || User.IsInRole(SettingsManager.PerfilUSC))
                        {
                            Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZARREQUISICION(modelDatos));
                            _resultadoIdReguisicion = modelDatos.COD_REQUISICION;
                        }
                        else {
                            _resultadoIdReguisicion = new LOGICA_REQUISICION().APROBAR_REQUISICION_LOGICA(modelDatos.COD_REQUISICION, User.Identity.GetUserId(), modelDatos.OBSERVACION);
                        }
                        npc.METODO = "Aprobar";
                        break;
                    case "Rechazar requisicion":
                        _resultadoIdReguisicion = new LOGICA_REQUISICION().REQUISICION_RECHAZAR_LOGICA(modelDatos.COD_REQUISICION, modelDatos.OBSERVACION, User.Identity.Name);
                        npc.METODO = "Rechazar";
                        break;
                    case "Enviar":

                        Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZARREQUISICION(modelDatos));
                        _resultadoIdReguisicion = modelDatos.COD_REQUISICION;
                        npc.METODO = "Enviar";
                        break;
                    case "DEVOLVER REQUISICIÓN":
                        _resultadoIdReguisicion = Convert.ToInt32(new LOGICA_REQUISICION().REQUISICION_MODIFICAR_LOGICA(modelDatos.COD_REQUISICION, modelDatos.OBSERVACION, User.Identity.GetUserId()));
                        npc.METODO = "Modificar";
                        break;
                }


                //INICIO Esta logica es para el POP UP----------
                npc.COD_REQUISICION_CREADA = _resultadoIdReguisicion;
                npc.COD_CARGO = modelDatos.COD_CARGO;
                npc.RESULTADO = !_resultadoIdReguisicion.Equals(0);
                TempData["resultado"] = npc;
                //FIN Esta logica es para el POP UP----------

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                RESPUESTA_POP_UP npc = new RESPUESTA_POP_UP();
                npc.RESULTADO = false;
                TempData["resultado"] = npc;
                return RedirectToAction("Index");
            }
        }
  
          
    }
}