using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION.ACCESS;

namespace LOGICA.REQUISICION_LOGICA
{
    public class LOGICA_REQUISICION
    {


        public List<SelectListItem> CONSULTAR_TIPOS_NECESIDAD(){
            return  new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x=> new SelectListItem() {
                Text= x.NOMBRE_NECESIDAD,
                Value=x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_ESTADOS() {
            return new ACCES_REQUISICION().CONSULTAR_ESTADOS_ACCESS().Select(x=> new SelectListItem() {
                Text = x.NOMBRE_ESTADO,
                Value = x.COD_ESTADO_REQUISICION.ToString()
            }).ToList();
        }


        public List<SelectListItem> CONSULTAR_TIPOS_REQUISICION()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_REQUISICION_ACCESS().Select(x => new SelectListItem(){
                Text = x.NOMBRE_REQUISICION,
                Value = x.COD_TIPO_REQUISICION.ToString()
            }).ToList();
        }

        public List<REQUISICIONViewModel> SOLICITAR_REQUISICIONES(FILTROREQUISICION _filtro) {
            string filtroDb=_filtro.filtro.ToLower() == "Activos" ? "" : _filtro.filtro;
            List<REQUISICIONViewModel> modelo = new List<REQUISICIONViewModel>();
            for (int i = 0; i < 2; i++)
            {
                REQUISICIONViewModel item = new REQUISICIONViewModel();
                item.COD_CARGO = 20738780;
                item.NOMBRE_CARGO_STR = "Ingeniero Desarrollo";
                item.EMAIL_USUARIO_CREACION = "martinezluir@globalhitss.com";
                item.USUARIO_CREACION = "Luis David Martinez Rojas" + i;
                item.NOMBRE_TIPO_REQUISICION = "Presupuestada";
                item.NOMBRE_ESTADO_REQUISICION = "Registrada";
                item.FECHA_CREACION = DateTime.Now.AddDays(-i).ToShortDateString();
                
                modelo.Add(item);
            }
            modelo.Add(new REQUISICIONViewModel()
            {
                COD_CARGO = 758913,
                NOMBRE_CARGO_STR = "Ingeniero Desarrollo",
                EMAIL_USUARIO_CREACION = "martinezluir@globalhitss.com",
                NOMBRE_TIPO_REQUISICION = "No Presupuestada",
                NOMBRE_ESTADO_REQUISICION = "Verificada BP",
                FECHA_CREACION = DateTime.Now.ToShortDateString()
            });

           
            return modelo;
        }

       
    }
}
