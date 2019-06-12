using G_H_WEB.Logica_Session;
using LOGICA.REQUISICION_LOGICA;
using Microsoft.AspNet.Identity;
using MODELO_DATOS.MODELO_REQUISICION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using UTILS.Settings;
using log4net;
using G_H_WEB.Models;
using System.Threading;
using REPOSITORIOS.TRAZA_LOG;

namespace G_H_WEB.Controllers
{
    [CustAuthFilter]
    public class REQUISICIONController : Controller
    {
        private LOG_CENTRALIZADO logCentralizado = new LOG_CENTRALIZADO(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));

        public ActionResult Index()
        {
            List<REQUISICIONViewModel> listaRequisicionesModel = null;
            try
            {
                logCentralizado.INICIANDO_LOG("CTRREQ1", "Index");
                // seccion filtro principal y consulta principal inicio
                FILTROREQUISICION _filtro = new FILTROREQUISICION();
                _filtro.idUsuario = User.Identity.GetUserId();
                if (TempData["tempFiltro"] != null) { _filtro.cod_estado_requisicion = Convert.ToInt32(TempData["tempFiltro"].ToString()); }
                _filtro.porUsuario = TempData["buscarPorUsuario"] as string ?? null;
                if (User.IsInRole(SettingsManager.PerfilJefe)) { _filtro.porUsuario = User.Identity.Name; }
                listaRequisicionesModel = new LOGICA_REQUISICION().SOLICITAR_REQUISICIONES(_filtro);
                // seccion filtro principal y consulta principal fin

                // seccion ViewBag inicio
                ViewBag.Estado = new LOGICA_REQUISICION().CONSULTAR_ESTADOS();
                ViewBag.Tipo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_REQUISICION();
                ViewBag.valorSeleccionado = _filtro.cod_estado_requisicion == null ? "" : _filtro.cod_estado_requisicion.ToString();
                // seccion ViewBag fin

                logCentralizado.FINALIZANDO_LOG("CTRREQ1", "Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTRREQ1", "Index", ex),
                    DETALLE = "Error al consultar las requisiciones"
                };
            }

