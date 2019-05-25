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
            MODEL_RETURN.LIST_DIA_LABORAL_HASTA = CONSULTAR_DIAS_LABORALES();
            MODEL_RETURN.LIST_HORARIO_LABORAL_DESDE = CONSULTAR_HORARIO_LABORAL();
            MODEL_RETURN.LIST_HORARIO_LABORAL_HASTA = CONSULTAR_HORARIO_LABORAL();
            MODEL_RETURN.LIST_NOMBRE_JORNADA_LABORAL = CONSULTAR_JORNADAS_LABORALES();
            MODEL_RETURN.LIST_MERCADO = CONSULTAR_MERCADO();
            MODEL_RETURN.LIST_TIPO_DOCUMENTO = CONSULTAR_TIPO_DOCUMENTO();



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
            MODEL_RETURN.LIST_HORARIO_LABORAL_DESDE = MODEL_ENTRADA.LIST_HORARIO_LABORAL_DESDE;
            MODEL_RETURN.LIST_HORARIO_LABORAL_HASTA = MODEL_ENTRADA.LIST_HORARIO_LABORAL_HASTA;
            MODEL_RETURN.LIST_NOMBRE_JORNADA_LABORAL = MODEL_ENTRADA.LIST_NOMBRE_JORNADA_LABORAL;
            MODEL_RETURN.LIST_MERCADO = MODEL_ENTRADA.LIST_MERCADO;
            MODEL_RETURN.LIST_TIPO_DOCUMENTO = MODEL_ENTRADA.LIST_TIPO_DOCUMENTO; 


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
                Value=x.coD_CENTRO_COSTO.ToString(),
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

        private List<SelectListItem> CONSULTAR_MERCADO()
        {
            return new PROXY().CONSULTAR_MERCADO_API().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE,
                Value = x.COD_MERCADO.ToString()
            }).ToList();
        }

        private List<SelectListItem> CONSULTAR_TIPO_DOCUMENTO()
        {
            return new PROXY().CONSULTAR_TIPO_DOCUMENTO_API().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE,
                Value = x.coD_TIPO_DOCUMENTO.ToString()
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
            List<SelectListItem> HORARIOS_LABORAL = new List<SelectListItem>();
            SelectListItem LHORARIO = new SelectListItem();
            LHORARIO.Text = "LUNES";
            LHORARIO.Value = "LUNES";
            HORARIOS_LABORAL.Add(LHORARIO);
            SelectListItem MHORARIO = new SelectListItem();
            MHORARIO.Text = "MARTES";
            MHORARIO.Value = "MARTES";
            HORARIOS_LABORAL.Add(MHORARIO);
            SelectListItem MMHORARIO = new SelectListItem();
            MMHORARIO.Text = "MIERCOLES";
            MMHORARIO.Value = "MIERCOLES";
            HORARIOS_LABORAL.Add(MMHORARIO);
            SelectListItem JHORARIO = new SelectListItem();
            JHORARIO.Text = "JUEVES";
            JHORARIO.Value = "JUEVES";
            HORARIOS_LABORAL.Add(JHORARIO);
            SelectListItem VHORARIO = new SelectListItem();
            VHORARIO.Text = "VIERNES";
            VHORARIO.Value = "VIERNES";
            HORARIOS_LABORAL.Add(VHORARIO);

            return HORARIOS_LABORAL;
        }

        public List<SelectListItem> CONSULTAR_HORARIO_LABORAL()
        {
            List<SelectListItem> DIAS_LABORAL = new List<SelectListItem>();
            DIAS_LABORAL.Add(new SelectListItem() {Text="00:00",Value="00:00"});
            DIAS_LABORAL.Add(new SelectListItem() { Text = "1:00", Value = "1:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "2:00", Value = "2:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "3:00", Value = "3:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "4:00", Value = "4:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "5:00", Value = "5:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "6:00", Value = "6:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "7:00", Value = "7:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "8:00", Value = "8:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "9:00", Value = "9:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "10:00", Value = "10:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "11:00", Value = "11:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "12:00", Value = "12:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "13:00", Value = "13:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "14:00", Value = "14:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "15:00", Value = "15:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "16:00", Value = "16:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "17:00", Value = "17:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "18:00", Value = "18:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "19:00", Value = "19:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "20:00", Value = "20:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "21:00", Value = "21:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "22:00", Value = "22:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "23:00", Value = "23:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "24:00", Value = "24:00" });


            return DIAS_LABORAL;
        }

        public List<REQUISICIONViewModel> SOLICITAR_REQUISICIONES(FILTROREQUISICION _filtro) {
            return new ACCES_REQUISICION().CONSULTAR_REQUISICION_PANTALLA_INICIO(_filtro);
        }

        private REQUISICIONViewModel CARGAR_MODELO_DEL_API(REQUISICIONViewModel MODELO_REQUISICION, PUNTOS_MEDIO API)
        {
            //INFORMACION REQUISICION
            //TIPO NECESIDAD
            MODELO_REQUISICION.COD_CARGO = Convert.ToInt32(API.COD_CARGO);
            MODELO_REQUISICION.NOMBRE_CARGO = API.NOMBRE_CARGO;
            //ORDEN
            MODELO_REQUISICION.COD_CECO = Convert.ToInt32(API.COD_CENTRO_COSTO);
            MODELO_REQUISICION.NOMBRE_CECO = API.NOMBRE_CENTRO_COSTO;
            
            //INFROMACION GENERAL
            MODELO_REQUISICION.COD_GERENCIA = Convert.ToInt32(API.COD_GERENCIA);
            MODELO_REQUISICION.NOMBRE_GERENCIA = API.NOMBRE_GERENCIA;
            MODELO_REQUISICION.COD_TIPO_CONTRATO = Convert.ToInt32(API.COD_TIPO_CONTRATO);
            MODELO_REQUISICION.NOMBRE_TIPO_CONTRATO = API.NOMBRE_TIPO_CONTRATO;
            MODELO_REQUISICION.JEFE_INMEDIATO = API.NOMBRE_JEFE;
            MODELO_REQUISICION.COD_CECO = Convert.ToInt32(API.COD_CENTRO_COSTO);
            MODELO_REQUISICION.NOMBRE_CECO = API.NOMBRE_CENTRO_COSTO;
            MODELO_REQUISICION.COD_SOCIEDAD = Convert.ToInt32(API.COD_SOCIEDAD);
            MODELO_REQUISICION.NOMBRE_SOCIEDAD = API.NOMBRE_SOCIEDAD;
            MODELO_REQUISICION.COD_EQUIPO_VENTAS = Convert.ToInt32(API.COD_EQUIPO_VENTA);
            MODELO_REQUISICION.NOMBRE_EQIPO_VENTAS = API.NOMBRE_EQUIPO_VENTA;
            MODELO_REQUISICION.COD_CIUDAD_TRABAJO = Convert.ToInt32(API.COD_DANE_CIUDAD);
            MODELO_REQUISICION.NOMBRE_CIUDAD_TRABAJO = API.NOMBRE_CIUDAD;
            MODELO_REQUISICION.COD_UBICACION_FISICA = Convert.ToInt32(API.COD_UBICACION_FISICA);
            MODELO_REQUISICION.NOMBRE_UBICACION_FISICA = API.NOMBRE_UBICACION_FIFICA;
            MODELO_REQUISICION.COD_NIVEL_RIESGO_ARL = Convert.ToInt32(API.COD_NIVEL_RIESGO);
            MODELO_REQUISICION.NIVEL_RIESGO_ARL = Convert.ToString(API.NIVEL_RIESGO);
            MODELO_REQUISICION.COD_CATEGORIA_ED = Convert.ToInt32(API.COD_CATEGORIA_EVALUACION_DESEMPENO);
            MODELO_REQUISICION.NOMBRE_CATEGORIA_ED = API.NOMBRE_CATEGORIA_EVALUACION_DESEMPENO;
            if (API.CARGO_CRITICO == "1")
            {
                MODELO_REQUISICION.CARGO_CRITICO = true;
            }
            else
            {
                MODELO_REQUISICION.CARGO_CRITICO = false;
            }               
            MODELO_REQUISICION.COD_JORNADA_LABORAL = Convert.ToInt32(API.COD_JORNADA_TRABAJO);
            MODELO_REQUISICION.NOMBRE_JORNADA_LABORAL = API.NOMBRE_JORNADA_TRABAJO;
            MODELO_REQUISICION.COD_HORARIO_LABORAL_DESDE = Convert.ToInt32(API.COD_HORARIO_TRABAJO);
            MODELO_REQUISICION.HORARIO_LABORAL_DESDE = API.horariO_DESDE;
            MODELO_REQUISICION.COD_HORARIO_LABORAL_HASTA = Convert.ToInt32(API.COD_HORARIO_TRABAJO);
            MODELO_REQUISICION.HORARIO_LABORAL_HASTA = API.horariO_HASTA;
            MODELO_REQUISICION.COD_DIA_LABORAL_DESDE = Convert.ToInt32(API.COD_DIA_LABORAL);
            MODELO_REQUISICION.DIA_LABORAL_DESDE = API.diaS_LABORALES_DESDE;
            MODELO_REQUISICION.COD_DIA_LABORAL_HASTA = Convert.ToInt32(API.COD_DIA_LABORAL);
            MODELO_REQUISICION.DIA_LABORAL_HASTA = API.diaS_LABORALES_HASTA;

            //INFROMACION SALARIAL
            MODELO_REQUISICION.SALARIO_FIJO = Convert.ToDecimal(API.SALARIO_FIJO);
            MODELO_REQUISICION.PORCENTAJE_SALARIO_FIJO = Convert.ToDecimal(API.PORCENTAJE_SALARIO_FIJO);
            MODELO_REQUISICION.SALARIO_VARIABLE = Convert.ToDecimal(API.SALARIO_VARIABLE);
            MODELO_REQUISICION.PORCENTAJE_SALARIO_VARIABLE = Convert.ToDecimal(API.PORCENTAJE_SALARIO_VARIABLE);
            MODELO_REQUISICION.SOBREREMUNERACION = Convert.ToDecimal(API.SOBREREMUNERACION);
            MODELO_REQUISICION.PORCENTAJE_SOBREREMUNERACION = Convert.ToDecimal(API.PORCENTAJE_SOBREREMUNERACION);
            MODELO_REQUISICION.EXTRA_FIJA = Convert.ToDecimal(API.EXTRA_FIJA);
            MODELO_REQUISICION.RECARGO_NOCTURNO = Convert.ToDecimal(API.RECARGO_NOCTURNO_FIJO);
            MODELO_REQUISICION.MEDIO_TRANSPORTE = Convert.ToDecimal(API.MEDIOS_TRANSPORTE);
            MODELO_REQUISICION.SALARIO_TOTAL = Convert.ToDecimal(API.SALARIO_TOTAL);
            MODELO_REQUISICION.BONO_ANUAL = Convert.ToDecimal(API.BONO_ANUAL);
            MODELO_REQUISICION.NUMERO_SALARIOS = Convert.ToInt32(API.NUMERO_SALARIO);
            MODELO_REQUISICION.MESES_GARANTIZADOS = Convert.ToInt32(API.MESES_GARANTIZADO);
            MODELO_REQUISICION.COD_TIPO_SALARIO = Convert.ToInt32(API.COD_TIPO_SALARIO);
            MODELO_REQUISICION.NOMBRE_TIPO_SALARIO = API.NOMBRE_TIPO_SALARIO;
            MODELO_REQUISICION.FACTOR_PRESTACIONAL = API.FP.Value;
            MODELO_REQUISICION.INGRESO_PROM_MENSUAL = Convert.ToDecimal(API.PROMEDIO_MES);
            MODELO_REQUISICION.INGRESO_PROM_ANUAL = Convert.ToDecimal(API.PROMEDIO_ANO);
            MODELO_REQUISICION.COD_MERCADO = Convert.ToInt32(API.COD_MERCADO);
            MODELO_REQUISICION.MERCADO = API.NOMBRE_MERCADO;
            MODELO_REQUISICION.COD_CATEGORIA = Convert.ToInt32(API.COD_CATEGORIA_SALARIALES);
            MODELO_REQUISICION.NOMBRE_CATEGORIA = API.NOMBRE_CATEGORIA_SALARIO;

            //PUNTO MEDIO
            MODELO_REQUISICION.PUNTO_MEDIO_80 = Convert.ToDecimal(API.PUNTO_MEDIO_80_PORCIENTO);
            MODELO_REQUISICION.PUNTO_MEDIO_100 = Convert.ToDecimal(API.PUNTO_MEDIO_100_PORCIENTO);
            MODELO_REQUISICION.PUNTO_MEDIO_120 = Convert.ToDecimal(API.PUNTO_MEDIO_120_PORCIENTO);

            MODELO_REQUISICION.POSICIONAMIENTO = API.POSICIONAMIENTO.Value;

            return MODELO_REQUISICION;
        }

        public REQUISICIONViewModel BUSCAR_REQUISICIONESBP(REQUISICIONViewModel model)
        {
            try
            {
                if (model.ES_MODIFICACION) {
                    PUNTOS_MEDIO PUESTO_EMPLEADO = new PROXY().CONSULTAR_PUESTOS_POR_CEDULA_API(model.NUMERO_DOCUMENTO_EMPLEADO);
                    model = CARGAR_MODELO_DEL_API(model, PUESTO_EMPLEADO);
                }
                else if (model.COD_CARGO != 0){
                    PUNTOS_MEDIO _puntosMedio = new PROXY().CONSULTAR_PUNTOS_MEDIO_API(model.COD_CARGO.ToString()).First();
                    model = CARGAR_MODELO_DEL_API(model, _puntosMedio);
                }
            }
            catch (Exception ex)
            {
                throw ex;                
            }
            return model;
        }

        public PUNTOS_MEDIO BUSCAR_CARGO_API(string idCargo)
        {
            PUNTOS_MEDIO _puntosMedio = new PUNTOS_MEDIO();
            try
            {
                if (!idCargo.Equals("0"))
                {
                    //List<PUNTOS_MEDIO> listPuntosMedio = new PROXY().CONSULTAR_PUNTOS_MEDIO_API(idCargo);
                    //if (listPuntosMedio.Count() > 0)
                    //{
                    //    _puntosMedio = listPuntosMedio.First();
                    //}

                    //Objeto de prueba cuando fallal el api
                    _puntosMedio = new PUNTOS_MEDIO()
                    {
                        COD_CARGO = 1,
                        COD_CENTRO_COSTO = 1,
                        COD_GERENCIA = 1,
                        COD_TIPO_CONTRATO = 1,
                        NOMBRE_JEFE = "prueba cargue",
                        COD_SOCIEDAD = 1,
                        COD_EQUIPO_VENTA = 1,
                        COD_DANE_CIUDAD = "1",
                        COD_UBICACION_FISICA = 1,
                        COD_NIVEL_RIESGO = 1,
                        COD_CATEGORIA_EVALUACION_DESEMPENO = 1,
                        CARGO_CRITICO = "1",
                        COD_JORNADA_TRABAJO = 1,
                        COD_HORARIO_TRABAJO = 1,
                        COD_DIA_LABORAL = 1,
                        SALARIO_FIJO = 1000,
                        PORCENTAJE_SALARIO_FIJO = 11,
                        SALARIO_VARIABLE = 22,
                        PORCENTAJE_SALARIO_VARIABLE = 33,
                        SOBREREMUNERACION = 44,
                        PORCENTAJE_SOBREREMUNERACION = 55,
                        EXTRA_FIJA = 66,
                        RECARGO_NOCTURNO_FIJO = 77,
                        MEDIOS_TRANSPORTE = 88,
                        SALARIO_TOTAL = 99,
                        BONO_ANUAL = 111,
                        NUMERO_SALARIO = 222,
                        MESES_GARANTIZADO = 333,
                        COD_TIPO_SALARIO = 444
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;          
            }
            return _puntosMedio;
        }

        public REQUISICIONViewModel BUSCAR_REQUISICIONES(int idRequsicion){
            REQUISICIONViewModel objReqModel = null;
            try {
                objReqModel = new ACCES_REQUISICION().CONSULTAR_REQUISICION_X_ID_ACCES(idRequsicion);
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


            if (_MODEL_CODIGOS.COD_CARGO != 0) {
                List<SelectListItem> LISTA_CARGO = _MODEL_CODIGOS.LIST_NOMBRE_CARGO.Where(x => x.Value == _MODEL_CODIGOS.COD_CARGO.ToString()).ToList();
                if (LISTA_CARGO.Count > 0){
                    _MODEL_CODIGOS.NOMBRE_CARGO = LISTA_CARGO.First().Text;
                } else {
                    _MODEL_CODIGOS.COD_CARGO = 0;
                }
            }
            if (_MODEL_CODIGOS.COD_GERENCIA != 0){
                List<SelectListItem> LISTA_GERENCIA = _MODEL_CODIGOS.LIST_NOMBRE_GERENCIA.Where(x => x.Value == _MODEL_CODIGOS.COD_GERENCIA.ToString()).ToList();
                if (LISTA_GERENCIA.Count() > 0)
                {
                    _MODEL_CODIGOS.NOMBRE_GERENCIA = LISTA_GERENCIA.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_GERENCIA = 0;
                }
            }
            if (_MODEL_CODIGOS.COD_TIPO_CONTRATO != 0) {
                List<SelectListItem> LISTA_CONTRATO = _MODEL_CODIGOS.LIST_NOMBRE_TIPO_CONTRATO.Where(x => x.Value == _MODEL_CODIGOS.COD_TIPO_CONTRATO.ToString()).ToList();
                if (LISTA_CONTRATO.Count > 0)
                {
                    _MODEL_CODIGOS.NOMBRE_TIPO_CONTRATO = LISTA_CONTRATO.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_TIPO_CONTRATO = 0;
                }
            }
            if (_MODEL_CODIGOS.COD_CECO != 0) {
                List<SelectListItem> LISTA_CECO = _MODEL_CODIGOS.LIST_NOMBRE_CECO.Where(x => x.Value == _MODEL_CODIGOS.COD_CECO.ToString()).ToList();
                if (LISTA_CECO.Count > 0) {
                    _MODEL_CODIGOS.NOMBRE_CECO = LISTA_CECO.First().Text;
                }else {
                    _MODEL_CODIGOS.COD_CECO = 0;
                }
                
            }
            if (_MODEL_CODIGOS.COD_SOCIEDAD != 0) {
                List<SelectListItem> LISTA_SOCIEDAD = _MODEL_CODIGOS.LIST_NOMBRE_SOCIEDAD.Where(x => x.Value == _MODEL_CODIGOS.COD_SOCIEDAD.ToString()).ToList();
                if (LISTA_SOCIEDAD.Count > 0) {
                    _MODEL_CODIGOS.NOMBRE_SOCIEDAD = LISTA_SOCIEDAD.First().Text;
                }else {
                    _MODEL_CODIGOS.COD_SOCIEDAD = 0;
                }
                
            }
            if (_MODEL_CODIGOS.COD_EQUIPO_VENTAS != 0) {
                List<SelectListItem> LISTA_VENTAS = _MODEL_CODIGOS.LIST_NOMBRE_EQIPO_VENTAS.Where(x => x.Value == _MODEL_CODIGOS.COD_EQUIPO_VENTAS.ToString()).ToList();
                if (LISTA_VENTAS.Count > 0)
                {
                    _MODEL_CODIGOS.NOMBRE_EQIPO_VENTAS = LISTA_VENTAS.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_EQUIPO_VENTAS = 0;
                }
            }
            if (_MODEL_CODIGOS.COD_CIUDAD_TRABAJO != 0)
            {
                List<SelectListItem> LISTA_CIUDAD_TRABAJO = _MODEL_CODIGOS.LIST_NOMBRE_CIUDAD_TRABAJO.Where(x => x.Value == _MODEL_CODIGOS.COD_CIUDAD_TRABAJO.ToString()).ToList();
                if (LISTA_CIUDAD_TRABAJO.Count > 0){
                    _MODEL_CODIGOS.NOMBRE_CIUDAD_TRABAJO = LISTA_CIUDAD_TRABAJO.First().Text;
                }else {
                    _MODEL_CODIGOS.COD_CIUDAD_TRABAJO = 0;
                }
            }
            if (_MODEL_CODIGOS.COD_UBICACION_FISICA != 0) {
                List<SelectListItem> LISTA_UBICACION_FISICA = _MODEL_CODIGOS.LIST_NOMBRE_UBICACION_FISICA.Where(x => x.Value == _MODEL_CODIGOS.COD_UBICACION_FISICA.ToString()).ToList();
                if (LISTA_UBICACION_FISICA.Count > 0){
                    _MODEL_CODIGOS.NOMBRE_UBICACION_FISICA = LISTA_UBICACION_FISICA.First().Text;
                } else {
                    _MODEL_CODIGOS.COD_UBICACION_FISICA = 0;
                }
                
            }
            if (_MODEL_CODIGOS.COD_NIVEL_RIESGO_ARL != 0) {
                List<SelectListItem> LISTA_RIESGO_ARL = _MODEL_CODIGOS.LIST_NIVEL_RIESGO_ARL.Where(x => x.Value == _MODEL_CODIGOS.COD_NIVEL_RIESGO_ARL.ToString()).ToList();
                if (LISTA_RIESGO_ARL.Count > 0) {
                    _MODEL_CODIGOS.NIVEL_RIESGO_ARL = LISTA_RIESGO_ARL.First().Text;
                } 
            }
            if (_MODEL_CODIGOS.COD_CATEGORIA_ED != 0) {
                List<SelectListItem> LISTA_CATEGORIA_ED = _MODEL_CODIGOS.LIST_NOMBRE_CATEGORIA_ED.Where(x => x.Value == _MODEL_CODIGOS.COD_CATEGORIA_ED.ToString()).ToList();
                if (LISTA_CATEGORIA_ED.Count > 0){
                    _MODEL_CODIGOS.NOMBRE_CATEGORIA_ED = LISTA_CATEGORIA_ED.First().Text;
                }
                else { _MODEL_CODIGOS.COD_CATEGORIA_ED = 0;
                }
                
            }
            if (_MODEL_CODIGOS.COD_JORNADA_LABORAL != 0) {
                List<SelectListItem> LISTA_JORNADA_LABORAL = _MODEL_CODIGOS.LIST_NOMBRE_JORNADA_LABORAL.Where(x => x.Value == _MODEL_CODIGOS.COD_JORNADA_LABORAL.ToString()).ToList();
                if (LISTA_JORNADA_LABORAL.Count > 0)
                {
                    _MODEL_CODIGOS.NOMBRE_JORNADA_LABORAL = LISTA_JORNADA_LABORAL.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_JORNADA_LABORAL = 0;
                }
               
            }
            if (_MODEL_CODIGOS.COD_DIA_LABORAL_DESDE !=0) {
                List<SelectListItem> LISTA_LABORAL_DESDE = _MODEL_CODIGOS.LIST_DIA_LABORAL_DESDE.Where(x => x.Value == _MODEL_CODIGOS.COD_DIA_LABORAL_DESDE.ToString()).ToList();
                if (LISTA_LABORAL_DESDE.Count > 0)
                {
                    _MODEL_CODIGOS.DIA_LABORAL_DESDE = LISTA_LABORAL_DESDE.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_DIA_LABORAL_DESDE = 0;
                }
                
            }
            if (_MODEL_CODIGOS.COD_DIA_LABORAL_HASTA != 0) {
                List<SelectListItem> LISTA_LABORAL_HASTA = _MODEL_CODIGOS.LIST_DIA_LABORAL_HASTA.Where(x => x.Value == _MODEL_CODIGOS.COD_DIA_LABORAL_HASTA.ToString()).ToList();
                if (LISTA_LABORAL_HASTA.Count > 0)
                {
                    _MODEL_CODIGOS.DIA_LABORAL_HASTA = LISTA_LABORAL_HASTA.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_DIA_LABORAL_HASTA = 0;
                }
        
            }
            if (_MODEL_CODIGOS.COD_TIPO_SALARIO != 0) {
                List<SelectListItem> LISTA_TIPO_SALARIO = _MODEL_CODIGOS.LIST_NOMBRE_TIPO_SALARIO.Where(x => x.Value == _MODEL_CODIGOS.COD_TIPO_SALARIO.ToString()).ToList();
                if (LISTA_TIPO_SALARIO.Count > 0)
                {
                    _MODEL_CODIGOS.NOMBRE_TIPO_SALARIO = LISTA_TIPO_SALARIO.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_TIPO_SALARIO = 0;
                }
               
            }
            if (_MODEL_CODIGOS.COD_CATEGORIA != 0) {
                List<SelectListItem> LISTA_COD_CATEGORIA = _MODEL_CODIGOS.LIST_NOMBRE_CATEGORIA.Where(x => x.Value == _MODEL_CODIGOS.COD_CATEGORIA.ToString()).ToList();
                if (LISTA_COD_CATEGORIA.Count > 0)
                {
                    _MODEL_CODIGOS.NOMBRE_CATEGORIA = LISTA_COD_CATEGORIA.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_CATEGORIA = 0;
                }
                
            }

            if (_MODEL_CODIGOS.COD_TIPO_SALARIO != 0) {
                List<SelectListItem> LISTA_TIPO_SALARIO = _MODEL_CODIGOS.LIST_NOMBRE_TIPO_SALARIO.Where(x => x.Value == _MODEL_CODIGOS.COD_TIPO_SALARIO.ToString()).ToList();
                if (LISTA_TIPO_SALARIO.Count > 0)
                {
                    _MODEL_CODIGOS.NOMBRE_TIPO_SALARIO = LISTA_TIPO_SALARIO.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_TIPO_SALARIO = 0;
                }
            }

            if (_MODEL_CODIGOS.COD_CARGO != 0) {
                List<SelectListItem> LISTA_NOMBRE_CARGO = _MODEL_CODIGOS.LIST_NOMBRE_CARGO.Where(x => x.Value == _MODEL_CODIGOS.COD_CARGO.ToString()).ToList();
                if (LISTA_NOMBRE_CARGO.Count > 0)
                {
                    _MODEL_CODIGOS.NOMBRE_CARGO = LISTA_NOMBRE_CARGO.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_CARGO = 0;
                }
            }

            if (_MODEL_CODIGOS.COD_JORNADA_LABORAL != 0) {
                List<SelectListItem> LISTA_JORNADA_LABORAL = _MODEL_CODIGOS.LIST_NOMBRE_JORNADA_LABORAL.Where(X => X.Value == _MODEL_CODIGOS.COD_JORNADA_LABORAL.ToString()).ToList();
                if (LISTA_JORNADA_LABORAL.Count > 0) {
                    _MODEL_CODIGOS.NOMBRE_JORNADA_LABORAL = LISTA_JORNADA_LABORAL.First().Text;
                }
                else
                {
                    _MODEL_CODIGOS.COD_JORNADA_LABORAL = 0;
                }
            }

            if (_MODEL_CODIGOS.COD_MERCADO != 0) {
                List<SelectListItem> LISTA_MERCADO = _MODEL_CODIGOS.LIST_MERCADO.Where(x => x.Value == _MODEL_CODIGOS.COD_MERCADO.ToString()).ToList();
                if (LISTA_MERCADO.Count > 0)
                {
                    _MODEL_CODIGOS.MERCADO = LISTA_MERCADO.First().Text;
                }
                else {
                    _MODEL_CODIGOS.COD_MERCADO = 0;
                }
            }

            if (_MODEL_CODIGOS.COD_TIPO_DOCUMENTO != 0)
            {
                List<SelectListItem> LISTA_TIPO_DOCUMENTO = _MODEL_CODIGOS.LIST_TIPO_DOCUMENTO.Where(X => X.Value == _MODEL_CODIGOS.COD_TIPO_DOCUMENTO.ToString()).ToList();
                if (LISTA_TIPO_DOCUMENTO.Count > 0)
                {
                    _MODEL_CODIGOS.NOMBRE_TIPO_DOCUMENTO = LISTA_TIPO_DOCUMENTO.First().Text;
                }
                else
                {
                    _MODEL_CODIGOS.COD_TIPO_DOCUMENTO = 0;
                }
            }

            return _MODEL_CODIGOS;
        }

        public int APROBAR_REQUISICION_LOGICA(int COD_REQUISICION, String ID_USUARIO, string observacion) {
          return new ACCES_REQUISICION().APROBAR_REQUISICION_ACESS(COD_REQUISICION, ID_USUARIO, observacion);
        }

        public int REQUISICION_MODIFICAR_LOGICA(int COD_REQUISICION, string oBSERVACIONES, String ID_USUARIO)
        {
            return new ACCES_REQUISICION().REQUISICION_MODIFICAR_ACESS(COD_REQUISICION, oBSERVACIONES, ID_USUARIO);
        }

        public int REQUISICION_RECHAZAR_LOGICA(int COD_REQUISICION, string oBSERVACIONES, String USUARIO)
        {
            return new ACCES_REQUISICION().REQUISICION_RECHAZAR_ACESS(COD_REQUISICION, oBSERVACIONES, USUARIO);
        }

        public List<SelectListItem> CONSULTAR_EMPLEADOS_LOGICA()
        {
            return new PROXY().CONSULTAR_EMPLEADOS_API().Select(x => new SelectListItem()
            {
                Text = x.NOMBRES,
                Value = x.DOCUMENTO_NUMERO.ToString()
            }).ToList();
        }
    }
}
