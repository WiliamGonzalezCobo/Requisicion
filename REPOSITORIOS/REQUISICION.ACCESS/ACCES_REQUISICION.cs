using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION_ENTITY;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTILS;

namespace REPOSITORIOS.REQUISICION.ACCESS
{
    public class ACCES_REQUISICION
    {
        public List<TIPO_NECESIDADViewModel> CONSULTAR_TIPOS_NECESIDAD_ACCESS()
        {
            List<TIPO_NECESIDADViewModel> lst = null;
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                ObjectResult<CONSULTAR_TIPOS_NECESIDAD_Result> consulta = db.CONSULTAR_TIPOS_NECESIDAD();
                lst = consulta.Select(x => new TIPO_NECESIDADViewModel()
                {
                    COD_TIPO_NECESIDAD = x.COD_TIPO_NECESIDAD,
                    NOMBRE_NECESIDAD = x.NOMBRE_NECESIDAD
                }).ToList();
            }
            return lst;
        }

        public List<ESTADOViewModel> CONSULTAR_ESTADOS_ACCESS()
        {
            List<ESTADOViewModel> lst = null;
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                ObjectResult<CONSULTAR_ESTADOS_Result> consulta = db.CONSULTAR_ESTADOS();
                lst = consulta.Select(x => new ESTADOViewModel()
                {
                    COD_ESTADO_REQUISICION = x.COD_ESTADO_REQUISICION,
                    NOMBRE_ESTADO = x.NOMBRE_ESTADO
                }).ToList();
            }
            return lst;
        }

        public List<TIPOViewModel> CONSULTAR_TIPOS_REQUISICION_ACCESS()
        {
            List<TIPOViewModel> lst = null;
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                ObjectResult<CONSULTAR_TIPOS_REQUISICION_Result> consulta = db.CONSULTAR_TIPOS_REQUISICION();
                lst = consulta.Select(x => new TIPOViewModel()
                {
                    COD_TIPO_REQUISICION = x.COD_TIPO_REQUISICION,
                    NOMBRE_REQUISICION = x.NOMBRE_REQUISICION
                }).ToList();
            }

            return lst;
        }
        public List<REQUISICIONViewModel> CONSULTAR_REQUISICION_PANTALLA_INICIO(FILTROREQUISICION _FILTRO) {
            using (var db = new GESTION_HUMANA_HITSSEntities2()) {
                ObjectResult<CONSULTA_PRINCIPALXUSUARIO_CODREQUISICION_Result> resultadoSP = 
                    db.CONSULTA_PRINCIPALXUSUARIO_CODREQUISICION(_FILTRO.idUsuario, _FILTRO.porUsuario,_FILTRO.cod_estado_requisicion);
                List<REQUISICIONViewModel> retorno = resultadoSP.ToList().Select(x => new REQUISICIONViewModel() {
                    NOMBRES_USUARIO = x.Nombres,
                    COD_REQUISICION=x.COD_REQUISICION,
                    COD_ESTADO_REQUISICION=x.COD_ESTADO_REQUISICION??0,
                    USUARIO_CREACION=x.USUARIO_CREACION,
                    EMAIL_USUARIO_CREACION=x.EMAIL_USUARIO_CREACION,
                    COD_CARGO=x.COD_CARGO??0,
                    NOMBRE_CARGO=x.NOMBRE_CARGO,
                    COD_TIPO_REQUISICION=x.COD_TIPO_REQUISICION??0,
                    NOMBRE_TIPO_REQUISICION=x.NOMBRE_REQUISICION,
                    FECHA_CREACION=x.FECHA_CREACION.Value.ToShortDateString(),
                    NOMBRE_ESTADO_REQUISICION=x.NOMBRE_ESTADO,
                    NUMERO_DOCUMENTO_EMPLEADO = x.NUMERO_DOCUMENTO_EMPLEADO,
                    NOMBRE_EMPLEADO = x.NOMBRE_EMPLEADO,
                    COLORES_ESTADOS=x.Color,
                    ES_MODIFICACION=x.ES_MODIFICACION??false
                }).ToList();
                return retorno;
             }
        }

        public Boolean ACTUALIZARREQUISICION_ACESS(REQUISICIONViewModel _MODEL)
        {
            try
            {
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    db.ACTUALIZAR_REQUISICION(
                   _MODEL.COD_REQUISICION,
                   _MODEL.COD_TIPO_NECESIDAD,
                   _MODEL.COD_CARGO,
                   _MODEL.NOMBRE_CARGO,
                   _MODEL.ORDEN,
                   _MODEL.COD_CECO.ToString(),
                   _MODEL.NOMBRE_CECO,
                   _MODEL.COD_TIPO_REQUISICION,
                   _MODEL.FECHA_INICIO.Year.Equals(1)?DateTime.Now:_MODEL.FECHA_INICIO,
                   _MODEL.FECHA_FIN.Year.Equals(1)? DateTime.Now:_MODEL.FECHA_FIN,
                   _MODEL.ES_MODIFICACION,
                   _MODEL.OBSERVACION,
                   1, //_MODEL.COD_ESTADO_REQUISICION, toca ver
                   _MODEL.USUARIO_MODIFICACION, //llenar con USER.
                   _MODEL.COD_GERENCIA,
                   _MODEL.NOMBRE_GERENCIA,
                   _MODEL.COD_TIPO_CONTRATO,
                   _MODEL.NOMBRE_TIPO_CONTRATO,
                   _MODEL.COD_TIPO_DOCUMENTO,
                   _MODEL.NUMERO_DOCUMENTO_EMPLEADO,
                   _MODEL.NOMBRE_EMPLEADO,
                   _MODEL.JEFE_INMEDIATO,
                   _MODEL.COD_SOCIEDAD,
                   _MODEL.NOMBRE_SOCIEDAD,
                   _MODEL.COD_EQUIPO_VENTAS,
                   _MODEL.NOMBRE_EQIPO_VENTAS,
                   _MODEL.COD_CIUDAD_TRABAJO,
                   _MODEL.NOMBRE_CIUDAD_TRABAJO,
                   _MODEL.COD_DANE_CIUDAD_TRABAJO,
                   _MODEL.COD_UBICACION_FISICA.ToString(),
                   _MODEL.NOMBRE_UBICACION_FISICA,
                   _MODEL.COD_NIVEL_RIESGO_ARL,
                   _MODEL.NIVEL_RIESGO_ARL,
                   _MODEL.COD_CATEGORIA_ED,
                   _MODEL.NOMBRE_CATEGORIA_ED,
                   _MODEL.CARGO_CRITICO.ToString(),
                   _MODEL.COD_JORNADA_LABORAL,
                   _MODEL.NOMBRE_JORNADA_LABORAL,
                   _MODEL.COD_HORARIO_LABORAL_DESDE,
                   _MODEL.HORARIO_LABORAL_DESDE,
                   _MODEL.COD_HORARIO_LABORAL_HASTA,
                   _MODEL.HORARIO_LABORAL_HASTA,
                   _MODEL.COD_DIA_LABORAL_DESDE,
                   _MODEL.DIA_LABORAL_DESDE,
                   _MODEL.COD_DIA_LABORAL_HASTA,
                   _MODEL.DIA_LABORAL_HASTA,
                   _MODEL.POSICION,
                   _MODEL.EMPRESA_TEMPORAL,
                   _MODEL.SALARIO_FIJO,
                   _MODEL.PORCENTAJE_SALARIO_FIJO,
                   _MODEL.SALARIO_VARIABLE,
                   _MODEL.PORCENTAJE_SALARIO_VARIABLE,
                    _MODEL.SOBREREMUNERACION,
                    _MODEL.PORCENTAJE_SOBREREMUNERACION,
                    _MODEL.EXTRA_FIJA,
                    _MODEL.RECARGO_NOCTURNO,
                    _MODEL.MEDIO_TRANSPORTE,
                    _MODEL.SALARIO_TOTAL,
                    _MODEL.BONO_ANUAL,
                    _MODEL.NUMERO_SALARIOS,
                    _MODEL.MESES_GARANTIZADOS,
                    _MODEL.COD_TIPO_SALARIO,
                    _MODEL.NOMBRE_TIPO_SALARIO,
                    _MODEL.FACTOR_PRESTACIONAL,
                    _MODEL.INGRESO_PROM_MENSUAL,
                    _MODEL.INGRESO_PROM_ANUAL,
                    _MODEL.COD_MERCADO,
                    _MODEL.MERCADO,
                    _MODEL.COD_CATEGORIA,
                    _MODEL.NOMBRE_CATEGORIA,
                    _MODEL.PUNTO_MEDIO_80,
                    _MODEL.PUNTO_MEDIO_100,
                    _MODEL.PUNTO_MEDIO_120,
                    _MODEL.POSICIONAMIENTO
                    );
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public REQUISICIONViewModel CONSULTAR_REQUISICION_X_ID_ACCES(int idReq)
        {
            REQUISICIONViewModel requicisionModel = new REQUISICIONViewModel();
            try
            {
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    CONSULTAR_REQUISICIONXID_Result respuesta = db.CONSULTAR_REQUISICIONXID(idReq).First();
                    requicisionModel.COD_REQUISICION = respuesta.COD_REQUISICION;
                    requicisionModel.COD_TIPO_NECESIDAD = respuesta.COD_TIPO_NECESIDAD ?? 0;
                    requicisionModel.COD_CARGO = respuesta.COD_CARGO ?? 0;
                    requicisionModel.NOMBRE_CARGO = respuesta.NOMBRE_CARGO;
                    requicisionModel.ORDEN = respuesta.ORDEN;
                    requicisionModel.COD_CECO =Convert.ToInt32(respuesta.COD_CECO);
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
                    requicisionModel.HORARIO_LABORAL_HASTA = respuesta.HORARIO_LABORAL_DESDE;
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
                    requicisionModel.FACTOR_PRESTACIONAL = respuesta.FACTOR_PRESTACIONAL??0;
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
                    requicisionModel.COD_HORARIO_LABORAL_DESDE = respuesta.COD_HORARIO_LABORAL_DESDE??0;
                    requicisionModel.COD_HORARIO_LABORAL_HASTA = respuesta.COD_HORARIO_LABORAL_HASTA??0;
                    requicisionModel.COD_MERCADO = respuesta.COD_MERCADO??0;
                    requicisionModel.FECHA_INICIO = respuesta.FECHA_INICIO ?? DateTime.Now;
                    requicisionModel.FECHA_FIN = respuesta.FECHA_FIN ?? DateTime.Now;
                    requicisionModel.DIA_LABORAL_DESDE = respuesta.DIA_LABORAL_DESDE;
                    requicisionModel.DIA_LABORAL_HASTA = respuesta.DIA_LABORAL_HASTA;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return requicisionModel;
        }

        public int INSERTAR_REQUISICION(REQUISICIONViewModel _modelo)
        {
            try
            {
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {

                    return db.INSERTAR_REQUISICION(
                         _modelo.COD_TIPO_NECESIDAD,
                         _modelo.COD_TIPO_REQUISICION,
                         _modelo.COD_CARGO,
                         _modelo.NOMBRE_CARGO,
                         _modelo.ORDEN,
                         _modelo.COD_CECO,
                         _modelo.NOMBRE_CECO,
                         _modelo.OBSERVACION,
                         _modelo.COD_TIPO_DOCUMENTO,
                         _modelo.NUMERO_DOCUMENTO_EMPLEADO,
                         _modelo.NOMBRE_EMPLEADO,
                         _modelo.FECHA_INICIO,
                         _modelo.FECHA_FIN,
                         _modelo.COD_GERENCIA,
                         _modelo.NOMBRE_GERENCIA,
                         _modelo.COD_SOCIEDAD,
                         _modelo.NOMBRE_SOCIEDAD,
                         _modelo.COD_EQUIPO_VENTAS,
                         _modelo.NOMBRE_EQIPO_VENTAS,
                         _modelo.COD_CATEGORIA_ED,
                         _modelo.NOMBRE_CATEGORIA_ED,
                         _modelo.CARGO_CRITICO,
                         _modelo.POSICION,
                         _modelo.SALARIO_FIJO,
                         _modelo.PORCENTAJE_SALARIO_FIJO,
                         _modelo.SALARIO_VARIABLE,
                         _modelo.PORCENTAJE_SALARIO_VARIABLE,
                         _modelo.SOBREREMUNERACION,
                         _modelo.EXTRA_FIJA,
                         _modelo.RECARGO_NOCTURNO,
                         _modelo.MEDIO_TRANSPORTE,
                         _modelo.SALARIO_TOTAL,
                         _modelo.BONO_ANUAL,
                         _modelo.NUMERO_SALARIOS,
                         _modelo.COD_NIVEL_RIESGO_ARL,
                         _modelo.COD_JORNADA_LABORAL,
                         _modelo.NOMBRE_JORNADA_LABORAL,
                         _modelo.COD_HORARIO_LABORAL_DESDE,
                         _modelo.HORARIO_LABORAL_DESDE,
                         _modelo.COD_HORARIO_LABORAL_HASTA,
                         _modelo.HORARIO_LABORAL_HASTA,
                         _modelo.COD_DIA_LABORAL_DESDE,
                         _modelo.DIA_LABORAL_DESDE,
                         _modelo.COD_DIA_LABORAL_HASTA,                         
                         _modelo.DIA_LABORAL_HASTA,
                        Convert.ToInt32(_modelo.PORCENTAJE_SOBREREMUNERACION),
                        _modelo.MESES_GARANTIZADOS,
                        _modelo.COD_TIPO_SALARIO,
                        _modelo.NOMBRE_TIPO_SALARIO,
                        _modelo.FACTOR_PRESTACIONAL.ToString(),  // EN BASE DE DATOS ES VARCHAR
                        _modelo.INGRESO_PROM_MENSUAL,
                        _modelo.INGRESO_PROM_ANUAL,
                        _modelo.COD_MERCADO,
                        _modelo.MERCADO??"",
                       _modelo.COD_CATEGORIA,
                       _modelo.PUNTO_MEDIO_80,
                       _modelo.PUNTO_MEDIO_100,
                       _modelo.PUNTO_MEDIO_120,
                       Convert.ToString(_modelo.POSICIONAMIENTO.ToString()), // EN BASE DE DATOS ES VARCHAR
                       _modelo.USUARIO_CREACION??"",
                       _modelo.COD_ESTADO_REQUISICION,
                       _modelo.ES_MODIFICACION
                   ).FirstOrDefault().Value;
                }

            }
            catch (SqlException ex)
            {
                var error = ex;
                return 0;
            }

        }

        public int APROBAR_REQUISICION_ACESS(int COD_REQUISICION, String ID_USUARIO, string observacion)
        {
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
              return  db.APROBAR_REQUISICION(
                   COD_REQUISICION,
                     ID_USUARIO,
                    observacion
                    ).First().Value;
            }
        }


        public int REQUISICION_MODIFICAR_ACESS(int COD_REQUISICION, string oBSERVACIONES,String ID_USUARIO)
        {
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                return db.MODIFICACIONES(
                    COD_REQUISICION,
                    oBSERVACIONES,
                       ID_USUARIO ).First().Value;
            }
        }

        public int REQUISICION_RECHAZAR_ACESS(int COD_REQUISICION, string oBSERVACIONES, String USUARIO)
        {
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                return db.RECHAZAR_REQUISICION(
                    COD_REQUISICION,
                    USUARIO,
                    oBSERVACIONES
                       ).First().Value;
            }
        }

        public List<TRAZA_BOTONES_ENTIDAD> TRAZA_BOTONES_ACESS(int COD_REQUISICION, string CAMPO_REQUISICION)
        {
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                ObjectResult<TRAZA_BOTONES_Result> RHISTORICO = db.TRAZA_BOTONES(COD_REQUISICION, CAMPO_REQUISICION);
                List<TRAZA_BOTONES_ENTIDAD> retorno = RHISTORICO.Select(x => new TRAZA_BOTONES_ENTIDAD()
                {
                    COD_REQUISICION = x.COD_REQUISICION,
                    COD_ROL=x.COD_ROL,
                    COD_NIVEL_RIESGO_ARL=x.COD_NIVEL_RIESGO_ARL,
                    NOMBRE_CATEGORIA_ED=x.NOMBRE_CATEGORIA_ED,
                    CARGO_CRITICO=x.CARGO_CRITICO,
                    COD_JORNADA_LABORAL=x.COD_JORNADA_LABORAL,
                    HORARIO_LABORAL_DESDE=x.HORARIO_LABORAL_DESDE,
                    HORARIO_LABORAL_HASTA=x.HORARIO_LABORAL_HASTA,
                    COD_DIA_LABORAL_DESDE=x.COD_DIA_LABORAL_DESDE,
                    COD_DIA_LABORAL_HASTA=x.COD_DIA_LABORAL_HASTA,
                    SALARIO_FIJO =x.SALARIO_FIJO,
                    PORCENTAJE_SALARIO_FIJO=x.PORCENTAJE_SALARIO_FIJO,
                    SALARIO_VARIABLE=x.SALARIO_VARIABLE,
                    PORCENTAJE_SALARIO_VARIABLE=x.PORCENTAJE_SALARIO_VARIABLE,
                    SOBREREMUNERACION=x.SOBREREMUNERACION,
                    PORCENTAJE_SOBREREMUNERACION=x.PORCENTAJE_SOBREREMUNERACION,
                    EXTRA_FIJA = x.EXTRA_FIJA,
                    RECARGO_NOCTURNO=x.RECARGO_NOCTURNO,
                    MEDIO_TRANSPORTE=x.MEDIO_TRANSPORTE,
                    SALARIO_TOTAL=x.SALARIO_TOTAL,
                    BONO_ANUAL=x.BONO_ANUAL,
                    NUMERO_SALARIOS=x.NUMERO_SALARIOS,
                    MESES_GARANTIZADOS=x.MESES_GARANTIZADOS,
                    COD_TIPO_SALARIO=x.COD_TIPO_SALARIO,
                    FACTOR_PRESTACIONAL=x.FACTOR_PRESTACIONAL,
                    INGRESO_PROM_MENSUAL=x.INGRESO_PROM_MENSUAL,
                    MERCADO=x.MERCADO,
                    COD_CATEGORIA=x.COD_CATEGORIA,
                    PUNTO_MEDIO_80=x.PUNTO_MEDIO_80,
                    PUNTO_MEDIO_100=x.PUNTO_MEDIO_100,
                    PUNTO_MEDIO_120=x.PUNTO_MEDIO_120,
                    POSICIONAMIENTO=x.POSICIONAMIENTO,
                    USUARIO_REGISTRO =x.USUARIO_REGISTRO,
                    FECHA_REGISTRO=x.FECHA_REGISTRO.ToShortDateString(),
                    COD_ESTADO=x.COD_ESTADO,
                    DIA_LABORAL_DESDE=x.DIA_LABORAL_DESDE,
                    DIA_LABORAL_HASTA=x.DIA_LABORAL_HASTA,
                    NOMBRE_JORNADA_LABORAL=x.NOMBRE_JORNADA_LABORAL,
                    NOMBRE_TIPO_SALARIO=x.NOMBRE_TIPO_SALARIO
                }).ToList();
                return retorno;
            }
        }

        public List<CONSULTA_NOTIFICACIONES_ENTIDAD> CONSULTA_NOTIFICACIONES_ACCESS( string COD_USUARIO) {
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                ObjectResult<CONSULTA_NOTIFICACIONES_Result> _NOTIFICACIONES = db.CONSULTA_NOTIFICACIONES( COD_USUARIO );
                List<CONSULTA_NOTIFICACIONES_ENTIDAD> _ENTIDAD_RETONO = _NOTIFICACIONES.Select(x => new CONSULTA_NOTIFICACIONES_ENTIDAD() {
                    NOMBRE_REQUISICION=x.NOMBRE_REQUISICION,
                    CANTIDAD=x.CANTIDAD.ToString(),
                    TOTAL=x.TOTAL.ToString(),
                    ES_MODIFICACION=x.ES_MODIFICACION??false

                }).ToList();

                return _ENTIDAD_RETONO;
            }
        }
    }
}
