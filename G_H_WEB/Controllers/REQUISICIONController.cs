using LOGICA.REQUISICION_LOGICA;
using Microsoft.AspNet.Identity;
using MODELO_DATOS.MODELO_REQUISICION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UTILS.Settings;
namespace G_H_WEB.Controllers
{
    public class REQUISICIONController : Controller
    {

        public ActionResult Index()
        {
           // seccion filtro principal y consulta principal inicio
            FILTROREQUISICION _filtro = new FILTROREQUISICION();
            _filtro.idUsuario = User.Identity.GetUserId();
            if (TempData["tempFiltro"]!=null) { _filtro.cod_estado_requisicion =Convert.ToInt32(TempData["tempFiltro"].ToString());}
            _filtro.porUsuario = TempData["buscarPorUsuario"] as string ?? null;
            if (User.IsInRole(SettingsManager.PerfilJefe)) { _filtro.porUsuario = User.Identity.Name; }
            List<REQUISICIONViewModel> modelo = new LOGICA_REQUISICION().SOLICITAR_REQUISICIONES(_filtro);
            // seccion filtro principal y consulta principal fin

            // seccion ViewBag inicio
            ViewBag.Estado = new LOGICA_REQUISICION().CONSULTAR_ESTADOS();
            ViewBag.Tipo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_REQUISICION();
            ViewBag.valorSeleccionado = _filtro.cod_estado_requisicion == null ? "": _filtro.cod_estado_requisicion.ToString();
            // seccion ViewBag fin

            
            return View(modelo);
        }


        public ActionResult filtros(string filtro)
        {
            TempData["tempFiltro"] = filtro==""?null:filtro;
            return RedirectToAction("Index");
        }

        public ActionResult buscarPorUsuario(string filtro)
        {
            TempData["buscarPorUsuario"] = filtro;
            return RedirectToAction("Index");
        }

        // GET: REQUISICION/Create
        public ActionResult Create(int? idTipo)
        {
            ViewBag.idTipo = idTipo;
            //Session["requisicion"] = idTipo;
            if (idTipo == SettingsManager.CodTipoReqPresupuestada)
            {
                return RedirectToAction("Consultar", "REQUISICION_PRESUPUESTADA", new { _idTipo = idTipo });
            }
            if (idTipo == SettingsManager.CodTipoReqNoPresupuestada) {
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
            return View();
        }


        public ActionResult Detalle(int _idRequisicion, int _tipoRequisicion)
        {
            //Session["requisicion"] = _tipoRequisicion;
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

            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ConsultarTraza(int COD_REQUISICION, string CAMPO_REQUISICION) {
            REQUISICIONViewModel modelDatos = new REQUISICIONViewModel();
            modelDatos = new LOGICA_REQUISICION().LLENAR_CONTROLES(modelDatos); 
            List<SelectListItem> LISTA_ARL = modelDatos.LIST_NIVEL_RIESGO_ARL;
            List<SelectListItem> LISTA_ESTADOS = modelDatos.LIST_NOMBRE_ESTADO_REQUISICION;
            List<SelectListItem> LISTA_CATEGORIA = modelDatos.LIST_NOMBRE_CATEGORIA;
            List<TRAZA_BOTONES_ENTIDAD> datosTraza= new LOGICA_REQUISICION().CONSULTAR_TRAZA_CAMPOS(COD_REQUISICION, CAMPO_REQUISICION, LISTA_ARL, LISTA_ESTADOS, LISTA_CATEGORIA);
            return Json(datosTraza, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultarModificaciones() {
            string COD_USUARIO = User.Identity.GetUserId();
            List<CONSULTA_NOTIFICACIONES_ENTIDAD> datosmodificacion = new LOGICA_REQUISICION().CONSULTA_NOTIFICACIONES(COD_USUARIO);
            return Json(datosmodificacion, JsonRequestBehavior.AllowGet);
        }
    }
}