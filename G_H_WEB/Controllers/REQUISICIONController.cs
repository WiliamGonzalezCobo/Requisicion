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
            FILTROREQUISICION _filtro = new FILTROREQUISICION();
            List<SelectListItem> lista_estado = new LOGICA_REQUISICION().CONSULTAR_ESTADOS();
            ViewBag.Estado = lista_estado;
            ViewBag.Tipo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_REQUISICION();
            _filtro.idUsuario = User.Identity.GetUserId();
            _filtro.filtro = TempData["tempFiltro"] as string ?? "";
            _filtro.porUsuario = TempData["buscarPorUsuario"] as string ?? "";
            List<REQUISICIONViewModel> modelo = new LOGICA_REQUISICION().SOLICITAR_REQUISICIONES(_filtro);
            ViewBag.valorSeleccionado = _filtro.filtro == "" ? "" : lista_estado.Where(x => x.Text == _filtro.filtro).First().Value;
            return View(modelo);
        }

        public ActionResult filtros(string filtro)
        {
            TempData["tempFiltro"] = filtro;
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
            if (idTipo == SettingsManager.CodTipoReqNoPresupuestada)
                return RedirectToAction("Index", "REQUISICION_NOPRESUPUESTADA");
            else
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

            return RedirectToAction("Index");
        }



    }
}