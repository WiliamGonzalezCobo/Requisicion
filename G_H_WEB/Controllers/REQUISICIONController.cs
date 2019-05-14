using LOGICA.REQUISICION_LOGICA;
using Microsoft.AspNet.Identity;
using MODELO_DATOS.MODELO_REQUISICION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace G_H_WEB.Controllers
{
    public class REQUISICIONController : Controller
    {

        LOGICA_REQUISICION requisicionLogica;

        public ActionResult Index(){
            FILTROREQUISICION _filtro = new FILTROREQUISICION();
            List <SelectListItem> lista_estado= new LOGICA_REQUISICION().CONSULTAR_ESTADOS();
            ViewBag.Estado = lista_estado;
            ViewBag.Tipo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_REQUISICION();
            _filtro.idUsuario = User.Identity.GetUserId();
            _filtro.filtro = TempData["tempFiltro"] as string ?? "";
            _filtro.porUsuario = TempData["buscarPorUsuario"] as string ?? "";
            List<REQUISICIONViewModel> modelo = new LOGICA_REQUISICION().SOLICITAR_REQUISICIONES(_filtro);
            ViewBag.valorSeleccionado = _filtro.filtro == "" ? "" : lista_estado.Where(x => x.Text == _filtro.filtro).First().Value;
            return View(modelo);
        }

        public ActionResult filtros(string filtro){
            TempData["tempFiltro"] = filtro;
           return RedirectToAction("Index");
        }

        public ActionResult buscarPorUsuario(string filtro){
            TempData["buscarPorUsuario"] = filtro;
            return RedirectToAction("Index");
        }




        // GET: REQUISICION/Create
        public ActionResult Create(int? idTipo) {
            if (idTipo == 2)
                return RedirectToAction("Index", "REQUISICION_NOPRESUPUESTADA");
            else
                return View();
            
        }


        public ActionResult Detalle(int _idRequisicion, string _tipoRequisicion) {
            if(_tipoRequisicion.ToLower()=="no presupuestada")
                return RedirectToAction("Detail", "REQUISICION_NOPRESUPUESTADA",new { idRequsicion= _idRequisicion });
            return null;
        }



    }
}