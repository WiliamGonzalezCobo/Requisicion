using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOGICA.LOGICA_REQUISICION;
using MODELO_DATOS.MODELO_REQUISICION;
using MODELO_DATOS.MODELO_REQUISICION.LISTAS_API;
using Newtonsoft.Json.Linq;
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
            MODEL_RETURN.LIST_DIA_LABORAL_DESDE = CONSULTAR_DIAS_LABORALES();
            MODEL_RETURN.LIST_DIA_LABORAL_HASTA = CONSULTAR_JORNADAS_LABORALES();// ESTE SOBRA



            return MODEL_RETURN;
        }

        public REQUISICIONViewModel LLENAR_CONTROLES_SESSSION(REQUISICIONViewModel MODEL_RETURN, REQUISICIONViewModel MODEL_ENTRADA)
        {

            MODEL_RETURN.LIST_NOMBRE_TIPO_NECESIDAD = MODEL_ENTRADA.LIST_NOMBRE_TIPO_NECESIDAD;
            MODEL_RETURN.LIST_NOMBRE_ESTADO_REQUISICION = MODEL_ENTRADA.LIST_NOMBRE_ESTADO_REQUISICION;
            MODEL_RETURN.LIST_NOMBRE_CECO = MODEL_ENTRADA.LIST_NOMBRE_CECO;
            MODEL_RETURN.LIST_NOMBRE_EQIPO_VENTAS = MODEL_ENTRADA.LIST_NOMBRE_EQIPO_VENTAS;
            MODEL_RETURN.LIST_NIVEL_RIESGO_ARL = MODEL_ENTRADA.LIST_NIVEL_RIESGO_ARL;
            MODEL_RETURN.LIST_NOMBRE_CATEGORIA_ED = MODEL_ENTRADA.LIST_NOMBRE_CATEGORIA_ED;
            MODEL_RETURN.LIST_NOMBRE_SOCIEDAD = MODEL_ENTRADA.LIST_NOMBRE_SOCIEDAD;
            MODEL_RETURN.LIST_NOMBRE_TIPO_CONTRATO = MODEL_ENTRADA.LIST_NOMBRE_TIPO_CONTRATO;
            MODEL_RETURN.LIST_NOMBRE_GERENCIA = MODEL_ENTRADA.LIST_NOMBRE_GERENCIA;
            MODEL_RETURN.LIST_NOMBRE_UBICACION_FISICA = MODEL_ENTRADA.LIST_NOMBRE_UBICACION_FISICA;
            MODEL_RETURN.LIST_NOMBRE_JORNADA_LABORAL = MODEL_ENTRADA.LIST_NOMBRE_JORNADA_LABORAL;
            MODEL_RETURN.LIST_NOMBRE_CIUDAD_TRABAJO = MODEL_ENTRADA.LIST_NOMBRE_CIUDAD_TRABAJO;
            MODEL_RETURN.LIST_NOMBRE_CATEGORIA = MODEL_ENTRADA.LIST_NOMBRE_CATEGORIA;
            MODEL_RETURN.LIST_NOMBRE_TIPO_SALARIO = MODEL_ENTRADA.LIST_NOMBRE_TIPO_SALARIO;
            MODEL_RETURN.LIST_NOMBRE_CARGO = MODEL_ENTRADA.LIST_NOMBRE_CARGO;
            MODEL_RETURN.LIST_NOMBRE_TIPO_REQUISICION = MODEL_ENTRADA.LIST_NOMBRE_TIPO_REQUISICION;
            MODEL_RETURN.LIST_DIA_LABORAL_DESDE = MODEL_ENTRADA.LIST_DIA_LABORAL_DESDE;
            MODEL_RETURN.LIST_DIA_LABORAL_HASTA = MODEL_ENTRADA.LIST_DIA_LABORAL_HASTA;


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
            return new PROXY().CONSULTAR_JORNADAS_LABORALES_API().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE,
                Value = x.COD_JORNADA_TRABAJO.ToString()
            }).ToList();
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
               Value =Convert.ToInt32(x.COD_CARGO).ToString()
           }).ToList(); ;
        }
        /// <summary>
        /// DESDE BASE DE DATOS, para la pantalla principal
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

        /// <summary>
        /// DESDE BASE DE DATOS
        /// MAPEDO
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> CONSULTAR_DIAS_LABORALES()
        {
            return new PROXY().CONSULTAR_DIAS_LABORALES_API().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE,
                Value = x.COD_DIAS_LABORAL.ToString()
            }).ToList();
        }

        public List<REQUISICIONViewModel> SOLICITAR_REQUISICIONES(FILTROREQUISICION _filtro) {
            return new ACCES_REQUISICION().CONSULTAR_REQUISICION_PANTALLA_INICIO(_filtro);
        }

   

        public REQUISICIONViewModel BUSCAR_REQUISICIONES(int idRequsicion){
            REQUISICIONViewModel objReqModel = null;
            try {
                objReqModel = new ACCES_REQUISICION().CONSULTAR_REQUISICION_X_ID_ACCES(idRequsicion);
                PUNTOS_MEDIO _puntosMedio = new PROXY().CONSULTAR_PUNTOS_MEDIO_API(objReqModel.COD_CARGO.ToString()).First();

            }
            catch (Exception ex) {
                throw ex;
            }
            return objReqModel;
        }

        public int INSERTAR_REQUISICION_LOGICA(REQUISICIONViewModel _modelo) {
            if (_modelo.COD_REQUISICION != 0){
                if (new ACCES_REQUISICION().ACTUALIZARREQUISICION_ACESS(_modelo)) {
                    return _modelo.COD_REQUISICION;
                } else {
                    return 0;
                }
            }
            else { 
            return new ACCES_REQUISICION().INSERTAR_REQUISICION(_modelo);
            }
        }
        public Boolean ACTUALIZARREQUISICION(REQUISICIONViewModel _modelo){
            return new ACCES_REQUISICION().ACTUALIZARREQUISICION_ACESS(_modelo);
        }
        // LO LLENO PARA LAS LISTAS
        public REQUISICIONViewModel CONSULTAR_VALORES_LISTAS_POR_CODIGO(REQUISICIONViewModel _MODEL_CODIGOS) {


            if (_MODEL_CODIGOS.COD_CARGO != 0) { _MODEL_CODIGOS.NOMBRE_CARGO = _MODEL_CODIGOS.LIST_NOMBRE_CARGO.Where(x => x.Value == _MODEL_CODIGOS.COD_CARGO.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_GERENCIA != 0) { _MODEL_CODIGOS.NOMBRE_GERENCIA = _MODEL_CODIGOS.LIST_NOMBRE_GERENCIA.Where(x => x.Value == _MODEL_CODIGOS.COD_GERENCIA.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_TIPO_CONTRATO != 0) { _MODEL_CODIGOS.NOMBRE_TIPO_CONTRATO = _MODEL_CODIGOS.LIST_NOMBRE_TIPO_CONTRATO.Where(x => x.Value == _MODEL_CODIGOS.COD_TIPO_CONTRATO.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_CECO != 0) { _MODEL_CODIGOS.NOMBRE_CECO = _MODEL_CODIGOS.LIST_NOMBRE_CECO.Where(x => x.Value == _MODEL_CODIGOS.COD_CECO.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_SOCIEDAD != 0) { _MODEL_CODIGOS.NOMBRE_SOCIEDAD = _MODEL_CODIGOS.LIST_NOMBRE_SOCIEDAD.Where(x => x.Value == _MODEL_CODIGOS.COD_SOCIEDAD.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_EQUIPO_VENTAS != 0) { _MODEL_CODIGOS.NOMBRE_EQIPO_VENTAS = _MODEL_CODIGOS.LIST_NOMBRE_EQIPO_VENTAS.Where(x => x.Value == _MODEL_CODIGOS.COD_EQUIPO_VENTAS.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_CIUDAD_TRABAJO != 0) { _MODEL_CODIGOS.NOMBRE_CIUDAD_TRABAJO = _MODEL_CODIGOS.LIST_NOMBRE_CIUDAD_TRABAJO.Where(x => x.Value == _MODEL_CODIGOS.COD_CIUDAD_TRABAJO.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_UBICACION_FISICA != 0) { _MODEL_CODIGOS.NOMBRE_UBICACION_FISICA = _MODEL_CODIGOS.LIST_NOMBRE_UBICACION_FISICA.Where(x => x.Value == _MODEL_CODIGOS.COD_UBICACION_FISICA.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_NIVEL_RIESGO_ARL != 0) { _MODEL_CODIGOS.NIVEL_RIESGO_ARL = _MODEL_CODIGOS.LIST_NIVEL_RIESGO_ARL.Where(x => x.Value == _MODEL_CODIGOS.COD_NIVEL_RIESGO_ARL.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_CATEGORIA_ED != 0) { _MODEL_CODIGOS.NOMBRE_CATEGORIA_ED = _MODEL_CODIGOS.LIST_NOMBRE_CATEGORIA_ED.Where(x => x.Value == _MODEL_CODIGOS.COD_CATEGORIA_ED.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_JORNADA_LABORAL != 0) { _MODEL_CODIGOS.NOMBRE_JORNADA_LABORAL = _MODEL_CODIGOS.LIST_NOMBRE_JORNADA_LABORAL.Where(x => x.Value == _MODEL_CODIGOS.COD_JORNADA_LABORAL.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_DIA_LABORAL_DESDE!=0) { _MODEL_CODIGOS.DIA_LABORAL_DESDE = _MODEL_CODIGOS.LIST_DIA_LABORAL_DESDE.Where(x => x.Value == _MODEL_CODIGOS.COD_DIA_LABORAL_DESDE.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_DIA_LABORAL_HASTA != 0) { _MODEL_CODIGOS.DIA_LABORAL_HASTA = _MODEL_CODIGOS.LIST_DIA_LABORAL_HASTA.Where(x => x.Value == _MODEL_CODIGOS.COD_DIA_LABORAL_HASTA.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_TIPO_SALARIO != 0) { _MODEL_CODIGOS.NOMBRE_TIPO_SALARIO = _MODEL_CODIGOS.LIST_NOMBRE_TIPO_SALARIO.Where(x => x.Value == _MODEL_CODIGOS.COD_TIPO_SALARIO.ToString()).First().Text; }
            if (_MODEL_CODIGOS.COD_CATEGORIA != 0) { _MODEL_CODIGOS.NOMBRE_CATEGORIA = _MODEL_CODIGOS.LIST_NOMBRE_CATEGORIA.Where(x => x.Value == _MODEL_CODIGOS.COD_CATEGORIA.ToString()).First().Text; }


            return _MODEL_CODIGOS;
        }

        public int APROBAR_REQUISICION_LOGICA(int COD_REQUISICION, String ID_USUARIO) {
          return new ACCES_REQUISICION().APROBAR_REQUISICION_ACESS(COD_REQUISICION, ID_USUARIO);
        }

        public int REQUISICION_MODIFICAR_LOGICA(int COD_REQUISICION, string oBSERVACIONES, String ID_USUARIO)
        {
            return new ACCES_REQUISICION().REQUISICION_MODIFICAR_ACESS(COD_REQUISICION, oBSERVACIONES, ID_USUARIO);
        }
    }
}
