using G_H_WEB.Logica_Session;
using G_H_WEB.Models;
using log4net;
using LOGICA.REQUISICION_LOGICA;
using Microsoft.AspNet.Identity;
using MODELO_DATOS.MODELO_REQUISICION;
using MODELO_DATOS.MODELO_REQUISICION.LISTAS_API;
using REPOSITORIOS.TRAZA_LOG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UTILS.Settings;

namespace G_H_WEB.Controllers
{
    [CustAuthFilter]
    public class LICENCIA_INCAPACIDADController : Controller
    {
        private LOG_CENTRALIZADO logCentralizado = new LOG_CENTRALIZADO(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));
        // GET: REQUISICION_NOPRESUPUESTADA
        public ActionResult Consultar(int? _idReq, int? _idTipo)
        {
            if (TempData["ErrorPost"] != null)
            {
                ViewBag.Error = (ERROR_GENERAL_ViewModel)TempData["ErrorPost"];
            }
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            try
            {
                logCentralizado.INICIANDO_LOG("CTR_REQ_LIC_INC1", "Consultar");
                ViewBag._idTipo = _idTipo;
                if (TempData["_idTipo"] != null)
                {
                    _idTipo = Convert.ToInt32(TempData["_idTipo"]);
                }
                if (_idTipo != null)
                {
                    if (SettingsManager.CodTipoReqLicencia.Equals(_idTipo))
                    {
                        ViewBag.RequisicionNombre = "Requisicion Licencia";
                    }
                    else if (SettingsManager.CodTipoReqIncapacidad.Equals(_idTipo))
                    {
                        ViewBag.RequisicionNombre = "Requisicion Incapacidad";
                    }
                }
                else
                {
                    return RedirectToAction("Index", "REQUISICION");
                }
                
                if (_idReq.HasValue)
                {
                    model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value) ?? new REQUISICIONViewModel();
                }
                model.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqLicencia;
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
                //FIN POP UP
                ViewBag.Busca_USUARIOS = new LOGICA_REQUISICION().CONSULTAR_EMPLEADOS_LICENCIA_INCAPACIDADES();

                logCentralizado.FINALIZANDO_LOG("CTR_REQ_LIC_INC1", "Consultar");

            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTR_REQ_LIC_INC1", "Consultar", ex),
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
                logCentralizado.INICIANDO_LOG("CTR_REQ_LIC_INC2", "Procesar");
                if (TempData["_idTipo"] != null)
                {
                    _idTipo = Convert.ToInt32(TempData["_idTipo"]);
                }
                if (_idTipo != null)
                {
                    if (SettingsManager.CodTipoReqLicencia.Equals(_idTipo))
                    {
                        modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqLicencia;
                    }
                    else if (SettingsManager.CodTipoReqIncapacidad.Equals(_idTipo))
                    {
                        modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqIncapacidad;
                    }
                }
                else
                {
                    return RedirectToAction("Index", "REQUISICION");
                }

                int _resultadoIdReguisicion = 0;
                
                modelDatos.USUARIO_CREACION = User.Identity.Name;
                modelDatos.USUARIO_MODIFICACION = User.Identity.Name;//      martinezluir esto es para test toca hacer la logica
                // llena los combos
                modelDatos = new LOGICA_REQUISICION().LLENAR_CONTROLES(modelDatos);
                // saca los valores de los combos
                modelDatos = new LOGICA_REQUISICION().CONSULTAR_VALORES_LISTAS_POR_CODIGO(modelDatos);

                //INICIO Esta logica es para el POP UP----------
                RESPUESTA_POP_UP npc = new RESPUESTA_POP_UP();
                // FIN

                switch (submitButton)
                {
                    case "Crear Requisición":
                        _resultadoIdReguisicion = new LOGICA_REQUISICION().INSERTAR_REQUISICION(modelDatos);
                        if (modelDatos.COD_REQUISICION == 0)
                            npc.METODO = "Crear";
                        else
                            npc.METODO = "Modificar";

                        break;
                    case "Aprobar":
                        if (User.IsInRole(SettingsManager.PerfilRRHH) || User.IsInRole(SettingsManager.PerfilUSC))
                        {
                            Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZAR_REQUISICION(modelDatos));
                            _resultadoIdReguisicion = modelDatos.COD_REQUISICION;
                        }
                        else
                        {
                            _resultadoIdReguisicion = new LOGICA_REQUISICION().APROBAR_REQUISICION_LOGICA(modelDatos.COD_REQUISICION, User.Identity.GetUserId(), modelDatos.OBSERVACION);
                        }
                        npc.METODO = "Aprobar";
                        break;
                    case "Rechazar":
                        _resultadoIdReguisicion = new LOGICA_REQUISICION().REQUISICION_RECHAZAR_LOGICA(modelDatos.COD_REQUISICION, modelDatos.OBSERVACION, User.Identity.Name);
                        npc.METODO = "Rechazar";
                        break;
                    case "Enviar":
                        Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZAR_REQUISICION(modelDatos));
                        _resultadoIdReguisicion = modelDatos.COD_REQUISICION;
                        npc.METODO = "Enviar";
                        break;
                    case "Modificar":
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
                logCentralizado.FINALIZANDO_LOG("CTR_REQ_LIC_INC2", "Procesar");
                return RedirectToAction("Consultar");
            }
            catch (Exception ex)
            {
                TempData["ErrorPost"] = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTR_REQ_LIC_INC2", "Procesar", ex),
                    DETALLE = "error al procesar la requisicion"
                };
                return RedirectToAction("Consultar");
            }
        }

        [HttpGet]
        public JsonResult ConsultarCargo(string NUMERO_DOCUMENTO_EMPLEADO)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("CTR_REQ_LIC_INC3", "ConsultarCargo");

                if (!string.IsNullOrEmpty(NUMERO_DOCUMENTO_EMPLEADO) && !NUMERO_DOCUMENTO_EMPLEADO.Equals(0))
                {
                    PUESTO datosCargo = new LOGICA_REQUISICION().BUSCAR_PUESTO_X_CARGO_API(NUMERO_DOCUMENTO_EMPLEADO);

                    return Json(datosCargo, JsonRequestBehavior.AllowGet);
                }

                logCentralizado.FINALIZANDO_LOG("CTR_REQ_LIC_INC3", "ConsultarCargo");

            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTR_REQ_LIC_INC3", "ConsultarCargo", ex),
                    DETALLE = "error al consultar puesto por cargo"
                };
            }


            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
    }
}