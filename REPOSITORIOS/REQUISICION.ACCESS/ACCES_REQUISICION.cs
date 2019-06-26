using log4net;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION_ENTITY;
using REPOSITORIOS.TRAZA_LOG;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace REPOSITORIOS.REQUISICION.ACCESS
{
    public class ACCES_REQUISICION
    {
        private LOG_CENTRALIZADO logCentralizado = new LOG_CENTRALIZADO(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));

        public List<TIPO_NECESIDADViewModel> CONSULTAR_TIPOS_NECESIDAD()
        {
            List<TIPO_NECESIDADViewModel> lst = null;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ1", "CONSULTAR_TIPOS_NECESIDAD");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    ObjectResult<CONSULTAR_TIPOS_NECESIDAD_Result> consulta = db.CONSULTAR_TIPOS_NECESIDAD();
                    lst = consulta.Select(x => new TIPO_NECESIDADViewModel()
                    {
                        COD_TIPO_NECESIDAD = x.COD_TIPO_NECESIDAD,
                        NOMBRE_NECESIDAD = x.NOMBRE_NECESIDAD
                    }).ToList();
                }
                logCentralizado.FINALIZANDO_LOG("REPREQ1", "CONSULTAR_TIPOS_NECESIDAD");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ1", "CONSULTAR_TIPOS_NECESIDAD", ex);
                throw ex;
            }

            return lst;
        }

        public List<ESTADOViewModel> CONSULTAR_ESTADOS()
        {
            List<ESTADOViewModel> lst = null;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ2", "CONSULTAR_ESTADOS");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    ObjectResult<CONSULTAR_ESTADOS_Result> consulta = db.CONSULTAR_ESTADOS();
                    lst = consulta.Select(x => new ESTADOViewModel()
                    {
                        COD_ESTADO_REQUISICION = x.COD_ESTADO_REQUISICION,
                        NOMBRE_ESTADO = x.NOMBRE_ESTADO
                    }).ToList();
                }
                logCentralizado.FINALIZANDO_LOG("REPREQ2", "CONSULTAR_ESTADOS");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ2", "CONSULTAR_ESTADOS", ex);

                throw ex;
            }

            return lst;
        }

        public List<TIPOViewModel> CONSULTAR_TIPOS_REQUISICION()
        {
            List<TIPOViewModel> lst = null;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ3", "CONSULTAR_TIPOS_REQUISICION");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    ObjectResult<CONSULTAR_TIPOS_REQUISICION_Result> consulta = db.CONSULTAR_TIPOS_REQUISICION();
                    lst = consulta.Select(x => new TIPOViewModel()
                    {
                        COD_TIPO_REQUISICION = x.COD_TIPO_REQUISICION,
                        NOMBRE_REQUISICION = x.NOMBRE_REQUISICION
                    }).ToList();
                }
                logCentralizado.FINALIZANDO_LOG("REPREQ3", "CONSULTAR_TIPOS_REQUISICION");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ3", "CONSULTAR_TIPOS_REQUISICION", ex);
                throw ex;
            }
            return lst;
        }

        public List<REQUISICIONViewModel> CONSULTAR_REQUISICION_X_FILTRO(FILTROREQUISICION _filtro)
        {
            List<REQUISICIONViewModel> retorno = null;
            try
            {
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    logCentralizado.INICIANDO_LOG("REPREQ4", "CONSULTAR_REQUISICION_X_FILTRO");
                    ObjectResult<CONSULTA_PRINCIPALXUSUARIO_CODREQUISICION_Result> resultadoSP =
                        db.CONSULTA_PRINCIPALXUSUARIO_CODREQUISICION(_filtro.idUsuario, _filtro.porUsuario, _filtro.cod_estado_requisicion);
                    retorno = resultadoSP.ToList().Select(x => new REQUISICIONViewModel()
                    {
                        NOMBRES_USUARIO = x.Nombres,
                        COD_REQUISICION = x.COD_REQUISICION,
                        COD_ESTADO_REQUISICION = x.COD_ESTADO_REQUISICION ?? 0,
                        USUARIO_CREACION = x.USUARIO_CREACION,
                        EMAIL_USUARIO_CREACION = x.EMAIL_USUARIO_CREACION,
                        COD_CARGO = x.COD_CARGO ?? 0,
                        NOMBRE_CARGO = x.NOMBRE_CARGO,
                        COD_TIPO_REQUISICION = x.COD_TIPO_REQUISICION ?? 0,
                        NOMBRE_TIPO_REQUISICION = x.NOMBRE_REQUISICION,
                        FECHA_CREACION = x.FECHA_CREACION.Value.ToShortDateString(),
                        NOMBRE_ESTADO_REQUISICION = x.NOMBRE_ESTADO,
                        NUMERO_DOCUMENTO_EMPLEADO = x.NUMERO_DOCUMENTO_EMPLEADO,
                        NOMBRE_EMPLEADO = x.NOMBRE_EMPLEADO,
                        COLORES_ESTADOS = x.Color,
                        ES_MODIFICACION = x.ES_MODIFICACION ?? false
                    }).ToList();

                    logCentralizado.FINALIZANDO_LOG("REPREQ4", "CONSULTAR_REQUISICION_X_FILTRO");
                }
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ4", "CONSULTAR_REQUISICION_X_FILTRO", ex);
                throw ex;
            }
            return retorno;
        }

        public Boolean ACTUALIZAR_REQUISICION(REQUISICIONViewModel _modelRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ5", "ACTUALIZAR_REQUISICION");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    db.ACTUALIZAR_REQUISICION(
                   _modelRequisicion.COD_REQUISICION,
                   _modelRequisicion.COD_TIPO_NECESIDAD,
                   _modelRequisicion.COD_CARGO,
                   _modelRequisicion.NOMBRE_CARGO,
                   _modelRequisicion.ORDEN,
                   _modelRequisicion.COD_CECO.ToString(),
                   _modelRequisicion.NOMBRE_CECO,
                   _modelRequisicion.COD_TIPO_REQUISICION,
                   _modelRequisicion.FECHA_INICIO.Year.Equals(1) ? DateTime.Now : _modelRequisicion.FECHA_INICIO,
                   _modelRequisicion.FECHA_FIN.Year.Equals(1) ? DateTime.Now : _modelRequisicion.FECHA_FIN,
                   _modelRequisicion.ES_MODIFICACION,
                   _modelRequisicion.OBSERVACION,
                   1, //_MODEL.COD_ESTADO_REQUISICION
                   _modelRequisicion.USUARIO_MODIFICACION, //llenar con USER.
                   _modelRequisicion.COD_GERENCIA,
                   _modelRequisicion.NOMBRE_GERENCIA,
                   _modelRequisicion.COD_TIPO_CONTRATO,
                   _modelRequisicion.NOMBRE_TIPO_CONTRATO,
                   _modelRequisicion.COD_TIPO_DOCUMENTO,
                   _modelRequisicion.NUMERO_DOCUMENTO_EMPLEADO,
                   _modelRequisicion.NOMBRE_EMPLEADO,
                   _modelRequisicion.JEFE_INMEDIATO,
                   _modelRequisicion.COD_SOCIEDAD,
                   _modelRequisicion.NOMBRE_SOCIEDAD,
                   _modelRequisicion.COD_EQUIPO_VENTAS,
                   _modelRequisicion.NOMBRE_EQIPO_VENTAS,
                   _modelRequisicion.COD_CIUDAD_TRABAJO,
                   _modelRequisicion.NOMBRE_CIUDAD_TRABAJO,
                   _modelRequisicion.COD_DANE_CIUDAD_TRABAJO,
                   _modelRequisicion.COD_UBICACION_FISICA.ToString(),
                   _modelRequisicion.NOMBRE_UBICACION_FISICA,
                   _modelRequisicion.COD_NIVEL_RIESGO_ARL,
                   _modelRequisicion.NIVEL_RIESGO_ARL,
                   _modelRequisicion.COD_CATEGORIA_ED,
                   _modelRequisicion.NOMBRE_CATEGORIA_ED,
                   _modelRequisicion.CARGO_CRITICO.ToString(),
                   _modelRequisicion.COD_JORNADA_LABORAL,
                   _modelRequisicion.NOMBRE_JORNADA_LABORAL,
                   _modelRequisicion.COD_HORARIO_LABORAL_DESDE,
                   _modelRequisicion.HORARIO_LABORAL_DESDE,
                   _modelRequisicion.COD_HORARIO_LABORAL_HASTA,
                   _modelRequisicion.HORARIO_LABORAL_HASTA,
                   _modelRequisicion.COD_DIA_LABORAL_DESDE,
                   _modelRequisicion.DIA_LABORAL_DESDE,
                   _modelRequisicion.COD_DIA_LABORAL_HASTA,
                   _modelRequisicion.DIA_LABORAL_HASTA,
                   _modelRequisicion.POSICION,
                   _modelRequisicion.EMPRESA_TEMPORAL,
                   _modelRequisicion.SALARIO_FIJO,
                   _modelRequisicion.PORCENTAJE_SALARIO_FIJO,
                   _modelRequisicion.SALARIO_VARIABLE,
                   _modelRequisicion.PORCENTAJE_SALARIO_VARIABLE,
                    _modelRequisicion.SOBREREMUNERACION,
                    _modelRequisicion.PORCENTAJE_SOBREREMUNERACION,
                    _modelRequisicion.EXTRA_FIJA,
                    _modelRequisicion.RECARGO_NOCTURNO,
                    _modelRequisicion.MEDIO_TRANSPORTE,
                    _modelRequisicion.SALARIO_TOTAL,
                    _modelRequisicion.BONO_ANUAL,
                    _modelRequisicion.NUMERO_SALARIOS,
                    _modelRequisicion.MESES_GARANTIZADOS,
                    _modelRequisicion.COD_TIPO_SALARIO,
                    _modelRequisicion.NOMBRE_TIPO_SALARIO,
                    _modelRequisicion.FACTOR_PRESTACIONAL,
                    _modelRequisicion.INGRESO_PROM_MENSUAL,
                    _modelRequisicion.INGRESO_PROM_ANUAL,
                    _modelRequisicion.COD_MERCADO,
                    _modelRequisicion.MERCADO,
                    _modelRequisicion.COD_CATEGORIA,
                    _modelRequisicion.NOMBRE_CATEGORIA,
                    _modelRequisicion.PUNTO_MEDIO_80,
                    _modelRequisicion.PUNTO_MEDIO_100,
                    _modelRequisicion.PUNTO_MEDIO_120,
                    _modelRequisicion.POSICIONAMIENTO,
                    _modelRequisicion.COD_CORREO_CONTROLLER
                    );
                }
                logCentralizado.FINALIZANDO_LOG("REPREQ5", "ACTUALIZAR_REQUISICION");
                return true;
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ5", "ACTUALIZAR_REQUISICION", ex);
                throw ex;
            }
        }

        public REQUISICIONViewModel CONSULTAR_REQUISICION_X_ID(int _idRequisicion, string id_usuario)
        {
            REQUISICIONViewModel requicisionModel = null;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ6", "CONSULTAR_REQUISICION_X_ID");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    CONSULTAR_REQUISICIONXID_Result respuesta = null;
                    List<CONSULTAR_REQUISICIONXID_Result> Resultado = db.CONSULTAR_REQUISICIONXID(id_usuario, _idRequisicion).ToList();
                    if (Resultado.ToList().Count > 0)
                    {
                        respuesta = Resultado.First();
                        requicisionModel = new REQUISICIONViewModel();

                        requicisionModel.COD_REQUISICION = respuesta.COD_REQUISICION;
                        requicisionModel.COD_TIPO_NECESIDAD = respuesta.COD_TIPO_NECESIDAD ?? 0;
                        requicisionModel.COD_CARGO = respuesta.COD_CARGO ?? 0;
                        requicisionModel.NOMBRE_CARGO = respuesta.NOMBRE_CARGO;
                        requicisionModel.ORDEN = respuesta.ORDEN;
                        requicisionModel.COD_CECO = Convert.ToInt32(respuesta.COD_CECO);
                        requicisionModel.NOMBRE_CECO = respuesta.NOMBRE_CECO;
                        requicisionModel.COD_TIPO_REQUISICION = respuesta.COD_TIPO_REQUISICION ?? 0;
                        requicisionModel.ES_MODIFICACION = respuesta.ES_MODIFICACION ?? false;
                        requicisionModel.OBSERVACION = "";
                        requicisionModel.OBSERVACIONES = respuesta.OBSERVACION ?? "";
                        requicisionModel.COD_ESTADO_REQUISICION = respuesta.COD_ESTADO_REQUISICION ?? 0;
                        requicisionModel.USUARIO_CREACION = respuesta.USUARIO_CREACION;
                        requicisionModel.FECHA_CREACION = respuesta.FECHA_CREACION.ToString() ?? DateTime.Now.ToShortDateString();
                        requicisionModel.USUARIO_MODIFICACION = respuesta.USUARIO_MODIFICACION;
                        requicisionModel.FECHA_MODIFICACION = respuesta.FECHA_MODIFICACION ?? DateTime.Now;
                        requicisionModel.COD_GERENCIA = respuesta.COD_GERENCIA ?? 0;
                        requicisionModel.NOMBRE_GERENCIA = respuesta.NOMBRE_GERENCIA;
                        requicisionModel.COD_TIPO_CONTRATO = respuesta.COD_TIPO_CONTRATO ?? 0;
                        requicisionModel.NOMBRE_TIPO_CONTRATO = respuesta.NOMBRE_TIPO_CONTRATO;
                        requicisionModel.COD_TIPO_DOCUMENTO = respuesta.COD_TIPO_DOCUMENTO ?? 0;
                        requicisionModel.NUMERO_DOCUMENTO_EMPLEADO = respuesta.NUMERO_DOCUMENTO_EMPLEADO;
                        requicisionModel.NOMBRE_EMPLEADO = respuesta.NOMBRE_EMPLEADO;
                        requicisionModel.JEFE_INMEDIATO = respuesta.JEFE_INMEDIATO;
                        requicisionModel.COD_SOCIEDAD = respuesta.COD_SOCIEDAD ?? 0;
                        requicisionModel.NOMBRE_SOCIEDAD = respuesta.NOMBRE_SOCIEDAD;
                        requicisionModel.COD_EQUIPO_VENTAS = respuesta.COD_EQUIPO_VENTAS ?? 0;
                        requicisionModel.NOMBRE_EQIPO_VENTAS = respuesta.NOMBRE_EQUIPO_VENTAS;
                        requicisionModel.COD_CIUDAD_TRABAJO = respuesta.COD_CIUDAD_TRABAJO ?? 0;
                        requicisionModel.NOMBRE_CIUDAD_TRABAJO = respuesta.NOMBRE_CIUDAD_TRABAJO;
                        requicisionModel.COD_DANE_CIUDAD_TRABAJO = respuesta.COD_DANE_CIUDAD_TRABAJO ?? 0;
                        requicisionModel.COD_UBICACION_FISICA = respuesta.COD_UBICACION_FISICA ?? 0;
                        requicisionModel.NOMBRE_UBICACION_FISICA = respuesta.NOMBRE_UBICACION_FISICA;
                        requicisionModel.COD_NIVEL_RIESGO_ARL = respuesta.COD_NIVEL_RIESGO_ARL ?? 0;
                        requicisionModel.NIVEL_RIESGO_ARL = respuesta.NIVEL_RIESGO_ARL;
                        requicisionModel.COD_CATEGORIA_ED = respuesta.COD_CATEGORIA_ED ?? 0;
                        requicisionModel.NOMBRE_CATEGORIA_ED = respuesta.NOMBRE_CATEGORIA_ED;
                        requicisionModel.CARGO_CRITICO = respuesta.CARGO_CRITICO ?? false;
                        requicisionModel.COD_JORNADA_LABORAL = respuesta.COD_JORNADA_LABORAL ?? 0;
                        requicisionModel.NOMBRE_JORNADA_LABORAL = respuesta.NOMBRE_JORNADA_LABORAL;
                        requicisionModel.HORARIO_LABORAL_DESDE = respuesta.HORARIO_LABORAL_DESDE;
                        requicisionModel.HORARIO_LABORAL_HASTA = respuesta.HORARIO_LABORAL_HASTA;
                        requicisionModel.COD_DIA_LABORAL_DESDE = respuesta.COD_DIA_LABORAL_DESDE ?? 0;
                        requicisionModel.COD_DIA_LABORAL_HASTA = respuesta.COD_DIA_LABORAL_HASTA ?? 0;
                        requicisionModel.POSICION = respuesta.POSICION;
                        requicisionModel.EMPRESA_TEMPORAL = respuesta.EMPRESA_TEMPORAL;
                        requicisionModel.SALARIO_FIJO = respuesta.SALARIO_FIJO ?? 0;
                        requicisionModel.PORCENTAJE_SALARIO_FIJO = respuesta.PORCENTAJE_SALARIO_FIJO ?? 0;
                        requicisionModel.SALARIO_VARIABLE = respuesta.SALARIO_VARIABLE ?? 0;
                        requicisionModel.PORCENTAJE_SALARIO_VARIABLE = respuesta.PORCENTAJE_SALARIO_VARIABLE ?? 0;
                        requicisionModel.SOBREREMUNERACION = respuesta.SOBREREMUNERACION ?? 0;
                        requicisionModel.PORCENTAJE_SOBREREMUNERACION = respuesta.PORCENTAJE_SOBREREMUNERACION ?? 0;
                        requicisionModel.EXTRA_FIJA = respuesta.EXTRA_FIJA ?? 0;
                        requicisionModel.RECARGO_NOCTURNO = respuesta.RECARGO_NOCTURNO ?? 0;
                        requicisionModel.MEDIO_TRANSPORTE = respuesta.MEDIO_TRANSPORTE ?? 0;
                        requicisionModel.SALARIO_TOTAL = respuesta.SALARIO_TOTAL ?? 0;
                        requicisionModel.BONO_ANUAL = respuesta.BONO_ANUAL ?? 0;
                        requicisionModel.NUMERO_SALARIOS = respuesta.NUMERO_SALARIOS ?? 0;
                        requicisionModel.MESES_GARANTIZADOS = respuesta.MESES_GARANTIZADOS ?? 0;
                        requicisionModel.COD_TIPO_SALARIO = respuesta.COD_TIPO_SALARIO ?? 0;
                        requicisionModel.NOMBRE_TIPO_SALARIO = respuesta.NOMBRE_TIPO_SALARIO;
                        requicisionModel.FACTOR_PRESTACIONAL = respuesta.FACTOR_PRESTACIONAL ?? 0;
                        requicisionModel.INGRESO_PROM_MENSUAL = respuesta.INGRESO_PROM_MENSUAL ?? 0;
                        requicisionModel.INGRESO_PROM_ANUAL = respuesta.INGRESO_PROM_ANUAL ?? 0;
                        requicisionModel.MERCADO = respuesta.MERCADO;
                        requicisionModel.COD_CATEGORIA = respuesta.COD_CATEGORIA ?? 0;
                        requicisionModel.NOMBRE_CATEGORIA = respuesta.NOMBRE_CATEGORIA;
                        requicisionModel.PUNTO_MEDIO_80 = respuesta.PUNTO_MEDIO_80 ?? 0;
                        requicisionModel.PUNTO_MEDIO_100 = respuesta.PUNTO_MEDIO_100 ?? 0;
                        requicisionModel.PUNTO_MEDIO_120 = respuesta.PUNTO_MEDIO_120 ?? 0;
                        requicisionModel.POSICIONAMIENTO = respuesta.POSICIONAMIENTO ?? 0;
                        requicisionModel.EMAIL_USUARIO_CREACION = respuesta.EMAIL_USUARIO_CREACION;
                        requicisionModel.LOGIN_EMPLEADO = respuesta.LOGIN_EMPLEADO;
                        requicisionModel.COD_HORARIO_LABORAL_DESDE = respuesta.COD_HORARIO_LABORAL_DESDE ?? 0;
                        requicisionModel.COD_HORARIO_LABORAL_HASTA = respuesta.COD_HORARIO_LABORAL_HASTA ?? 0;
                        requicisionModel.COD_MERCADO = respuesta.COD_MERCADO ?? 0;
                        requicisionModel.FECHA_INICIO = respuesta.FECHA_INICIO ?? DateTime.Now;
                        requicisionModel.FECHA_FIN = respuesta.FECHA_FIN ?? DateTime.Now;
                        requicisionModel.DIA_LABORAL_DESDE = respuesta.DIA_LABORAL_DESDE;
                        requicisionModel.DIA_LABORAL_HASTA = respuesta.DIA_LABORAL_HASTA;
                        requicisionModel.COD_CORREO_CONTROLLER = respuesta.COD_CORREO_CONTROLLER;

                    }
                }
                logCentralizado.FINALIZANDO_LOG("REPREQ6", "CONSULTAR_REQUISICION_X_ID");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ6", "CONSULTAR_REQUISICION_X_ID", ex);
                throw ex;
            }
            return requicisionModel;
        }

        public int INSERTAR_REQUISICION(REQUISICIONViewModel _modelRequisicion)
        {
            int resultado = 0;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ7", "INSERTAR_REQUISICION");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {

                    resultado = db.INSERTAR_REQUISICION(
                         _modelRequisicion.COD_TIPO_NECESIDAD,
                         _modelRequisicion.COD_TIPO_REQUISICION,
                         _modelRequisicion.COD_CARGO,
                         _modelRequisicion.NOMBRE_CARGO,
                         _modelRequisicion.ORDEN,
                         _modelRequisicion.COD_CECO,
                         _modelRequisicion.NOMBRE_CECO,
                         _modelRequisicion.OBSERVACION,
                         _modelRequisicion.COD_TIPO_DOCUMENTO,
                         _modelRequisicion.NUMERO_DOCUMENTO_EMPLEADO,
                         _modelRequisicion.NOMBRE_EMPLEADO,
                         _modelRequisicion.JEFE_INMEDIATO,
                         _modelRequisicion.FECHA_INICIO,
                         _modelRequisicion.FECHA_FIN,
                         _modelRequisicion.COD_GERENCIA,
                         _modelRequisicion.NOMBRE_GERENCIA,
                         _modelRequisicion.COD_SOCIEDAD,
                         _modelRequisicion.NOMBRE_SOCIEDAD,
                         _modelRequisicion.COD_EQUIPO_VENTAS,
                         _modelRequisicion.NOMBRE_EQIPO_VENTAS,
                         _modelRequisicion.COD_CATEGORIA_ED,
                         _modelRequisicion.NOMBRE_CATEGORIA_ED,
                         _modelRequisicion.CARGO_CRITICO,
                         _modelRequisicion.POSICION,
                         _modelRequisicion.SALARIO_FIJO,
                         _modelRequisicion.PORCENTAJE_SALARIO_FIJO,
                         _modelRequisicion.SALARIO_VARIABLE,
                         _modelRequisicion.PORCENTAJE_SALARIO_VARIABLE,
                         _modelRequisicion.SOBREREMUNERACION,
                         _modelRequisicion.EXTRA_FIJA,
                         _modelRequisicion.RECARGO_NOCTURNO,
                         _modelRequisicion.MEDIO_TRANSPORTE,
                         _modelRequisicion.SALARIO_TOTAL,
                         _modelRequisicion.BONO_ANUAL,
                         _modelRequisicion.NUMERO_SALARIOS,
                         _modelRequisicion.COD_NIVEL_RIESGO_ARL,
                         _modelRequisicion.NIVEL_RIESGO_ARL,
                         _modelRequisicion.COD_JORNADA_LABORAL,
                         _modelRequisicion.NOMBRE_JORNADA_LABORAL,
                         _modelRequisicion.COD_HORARIO_LABORAL_DESDE,
                         _modelRequisicion.HORARIO_LABORAL_DESDE,
                         _modelRequisicion.COD_HORARIO_LABORAL_HASTA,
                         _modelRequisicion.HORARIO_LABORAL_HASTA,
                         _modelRequisicion.COD_DIA_LABORAL_DESDE,
                         _modelRequisicion.DIA_LABORAL_DESDE,
                         _modelRequisicion.COD_DIA_LABORAL_HASTA,
                         _modelRequisicion.DIA_LABORAL_HASTA,
                        Convert.ToInt32(_modelRequisicion.PORCENTAJE_SOBREREMUNERACION),
                        _modelRequisicion.MESES_GARANTIZADOS,
                        _modelRequisicion.COD_TIPO_SALARIO,
                        _modelRequisicion.NOMBRE_TIPO_SALARIO,
                        _modelRequisicion.FACTOR_PRESTACIONAL.ToString(),
                        _modelRequisicion.INGRESO_PROM_MENSUAL,
                        _modelRequisicion.INGRESO_PROM_ANUAL,
                        _modelRequisicion.COD_MERCADO,
                        _modelRequisicion.MERCADO ?? "",
                       _modelRequisicion.COD_CATEGORIA,
                       _modelRequisicion.PUNTO_MEDIO_80,
                       _modelRequisicion.PUNTO_MEDIO_100,
                       _modelRequisicion.PUNTO_MEDIO_120,
                       Convert.ToString(_modelRequisicion.POSICIONAMIENTO.ToString()),
                       _modelRequisicion.USUARIO_CREACION ?? "",
                       _modelRequisicion.COD_ESTADO_REQUISICION,
                       _modelRequisicion.ES_MODIFICACION,
                       _modelRequisicion.COD_CORREO_CONTROLLER,
                       _modelRequisicion.COD_TIPO_CONTRATO,
                       _modelRequisicion.NOMBRE_TIPO_CONTRATO
                   ).FirstOrDefault().Value;
                }
                logCentralizado.FINALIZANDO_LOG("REPREQ7", "INSERTAR_REQUISICION");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ7", "INSERTAR_REQUISICION", ex);
                throw ex;
            }
            return resultado;
        }

        public int APROBAR_REQUISICION(int _codRequisicion, string _codUsuario, string _observacion)
        {
            int idRequisicionAprobada = 0;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ8", "APROBAR_REQUISICION");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    idRequisicionAprobada = db.APROBAR_REQUISICION(
                         _codRequisicion,
                           _codUsuario,
                          _observacion
                          ).First().Value;
                }
                logCentralizado.FINALIZANDO_LOG("REPREQ8", "APROBAR_REQUISICION");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ8", "APROBAR_REQUISICION", ex);
                throw ex;
            }
            return idRequisicionAprobada;


        }

        public int MODIFICAR_REQUISICION(int _codRequisicion, string _observacion, string _codUsuario)
        {
            int idRequisicionModificada = 0;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ9", "MODIFICAR_REQUISICION");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    idRequisicionModificada = db.MODIFICACIONES(
                        _codRequisicion,
                        _observacion,
                           _codUsuario).First().Value;
                }

                logCentralizado.FINALIZANDO_LOG("REPREQ9", "MODIFICAR_REQUISICION");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ9", "MODIFICAR_REQUISICION", ex);
                throw ex;
            }
            return idRequisicionModificada;
        }

        public int RECHAZAR_REQUISICION(int _codRequisicion, string _observacion, string _usuario)
        {
            int idRequisicionRechazada = 0;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ10", "RECHAZAR_REQUISICION");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    idRequisicionRechazada = db.RECHAZAR_REQUISICION(
                        _codRequisicion,
                        _usuario,
                        _observacion
                           ).First().Value;
                }

                logCentralizado.FINALIZANDO_LOG("REPREQ10", "RECHAZAR_REQUISICION");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ10", "RECHAZAR_REQUISICION", ex);
                throw ex;
            }
            return idRequisicionRechazada;

        }

        public List<TRAZA_BOTONES_ENTIDAD> CONSULTAR_TRAZA_CAMPOS(int _codRequisicion, string _campoRequisicion)
        {
            List<TRAZA_BOTONES_ENTIDAD> retorno = null;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ11", "CONSULTAR_TRAZA_CAMPOS");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    ObjectResult<HISTORICOS> RHISTORICO = db.TRAZA_BOTONES(_codRequisicion, _campoRequisicion);
                    retorno = RHISTORICO.Select(x => new TRAZA_BOTONES_ENTIDAD()
                    {
                        COD_REQUISICION = x.COD_REQUISICION,
                        COD_ROL = x.COD_ROL,
                        COD_NIVEL_RIESGO_ARL = x.COD_NIVEL_RIESGO_ARL,
                        NOMBRE_CATEGORIA_ED = x.NOMBRE_CATEGORIA_ED,
                        CARGO_CRITICO = x.CARGO_CRITICO,
                        COD_JORNADA_LABORAL = x.COD_JORNADA_LABORAL,
                        HORARIO_LABORAL_DESDE = x.HORARIO_LABORAL_DESDE,
                        HORARIO_LABORAL_HASTA = x.HORARIO_LABORAL_HASTA,
                        COD_DIA_LABORAL_DESDE = x.COD_DIA_LABORAL_DESDE,
                        COD_DIA_LABORAL_HASTA = x.COD_DIA_LABORAL_HASTA,
                        SALARIO_FIJO = x.SALARIO_FIJO,
                        PORCENTAJE_SALARIO_FIJO = x.PORCENTAJE_SALARIO_FIJO,
                        SALARIO_VARIABLE = x.SALARIO_VARIABLE,
                        PORCENTAJE_SALARIO_VARIABLE = x.PORCENTAJE_SALARIO_VARIABLE,
                        SOBREREMUNERACION = x.SOBREREMUNERACION,
                        PORCENTAJE_SOBREREMUNERACION = x.PORCENTAJE_SOBREREMUNERACION,
                        EXTRA_FIJA = x.EXTRA_FIJA,
                        RECARGO_NOCTURNO = x.RECARGO_NOCTURNO,
                        MEDIO_TRANSPORTE = x.MEDIO_TRANSPORTE,
                        SALARIO_TOTAL = x.SALARIO_TOTAL,
                        BONO_ANUAL = x.BONO_ANUAL,
                        NUMERO_SALARIOS = x.NUMERO_SALARIOS,
                        MESES_GARANTIZADOS = x.MESES_GARANTIZADOS,
                        COD_TIPO_SALARIO = x.COD_TIPO_SALARIO,
                        FACTOR_PRESTACIONAL = x.FACTOR_PRESTACIONAL,
                        INGRESO_PROM_MENSUAL = x.INGRESO_PROM_MENSUAL,
                        MERCADO = x.MERCADO,
                        COD_CATEGORIA = x.COD_CATEGORIA,
                        PUNTO_MEDIO_80 = x.PUNTO_MEDIO_80,
                        PUNTO_MEDIO_100 = x.PUNTO_MEDIO_100,
                        PUNTO_MEDIO_120 = x.PUNTO_MEDIO_120,
                        POSICIONAMIENTO = x.POSICIONAMIENTO,
                        USUARIO_REGISTRO = x.USUARIO_REGISTRO,
                        FECHA_REGISTRO = x.FECHA_REGISTRO.ToShortDateString(),
                        COD_ESTADO = x.COD_ESTADO,
                        DIA_LABORAL_DESDE = x.DIA_LABORAL_DESDE,
                        DIA_LABORAL_HASTA = x.DIA_LABORAL_HASTA,
                        NOMBRE_JORNADA_LABORAL = x.NOMBRE_JORNADA_LABORAL,
                        NOMBRE_TIPO_SALARIO = x.NOMBRE_TIPO_SALARIO,
                        CATRGORIA = x.CATRGORIA
                    }).ToList();
                }
                logCentralizado.FINALIZANDO_LOG("REPREQ11", "CONSULTAR_TRAZA_CAMPOS");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ11", "CONSULTAR_TRAZA_CAMPOS", ex);
                throw ex;
            }

            return retorno;
        }

        public List<CONSULTA_NOTIFICACIONES_ENTIDAD> CONSULTAR_NOTIFICACIONES(string _codUsuario)
        {
            List<CONSULTA_NOTIFICACIONES_ENTIDAD> _ENTIDAD_RETONO = null;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ12", "CONSULTAR_NOTIFICACIONES");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    ObjectResult<CONSULTA_NOTIFICACIONES_Result> _NOTIFICACIONES = db.CONSULTA_NOTIFICACIONES(_codUsuario);
                    _ENTIDAD_RETONO = _NOTIFICACIONES.Select(x => new CONSULTA_NOTIFICACIONES_ENTIDAD()
                    {
                        NOMBRE_REQUISICION = x.NOMBRE_REQUISICION,
                        CANTIDAD = x.CANTIDAD.ToString(),
                        TOTAL = x.TOTAL.ToString(),
                        ES_MODIFICACION = x.ES_MODIFICACION ?? false

                    }).ToList();
                }

                logCentralizado.FINALIZANDO_LOG("REPREQ12", "CONSULTAR_NOTIFICACIONES");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ12", "CONSULTAR_NOTIFICACIONES", ex);
                throw ex;
            }
            return _ENTIDAD_RETONO;

        }

        public List<TRAZA_BOTONES_VISIBLES> CONSULTAR_CAMPOS_TRAZAS_VISIBLES(int _codRequisicion)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ13", "CONSULTAR_CAMPOS_TRAZAS_VISIBLES");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    List<CONSULTAR_CAMPOS_TRAZA_Result> _listaCam = db.CONSULTAR_CAMPOS_TRAZA(_codRequisicion).ToList();
                    List<TRAZA_BOTONES_VISIBLES> _LIST_CAMPOS = _listaCam.Select(x => new TRAZA_BOTONES_VISIBLES()
                    {
                        COD_REQUISICION = x.COD_REQUISICION.Value,
                        CAMPOS = x.NOMBRE_CAMPO,
                        TRAZA = x.TRAZA
                    }).ToList();

                    logCentralizado.FINALIZANDO_LOG("REPREQ13", "CONSULTAR_CAMPOS_TRAZAS_VISIBLES");
                    return _LIST_CAMPOS;
                }
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ13", "CONSULTAR_CAMPOS_TRAZAS_VISIBLES", ex);
                throw ex;
            }
        }

        public void INSERTAR_CAMPOS_TRAZAS_VISIBLES(List<TRAZA_BOTONES_VISIBLES> _traza)
        {
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ14", "INSERTAR_CAMPOS_TRAZAS_VISIBLES");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    foreach (var item in _traza)
                    {
                        db.INSERTAR_TRAZAS(item.COD_REQUISICION, item.CAMPOS, item.TRAZA);
                    }
                    logCentralizado.FINALIZANDO_LOG("REPREQ14", "INSERTAR_CAMPOS_TRAZAS_VISIBLES");
                }
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ14", "INSERTAR_CAMPOS_TRAZAS_VISIBLES", ex);
                throw ex;
            }
        }

        public List<CONSULTA_USUARIO_ENTIDAD> CONSULTAR_USUARIOS(string _codUsuario)
        {
            List<CONSULTA_USUARIO_ENTIDAD> _ENTIDAD_RETONO = null;
            try
            {
                logCentralizado.INICIANDO_LOG("REPREQ15", "CONSULTAR_USUARIOS");
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    ObjectResult<CONSULTAR_USUARIO_Result> _USUARIOS = db.CONSULTAR_USUARIO(_codUsuario);
                    _ENTIDAD_RETONO = _USUARIOS.Select(x => new CONSULTA_USUARIO_ENTIDAD()
                    {
                        NOMBRE = x.Nombre,
                        ROL = x.Rol

                    }).ToList();
                }

                logCentralizado.FINALIZANDO_LOG("REPREQ15", "CONSULTAR_USUARIOS");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("REPREQ15", "CONSULTAR_USUARIOS", ex);
                throw ex;
            }
            return _ENTIDAD_RETONO;

        }


    }
}
