using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LOGICA.LOGICA_REQUISICION;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION.ACCESS;

namespace LOGICA.REQUISICION_LOGICA
{
    public class LOGICA_REQUISICION
    {

        public REQUISICIONViewModel LLENAR_CONTROLES(REQUISICIONViewModel MODEL_RETURN) {

            MODEL_RETURN.LIST_NOMBRE_TIPO_NECESIDAD = CONSULTAR_TIPOS_NECESIDAD();
            MODEL_RETURN.LIST_NOMBRE_ESTADO_REQUISICION = CONSULTAR_ESTADOS();
            MODEL_RETURN.LIST_NOMBRE_CECO = CONSULTAR_CECOS();
            MODEL_RETURN.LIST_NOMBRE_EQIPO_VENTAS = CONSULTAR_EQUIPOS_VENTAS();
            MODEL_RETURN.LIST_NIVEL_RIESGO_ARL = CONSULTAR_RIESGOS_ARL();
            MODEL_RETURN.LIST_NOMBRE_CATEGORIA_ED = CONSULTAR_CATEGORIAS_ED();
            MODEL_RETURN.LIST_NOMBRE_SOCIEDAD  = CONSULTAR_SOCIEDADES();
            MODEL_RETURN.LIST_NOMBRE_TIPO_CONTRATO = CONSULTAR_CONTRATOS();
            MODEL_RETURN.LIST_NOMBRE_GERENCIA = CONSULTAR_GERENCIAS();
            MODEL_RETURN.LIST_NOMBRE_UBICACION_FISICA = CONSULTAR_UBICACIONES_FISICAS();
            MODEL_RETURN.LIST_NOMBRE_JORNADA_LABORAL = CONSULTAR_JORNADAS_LABORALES();
            MODEL_RETURN.LIST_NOMBRE_CIUDAD_TRABAJO = CONSULTAR_CIUDADES_TRABAJO();
            MODEL_RETURN.LIST_NOMBRE_CATEGORIA = CONSULTAR_CATEGORIAS();
            MODEL_RETURN.LIST_NOMBRE_TIPO_SALARIO = CONSULTAR_TIPOS_SALARIOS();
            MODEL_RETURN.LIST_NOMBRE_CARGO = CONSULTAR_CARGOS();
            MODEL_RETURN.LIST_NOMBRE_TIPO_REQUISICION = CONSULTAR_TIPOS_REQUISICION();

            return MODEL_RETURN;
        }
        /// <summary>
        /// desde base de datos
        /// mapeada
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_TIPOS_NECESIDAD(){
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem(){
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }
        /// <summary>
        /// desde base de datos
        /// mapeada
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> CONSULTAR_ESTADOS(){
            return new ACCES_REQUISICION().CONSULTAR_ESTADOS_ACCESS().Select(x => new SelectListItem(){
                Text = x.NOMBRE_ESTADO,
                Value = x.COD_ESTADO_REQUISICION.ToString()
            }).ToList();
        }
        /// <summary>
        /// desde la api
        /// MAPEADO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_CECOS() {
            return new PROXY().CONSULTAR_CECO_API().Select(x => new SelectListItem() {
                Value=x.COD_CENTRO_TRABAJO.ToString(),
                Text=x.NOMBRE
            }).ToList();
        }

        /// <summary>
        /// Desde la api
        /// MAPEADO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_EQUIPOS_VENTAS(){
            return new PROXY().CONSULTAR_EQUIPOS_VENTAS_API().Select(x => new SelectListItem(){
                Text = x.NOMBRE,
                Value = x.COD_EQUIPO_VENTA.ToString()
            }).ToList();
        }

