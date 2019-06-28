using G_H_WEB.Logica_Session;
using G_H_WEB.Models;
using log4net;
using LOGICA.REQUISICION_LOGICA;
using Microsoft.AspNet.Identity;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.TRAZA_LOG;
using MODELO_DATOS.MODELO_REQUISICION.LISTAS_API;
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
        private LOG_CENTRALIZADO logCentralizado = new LOG_CENTRALIZADO(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));
        public ActionResult Consultar(int? _idReq, int? _idTipo, string link_controler = "", string COD_ASPNETUSER_CONTROLLER = "")
        {
            if (COD_ASPNETUSER_CONTROLLER != "") { Session["COD_ASPNETUSER_CONTROLLER"] = COD_ASPNETUSER_CONTROLLER; }
            if (TempData["ErrorPost"] != null)
            {
                ViewBag.Error = (ERROR_GENERAL_ViewModel)TempData["ErrorPost"];
            }
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            try
            {
                logCentralizado.INICIANDO_LOG("CTR_REQ_NO_PRE1", "Consultar");
                
                if (_idReq.HasValue)
                {
                    string _USER = User.Identity.GetUserId() ?? Session["COD_ASPNETUSER_CONTROLLER"].ToString();
                    model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value, link_controler, _USER);
                    if (model == null)
                    {
                        ViewBag.ReqModificada = false;
                        Session.Remove("COD_ASPNETUSER_CONTROLLER");
                        return RedirectToAction("ConsultarRequisiciones", "REQUISICION");
                    }
                    else
                    {
                        ViewBag.ReqModificada = true;
                    }
                    if (User.IsInRole(SettingsManager.PerfilBp) && (!model.COD_ESTADO_REQUISICION.Equals(SettingsManager.EstadoDevueltaRRHH) && !model.COD_ESTADO_REQUISICION.Equals(SettingsManager.EstadoDevueltaUSC)))
                    {
                        model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES_BP(model) ?? new REQUISICIONViewModel();
                    }
                }

                if (_idReq != null)
                {
                    if (!User.IsInRole(SettingsManager.PerfilJefe) && !User.IsInRole(SettingsManager.PerfilController))
                    {
                        List<TRAZA_BOTONES_VISIBLES> _listaCampos = new LOGICA_REQUISICION().CONSULTAR_CAMPOS_TRAZAS_VISIBLES(_idReq.Value);
                        ViewBag.traza = _listaCampos;
                        ViewBag.ReqModificada = true;
                    }
                }
                else
                {
                    ViewBag.ReqModificada = false;
                }

                LOGICA_REQUISICION logicaReq = new LOGICA_REQUISICION(
                    User.IsInRole(SettingsManager.PerfilJefe),
                    User.IsInRole(SettingsManager.PerfilController),
                    User.IsInRole(SettingsManager.PerfilBp),
                    User.IsInRole(SettingsManager.PerfilRRHH),
                    User.IsInRole(SettingsManager.PerfilUSC)
                    );
                model = logicaReq.LLENAR_CONTROLES(model,SettingsManager.CodTipoReqNoPresupuestada);

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
                ViewBag.Busca_USUARIOS = new LOGICA_REQUISICION().CONSULTAR_EMPLEADOS();
                ViewBag.PERMISOS_CONTROLLER = link_controler;
                logCentralizado.FINALIZANDO_LOG("CTR_REQ_NO_PRE1", "Consultar");
                if (TempData["listadoErroresModelo"] != null)
                {
                    model.LIST_VALIDACION_ERRORES = (List<VALIDACION_ERRORES_ViewModel>)TempData["listadoErroresModelo"];
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTR_REQ_NO_PRE1", "Consultar", ex),
                    DETALLE = "error al consultar la requisicion"
                };
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Procesar(REQUISICIONViewModel modelDatos, string submitButton, int? _idTipo)
        {
            try
            {
                VALIDACION_MODEL_REQUISICION valModelReq = new VALIDACION_MODEL_REQUISICION(
                    User.IsInRole(SettingsManager.PerfilJefe),
                    User.IsInRole(SettingsManager.PerfilController),
                    User.IsInRole(SettingsManager.PerfilBp),
                    User.IsInRole(SettingsManager.PerfilRRHH),
                    User.IsInRole(SettingsManager.PerfilUSC)
                    );
                
                logCentralizado.INICIANDO_LOG("CTR_REQ_NO_PRE2", "Procesar");
                string _User = "";
                int _resultadoIdReguisicion = 0;
                modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqNoPresupuestada;
                modelDatos.USUARIO_CREACION = User.Identity.Name;
                modelDatos.USUARIO_MODIFICACION = User.Identity.Name;
                REQUISICIONViewModel listas = new REQUISICIONViewModel();
                // llena los combos
                LOGICA_REQUISICION logicaReq = new LOGICA_REQUISICION(
                    User.IsInRole(SettingsManager.PerfilJefe),
                    User.IsInRole(SettingsManager.PerfilController),
                    User.IsInRole(SettingsManager.PerfilBp),
                    User.IsInRole(SettingsManager.PerfilRRHH),
                    User.IsInRole(SettingsManager.PerfilUSC)
                    );
                modelDatos = logicaReq.LLENAR_CONTROLES(modelDatos,modelDatos.COD_TIPO_REQUISICION);
                // saca los valores de los combos
                modelDatos = new LOGICA_REQUISICION().CONSULTAR_VALORES_LISTAS_POR_CODIGO(modelDatos);

                //INICIO Esta logica es para el POP UP----------
                RESPUESTA_POP_UP npc = new RESPUESTA_POP_UP();
                // FIN


                //Valida si los datos del modelo son validos para almacenar en la base de datos
                modelDatos.LIST_VALIDACION_ERRORES = valModelReq.ValidarModelo(modelDatos, modelDatos.COD_TIPO_REQUISICION, submitButton);
                if (modelDatos.LIST_VALIDACION_ERRORES.Count <= 0)
                {
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
                            if (User.IsInRole(SettingsManager.PerfilRRHH) || User.IsInRole(SettingsManager.PerfilUSC))
                            {
                                Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZAR_REQUISICION(modelDatos));
                                _resultadoIdReguisicion = modelDatos.COD_REQUISICION;
                            }
                            else
                            {
                                _User = User.Identity.GetUserId() ?? Session["COD_ASPNETUSER_CONTROLLER"].ToString();
                                _resultadoIdReguisicion = new LOGICA_REQUISICION().APROBAR_REQUISICION_LOGICA(modelDatos.COD_REQUISICION, _User, modelDatos.OBSERVACION);
                            }

                            npc.METODO = "Aprobar";
                            break;
                        case "ENVIAR RESPUESTA":
                            modelDatos.OBSERVACION = string.Format("Motivo Rechazo: {0}", modelDatos.OBSERVACION);
                            _resultadoIdReguisicion = new LOGICA_REQUISICION().REQUISICION_RECHAZAR_LOGICA(modelDatos.COD_REQUISICION, modelDatos.OBSERVACION, User.Identity.Name);

                            npc.METODO = "Rechazar";
                            break;
                        case "Enviar Requisición":
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
                }
                else
                {
                    TempData["listadoErroresModelo"] = modelDatos.LIST_VALIDACION_ERRORES;
                }

                //INICIO Esta logica es para el POP UP----------
                npc.COD_REQUISICION_CREADA = _resultadoIdReguisicion;
                npc.COD_CARGO = modelDatos.COD_CARGO;
                npc.RESULTADO = !_resultadoIdReguisicion.Equals(0);
                TempData["resultado"] = npc;
                //FIN Esta logica es para el POP UP----------

                if (Session["COD_ASPNETUSER_CONTROLLER"] != null)
                {
                    Session.Remove("COD_ASPNETUSER_CONTROLLER");
                    return RedirectToAction("Consultar", "REQUISICION_PRESUPUESTADA", new { link_controler = "mostrar resultado" });
                }

                logCentralizado.FINALIZANDO_LOG("CTR_REQ_NO_PRE2", "Procesar");
                return RedirectToAction("Consultar");
            }
            catch (Exception ex)
            {
                TempData["ErrorPost"] = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTR_REQ_NO_PRE2", "Procesar", ex),
                    DETALLE = "error al procesar la requisicion"
                };
                return RedirectToAction("Consultar");
            }
        }

 
    }
}