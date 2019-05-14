using LOGICA.REQUISICION_LOGICA;
using MODELO_DATOS.MODELO_REQUISICION;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace G_H_WEB.Controllers
{
    public class REQUISICIONController : Controller
    {
        LOGICA_REQUISICION requisicionLogica;

        public ActionResult Index(){
           LOGICA_REQUISICION logica = new LOGICA_REQUISICION();
            List<REQUISICIONViewModel> modelo = new List<REQUISICIONViewModel>();
            for (int i = 0; i < 2; i++){
                REQUISICIONViewModel item = new REQUISICIONViewModel();
                item.COD_CARGO = 11111 + i;
                item.EMAIL_USUARIO_CREACION = "asda@asd.asd";
                item.USUARIO_CREACION = "usuario" + i;
                item.NOMBRE_TIPO_REQUISICION = "REQUISICION" + i;
                item.NOMBRE_ESTADO_REQUISICION = "ESTADO" + i;
                item.FECHA_CREACION = DateTime.Now.AddDays(-i).ToShortDateString();
                modelo.Add(item);
            }
          
            ViewBag.Estado = new LOGICA_REQUISICION().CONSULTAR_ESTADOS();
            ViewBag.Tipo = new LOGICA_REQUISICION().CONSULTAR_TIPOS_REQUISICION();
            return View(modelo);
        }
		
		 // GET: REQUISICION/Create
        public ActionResult Create(int? idTipo)
        {
            
            Session["requisicion"] = idTipo;
            if (idTipo != null)
            {
                if (idTipo == 1)
                {
                    return RedirectToAction("Index", "REQUISICION_PRESUPUESTADA");
                }
                else {
                    return View();
                }
                
            }
            else
            {
                ViewBag.scripCall = "ValidarModificacion();";
                return new EmptyResult();

            }
            //
        }


        private void LlenarControles()
        {
    


            List<SelectListItem> lsTipo = new List<SelectListItem>();
            for (int i = 0; i < 3; i++)
            {
                lsTipo.Add(new SelectListItem() { Text = "REQUISICION" + i, Value = i.ToString() });
            }
            ViewBag.Tipo = lsTipo;


        }

    // POST: REQUISICION/Create
    [HttpPost]

        public ActionResult Create(REQUISICIONViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View();
                }
                return View();
                // TODO: Add insert logic here
                //return PartialView("Modificacion", collection);

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Modificacion()
        {
            LlenarControles();
            try
            {

                return View();
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public JsonResult CrearModificacion(REQUISICIONViewModel model)
        {
            //enviar a base
            //bool response = true;
            return Json(model);
        }

        [HttpPost]
        public JsonResult EnviarModificacion(REQUISICIONViewModel model)
        {
            LlenarControles();
            try
            {
                model.ES_MODIFICACION = true;
                //enviar a base
                return Json(model);
            }
            catch
            {
                return Json(model);
            }
        }



        [HttpPost]
        public JsonResult EnviarInfocreacion(REQUISICIONViewModel model)
        {

            try
            {

                var a = model.NOMBRE_CARGO;


                //enviar a base
                return Json(model);
            }
            catch
            {
                return Json(model);
            }
        }


     

        //[HttpPost]
        public ActionResult SelectRequisicion()
        {
            try
            {
                // TODO: Add delete logic here

                return PartialView("_SelectRequisicion");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Licencia_Incapacidad() {
            REQUISICIONViewModel rvm = new REQUISICIONViewModel();

            rvm.TIPO_DOCUMENTO = new List<SelectListItem>() {
                   new SelectListItem { Text = "C.C", Value = "1" },
                   new SelectListItem { Text = "C.E", Value = "2" },
                   new SelectListItem { Text = "Pasaporte", Value = "3" } };

            rvm.NOMBRE_CARGO = new List<SelectListItem>() {
                   new SelectListItem { Text = "Nombre 1", Value = "1" },
                   new SelectListItem { Text = "Nombre 2", Value = "2" },
                   new SelectListItem { Text = "Nombre 3", Value = "3" }};


            rvm.NOMBRE_GERENCIA_LISTA = new List<SelectListItem>() {
                new SelectListItem { Text = "Nombre 1", Value = "1" },
                   new SelectListItem { Text = "Nombre 2", Value = "2" },
                   new SelectListItem { Text = "Nombre 3", Value = "3" }
                   };


            rvm.NOMBRE_SOCIEDAD_LISTA = new List<SelectListItem>() {
                new SelectListItem { Text = "Nombre 1", Value = "1" },
                   new SelectListItem { Text = "Nombre 2", Value = "2" },
                   new SelectListItem { Text = "Nombre 3", Value = "3" }
                   };


            rvm.COD_EQUIPO_VENTAS_LISTA = new List<SelectListItem>() {
                new SelectListItem { Text = "Nombre 1", Value = "1" },
                   new SelectListItem { Text = "Nombre 2", Value = "2" },
                   new SelectListItem { Text = "Nombre 3", Value = "3" }
                   };




            rvm.COD_CATEGORIA_ED_LISTA = new List<SelectListItem>() {
                new SelectListItem { Text = "Nombre 1", Value = "1" },
                   new SelectListItem { Text = "Nombre 2", Value = "2" },
                   new SelectListItem { Text = "Nombre 3", Value = "3" }
                   };

            //ViewBag.resultado = TempData["resultado"]??false;

            return View (rvm);
        }

        [HttpPost]
        public ActionResult Licencia_Incapacidad(REQUISICIONViewModel model)
        {
            // implementamos Silvia

            TempData["resultado"] = true;
            return   RedirectToAction("Licencia_Incapacidad", "REQUISICION");
        }
		
		 public ActionResult No_Presupuestada()
        {
            List<SelectListItem> lstAux = new List<SelectListItem>();
            List<SelectListItem> lstAuxLab = new List<SelectListItem>();

            lstAux.Add(new SelectListItem() { Text = "Tipo 1", Value = "1" });
            lstAux.Add(new SelectListItem() { Text = "Tipo 2", Value = "2" });
            lstAux.Add(new SelectListItem() { Text = "Tipo 3", Value = "3" });
            lstAux.Add(new SelectListItem() { Text = "Tipo 4", Value = "4" });
            
            lstAuxLab.Add(new SelectListItem() { Text = "Tiempo Parcial", Value = "TP" });
            lstAuxLab.Add(new SelectListItem() { Text = "Tiempo Completo", Value = "TC" });
            lstAuxLab.Add(new SelectListItem() { Text = "Medio Tiempo", Value = "MT" });

            ViewBag.Options = lstAux;
            ViewBag.OptionsLab = lstAuxLab;

            return View();
        }

        [HttpPost]
        public ActionResult Aprobar_Click(REQUISICIONViewModel requisitionModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    requisicionLogica = new LOGICA_REQUISICION();
                    //requisicionLogica.AgregarRequisicion(requisitionModel);
                    return View();
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public REQUISICIONViewModel Modificar_Click(REQUISICIONViewModel requisitionModel)
        {
            try
            {
                return requisitionModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public REQUISICIONViewModel Rechazar_Click(REQUISICIONViewModel requisitionModel)
        {
            try
            {
                return requisitionModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}