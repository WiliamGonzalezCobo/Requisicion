﻿using LOGICA.REQUISICION_LOGICA;
using MODELO_DATOS.MODELO_REQUISICION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G_H_WEB.Controllers
{
    public class REQUISICION_NOPRESUPUESTADAController : Controller
    {
        // GET: REQUISICION_NOPRESUPUESTADA
        public ActionResult Index(){
            List<SelectListItem> listaNecesidad = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            NO_PRESUPESTADA_CREACION fromPost = TempData["resultado"] as NO_PRESUPESTADA_CREACION;
            // este filtro se debe hacer sobre la lista NOMBRE_CARGO y no sobre necesidad 
            if (fromPost != null)
                fromPost.NOMBRE_COD_CARGO = listaNecesidad.Where(x => x.Value == fromPost.COD_CARGO.ToString()).First().Text;
            ViewBag.Necesidad = listaNecesidad;
            ViewBag.resultadoNojefe = fromPost!= null?fromPost.RESULTADO:false;
            ViewBag.resultadoPopUpNoJefe = fromPost;
            ViewBag.Options= new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            return View();
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel modelDatos) {
            try{
                // ir hasta base de datos
                NO_PRESUPESTADA_CREACION npc = new NO_PRESUPESTADA_CREACION();
                npc.COD_CARGO = modelDatos.COD_CARGO;
                npc.RESULTADO = true;
                TempData["resultado"] = npc;
                return RedirectToAction("Index");
            } catch (Exception) {
                NO_PRESUPESTADA_CREACION npc = new NO_PRESUPESTADA_CREACION();
                npc.RESULTADO = false;
                TempData["resultado"] = npc;
                return RedirectToAction("Index");
            }
        }
    }
}