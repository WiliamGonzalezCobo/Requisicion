using LOGICA.LICENCIA_INCAPACIDAD_LOGICA;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION_ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G_H_WEB.Controllers
{
    public class LICENCIA_INCAPACIDADController : Controller
    {
       private GESTION_HUMANA_HITSSEntities2 db = new GESTION_HUMANA_HITSSEntities2();
        // GET: LICENCIA_INCAPACIDAD
        public ActionResult Index()
        {           
            REQUISICIONViewModel rvm = new REQUISICIONViewModel();

            rvm.TIPO_DOCUMENTO = new List<SelectListItem>() {
                   new SelectListItem { Text = "C.C", Value = "1" },
                   new SelectListItem { Text = "C.E", Value = "2" },
                   new SelectListItem { Text = "Pasaporte", Value = "3" } };

            rvm.NOMBRE_CARGO = new List<SelectListItem>() {
                   new SelectListItem { Text = "Cargo 1", Value = "1" },
                   new SelectListItem { Text = "Cargo 2", Value = "2" },
                   new SelectListItem { Text = "Cargo 3", Value = "3" }};


            rvm.NOMBRE_GERENCIA_LISTA = new List<SelectListItem>() {
                new SelectListItem { Text = "Gerencia 1", Value = "1" },
                   new SelectListItem { Text = "Gerencia 2", Value = "2" },
                   new SelectListItem { Text = "Gerencia 3", Value = "3" }
                   };


            rvm.NOMBRE_SOCIEDAD_LISTA = new List<SelectListItem>() {
                new SelectListItem { Text = "Sociedad 1", Value = "1" },
                   new SelectListItem { Text = "Sociedad 2", Value = "2" },
                   new SelectListItem { Text = "Sociedad 3", Value = "3" }
                   };


            rvm.COD_EQUIPO_VENTAS_LISTA = new List<SelectListItem>() {
                new SelectListItem { Text = "Eq Ventas 1", Value = "1" },
                   new SelectListItem { Text = "Eq Ventas 2", Value = "2" },
                   new SelectListItem { Text = "Eq Ventas 3", Value = "3" }
                   };
                       

            rvm.COD_CATEGORIA_ED_LISTA = new List<SelectListItem>() {
                new SelectListItem { Text = "Categoria 1", Value = "1" },
                   new SelectListItem { Text = "Categoria 2", Value = "2" },
                   new SelectListItem { Text = "Categoria 3", Value = "3" }
                   };


            rvm.LIST_NOMBRE_TIPO_CONTRATO = new List<SelectListItem>(){
                new SelectListItem { Text = "Indefinido" , Value ="1" },
                new SelectListItem { Text = "Termino Fijo" , Value ="2" },
                new SelectListItem { Text = "Prestacion de servicios" , Value ="3" }
            };

            rvm.LIST_NIVEL_RIESGO_ARL = new List<SelectListItem>() {
                new SelectListItem { Text = "Nivel ARL 1" , Value ="1" },
                new SelectListItem { Text = "Nivel ARL 2" , Value ="2" },
                new SelectListItem { Text = "Nivel ARL 3" , Value ="3" }
            };

            rvm.LIST_NOMBRE_TIPO_SALARIO = new List<SelectListItem>() {
                new SelectListItem { Text = "T Salario 1" , Value ="1" },
                new SelectListItem { Text = "T Salario 2" , Value ="2" },
                new SelectListItem { Text = "T Salario 3" , Value ="3" }
            };

            rvm.LIST_NOMBRE_CATEGORIA = new List<SelectListItem>() {
                new SelectListItem { Text = "L Categoria 1" , Value ="1" },
                new SelectListItem { Text = "L Categoria 2" , Value ="2" },
                new SelectListItem { Text = "L Categoria 3" , Value ="3" }
            };

            ViewBag.resultado = TempData["resultado"] ?? false;

            return View(rvm);
        }

        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel model)
        {
            if(model.COD_TIPO_REQUISICION == 0)
                model.COD_TIPO_REQUISICION = 3;
            if(model.COD_ESTADO_REQUISICION == 0)
                model.COD_ESTADO_REQUISICION = 1;
            if(model.COD_TIPO_NECESIDAD==0)
                model.COD_TIPO_NECESIDAD = 2;
            if(model.USUARIO_CREACION==null)
                model.USUARIO_CREACION = User.Identity.Name; 
            if (model.COD_ESTADO_REQUISICION == 0)
                model.COD_ESTADO_REQUISICION = 1;
            
            


            string Respuesta = new LOGICA_LICENCIA_INCAPACIDAD().INSERTAR_LICENCIA_INCAPACIDAD(model);
            if (Respuesta == "Exitoso")
            {
                TempData["resultado"] = "true";
            }

            //TempData["resultado"] = "true";
            return RedirectToAction("Index", "licencia_incapacidad");
        }

        [HttpPost]
        public ActionResult Guardar_click(REQUISICIONViewModel model)
        {
            // implementamos Silvia

            TempData["resultadoModelo"].Equals(model);

            
            
            return RedirectToAction("Index", "licencia_incapacidad");
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

    }
}