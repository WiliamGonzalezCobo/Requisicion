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

            REQUISICIONViewModel MODEL_SESSION = new REQUISICIONViewModel();
            if (Session["objetoListas"]==null)
                Session["objetoListas"] = new LOGICA_REQUISICION().LLENAR_CONTROLES(MODEL_SESSION);
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
            Session["requisicion"] = idTipo;
            if (idTipo == SettingsManager.CodTipoReqPresupuestada)
            {
                return RedirectToAction("Index", "REQUISICION_PRESUPUESTADA");
            }
            if (idTipo == SettingsManager.CodTipoReqNoPresupuestada) {
                return RedirectToAction("Index", "REQUISICION_NOPRESUPUESTADA");
            }
            if (idTipo.Equals(SettingsManager.CodTipoReqIncapacidad))
            {
                return RedirectToAction("Index", "LICENCIA_INCAPACIDAD");
            }
            if (idTipo.Equals(SettingsManager.CodTipoReqLicencia))
            {
                return RedirectToAction("Index", "LICENCIA_INCAPACIDAD");
            }
            return View();
        }


        public ActionResult Detalle(int _idRequisicion, int _tipoRequisicion)
        {

            if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqPresupuestada))
            {
                return RedirectToAction("Index", "REQUISICION_PRESUPUESTADA", new { _idReq = _idRequisicion });
            }
            if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqNoPresupuestada))
            {
                return RedirectToAction("Index", "REQUISICION_NOPRESUPUESTADA", new { _idReq = _idRequisicion });
            }
            if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqIncapacidad))
            {
                return RedirectToAction("Index", "LICENCIA_INCAPACIDAD", new { _idReq = _idRequisicion });
            }
            if (_tipoRequisicion.Equals(SettingsManager.CodTipoReqLicencia))
            {
                return RedirectToAction("Index", "LICENCIA_INCAPACIDAD", new { _idReq = _idRequisicion });
            }


            return RedirectToAction("Index");
        }



    }
}