        /// <summary>
        /// desde la api
        /// MAPEADO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_RIESGOS_ARL(){
            return new PROXY().CONSULTAR_RIESGOS_ARL_API().Select(x => new SelectListItem(){
                Text = x.NIVELRIESGO.ToString(),
                Value = x.COD_NIVEL_RIESGO.ToString()
            }).ToList();
        }

        /// <summary>
        /// DESDE L API
        /// MAPEADO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_CATEGORIAS_ED() {
            return new PROXY().CONSULTAR_CATEGORIAS_ED_API().Select(x => new SelectListItem() {
                Text = x.NOMBRE,
                Value = x.COD_CATEGORIA_EVALUACION_DESEMPENO.ToString()
            }).ToList();
        }
        /// <summary>
        /// DESDE LA API
        /// MAPEADO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_SOCIEDADES(){
            return new PROXY().CONSULTAR_SOCIEDAD_API().Select(x => new SelectListItem(){
                Text = x.NOMBRE,
                Value = x.COD_SOCIEDAD.ToString()
            }).ToList();
        }
        /// <summary>
        /// DESDE LA API
        /// MAPEADO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_CONTRATOS(){
            return new PROXY().CONSULTAR_CONTRATO_API().Select(x => new SelectListItem() {
                Text = x.NOMBRE,
                Value = x.COD_TIPO_CONTRATO.ToString()
            }).ToList();
        }
        /// <summary>
        /// DESDE LA API
        /// MAPEDO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_GERENCIAS(){
            return new PROXY().CONSULTAR_GERENCIAS_API().Select(x => new SelectListItem(){
                Text = x.NOMBRE,
                Value = x.COD_GERENCIA.ToString()
            }).ToList();
        }
        /// <summary>
        /// DESDE LA API
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_UBICACIONES_FISICAS(){
            return new PROXY().CONSULTAR_UBICACIONES_FISICAS_API().Select(x => new SelectListItem(){
                Text = x.NOMBRE,
                Value = x.COD_UBICACION_FISICA.ToString()
            }).ToList();
        }

        private List<SelectListItem> CONSULTAR_JORNADAS_LABORALES() {
            List<SelectListItem> jornadas = new List<SelectListItem>(){
                new SelectListItem() {Text="Tiempo Parcial", Value="1"},
                new SelectListItem() { Text="Tiempo Completo", Value="2"},
                new SelectListItem() { Text="Medio Tiempo", Value="3"}
            };
            return jornadas;
        }

        /// <summary>
        /// DESDE LA API
        /// MAPEADO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_CIUDADES_TRABAJO(){
            return new PROXY().CONSULTAR_CIUDADES_TRABAJO_API().Select(x => new SelectListItem() {
                Text = x.NOMBRE,
                Value = x.COD_CIUDAD.ToString()
            }).ToList();
        }
        /// <summary>
        /// DESDE LA API
        /// MAPEADO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_CATEGORIAS(){
            return new PROXY().CONSULTAR_CATEGORIAS_API().Select(x => new SelectListItem(){
                Text = x.NOMBRE,
                Value = x.COD_CATEGORIAS_SALARIAL.ToString()
            }).ToList();
        }
        /// <summary>
        /// DESDE LA API
        /// MAPEDO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_TIPOS_SALARIOS() {
            return new PROXY().CONSULTAR_TIPOS_SALARIOS_API().Select(x => new SelectListItem(){
                Text = x.NOMBRE,
                Value = x.COD_TIPO_SALARIO.ToString()
            }).ToList();
        }
        /// <summary>
        /// DESDE LA API
        /// MAPEDO
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_CARGOS() {
           return new PROXY().CONSULTAR_CARGOS_API().Select(x => new SelectListItem(){
               Text = x.NOMBRE,
               Value = x.COD_CARGO.ToString()
           }).ToList(); ;
        }
        /// <summary>
        /// DESDE BASE DE DATOS
        /// MAPEDO
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> CONSULTAR_TIPOS_REQUISICION()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_REQUISICION_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_REQUISICION,
                Value = x.COD_TIPO_REQUISICION.ToString()
            }).ToList();
        }

        public List<REQUISICIONViewModel> SOLICITAR_REQUISICIONES(FILTROREQUISICION _filtro)
        {
            string filtroDb = _filtro.filtro.ToLower() == "Activos" ? "" : _filtro.filtro;
            List<REQUISICIONViewModel> modelo = new List<REQUISICIONViewModel>();
            for (int i = 0; i < 2; i++)
            {
                REQUISICIONViewModel item = new REQUISICIONViewModel();
                item.COD_REQUISICION = i;
                item.COD_CARGO = 20738780;
                item.NOMBRE_CARGO = "Ingeniero Desarrollo";
                item.EMAIL_USUARIO_CREACION = "martinezluir@globalhitss.com";
                item.USUARIO_CREACION = "Luis David Martinez Rojas" + i;
                item.NOMBRE_TIPO_REQUISICION = "Presupuestada";
                item.NOMBRE_ESTADO_REQUISICION = "Registrada";
                item.FECHA_CREACION = DateTime.Now.AddDays(-i).ToShortDateString();
                item.COD_TIPO_REQUISICION = 2;

                modelo.Add(item);
            }
            modelo.Add(new REQUISICIONViewModel()
            {
                COD_REQUISICION = 3,
                COD_CARGO = 758913,
                NOMBRE_CARGO = "Ingeniero Desarrollo",
                EMAIL_USUARIO_CREACION = "martinezluir@globalhitss.com",
                USUARIO_CREACION = "Luis David Martinez Rojas 3",
                NOMBRE_TIPO_REQUISICION = "No Presupuestada",
                NOMBRE_ESTADO_REQUISICION = "Verificada BP",
                FECHA_CREACION = DateTime.Now.ToShortDateString(),
                COD_TIPO_REQUISICION = 2
            });
            modelo.Add(new REQUISICIONViewModel()
            {
                COD_REQUISICION = 123456789,
                COD_CARGO = 758913,
                NOMBRE_CARGO = "Ingeniero Desarrollo",
                EMAIL_USUARIO_CREACION = "martinezluir@globalhitss.com",
                USUARIO_CREACION = "Luis David Martinez Rojas",
                NOMBRE_TIPO_REQUISICION = "No Presupuestada",
                NOMBRE_ESTADO_REQUISICION = "Verificada BP",
                FECHA_CREACION = DateTime.Now.ToShortDateString(),
                COD_TIPO_REQUISICION = 2
            });
            modelo.Add(new REQUISICIONViewModel()
            {
                COD_REQUISICION = 4,
                COD_CARGO = 758913,
                NOMBRE_CARGO = "Ingeniero Desarrollo",
                NOMBRE_TIPO_REQUISICION = "No Presupuestada",
                NOMBRE_ESTADO_REQUISICION = "Verificada BP",
                FECHA_CREACION = DateTime.Now.ToShortDateString(),
                EMAIL_USUARIO_CREACION = "williamFabian@globalhitss.com",
                USUARIO_CREACION = "Luis David Martinez Rojas",
                COD_TIPO_REQUISICION = 1
            });


            return modelo;
        }

        public REQUISICIONViewModel BUSCAR_REQUISICIONES(int idRequsicion){
            REQUISICIONViewModel objReqModel = null;
            try {
                objReqModel = null;
            }
            catch (Exception ex) {
                throw ex;
            }
            return objReqModel;
        }


           
  

        public Boolean INSERTAR_REQUISICION_LOGICA(REQUISICIONViewModel _modelo, string usuario) {
            return new ACCES_REQUISICION().INSERTAR_REQUISICION(_modelo, usuario);
        }
    }
}
