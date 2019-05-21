using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION_ENTITY;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
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
        public List<REQUISICIONViewModel> CONSULTAR_REQUISICION_PANTALLA_INICIO(FILTROREQUISICION _FILTRO) {
            using (var db = new GESTION_HUMANA_HITSSEntities2()) {
                ObjectResult<CONSULTA_PRINCIPALXUSUARIO_CODREQUISICION_Result> resultadoSP = 
                    db.CONSULTA_PRINCIPALXUSUARIO_CODREQUISICION(_FILTRO.idUsuario, _FILTRO.porUsuario,_FILTRO.cod_estado_requisicion);
                List<REQUISICIONViewModel> retorno = resultadoSP.ToList().Select(x => new REQUISICIONViewModel() {
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
                    COLORES_ESTADOS=x.Color
                }).ToList();
                return retorno;
             }
        }

        public REQUISICIONViewModel ACTUALIZARREQUISICION(REQUISICIONViewModel _MODEL)
        {
            //using (var db = new GESTION_HUMANA_HITSSEntities2()){
            //    db.ACTUALIZAR_REQUISICION(
            //   _MODEL.COD_REQUISICION,
            //   _MODEL.COD_TIPO_NECESIDAD,
            //   _MODEL.COD_CARGO,
            //   _MODEL.NOMBRE_CARGO,
            //   _MODEL.ORDEN,
            //   _MODEL.COD_CECO,
            //   _MODEL.NOMBRE_CECO,
            //   _MODEL.COD_TIPO_REQUISICION,
            //   _MODEL.FECHA_INICIO,
            //   _MODEL.FECHA_FIN,
            //   _MODEL.ES_MODIFICACION,
            //   _MODEL.OBSERVACION,
            //   _MODEL.COD_ESTADO_REQUISICION,
            //   _MODEL.USUARIO_MODIFICACION, //llenar con USER.
            //        new ObjectParameter("USUARIO_MODIFICACION", uSUARIO_MODIFICACION) :
            //        new ObjectParameter("USUARIO_MODIFICACION", typeof(string));

            //    var cOD_GERENCIAParameter = cOD_GERENCIA.HasValue ?
            //        new ObjectParameter("COD_GERENCIA", cOD_GERENCIA) :
            //        new ObjectParameter("COD_GERENCIA", typeof(int));

            //    var nOMBRE_GERENCIAParameter = nOMBRE_GERENCIA != null ?
            //        new ObjectParameter("NOMBRE_GERENCIA", nOMBRE_GERENCIA) :
            //        new ObjectParameter("NOMBRE_GERENCIA", typeof(string));

            //    var cOD_TIPO_CONTRATOParameter = cOD_TIPO_CONTRATO.HasValue ?
            //        new ObjectParameter("COD_TIPO_CONTRATO", cOD_TIPO_CONTRATO) :
            //        new ObjectParameter("COD_TIPO_CONTRATO", typeof(int));

            //    var nOMBRE_TIPO_CONTRATOParameter = nOMBRE_TIPO_CONTRATO != null ?
            //        new ObjectParameter("NOMBRE_TIPO_CONTRATO", nOMBRE_TIPO_CONTRATO) :
            //        new ObjectParameter("NOMBRE_TIPO_CONTRATO", typeof(string));

            //    var cOD_TIPO_DOCUMENTOParameter = cOD_TIPO_DOCUMENTO.HasValue ?
            //        new ObjectParameter("COD_TIPO_DOCUMENTO", cOD_TIPO_DOCUMENTO) :
            //        new ObjectParameter("COD_TIPO_DOCUMENTO", typeof(int));

            //    var nUMERO_DOCUMENTO_EMPLEADOParameter = nUMERO_DOCUMENTO_EMPLEADO != null ?
            //        new ObjectParameter("NUMERO_DOCUMENTO_EMPLEADO", nUMERO_DOCUMENTO_EMPLEADO) :
            //        new ObjectParameter("NUMERO_DOCUMENTO_EMPLEADO", typeof(string));

            //    var nOMBRE_EMPLEADOParameter = nOMBRE_EMPLEADO != null ?
            //        new ObjectParameter("NOMBRE_EMPLEADO", nOMBRE_EMPLEADO) :
            //        new ObjectParameter("NOMBRE_EMPLEADO", typeof(string));

            //    var jEFE_INMEDIATOParameter = jEFE_INMEDIATO != null ?
            //        new ObjectParameter("JEFE_INMEDIATO", jEFE_INMEDIATO) :
            //        new ObjectParameter("JEFE_INMEDIATO", typeof(string));

            //    var cOD_SOCIEDADParameter = cOD_SOCIEDAD.HasValue ?
            //        new ObjectParameter("COD_SOCIEDAD", cOD_SOCIEDAD) :
            //        new ObjectParameter("COD_SOCIEDAD", typeof(int));

            //    var nOMBRE_SOCIEDADParameter = nOMBRE_SOCIEDAD != null ?
            //        new ObjectParameter("NOMBRE_SOCIEDAD", nOMBRE_SOCIEDAD) :
            //        new ObjectParameter("NOMBRE_SOCIEDAD", typeof(string));

            //    var cOD_EQUIPO_VENTASParameter = cOD_EQUIPO_VENTAS.HasValue ?
            //        new ObjectParameter("COD_EQUIPO_VENTAS", cOD_EQUIPO_VENTAS) :
            //        new ObjectParameter("COD_EQUIPO_VENTAS", typeof(int));

            //    var nOMBRE_EQUIPO_VENTASParameter = nOMBRE_EQUIPO_VENTAS != null ?
            //        new ObjectParameter("NOMBRE_EQUIPO_VENTAS", nOMBRE_EQUIPO_VENTAS) :
            //        new ObjectParameter("NOMBRE_EQUIPO_VENTAS", typeof(string));

            //    var cOD_CIUDAD_TRABAJOParameter = cOD_CIUDAD_TRABAJO.HasValue ?
            //        new ObjectParameter("COD_CIUDAD_TRABAJO", cOD_CIUDAD_TRABAJO) :
            //        new ObjectParameter("COD_CIUDAD_TRABAJO", typeof(int));

            //    var nOMBRE_CIUDAD_TRABAJOParameter = nOMBRE_CIUDAD_TRABAJO != null ?
            //        new ObjectParameter("NOMBRE_CIUDAD_TRABAJO", nOMBRE_CIUDAD_TRABAJO) :
            //        new ObjectParameter("NOMBRE_CIUDAD_TRABAJO", typeof(string));

            //    var cOD_DANE_CIUDAD_TRABAJOParameter = cOD_DANE_CIUDAD_TRABAJO.HasValue ?
            //        new ObjectParameter("COD_DANE_CIUDAD_TRABAJO", cOD_DANE_CIUDAD_TRABAJO) :
            //        new ObjectParameter("COD_DANE_CIUDAD_TRABAJO", typeof(int));

            //    var cOD_UBICACION_FISICAParameter = cOD_UBICACION_FISICA != null ?
            //        new ObjectParameter("COD_UBICACION_FISICA", cOD_UBICACION_FISICA) :
            //        new ObjectParameter("COD_UBICACION_FISICA", typeof(string));

            //    var nOMBRE_UBICACION_FISICAParameter = nOMBRE_UBICACION_FISICA != null ?
            //        new ObjectParameter("NOMBRE_UBICACION_FISICA", nOMBRE_UBICACION_FISICA) :
            //        new ObjectParameter("NOMBRE_UBICACION_FISICA", typeof(string));

            //    var cOD_NIVEL_RIESGO_ARLParameter = cOD_NIVEL_RIESGO_ARL.HasValue ?
            //        new ObjectParameter("COD_NIVEL_RIESGO_ARL", cOD_NIVEL_RIESGO_ARL) :
            //        new ObjectParameter("COD_NIVEL_RIESGO_ARL", typeof(int));

            //    var nIVEL_RIESGO_ARLParameter = nIVEL_RIESGO_ARL != null ?
            //        new ObjectParameter("NIVEL_RIESGO_ARL", nIVEL_RIESGO_ARL) :
            //        new ObjectParameter("NIVEL_RIESGO_ARL", typeof(string));

            //    var cOD_CATEGORIA_EDParameter = cOD_CATEGORIA_ED.HasValue ?
            //        new ObjectParameter("COD_CATEGORIA_ED", cOD_CATEGORIA_ED) :
            //        new ObjectParameter("COD_CATEGORIA_ED", typeof(int));

            //    var nOMBRE_CATEGORIA_EDParameter = nOMBRE_CATEGORIA_ED != null ?
            //        new ObjectParameter("NOMBRE_CATEGORIA_ED", nOMBRE_CATEGORIA_ED) :
            //        new ObjectParameter("NOMBRE_CATEGORIA_ED", typeof(string));

            //    var cARGO_CRITICOParameter = cARGO_CRITICO != null ?
            //        new ObjectParameter("CARGO_CRITICO", cARGO_CRITICO) :
            //        new ObjectParameter("CARGO_CRITICO", typeof(string));

            //    var cOD_JORNADA_LABORALParameter = cOD_JORNADA_LABORAL.HasValue ?
            //        new ObjectParameter("COD_JORNADA_LABORAL", cOD_JORNADA_LABORAL) :
            //        new ObjectParameter("COD_JORNADA_LABORAL", typeof(int));

            //    var nOMBRE_JORNADA_LABORALParameter = nOMBRE_JORNADA_LABORAL != null ?
            //        new ObjectParameter("NOMBRE_JORNADA_LABORAL", nOMBRE_JORNADA_LABORAL) :
            //        new ObjectParameter("NOMBRE_JORNADA_LABORAL", typeof(string));

            //    var hORARIO_LABORAL_DESDEParameter = hORARIO_LABORAL_DESDE != null ?
            //        new ObjectParameter("HORARIO_LABORAL_DESDE", hORARIO_LABORAL_DESDE) :
            //        new ObjectParameter("HORARIO_LABORAL_DESDE", typeof(string));

            //    var hORARIO_LABORAL_HASTAParameter = hORARIO_LABORAL_HASTA != null ?
            //        new ObjectParameter("HORARIO_LABORAL_HASTA", hORARIO_LABORAL_HASTA) :
            //        new ObjectParameter("HORARIO_LABORAL_HASTA", typeof(string));

            //    var cOD_DIA_LABORAL_DESDEParameter = cOD_DIA_LABORAL_DESDE.HasValue ?
            //        new ObjectParameter("COD_DIA_LABORAL_DESDE", cOD_DIA_LABORAL_DESDE) :
            //        new ObjectParameter("COD_DIA_LABORAL_DESDE", typeof(int));

            //    var cOD_DIA_LABORAL_HASTAParameter = cOD_DIA_LABORAL_HASTA.HasValue ?
            //        new ObjectParameter("COD_DIA_LABORAL_HASTA", cOD_DIA_LABORAL_HASTA) :
            //        new ObjectParameter("COD_DIA_LABORAL_HASTA", typeof(int));

            //    var pOSICIONParameter = pOSICION != null ?
            //        new ObjectParameter("POSICION", pOSICION) :
            //        new ObjectParameter("POSICION", typeof(string));

            //    var eMPRESA_TEMPORALParameter = eMPRESA_TEMPORAL != null ?
            //        new ObjectParameter("EMPRESA_TEMPORAL", eMPRESA_TEMPORAL) :
            //        new ObjectParameter("EMPRESA_TEMPORAL", typeof(string));

            //    var sALARIO_FIJOParameter = sALARIO_FIJO.HasValue ?
            //        new ObjectParameter("SALARIO_FIJO", sALARIO_FIJO) :
            //        new ObjectParameter("SALARIO_FIJO", typeof(decimal));

            //    var pORCENTAJE_SALARIO_FIJOParameter = pORCENTAJE_SALARIO_FIJO.HasValue ?
            //        new ObjectParameter("PORCENTAJE_SALARIO_FIJO", pORCENTAJE_SALARIO_FIJO) :
            //        new ObjectParameter("PORCENTAJE_SALARIO_FIJO", typeof(decimal));

            //    var sALARIO_VARIABLEParameter = sALARIO_VARIABLE.HasValue ?
            //        new ObjectParameter("SALARIO_VARIABLE", sALARIO_VARIABLE) :
            //        new ObjectParameter("SALARIO_VARIABLE", typeof(decimal));

            //    var pORCENTAJE_SALARIO_VARIABLEParameter = pORCENTAJE_SALARIO_VARIABLE.HasValue ?
            //        new ObjectParameter("PORCENTAJE_SALARIO_VARIABLE", pORCENTAJE_SALARIO_VARIABLE) :
            //        new ObjectParameter("PORCENTAJE_SALARIO_VARIABLE", typeof(decimal));

            //    var sOBREREMUNERACIONParameter = sOBREREMUNERACION.HasValue ?
            //        new ObjectParameter("SOBREREMUNERACION", sOBREREMUNERACION) :
            //        new ObjectParameter("SOBREREMUNERACION", typeof(decimal));

            //    var pORCENTAJE_SOBREREMUNERACIONParameter = pORCENTAJE_SOBREREMUNERACION.HasValue ?
            //        new ObjectParameter("PORCENTAJE_SOBREREMUNERACION", pORCENTAJE_SOBREREMUNERACION) :
            //        new ObjectParameter("PORCENTAJE_SOBREREMUNERACION", typeof(decimal));

            //    var eXTRA_FIJAParameter = eXTRA_FIJA.HasValue ?
            //        new ObjectParameter("EXTRA_FIJA", eXTRA_FIJA) :
            //        new ObjectParameter("EXTRA_FIJA", typeof(decimal));

            //    var rECARGO_NOCTURNOParameter = rECARGO_NOCTURNO.HasValue ?
            //        new ObjectParameter("RECARGO_NOCTURNO", rECARGO_NOCTURNO) :
            //        new ObjectParameter("RECARGO_NOCTURNO", typeof(decimal));

            //    var mEDIO_TRANSPORTEParameter = mEDIO_TRANSPORTE.HasValue ?
            //        new ObjectParameter("MEDIO_TRANSPORTE", mEDIO_TRANSPORTE) :
            //        new ObjectParameter("MEDIO_TRANSPORTE", typeof(decimal));

            //    var sALARIO_TOTALParameter = sALARIO_TOTAL.HasValue ?
            //        new ObjectParameter("SALARIO_TOTAL", sALARIO_TOTAL) :
            //        new ObjectParameter("SALARIO_TOTAL", typeof(decimal));

            //    var bONO_ANUALParameter = bONO_ANUAL.HasValue ?
            //        new ObjectParameter("BONO_ANUAL", bONO_ANUAL) :
            //        new ObjectParameter("BONO_ANUAL", typeof(decimal));

            //    var nUMERO_SALARIOSParameter = nUMERO_SALARIOS.HasValue ?
            //        new ObjectParameter("NUMERO_SALARIOS", nUMERO_SALARIOS) :
            //        new ObjectParameter("NUMERO_SALARIOS", typeof(int));

            //    var mESES_GARANTIZADOSParameter = mESES_GARANTIZADOS.HasValue ?
            //        new ObjectParameter("MESES_GARANTIZADOS", mESES_GARANTIZADOS) :
            //        new ObjectParameter("MESES_GARANTIZADOS", typeof(int));

            //    var cOD_TIPO_SALARIOParameter = cOD_TIPO_SALARIO.HasValue ?
            //        new ObjectParameter("COD_TIPO_SALARIO", cOD_TIPO_SALARIO) :
            //        new ObjectParameter("COD_TIPO_SALARIO", typeof(int));

            //    var nOMBRE_TIPO_SALARIOParameter = nOMBRE_TIPO_SALARIO != null ?
            //        new ObjectParameter("NOMBRE_TIPO_SALARIO", nOMBRE_TIPO_SALARIO) :
            //        new ObjectParameter("NOMBRE_TIPO_SALARIO", typeof(string));

            //    var fACTOR_PRESTACIONALParameter = fACTOR_PRESTACIONAL.HasValue ?
            //        new ObjectParameter("FACTOR_PRESTACIONAL", fACTOR_PRESTACIONAL) :
            //        new ObjectParameter("FACTOR_PRESTACIONAL", typeof(decimal));

            //    var iNGRESO_PROM_MENSUALParameter = iNGRESO_PROM_MENSUAL.HasValue ?
            //        new ObjectParameter("INGRESO_PROM_MENSUAL", iNGRESO_PROM_MENSUAL) :
            //        new ObjectParameter("INGRESO_PROM_MENSUAL", typeof(decimal));

            //    var iNGRESO_PROM_ANUALParameter = iNGRESO_PROM_ANUAL.HasValue ?
            //        new ObjectParameter("INGRESO_PROM_ANUAL", iNGRESO_PROM_ANUAL) :
            //        new ObjectParameter("INGRESO_PROM_ANUAL", typeof(decimal));

            //    var mERCADOParameter = mERCADO != null ?
            //        new ObjectParameter("MERCADO", mERCADO) :
            //        new ObjectParameter("MERCADO", typeof(string));

            //    var cOD_CATEGORIAParameter = cOD_CATEGORIA.HasValue ?
            //        new ObjectParameter("COD_CATEGORIA", cOD_CATEGORIA) :
            //        new ObjectParameter("COD_CATEGORIA", typeof(int));

            //    var nOMBRE_CATEGORIAParameter = nOMBRE_CATEGORIA != null ?
            //        new ObjectParameter("NOMBRE_CATEGORIA", nOMBRE_CATEGORIA) :
            //        new ObjectParameter("NOMBRE_CATEGORIA", typeof(string));

            //    var pUNTO_MEDIO_80Parameter = pUNTO_MEDIO_80.HasValue ?
            //        new ObjectParameter("PUNTO_MEDIO_80", pUNTO_MEDIO_80) :
            //        new ObjectParameter("PUNTO_MEDIO_80", typeof(decimal));

            //    var pUNTO_MEDIO_100Parameter = pUNTO_MEDIO_100.HasValue ?
            //        new ObjectParameter("PUNTO_MEDIO_100", pUNTO_MEDIO_100) :
            //        new ObjectParameter("PUNTO_MEDIO_100", typeof(decimal));

            //    var pUNTO_MEDIO_120Parameter = pUNTO_MEDIO_120.HasValue ?
            //        new ObjectParameter("PUNTO_MEDIO_120", pUNTO_MEDIO_120) :
            //        new ObjectParameter("PUNTO_MEDIO_120", typeof(decimal));

            //    var pOSICIONAMIENTOParameter = pOSICIONAMIENTO.HasValue ?
            //        new ObjectParameter("POSICIONAMIENTO", pOSICIONAMIENTO) :
            //        new ObjectParameter("POSICIONAMIENTO", typeof(decimal));)
            return null;
            //}

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
                    requicisionModel.COD_TIPO_NECESIDAD = respuesta.COD_TIPO_NECESIDAD??0;
                    requicisionModel.COD_CARGO = respuesta.COD_CARGO??0;
                    requicisionModel.NOMBRE_CARGO = respuesta.NOMBRE_CARGO;
                    requicisionModel.ORDEN = respuesta.ORDEN;
                    requicisionModel.COD_CECO = respuesta.COD_CARGO??0;
                    requicisionModel.NOMBRE_CECO = respuesta.NOMBRE_CARGO;
                    requicisionModel.COD_TIPO_REQUISICION = respuesta.COD_TIPO_REQUISICION??0;
                    requicisionModel.FECHA_INICIO = respuesta.FECHA_INICIO??DateTime.Now;
                    requicisionModel.FECHA_FIN = respuesta.FECHA_FIN??DateTime.Now;
                    requicisionModel.ES_MODIFICACION = respuesta.ES_MODIFICACION??false;
                    requicisionModel.OBSERVACION = respuesta.OBSERVACION;
                    requicisionModel.COD_ESTADO_REQUISICION = respuesta.COD_ESTADO_REQUISICION??0;
                    requicisionModel.USUARIO_CREACION = respuesta.USUARIO_CREACION;
                    requicisionModel.FECHA_CREACION = respuesta.FECHA_CREACION.ToString()??DateTime.Now.ToShortDateString();
                    requicisionModel.USUARIO_MODIFICACION = respuesta.USUARIO_MODIFICACION;
                    requicisionModel.FECHA_MODIFICACION = respuesta.FECHA_MODIFICACION??DateTime.Now;
                    requicisionModel.COD_GERENCIA = respuesta.COD_GERENCIA??0;
                    requicisionModel.NOMBRE_GERENCIA = respuesta.NOMBRE_GERENCIA;
                    requicisionModel.COD_TIPO_CONTRATO = respuesta.COD_TIPO_CONTRATO??0;
                    requicisionModel.NOMBRE_TIPO_CONTRATO = respuesta.NOMBRE_TIPO_CONTRATO;
                    requicisionModel.COD_TIPO_DOCUMENTO = respuesta.COD_TIPO_DOCUMENTO ?? 0;
                    requicisionModel.NUMERO_DOCUMENTO_EMPLEADO = respuesta.NUMERO_DOCUMENTO_EMPLEADO;
                    requicisionModel.NOMBRE_EMPLEADO = respuesta.NOMBRE_EMPLEADO;
                    requicisionModel.JEFE_INMEDIATO = respuesta.JEFE_INMEDIATO;
                    requicisionModel.COD_SOCIEDAD = respuesta.COD_SOCIEDAD??0;
                    requicisionModel.NOMBRE_SOCIEDAD = respuesta.NOMBRE_SOCIEDAD;
                    requicisionModel.COD_EQUIPO_VENTAS = respuesta.COD_EQUIPO_VENTAS??0;
                    requicisionModel.NOMBRE_EQIPO_VENTAS = respuesta.NOMBRE_EQUIPO_VENTAS;
                    requicisionModel.COD_CIUDAD_TRABAJO = respuesta.COD_CIUDAD_TRABAJO??0;
                    requicisionModel.NOMBRE_CIUDAD_TRABAJO = respuesta.NOMBRE_CIUDAD_TRABAJO;
                    requicisionModel.COD_DANE_CIUDAD_TRABAJO = respuesta.COD_DANE_CIUDAD_TRABAJO??0;
                    requicisionModel.COD_UBICACION_FISICA = respuesta.COD_UBICACION_FISICA??0;
                    requicisionModel.NOMBRE_UBICACION_FISICA = respuesta.NOMBRE_UBICACION_FISICA;
                    requicisionModel.COD_NIVEL_RIESGO_ARL = respuesta.COD_NIVEL_RIESGO_ARL??0;
                    requicisionModel.NIVEL_RIESGO_ARL = respuesta.NIVEL_RIESGO_ARL;
                    requicisionModel.COD_CATEGORIA_ED = respuesta.COD_CATEGORIA_ED??0;
                    requicisionModel.NOMBRE_CATEGORIA_ED = respuesta.NOMBRE_CATEGORIA_ED;
                    requicisionModel.CARGO_CRITICO = respuesta.CARGO_CRITICO ?? false;
                    requicisionModel.COD_JORNADA_LABORAL = respuesta.COD_JORNADA_LABORAL??0;
                    requicisionModel.NOMBRE_JORNADA_LABORAL = respuesta.NOMBRE_JORNADA_LABORAL;
                    requicisionModel.HORARIO_LABORAL_DESDE = respuesta.HORARIO_LABORAL_DESDE;
                    requicisionModel.COD_DIA_LABORAL_DESDE = respuesta.COD_DIA_LABORAL_DESDE??0;
                    requicisionModel.POSICION = respuesta.POSICION;
                    requicisionModel.EMPRESA_TEMPORAL = respuesta.EMPRESA_TEMPORAL;
                    requicisionModel.SALARIO_FIJO = respuesta.SALARIO_FIJO??0;
                    requicisionModel.PORCENTAJE_SALARIO_FIJO = respuesta.PORCENTAJE_SALARIO_FIJO??0;
                    requicisionModel.SALARIO_VARIABLE = respuesta.SALARIO_VARIABLE ?? 0;
                    requicisionModel.PORCENTAJE_SALARIO_VARIABLE = respuesta.PORCENTAJE_SALARIO_VARIABLE ?? 0;
                    requicisionModel.SOBREREMUNERACION = respuesta.SOBREREMUNERACION??0;
                    requicisionModel.PORCENTAJE_SOBREREMUNERACION = respuesta.PORCENTAJE_SOBREREMUNERACION??0;
                    requicisionModel.EXTRA_FIJA = respuesta.EXTRA_FIJA??0;
                    requicisionModel.RECARGO_NOCTURNO = respuesta.RECARGO_NOCTURNO??0;
                    requicisionModel.MEDIO_TRANSPORTE = respuesta.MEDIO_TRANSPORTE??0;
                    requicisionModel.SALARIO_TOTAL = respuesta.SALARIO_TOTAL??0;
                    requicisionModel.BONO_ANUAL = respuesta.BONO_ANUAL??0;
                    requicisionModel.NUMERO_SALARIOS = respuesta.NUMERO_SALARIOS??0;
                    requicisionModel.MESES_GARANTIZADOS = respuesta.MESES_GARANTIZADOS??0;
                    requicisionModel.COD_TIPO_SALARIO = respuesta.COD_TIPO_REQUISICION??0;
                    requicisionModel.NOMBRE_TIPO_SALARIO = respuesta.NOMBRE_TIPO_SALARIO;
                    requicisionModel.INGRESO_PROM_MENSUAL = respuesta.INGRESO_PROM_MENSUAL??0;
                    requicisionModel.INGRESO_PROM_ANUAL = respuesta.INGRESO_PROM_ANUAL??0;
                    requicisionModel.MERCADO = respuesta.MERCADO;
                    requicisionModel.COD_CATEGORIA = respuesta.COD_CATEGORIA??0;
                    requicisionModel.NOMBRE_CATEGORIA = respuesta.NOMBRE_CATEGORIA;
                    requicisionModel.PUNTO_MEDIO_80 = respuesta.PUNTO_MEDIO_80??0;
                    requicisionModel.PUNTO_MEDIO_100 = respuesta.PUNTO_MEDIO_100??0;
                    requicisionModel.PUNTO_MEDIO_120 = respuesta.PUNTO_MEDIO_120??0; 
                    requicisionModel.POSICIONAMIENTO = respuesta.POSICIONAMIENTO??0;
                    requicisionModel.EMAIL_USUARIO_CREACION = respuesta.EMAIL_USUARIO_CREACION;
                    requicisionModel.LOGIN_EMPLEADO = respuesta.LOGIN_EMPLEADO; 
    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return requicisionModel;
        }

        public int INSERTAR_REQUISICION(REQUISICIONViewModel _modelo, string usuario) {
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
                         _modelo.OBSERVACION_CREACION,
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
                         _modelo.COD_DIA_LABORAL_DESDE,
                         _modelo.COD_DIA_LABORAL_HASTA,
                          _modelo.COD_DIA_LABORAL_DESDE,
                         _modelo.COD_DIA_LABORAL_HASTA,
                        Convert.ToInt32(_modelo.PORCENTAJE_SOBREREMUNERACION),
                        _modelo.MESES_GARANTIZADOS,
                        _modelo.COD_TIPO_SALARIO,
                        _modelo.FACTOR_PRESTACIONAL.ToString(),  // EN BASE DE DATOS ES VARCHAR
                        _modelo.INGRESO_PROM_MENSUAL,
                        _modelo.INGRESO_PROM_ANUAL,
                        _modelo.MERCADO,
                       _modelo.COD_CATEGORIA,
                       _modelo.PUNTO_MEDIO_80,
                       _modelo.PUNTO_MEDIO_100,
                       _modelo.PUNTO_MEDIO_120,
                       _modelo.POSICIONAMIENTO.ToString(), // EN BASE DE DATOS ES VARCHAR
                       usuario,
                       1
                   ).FirstOrDefault().Value;
                }
                
            }
            catch (SqlException ex)
            {
                var error = ex;
                return 0;
            }

        }
    }
}
