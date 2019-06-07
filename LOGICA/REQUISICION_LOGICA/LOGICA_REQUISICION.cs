using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOGICA.LOGICA_REQUISICION;
using LOGICA.MODELO_LOGICA;
using MODELO_DATOS.MODELO_REQUISICION;
using MODELO_DATOS.MODELO_REQUISICION.LISTAS_API;
using Newtonsoft.Json.Linq;
using REPOSITORIOS.REQUISICION.ACCESS;

namespace LOGICA.REQUISICION_LOGICA
{
    public class LOGICA_REQUISICION
    {

        public REQUISICIONViewModel LLENAR_CONTROLES(REQUISICIONViewModel _modelReturn) {

            _modelReturn.LIST_NOMBRE_TIPO_NECESIDAD = CONSULTAR_TIPOS_NECESIDAD();
            _modelReturn.LIST_NOMBRE_ESTADO_REQUISICION = CONSULTAR_ESTADOS();
            _modelReturn.LIST_NOMBRE_CECO = CONSULTAR_CECOS();
            _modelReturn.LIST_NOMBRE_EQIPO_VENTAS = CONSULTAR_EQUIPOS_VENTAS();
            _modelReturn.LIST_NIVEL_RIESGO_ARL = CONSULTAR_RIESGOS_ARL();
            _modelReturn.LIST_NOMBRE_CATEGORIA_ED = CONSULTAR_CATEGORIAS_ED();
            _modelReturn.LIST_NOMBRE_SOCIEDAD  = CONSULTAR_SOCIEDADES();
            _modelReturn.LIST_NOMBRE_TIPO_CONTRATO = CONSULTAR_CONTRATOS();
            _modelReturn.LIST_NOMBRE_GERENCIA = CONSULTAR_GERENCIAS();
            _modelReturn.LIST_NOMBRE_UBICACION_FISICA = CONSULTAR_UBICACIONES_FISICAS();
            _modelReturn.LIST_NOMBRE_JORNADA_LABORAL = CONSULTAR_JORNADAS_LABORALES();
            _modelReturn.LIST_NOMBRE_CIUDAD_TRABAJO = CONSULTAR_CIUDADES_TRABAJO();
            _modelReturn.LIST_NOMBRE_CATEGORIA = CONSULTAR_CATEGORIAS();
            _modelReturn.LIST_NOMBRE_TIPO_SALARIO = CONSULTAR_TIPOS_SALARIOS();
            _modelReturn.LIST_NOMBRE_CARGO = CONSULTAR_CARGOS();
            _modelReturn.LIST_NOMBRE_TIPO_REQUISICION = CONSULTAR_TIPOS_REQUISICION();
            _modelReturn.LIST_DIA_LABORAL_DESDE = CONSULTAR_DIAS_LABORALES();
            _modelReturn.LIST_DIA_LABORAL_HASTA = CONSULTAR_DIAS_LABORALES();
            _modelReturn.LIST_HORARIO_LABORAL_DESDE = CONSULTAR_HORARIO_LABORAL();
            _modelReturn.LIST_HORARIO_LABORAL_HASTA = CONSULTAR_HORARIO_LABORAL();
            _modelReturn.LIST_NOMBRE_JORNADA_LABORAL = CONSULTAR_JORNADAS_LABORALES();
            _modelReturn.LIST_MERCADO = CONSULTAR_MERCADO();
            _modelReturn.LIST_TIPO_DOCUMENTO = CONSULTAR_TIPO_DOCUMENTO();



            return _modelReturn;
        }
        /// <summary>
        /// desde base de datos
        /// mapeada
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> CONSULTAR_TIPOS_NECESIDAD(){
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD().Select(x => new SelectListItem(){
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
            return new ACCES_REQUISICION().CONSULTAR_ESTADOS().Select(x => new SelectListItem(){
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
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_REQUISICION().Select(x => new SelectListItem()
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
            DIAS_LABORAL.Add(new SelectListItem() { Text = "1:30", Value = "1:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "2:00", Value = "2:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "2:30", Value = "2:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "3:00", Value = "3:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "3:30", Value = "3:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "4:00", Value = "4:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "4:30", Value = "4:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "5:00", Value = "5:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "5:30", Value = "5:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "6:00", Value = "6:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "6:30", Value = "6:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "7:00", Value = "7:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "7:30", Value = "7:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "8:00", Value = "8:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "8:30", Value = "8:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "9:00", Value = "9:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "9:30", Value = "9:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "10:00", Value = "10:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "10:30", Value = "10:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "11:00", Value = "11:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "11:30", Value = "11:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "12:00", Value = "12:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "12:30", Value = "12:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "13:00", Value = "13:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "13:30", Value = "13:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "14:00", Value = "14:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "14:30", Value = "14:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "15:00", Value = "15:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "15:30", Value = "15:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "16:00", Value = "16:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "16:30", Value = "16:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "17:00", Value = "17:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "17:30", Value = "17:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "18:00", Value = "18:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "18:30", Value = "18:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "19:00", Value = "19:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "19:30", Value = "19:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "20:00", Value = "20:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "20:30", Value = "20:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "21:00", Value = "21:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "21:30", Value = "21:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "22:00", Value = "22:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "22:30", Value = "22:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "23:00", Value = "23:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "23:30", Value = "23:30" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "24:00", Value = "24:00" });
            DIAS_LABORAL.Add(new SelectListItem() { Text = "24:30", Value = "24:30" });


            return DIAS_LABORAL;
        }

        public List<REQUISICIONViewModel> SOLICITAR_REQUISICIONES(FILTROREQUISICION _filtro) {
            return new ACCES_REQUISICION().CONSULTAR_REQUISICION_X_FILTRO(_filtro);
        }

        private REQUISICIONViewModel CARGAR_MODELO_DEL_API(REQUISICIONViewModel _modeloRequisicion, PUESTO _puesto)
        {

            //INFROMACION GENERAL
            _modeloRequisicion.COD_GERENCIA = Convert.ToInt32(_puesto.COD_GERENCIA);
            _modeloRequisicion.NOMBRE_GERENCIA = _puesto.NOMBRE_GERENCIA;
            _modeloRequisicion.COD_TIPO_CONTRATO = Convert.ToInt32(_puesto.COD_TIPO_CONTRATO);
            _modeloRequisicion.NOMBRE_TIPO_CONTRATO = _puesto.NOMBRE_TIPO_CONTRATO;
            _modeloRequisicion.JEFE_INMEDIATO = _puesto.NOMBRE_JEFE;
            _modeloRequisicion.COD_SOCIEDAD = Convert.ToInt32(_puesto.COD_SOCIEDAD);
            _modeloRequisicion.NOMBRE_SOCIEDAD = _puesto.NOMBRE_SOCIEDAD;
            _modeloRequisicion.COD_EQUIPO_VENTAS = Convert.ToInt32(_puesto.COD_EQUIPO_VENTA);
            _modeloRequisicion.NOMBRE_EQIPO_VENTAS = _puesto.NOMBRE_EQUIPO_VENTA;
            _modeloRequisicion.COD_CIUDAD_TRABAJO = Convert.ToInt32(_puesto.COD_DANE_CIUDAD);
            _modeloRequisicion.NOMBRE_CIUDAD_TRABAJO = _puesto.NOMBRE_CIUDAD;
            _modeloRequisicion.COD_UBICACION_FISICA = Convert.ToInt32(_puesto.COD_UBICACION_FISICA);
            _modeloRequisicion.NOMBRE_UBICACION_FISICA = _puesto.NOMBRE_UBICACION_FIFICA;
            _modeloRequisicion.COD_NIVEL_RIESGO_ARL = Convert.ToInt32(_puesto.COD_NIVEL_RIESGO);
            _modeloRequisicion.NIVEL_RIESGO_ARL = Convert.ToString(_puesto.NIVEL_RIESGO);
            _modeloRequisicion.COD_CATEGORIA_ED = Convert.ToInt32(_puesto.COD_CATEGORIA_EVALUACION_DESEMPENO);
            _modeloRequisicion.NOMBRE_CATEGORIA_ED = _puesto.NOMBRE_CATEGORIA_EVALUACION_DESEMPENO;
            if (_puesto.CARGO_CRITICO == "1")
            {
                _modeloRequisicion.CARGO_CRITICO = true;
            }
            else
            {
                _modeloRequisicion.CARGO_CRITICO = false;
            }               
            _modeloRequisicion.COD_JORNADA_LABORAL = Convert.ToInt32(_puesto.COD_JORNADA_TRABAJO);
            _modeloRequisicion.NOMBRE_JORNADA_LABORAL = _puesto.NOMBRE_JORNADA_TRABAJO;
            _modeloRequisicion.COD_HORARIO_LABORAL_DESDE = Convert.ToInt32(_puesto.COD_HORARIO_TRABAJO);
            _modeloRequisicion.HORARIO_LABORAL_DESDE = _puesto.horariO_DESDE;
            _modeloRequisicion.COD_HORARIO_LABORAL_HASTA = Convert.ToInt32(_puesto.COD_HORARIO_TRABAJO);
            _modeloRequisicion.HORARIO_LABORAL_HASTA = _puesto.horariO_HASTA;
            _modeloRequisicion.COD_DIA_LABORAL_DESDE = Convert.ToInt32(_puesto.COD_DIA_LABORAL);
            _modeloRequisicion.DIA_LABORAL_DESDE = _puesto.diaS_LABORALES_DESDE;
            _modeloRequisicion.COD_DIA_LABORAL_HASTA = Convert.ToInt32(_puesto.COD_DIA_LABORAL);
            _modeloRequisicion.DIA_LABORAL_HASTA = _puesto.diaS_LABORALES_HASTA;

            //INFROMACION SALARIAL
            _modeloRequisicion.SALARIO_FIJO = Convert.ToDecimal(_puesto.SALARIO_FIJO);
            _modeloRequisicion.PORCENTAJE_SALARIO_FIJO = Convert.ToDecimal(_puesto.PORCENTAJE_SALARIO_FIJO);
            _modeloRequisicion.SALARIO_VARIABLE = Convert.ToDecimal(_puesto.SALARIO_VARIABLE);
            _modeloRequisicion.PORCENTAJE_SALARIO_VARIABLE = Convert.ToDecimal(_puesto.PORCENTAJE_SALARIO_VARIABLE);
            _modeloRequisicion.SOBREREMUNERACION = Convert.ToDecimal(_puesto.SOBREREMUNERACION);
            _modeloRequisicion.PORCENTAJE_SOBREREMUNERACION = Convert.ToDecimal(_puesto.PORCENTAJE_SOBREREMUNERACION);
            _modeloRequisicion.EXTRA_FIJA = Convert.ToDecimal(_puesto.EXTRA_FIJA);
            _modeloRequisicion.RECARGO_NOCTURNO = Convert.ToDecimal(_puesto.RECARGO_NOCTURNO_FIJO);
            _modeloRequisicion.MEDIO_TRANSPORTE = Convert.ToDecimal(_puesto.MEDIOS_TRANSPORTE);
            _modeloRequisicion.SALARIO_TOTAL = Convert.ToDecimal(_puesto.SALARIO_TOTAL);
            _modeloRequisicion.BONO_ANUAL = Convert.ToDecimal(_puesto.BONO_ANUAL);
            _modeloRequisicion.NUMERO_SALARIOS = Convert.ToInt32(_puesto.NUMERO_SALARIO);
            _modeloRequisicion.MESES_GARANTIZADOS = Convert.ToInt32(_puesto.MESES_GARANTIZADO);
            _modeloRequisicion.COD_TIPO_SALARIO = Convert.ToInt32(_puesto.COD_TIPO_SALARIO);
            _modeloRequisicion.NOMBRE_TIPO_SALARIO = _puesto.NOMBRE_TIPO_SALARIO;
            _modeloRequisicion.FACTOR_PRESTACIONAL = _puesto.FP.Value;
            _modeloRequisicion.INGRESO_PROM_MENSUAL = Convert.ToDecimal(_puesto.PROMEDIO_MES);
            _modeloRequisicion.INGRESO_PROM_ANUAL = Convert.ToDecimal(_puesto.PROMEDIO_ANO);
            _modeloRequisicion.COD_MERCADO = Convert.ToInt32(_puesto.COD_MERCADO);
            _modeloRequisicion.MERCADO = _puesto.NOMBRE_MERCADO;
            _modeloRequisicion.COD_CATEGORIA = Convert.ToInt32(_puesto.COD_CATEGORIA_SALARIALES);
            _modeloRequisicion.NOMBRE_CATEGORIA = _puesto.NOMBRE_CATEGORIA_SALARIO;

            //PUNTO MEDIO
            _modeloRequisicion.PUNTO_MEDIO_80 = Convert.ToDecimal(_puesto.PUNTO_MEDIO_80_PORCIENTO);
            _modeloRequisicion.PUNTO_MEDIO_100 = Convert.ToDecimal(_puesto.PUNTO_MEDIO_100_PORCIENTO);
            _modeloRequisicion.PUNTO_MEDIO_120 = Convert.ToDecimal(_puesto.PUNTO_MEDIO_120_PORCIENTO);

            _modeloRequisicion.POSICIONAMIENTO = _puesto.POSICIONAMIENTO.Value;

            return _modeloRequisicion;
        }

        public REQUISICIONViewModel BUSCAR_REQUISICIONES_BP(REQUISICIONViewModel _modeloRequisicion)
        {
            try
            {
                if (_modeloRequisicion.ES_MODIFICACION) {
                    PUESTO puestoEmpleado = new PROXY().CONSULTAR_PUESTOS_X_CEDULA_API(_modeloRequisicion.NUMERO_DOCUMENTO_EMPLEADO);
                    _modeloRequisicion = CARGAR_MODELO_DEL_API(_modeloRequisicion, puestoEmpleado);
                }
                else if (_modeloRequisicion.COD_CARGO != 0){
                    PUESTO puesto = new PROXY().CONSULTAR_PUESTO_X_COD_CARGO_API(_modeloRequisicion.COD_CARGO.ToString()).First();
                    _modeloRequisicion = CARGAR_MODELO_DEL_API(_modeloRequisicion, puesto);
                }
            }
            catch (Exception ex)
            {
                throw ex;                
            }
            return _modeloRequisicion;
        }

        public PUESTO BUSCAR_PUESTO_X_CARGO_API(string _idCargo)
        {
            PUESTO puesto = new PUESTO();
            try
            {
                if (!_idCargo.Equals("0"))
                {
                    List<PUESTO> listPuestos = new PROXY().CONSULTAR_PUESTO_X_COD_CARGO_API(_idCargo);
                    if (listPuestos.Count() > 0)
                    {
                        puesto = listPuestos.First();
                    }

                    //Objeto de prueba cuando fallal el api
                    //_puntosMedio = new PUNTOS_MEDIO()
                    //{
                    //    COD_CARGO = 1,
                    //    COD_CENTRO_COSTO = 1,
                    //    COD_GERENCIA = 1,
                    //    COD_TIPO_CONTRATO = 1,
                    //    NOMBRE_JEFE = "prueba cargue",
                    //    COD_SOCIEDAD = 1,
                    //    COD_EQUIPO_VENTA = 1,
                    //    COD_DANE_CIUDAD = "1",
                    //    COD_UBICACION_FISICA = 1,
                    //    COD_NIVEL_RIESGO = 1,
                    //    COD_CATEGORIA_EVALUACION_DESEMPENO = 1,
                    //    CARGO_CRITICO = "1",
                    //    COD_JORNADA_TRABAJO = 1,
                    //    COD_HORARIO_TRABAJO = 1,
                    //    COD_DIA_LABORAL = 1,
                    //    SALARIO_FIJO = 1000,
                    //    PORCENTAJE_SALARIO_FIJO = 11,
                    //    SALARIO_VARIABLE = 22,
                    //    PORCENTAJE_SALARIO_VARIABLE = 33,
                    //    SOBREREMUNERACION = 44,
                    //    PORCENTAJE_SOBREREMUNERACION = 55,
                    //    EXTRA_FIJA = 66,
                    //    RECARGO_NOCTURNO_FIJO = 77,
                    //    MEDIOS_TRANSPORTE = 88,
                    //    SALARIO_TOTAL = 99,
                    //    BONO_ANUAL = 111,
                    //    NUMERO_SALARIO = 222,
                    //    MESES_GARANTIZADO = 333,
                    //    COD_TIPO_SALARIO = 444
                    //};
                }
            }
            catch (Exception ex)
            {
                throw ex;          
            }
            return puesto;
        }

        public REQUISICIONViewModel BUSCAR_REQUISICIONES(int _idRequsicion){
            REQUISICIONViewModel objReqModel = null;
            try {
                objReqModel = new ACCES_REQUISICION().CONSULTAR_REQUISICION_X_ID(_idRequsicion);
            }
            catch (Exception ex) {
                throw ex;
            }
            return objReqModel;
        }

        public int INSERTAR_REQUISICION(REQUISICIONViewModel _modeloRequisicion) {
            if (_modeloRequisicion.COD_REQUISICION != 0){
                if (new ACCES_REQUISICION().ACTUALIZAR_REQUISICION(_modeloRequisicion)) {
                    return _modeloRequisicion.COD_REQUISICION;
                } else {
                    return 0;
                }
            }
            else { 
            return new ACCES_REQUISICION().INSERTAR_REQUISICION(_modeloRequisicion);
            }
        }

        public Boolean ACTUALIZAR_REQUISICION(REQUISICIONViewModel _modeloRequisicion){
            return new ACCES_REQUISICION().ACTUALIZAR_REQUISICION(_modeloRequisicion);
        }

        public REQUISICIONViewModel CONSULTAR_VALORES_LISTAS_POR_CODIGO(REQUISICIONViewModel _modeloRequisicion) {


            if (_modeloRequisicion.COD_CARGO != 0) {
                List<SelectListItem> LISTA_CARGO = _modeloRequisicion.LIST_NOMBRE_CARGO.Where(x => x.Value == _modeloRequisicion.COD_CARGO.ToString()).ToList();
                if (LISTA_CARGO.Count > 0){
                    _modeloRequisicion.NOMBRE_CARGO = LISTA_CARGO.First().Text;
                } else {
                    _modeloRequisicion.COD_CARGO = 0;
                }
            }
            if (_modeloRequisicion.COD_GERENCIA != 0){
                List<SelectListItem> LISTA_GERENCIA = _modeloRequisicion.LIST_NOMBRE_GERENCIA.Where(x => x.Value == _modeloRequisicion.COD_GERENCIA.ToString()).ToList();
                if (LISTA_GERENCIA.Count() > 0)
                {
                    _modeloRequisicion.NOMBRE_GERENCIA = LISTA_GERENCIA.First().Text;
                }
                else {
                    _modeloRequisicion.COD_GERENCIA = 0;
                }
            }
            if (_modeloRequisicion.COD_TIPO_CONTRATO != 0) {
                List<SelectListItem> LISTA_CONTRATO = _modeloRequisicion.LIST_NOMBRE_TIPO_CONTRATO.Where(x => x.Value == _modeloRequisicion.COD_TIPO_CONTRATO.ToString()).ToList();
                if (LISTA_CONTRATO.Count > 0)
                {
                    _modeloRequisicion.NOMBRE_TIPO_CONTRATO = LISTA_CONTRATO.First().Text;
                }
                else {
                    _modeloRequisicion.COD_TIPO_CONTRATO = 0;
                }
            }
            if (_modeloRequisicion.COD_CECO != 0) {
                List<SelectListItem> LISTA_CECO = _modeloRequisicion.LIST_NOMBRE_CECO.Where(x => x.Value == _modeloRequisicion.COD_CECO.ToString()).ToList();
                if (LISTA_CECO.Count > 0) {
                    _modeloRequisicion.NOMBRE_CECO = LISTA_CECO.First().Text;
                }else {
                    _modeloRequisicion.COD_CECO = 0;
                }
                
            }
            if (_modeloRequisicion.COD_SOCIEDAD != 0) {
                List<SelectListItem> LISTA_SOCIEDAD = _modeloRequisicion.LIST_NOMBRE_SOCIEDAD.Where(x => x.Value == _modeloRequisicion.COD_SOCIEDAD.ToString()).ToList();
                if (LISTA_SOCIEDAD.Count > 0) {
                    _modeloRequisicion.NOMBRE_SOCIEDAD = LISTA_SOCIEDAD.First().Text;
                }else {
                    _modeloRequisicion.COD_SOCIEDAD = 0;
                }
                
            }
            if (_modeloRequisicion.COD_EQUIPO_VENTAS != 0) {
                List<SelectListItem> LISTA_VENTAS = _modeloRequisicion.LIST_NOMBRE_EQIPO_VENTAS.Where(x => x.Value == _modeloRequisicion.COD_EQUIPO_VENTAS.ToString()).ToList();
                if (LISTA_VENTAS.Count > 0)
                {
                    _modeloRequisicion.NOMBRE_EQIPO_VENTAS = LISTA_VENTAS.First().Text;
                }
                else {
                    _modeloRequisicion.COD_EQUIPO_VENTAS = 0;
                }
            }
            if (_modeloRequisicion.COD_CIUDAD_TRABAJO != 0)
            {
                List<SelectListItem> LISTA_CIUDAD_TRABAJO = _modeloRequisicion.LIST_NOMBRE_CIUDAD_TRABAJO.Where(x => x.Value == _modeloRequisicion.COD_CIUDAD_TRABAJO.ToString()).ToList();
                if (LISTA_CIUDAD_TRABAJO.Count > 0){
                    _modeloRequisicion.NOMBRE_CIUDAD_TRABAJO = LISTA_CIUDAD_TRABAJO.First().Text;
                }else {
                    _modeloRequisicion.COD_CIUDAD_TRABAJO = 0;
                }
            }
            if (_modeloRequisicion.COD_UBICACION_FISICA != 0) {
                List<SelectListItem> LISTA_UBICACION_FISICA = _modeloRequisicion.LIST_NOMBRE_UBICACION_FISICA.Where(x => x.Value == _modeloRequisicion.COD_UBICACION_FISICA.ToString()).ToList();
                if (LISTA_UBICACION_FISICA.Count > 0){
                    _modeloRequisicion.NOMBRE_UBICACION_FISICA = LISTA_UBICACION_FISICA.First().Text;
                } else {
                    _modeloRequisicion.COD_UBICACION_FISICA = 0;
                }
                
            }
            if (_modeloRequisicion.COD_NIVEL_RIESGO_ARL != 0) {
                List<SelectListItem> LISTA_RIESGO_ARL = _modeloRequisicion.LIST_NIVEL_RIESGO_ARL.Where(x => x.Value == _modeloRequisicion.COD_NIVEL_RIESGO_ARL.ToString()).ToList();
                if (LISTA_RIESGO_ARL.Count > 0) {
                    _modeloRequisicion.NIVEL_RIESGO_ARL = LISTA_RIESGO_ARL.First().Text;
                } 
            }
            if (_modeloRequisicion.COD_CATEGORIA_ED != 0) {
                List<SelectListItem> LISTA_CATEGORIA_ED = _modeloRequisicion.LIST_NOMBRE_CATEGORIA_ED.Where(x => x.Value == _modeloRequisicion.COD_CATEGORIA_ED.ToString()).ToList();
                if (LISTA_CATEGORIA_ED.Count > 0){
                    _modeloRequisicion.NOMBRE_CATEGORIA_ED = LISTA_CATEGORIA_ED.First().Text;
                }
                else { _modeloRequisicion.COD_CATEGORIA_ED = 0;
                }
                
            }
            if (_modeloRequisicion.COD_JORNADA_LABORAL != 0) {
                List<SelectListItem> LISTA_JORNADA_LABORAL = _modeloRequisicion.LIST_NOMBRE_JORNADA_LABORAL.Where(x => x.Value == _modeloRequisicion.COD_JORNADA_LABORAL.ToString()).ToList();
                if (LISTA_JORNADA_LABORAL.Count > 0)
                {
                    _modeloRequisicion.NOMBRE_JORNADA_LABORAL = LISTA_JORNADA_LABORAL.First().Text;
                }
                else {
                    _modeloRequisicion.COD_JORNADA_LABORAL = 0;
                }
               
            }
            if (_modeloRequisicion.COD_DIA_LABORAL_DESDE !=0) {
                List<SelectListItem> LISTA_LABORAL_DESDE = _modeloRequisicion.LIST_DIA_LABORAL_DESDE.Where(x => x.Value == _modeloRequisicion.COD_DIA_LABORAL_DESDE.ToString()).ToList();
                if (LISTA_LABORAL_DESDE.Count > 0)
                {
                    _modeloRequisicion.DIA_LABORAL_DESDE = LISTA_LABORAL_DESDE.First().Text;
                }
                else {
                    _modeloRequisicion.COD_DIA_LABORAL_DESDE = 0;
                }
                
            }
            if (_modeloRequisicion.COD_DIA_LABORAL_HASTA != 0) {
                List<SelectListItem> LISTA_LABORAL_HASTA = _modeloRequisicion.LIST_DIA_LABORAL_HASTA.Where(x => x.Value == _modeloRequisicion.COD_DIA_LABORAL_HASTA.ToString()).ToList();
                if (LISTA_LABORAL_HASTA.Count > 0)
                {
                    _modeloRequisicion.DIA_LABORAL_HASTA = LISTA_LABORAL_HASTA.First().Text;
                }
                else {
                    _modeloRequisicion.COD_DIA_LABORAL_HASTA = 0;
                }
        
            }
            if (_modeloRequisicion.COD_TIPO_SALARIO != 0) {
                List<SelectListItem> LISTA_TIPO_SALARIO = _modeloRequisicion.LIST_NOMBRE_TIPO_SALARIO.Where(x => x.Value == _modeloRequisicion.COD_TIPO_SALARIO.ToString()).ToList();
                if (LISTA_TIPO_SALARIO.Count > 0)
                {
                    _modeloRequisicion.NOMBRE_TIPO_SALARIO = LISTA_TIPO_SALARIO.First().Text;
                }
                else {
                    _modeloRequisicion.COD_TIPO_SALARIO = 0;
                }
               
            }
            if (_modeloRequisicion.COD_CATEGORIA != 0) {
                List<SelectListItem> LISTA_COD_CATEGORIA = _modeloRequisicion.LIST_NOMBRE_CATEGORIA.Where(x => x.Value == _modeloRequisicion.COD_CATEGORIA.ToString()).ToList();
                if (LISTA_COD_CATEGORIA.Count > 0)
                {
                    _modeloRequisicion.NOMBRE_CATEGORIA = LISTA_COD_CATEGORIA.First().Text;
                }
                else {
                    _modeloRequisicion.COD_CATEGORIA = 0;
                }
                
            }

            if (_modeloRequisicion.COD_TIPO_SALARIO != 0) {
                List<SelectListItem> LISTA_TIPO_SALARIO = _modeloRequisicion.LIST_NOMBRE_TIPO_SALARIO.Where(x => x.Value == _modeloRequisicion.COD_TIPO_SALARIO.ToString()).ToList();
                if (LISTA_TIPO_SALARIO.Count > 0)
                {
                    _modeloRequisicion.NOMBRE_TIPO_SALARIO = LISTA_TIPO_SALARIO.First().Text;
                }
                else {
                    _modeloRequisicion.COD_TIPO_SALARIO = 0;
                }
            }

            if (_modeloRequisicion.COD_CARGO != 0) {
                List<SelectListItem> LISTA_NOMBRE_CARGO = _modeloRequisicion.LIST_NOMBRE_CARGO.Where(x => x.Value == _modeloRequisicion.COD_CARGO.ToString()).ToList();
                if (LISTA_NOMBRE_CARGO.Count > 0)
                {
                    _modeloRequisicion.NOMBRE_CARGO = LISTA_NOMBRE_CARGO.First().Text;
                }
                else {
                    _modeloRequisicion.COD_CARGO = 0;
                }
            }

            if (_modeloRequisicion.COD_JORNADA_LABORAL != 0) {
                List<SelectListItem> LISTA_JORNADA_LABORAL = _modeloRequisicion.LIST_NOMBRE_JORNADA_LABORAL.Where(X => X.Value == _modeloRequisicion.COD_JORNADA_LABORAL.ToString()).ToList();
                if (LISTA_JORNADA_LABORAL.Count > 0) {
                    _modeloRequisicion.NOMBRE_JORNADA_LABORAL = LISTA_JORNADA_LABORAL.First().Text;
                }
                else
                {
                    _modeloRequisicion.COD_JORNADA_LABORAL = 0;
                }
            }

            if (_modeloRequisicion.COD_MERCADO != 0) {
                List<SelectListItem> LISTA_MERCADO = _modeloRequisicion.LIST_MERCADO.Where(x => x.Value == _modeloRequisicion.COD_MERCADO.ToString()).ToList();
                if (LISTA_MERCADO.Count > 0)
                {
                    _modeloRequisicion.MERCADO = LISTA_MERCADO.First().Text;
                }
                else {
                    _modeloRequisicion.COD_MERCADO = 0;
                }
            }

            if (_modeloRequisicion.COD_TIPO_DOCUMENTO != 0)
            {
                List<SelectListItem> LISTA_TIPO_DOCUMENTO = _modeloRequisicion.LIST_TIPO_DOCUMENTO.Where(X => X.Value == _modeloRequisicion.COD_TIPO_DOCUMENTO.ToString()).ToList();
                if (LISTA_TIPO_DOCUMENTO.Count > 0)
                {
                    _modeloRequisicion.NOMBRE_TIPO_DOCUMENTO = LISTA_TIPO_DOCUMENTO.First().Text;
                }
                else
                {
                    _modeloRequisicion.COD_TIPO_DOCUMENTO = 0;
                }
            }

            return _modeloRequisicion;
        }

        public int APROBAR_REQUISICION_LOGICA(int _codRequisicion, string _idUsuario, string _observacion) {
          return new ACCES_REQUISICION().APROBAR_REQUISICION(_codRequisicion, _idUsuario, _observacion);
        }

        public int REQUISICION_MODIFICAR_LOGICA(int _codRequisicion, string _observacion, string _idUsuario)
        {
            return new ACCES_REQUISICION().MODIFICAR_REQUISICION(_codRequisicion, _observacion, _idUsuario);
        }

        public int REQUISICION_RECHAZAR_LOGICA(int _codRequisicion, string _observacion, string _usuario)
        {
            return new ACCES_REQUISICION().RECHAZAR_REQUISICION(_codRequisicion, _observacion, _usuario);
        }

        public List<SelectListItem> CONSULTAR_EMPLEADOS()
        {

            EMPLEADO apiEmpleado = new EMPLEADO();
            List<SelectListItem> listEmpleados = new List<SelectListItem>();
            try
            {
                listEmpleados = apiEmpleado.CONSULTAR_EMPLEADOS().Select(x => new SelectListItem()
                {
                    Text = x.NOMBRES,
                    Value = x.DOCUMENTO_NUMERO
                }).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listEmpleados;
        }

        public List<TRAZA_BOTONES_ENTIDAD> CONSULTAR_TRAZA_CAMPOS(int _codRequisicion, string _campoRequisicion, List<SelectListItem> _listaArl, List<SelectListItem> _listaEstados, List<SelectListItem> _listaCategoria) {
            List <TRAZA_BOTONES_ENTIDAD> OBJETO_TRAZA = new ACCES_REQUISICION().CONSULTAR_TRAZA_CAMPOS(_codRequisicion, _campoRequisicion);
            foreach (TRAZA_BOTONES_ENTIDAD ITEM in OBJETO_TRAZA) {
                if (ITEM.COD_NIVEL_RIESGO_ARL != null && ITEM.COD_NIVEL_RIESGO_ARL!=0){
                    ITEM.NOMBRE_ARL = _listaArl.Where(x => x.Value == ITEM.COD_NIVEL_RIESGO_ARL.ToString()).First().Text;
                }
                if (ITEM.COD_ESTADO != 0){
                    ITEM.NOMBRE_ESTADOS_REQUISICION = _listaEstados.Where(x => x.Value == ITEM.COD_ESTADO.ToString()).First().Text;
                }
                if (ITEM.COD_CATEGORIA != 0 && ITEM.COD_CATEGORIA!=null)
                {
                    ITEM.CATRGORIA = _listaCategoria.Where(x => x.Value == ITEM.COD_CATEGORIA.ToString()).First().Text;
                }
            }
            return OBJETO_TRAZA;
        }

        public List<CONSULTA_NOTIFICACIONES_ENTIDAD> CONSULTA_NOTIFICACIONES(string _codUsuario) {
            List <CONSULTA_NOTIFICACIONES_ENTIDAD> LISTA_NOTIFICACIONES= new ACCES_REQUISICION().CONSULTAR_NOTIFICACIONES(_codUsuario);
            foreach (CONSULTA_NOTIFICACIONES_ENTIDAD ITEM in LISTA_NOTIFICACIONES) {
                if (ITEM.ES_MODIFICACION)
                    ITEM.NOMBRE_REQUISICION = "Modificacion";
            }
            return LISTA_NOTIFICACIONES;
        }
    }
}
