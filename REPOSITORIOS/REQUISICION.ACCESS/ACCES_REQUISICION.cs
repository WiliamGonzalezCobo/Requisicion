using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION_ENTITY;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public REQUISICIONViewModel CONSULTAR_REQUISICION_X_ID(int idReq)
        {
            REQUISICIONViewModel requicisionModel = null;
            try
            {
                using (var db = new GESTION_HUMANA_HITSSEntities2())
                {
                    REQUISICION_REQUISICION queryReq =
                         (from r in db.REQUISICION_REQUISICION
                          where r.COD_REQUISICION.Equals(idReq)
                          select r).First();

                    requicisionModel = new REQUISICIONViewModel()
                    {
                        COD_REQUISICION = queryReq.COD_REQUISICION,
                        COD_TIPO_NECESIDAD = queryReq.COD_TIPO_NECESIDAD.HasValue ? queryReq.COD_TIPO_NECESIDAD.Value : 0,
                        COD_CARGO = queryReq.COD_CARGO.HasValue ? queryReq.COD_CARGO.Value : 0,
                        NOMBRE_CARGO = queryReq.NOMBRE_CARGO,
                        ORDEN = queryReq.ORDEN,
                        COD_CECO = Convert.ToInt32(queryReq.COD_CECO),//en base de datos es string
                        NOMBRE_CECO = queryReq.NOMBRE_CECO,
                        COD_TIPO_REQUISICION = queryReq.COD_TIPO_REQUISICION.HasValue ? queryReq.COD_TIPO_REQUISICION.Value : 0,
                        FECHA_INICIO = queryReq.FECHA_INICIO.HasValue ? queryReq.FECHA_INICIO.Value : DateTime.Now,
                        FECHA_FIN = queryReq.FECHA_FIN.HasValue ? queryReq.FECHA_FIN.Value : new DateTime(),
                        ES_MODIFICACION = queryReq.ES_MODIFICACION.HasValue ? queryReq.ES_MODIFICACION.Value : false,
                        OBSERVACION = queryReq.OBSERVACION,
                        COD_ESTADO_REQUISICION = queryReq.COD_ESTADO_REQUISICION.HasValue ? queryReq.COD_ESTADO_REQUISICION.Value : 0,
                        USUARIO_CREACION = queryReq.USUARIO_CREACION,
                        FECHA_CREACION = queryReq.FECHA_CREACION.HasValue ? queryReq.FECHA_CREACION.Value.ToString() : new DateTime().ToString(), //en el modelo es string
                        USUARIO_MODIFICACION = queryReq.USUARIO_MODIFICACION,
                        FECHA_MODIFICACION = queryReq.FECHA_MODIFICACION.HasValue ? queryReq.FECHA_MODIFICACION.Value : new DateTime(),
                        COD_GERENCIA = queryReq.COD_GERENCIA.HasValue ? queryReq.COD_GERENCIA.Value : 0,
                        NOMBRE_GERENCIA = queryReq.NOMBRE_GERENCIA,
                        COD_TIPO_CONTRATO = queryReq.COD_TIPO_CONTRATO.HasValue ? queryReq.COD_TIPO_CONTRATO.Value : 0,
                        NOMBRE_TIPO_CONTRATO = queryReq.NOMBRE_TIPO_CONTRATO,
                        COD_TIPO_DOCUMENTO = queryReq.COD_TIPO_DOCUMENTO.HasValue ? queryReq.COD_TIPO_DOCUMENTO.Value : 0,
                        NUMERO_DOCUMENTO_EMPLEADO = queryReq.NUMERO_DOCUMENTO_EMPLEADO,
                        NOMBRE_EMPLEADO = queryReq.NOMBRE_EMPLEADO,
                        JEFE_INMEDIATO = queryReq.JEFE_INMEDIATO,
                        COD_SOCIEDAD = queryReq.COD_SOCIEDAD.HasValue ? queryReq.COD_SOCIEDAD.Value : 0,
                        NOMBRE_SOCIEDAD = queryReq.NOMBRE_SOCIEDAD,
                        COD_EQUIPO_VENTAS = queryReq.COD_EQUIPO_VENTAS.HasValue ? queryReq.COD_EQUIPO_VENTAS.Value : 0,
                        NOMBRE_EQIPO_VENTAS = queryReq.NOMBRE_EQUIPO_VENTAS,
                        COD_CIUDAD_TRABAJO = queryReq.COD_CIUDAD_TRABAJO.HasValue ? queryReq.COD_CIUDAD_TRABAJO.Value : 0,
                        NOMBRE_CIUDAD_TRABAJO = queryReq.NOMBRE_CIUDAD_TRABAJO,
                        COD_DANE_CIUDAD_TRABAJO = queryReq.COD_DANE_CIUDAD_TRABAJO.HasValue ? queryReq.COD_DANE_CIUDAD_TRABAJO.Value : 0,
                        COD_UBICACION_FISICA = queryReq.COD_UBICACION_FISICA.HasValue ? queryReq.COD_UBICACION_FISICA.Value : 0,
                        NOMBRE_UBICACION_FISICA = queryReq.NOMBRE_UBICACION_FISICA,
                        COD_NIVEL_RIESGO_ARL = queryReq.COD_NIVEL_RIESGO_ARL.HasValue ? queryReq.COD_NIVEL_RIESGO_ARL.Value : 0,
                        NIVEL_RIESGO_ARL = queryReq.NIVEL_RIESGO_ARL,
                        COD_CATEGORIA_ED = queryReq.COD_CATEGORIA_ED.HasValue ? queryReq.COD_CATEGORIA_ED.Value : 0,
                        NOMBRE_CATEGORIA_ED = queryReq.NOMBRE_CATEGORIA_ED,
                        CARGO_CRITICO = queryReq.CARGO_CRITICO.HasValue ? queryReq.CARGO_CRITICO.Value : false,
                        COD_JORNADA_LABORAL = queryReq.COD_JORNADA_LABORAL.HasValue ? queryReq.COD_JORNADA_LABORAL.Value : 0,
                        NOMBRE_JORNADA_LABORAL = queryReq.NOMBRE_JORNADA_LABORAL,
                        HORARIO_LABORAL_DESDE = queryReq.HORARIO_LABORAL_DESDE,
                        HORARIO_LABORAL_HASTA = queryReq.HORARIO_LABORAL_HASTA,
                        COD_DIA_LABORAL_DESDE = queryReq.COD_DIA_LABORAL_DESDE.HasValue ? queryReq.COD_DIA_LABORAL_DESDE.Value : 0,
                        COD_DIA_LABORAL_HASTA = queryReq.COD_DIA_LABORAL_HASTA.HasValue ? queryReq.COD_DIA_LABORAL_HASTA.Value : 0,
                        POSICION = queryReq.POSICION,
                        EMPRESA_TEMPORAL = queryReq.EMPRESA_TEMPORAL,
                        SALARIO_FIJO = queryReq.SALARIO_FIJO.HasValue ? queryReq.SALARIO_FIJO.Value : 0,
                        PORCENTAJE_SALARIO_FIJO = queryReq.PORCENTAJE_SALARIO_FIJO.HasValue ? queryReq.PORCENTAJE_SALARIO_FIJO.Value : 0,
                        SALARIO_VARIABLE = queryReq.SALARIO_VARIABLE.HasValue ? queryReq.SALARIO_VARIABLE.Value : 0,
                        PORCENTAJE_SALARIO_VARIABLE = queryReq.PORCENTAJE_SALARIO_VARIABLE.HasValue ? queryReq.PORCENTAJE_SALARIO_VARIABLE.Value : 0,
                        SOBREREMUNERACION = queryReq.SOBREREMUNERACION.HasValue ? queryReq.SOBREREMUNERACION.Value : 0,
                        PORCENTAJE_SOBREREMUNERACION = queryReq.PORCENTAJE_SOBREREMUNERACION.HasValue ? queryReq.PORCENTAJE_SOBREREMUNERACION.Value : 0,
                        EXTRA_FIJA = queryReq.EXTRA_FIJA.HasValue ? queryReq.EXTRA_FIJA.Value : 0,
                        RECARGO_NOCTURNO = queryReq.RECARGO_NOCTURNO.HasValue ? queryReq.RECARGO_NOCTURNO.Value : 0,
                        MEDIO_TRANSPORTE = queryReq.MEDIO_TRANSPORTE.HasValue ? queryReq.MEDIO_TRANSPORTE.Value : 0,
                        SALARIO_TOTAL = queryReq.SALARIO_TOTAL.HasValue ? queryReq.SALARIO_TOTAL.Value : 0,
                        BONO_ANUAL = queryReq.BONO_ANUAL.HasValue ? queryReq.BONO_ANUAL.Value : 0,
                        NUMERO_SALARIOS = queryReq.NUMERO_SALARIOS.HasValue ? queryReq.NUMERO_SALARIOS.Value : 0,
                        MESES_GARANTIZADOS = queryReq.MESES_GARANTIZADOS.HasValue ? queryReq.MESES_GARANTIZADOS.Value:0,
                        COD_TIPO_SALARIO = queryReq.COD_TIPO_SALARIO.HasValue?queryReq.COD_TIPO_SALARIO.Value:0,
                        NOMBRE_TIPO_SALARIO = queryReq.NOMBRE_TIPO_SALARIO,
                        FACTOR_PRESTACIONAL = queryReq.FACTOR_PRESTACIONAL.HasValue?queryReq.FACTOR_PRESTACIONAL.Value:0,
                        INGRESO_PROM_MENSUAL = queryReq.INGRESO_PROM_MENSUAL.HasValue?queryReq.INGRESO_PROM_MENSUAL.Value:0,
                        INGRESO_PROM_ANUAL = queryReq.INGRESO_PROM_ANUAL.HasValue ? queryReq.INGRESO_PROM_ANUAL.Value : 0,
                        MERCADO = queryReq.MERCADO,
                        COD_CATEGORIA = queryReq.COD_CATEGORIA.HasValue ? queryReq.COD_CATEGORIA.Value : 0,
                        NOMBRE_CATEGORIA = queryReq.NOMBRE_CATEGORIA,
                        PUNTO_MEDIO_80 = queryReq.PUNTO_MEDIO_80.HasValue ? queryReq.PUNTO_MEDIO_80.Value : 0,
                        PUNTO_MEDIO_100 = queryReq.PUNTO_MEDIO_100.HasValue ? queryReq.PUNTO_MEDIO_100.Value : 0,
                        PUNTO_MEDIO_120 = queryReq.PUNTO_MEDIO_120.HasValue ? queryReq.PUNTO_MEDIO_120.Value : 0,
                        POSICIONAMIENTO = queryReq.POSICIONAMIENTO.HasValue ? queryReq.POSICIONAMIENTO.Value:0,
                        EMAIL_USUARIO_CREACION = queryReq.EMAIL_USUARIO_CREACION,
                        LOGIN_EMPLEADO = queryReq.LOGIN_EMPLEADO
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return requicisionModel;
        }
    }
}