            return View(listaRequisicionesModel);
        }


        public ActionResult filtros(string filtro)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("CTRREQ2", "filtros");

                TempData["tempFiltro"] = filtro == "" ? null : filtro;

                logCentralizado.FINALIZANDO_LOG("CTRREQ2", "filtros");
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTRREQ2", "filtros", ex),
                    DETALLE = "Error al consultar los filtros"
                };
            }

            return RedirectToAction("Index");
        }

        public ActionResult buscarPorUsuario(string filtro)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("CTRREQ3", "buscarPorUsuario");
                TempData["buscarPorUsuario"] = filtro;

                logCentralizado.FINALIZANDO_LOG("CTRREQ3", "buscarPorUsuario");
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTRREQ3", "buscarPorUsuario", ex),
                    DETALLE = "Error al buscar por usuario"
                };
            }

            return RedirectToAction("Index");
        }

        // GET: REQUISICION/Create
        public ActionResult Create(int? idTipo)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("CTRREQ4", "Create");
                ViewBag.idTipo = idTipo;
                //Session["requisicion"] = idTipo;
                if (idTipo == SettingsManager.CodTipoReqPresupuestada)
                {
                    return RedirectToAction("Consultar", "REQUISICION_PRESUPUESTADA", new { _idTipo = idTipo });
                }
                if (idTipo == SettingsManager.CodTipoReqNoPresupuestada)
                {
                    return RedirectToAction("Consultar", "REQUISICION_NOPRESUPUESTADA", new { _idTipo = idTipo });
                }
                if (idTipo.Equals(SettingsManager.CodTipoReqIncapacidad))
                {
                    return RedirectToAction("Consultar", "LICENCIA_INCAPACIDAD", new { _idTipo = idTipo });
                }
                if (idTipo.Equals(SettingsManager.CodTipoReqLicencia))
                {
                    return RedirectToAction("Consultar", "LICENCIA_INCAPACIDAD", new { _idTipo = idTipo });
                }

                logCentralizado.FINALIZANDO_LOG("CTRREQ4", "Create");

            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTRREQ4", "Create", ex),
                    DETALLE = "error al crear una requisicion"
                };
            }

            return View();
        }


        public ActionResult Detalle(int _idRequisicion, int _tipoRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("CTRREQ5", "Detalle");
                ViewBag.idTipo = _tipoRequisicion;
                if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqPresupuestada))
                {
                    return RedirectToAction("Consultar", "REQUISICION_PRESUPUESTADA", new { _idReq = _idRequisicion, _idTipo = _tipoRequisicion });
                }
                if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqNoPresupuestada))
                {
                    return RedirectToAction("Consultar", "REQUISICION_NOPRESUPUESTADA", new { _idReq = _idRequisicion, _idTipo = _tipoRequisicion });
                }
                if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqIncapacidad))
                {
                    return RedirectToAction("Consultar", "LICENCIA_INCAPACIDAD", new { _idReq = _idRequisicion, _idTipo = _tipoRequisicion });
                }
                if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqLicencia))
                {
                    return RedirectToAction("Consultar", "LICENCIA_INCAPACIDAD", new { _idReq = _idRequisicion, _idTipo = _tipoRequisicion });
                }

                logCentralizado.FINALIZANDO_LOG("CTRREQ5", "Detalle");

            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTRREQ5", "Detalle", ex),
                    DETALLE = "error al ver detalle"
                };
            }
            return RedirectToAction("Index");
        }


        public JsonResult ConsultarTraza(int COD_REQUISICION, string CAMPO_REQUISICION)
        {
            List<TRAZA_BOTONES_ENTIDAD> datosTraza = null;
            try
            {
                logCentralizado.INICIANDO_LOG("CTRREQ6", "ConsultarTraza");
                REQUISICIONViewModel modelDatos = new REQUISICIONViewModel();
                modelDatos = new LOGICA_REQUISICION().LLENAR_CONTROLES(modelDatos);
                List<SelectListItem> LISTA_ARL = modelDatos.LIST_NIVEL_RIESGO_ARL;
                List<SelectListItem> LISTA_ESTADOS = modelDatos.LIST_NOMBRE_ESTADO_REQUISICION;
                List<SelectListItem> LISTA_CATEGORIA = modelDatos.LIST_NOMBRE_CATEGORIA;
                datosTraza = new LOGICA_REQUISICION().CONSULTAR_TRAZA_CAMPOS(COD_REQUISICION, CAMPO_REQUISICION, LISTA_ARL, LISTA_ESTADOS, LISTA_CATEGORIA);

                logCentralizado.FINALIZANDO_LOG("CTRREQ6", "ConsultarTraza");

            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTRREQ6", "ConsultarTraza", ex),
                    DETALLE = "error al consultar trazas"
                };
            }

            return Json(datosTraza, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultarModificaciones()
        {
            List<CONSULTA_NOTIFICACIONES_ENTIDAD> datosmodificacion = null;
            try
            {
                logCentralizado.INICIANDO_LOG("CTRREQ7", "ConsultarModificaciones");

                string COD_USUARIO = User.Identity.GetUserId();
                datosmodificacion = new LOGICA_REQUISICION().CONSULTA_NOTIFICACIONES(COD_USUARIO);

                logCentralizado.FINALIZANDO_LOG("CTRREQ7", "ConsultarModificaciones");
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTRREQ7", "ConsultarModificaciones", ex),
                    DETALLE = "error al crear una requisicion"
                };
            }

            return Json(datosmodificacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultarUsuario()
        {
            List<CONSULTA_USUARIO_ENTIDAD> datosUsuario = null;
            try
            {
                logCentralizado.INICIANDO_LOG("CTRREQ8", "ConsultarUsuario");

                string COD_USUARIO = User.Identity.GetUserId();
                datosUsuario = new LOGICA_REQUISICION().CONSULTA_USUARIOS(COD_USUARIO);

                logCentralizado.FINALIZANDO_LOG("CTRREQ7", "ConsultarModificaciones");
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTRREQ8", "ConsultarUsuario", ex),
                    DETALLE = "error al consultar datos del usuario"
                };
            }

            return Json(datosUsuario, JsonRequestBehavior.AllowGet);
        }
    }
}