using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G_H_WEB.Logica_Session;
using LOGICA.REQUISICION_LOGICA;
using Microsoft.AspNet.Identity;
using MODELO_DATOS.MODELO_REQUISICION;
using UTILS.Settings;

namespace G_H_WEB.Controllers
{
    [CustAuthFilter]
    public class REQUISICION_PRESUPUESTADAController : Controller
    {
        // GET: REQUISICION_PRESUPUESTADA
        public ActionResult Consultar(int? _idReq, int? _idTipo, string link_controler="",string COD_ASPNETUSER_CONTROLLER="")
        {
            if (COD_ASPNETUSER_CONTROLLER!=""){ Session["COD_ASPNETUSER_CONTROLLER"] = COD_ASPNETUSER_CONTROLLER; }
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            try
            {
               
                if (_idReq.HasValue){
                    model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value, link_controler) ?? new REQUISICIONViewModel();
                    if (User.IsInRole(SettingsManager.PerfilBp)){
                        model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES_BP(model) ?? new REQUISICIONViewModel();
                    }
                }
                model = new LOGICA_REQUISICION().LLENAR_CONTROLES(model);

                // Esto es para el POP UP
                List<SelectListItem> listacargos = model.LIST_NOMBRE_CARGO;
                RESPUESTA_POP_UP fromPost = TempData["resultado"] as RESPUESTA_POP_UP;
                // este filtro se debe hacer sobre la lista NOMBRE_CARGO y no sobre necesidad 
                if (fromPost != null && fromPost.RESULTADO == true && fromPost.COD_CARGO != 0)
                    fromPost.NOMBRE_COD_CARGO = listacargos.Where(x => x.Value == fromPost.COD_CARGO.ToString()).First().Text;
                //Logica para el POP UP
                ViewBag.resultadoInsertExitosoOno = fromPost != null ? !fromPost.RESULTADO.Equals(0) : false;
                ViewBag.resultadoPopUpNoJefe = fromPost;
                ViewBag.Busca_USUARIOS = new LOGICA_REQUISICION().CONSULTAR_EMPLEADOS();
                ViewBag.PERMISOS_CONTROLLER = link_controler;
            }
            catch (Exception ex){
                ViewBag.Error = ex.Message;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Procesar(REQUISICIONViewModel modelDatos, string submitButton, int? _idTipo)
        {
            try
            {
                string _User = "";
                int _resultadoIdReguisicion = 0;
                modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqPresupuestada;

                modelDatos.USUARIO_CREACION = User.Identity.Name;
                modelDatos.USUARIO_MODIFICACION = User.Identity.Name;//      martinezluir esto es para test toca hacer la logica
                REQUISICIONViewModel listas = new REQUISICIONViewModel();
                // llena los combos
                modelDatos = new LOGICA_REQUISICION().LLENAR_CONTROLES(modelDatos);
                // saca los valores de los combos
                modelDatos = new LOGICA_REQUISICION().CONSULTAR_VALORES_LISTAS_POR_CODIGO(modelDatos);

                //INICIO Esta logica es para el POP UP----------
                RESPUESTA_POP_UP npc = new RESPUESTA_POP_UP();
                // FIN

                switch (submitButton)
                {
                    case "CREAR REQUISICIÓN":
                        _resultadoIdReguisicion = new LOGICA_REQUISICION().INSERTAR_REQUISICION(modelDatos, User.Identity.GetUserId());
                        if (modelDatos.COD_REQUISICION == 0)
                            npc.METODO = "Crear";
                        else
                            npc.METODO = "Modificar";

                        break;
                    case "APROBAR REQUISICIÓN":

                        if (User.IsInRole(SettingsManager.PerfilRRHH) || User.IsInRole(SettingsManager.PerfilUSC)){
                            Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZAR_REQUISICION(modelDatos));
                            _resultadoIdReguisicion = modelDatos.COD_REQUISICION;
                        }
                        else{
                            _User = User.Identity.GetUserId() ?? Session["COD_ASPNETUSER_CONTROLLER"].ToString();
                            _resultadoIdReguisicion = new LOGICA_REQUISICION().APROBAR_REQUISICION_LOGICA(modelDatos.COD_REQUISICION, _User, modelDatos.OBSERVACION);
                        }
                        npc.METODO = "Aprobar";
                        break;
                    case "Rechazar requisición":
                       
                        _resultadoIdReguisicion = new LOGICA_REQUISICION().REQUISICION_RECHAZAR_LOGICA(modelDatos.COD_REQUISICION, modelDatos.OBSERVACION, User.Identity.Name);
                        npc.METODO = "Rechazar";
                        break;
                    case "Enviar":
                        Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZAR_REQUISICION(modelDatos));
                        _resultadoIdReguisicion = modelDatos.COD_REQUISICION;
                        npc.METODO = "Enviar";
                        break;
                    case "DEVOLVER REQUISICIÓN":
                        _User = User.Identity.GetUserId() ?? Session["COD_ASPNETUSER_CONTROLLER"].ToString();
                        _resultadoIdReguisicion = Convert.ToInt32(new LOGICA_REQUISICION().REQUISICION_MODIFICAR_LOGICA(modelDatos.COD_REQUISICION, modelDatos.OBSERVACION, _User));
                        npc.METODO = "Modificar";
                        break;
                }


                //INICIO Esta logica es para el POP UP----------
                npc.COD_REQUISICION_CREADA = _resultadoIdReguisicion;
                npc.COD_CARGO = modelDatos.COD_CARGO;
                npc.RESULTADO = !_resultadoIdReguisicion.Equals(0);
                TempData["resultado"] = npc;
                //FIN Esta logica es para el POP UP----------
                if (Session["COD_ASPNETUSER_CONTROLLER"] != null) {
                    Session.Remove("COD_ASPNETUSER_CONTROLLER");
                    return RedirectToAction("Consultar", "REQUISICION_PRESUPUESTADA", new {link_controler = "mostrar resultado" });
                }
                
                    return RedirectToAction("Consultar");
            }
            catch
            {
                return View();
            }
        }
    }
}