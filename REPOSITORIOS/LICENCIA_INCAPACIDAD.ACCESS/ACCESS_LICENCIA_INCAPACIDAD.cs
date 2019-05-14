using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION_ENTITY;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORIOS.LICENCIA_INCAPACIDAD.ACCESS
{
    public class ACCESS_LICENCIA_INCAPACIDAD
    {
        public string INSERTAR_LICENCIA_INCAPACIDAD(REQUISICIONViewModel model)
        {
            //string ConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();            

            //using (SqlConnection conn = new SqlConnection(ConnString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("[GESTION_HUMANA_HITSS].[dbo].[REQUISICION.REQUISICION]", conn))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@COD_TIPO_NECESIDAD", model.COD_TIPO_NECESIDAD);
            //        cmd.Parameters.AddWithValue("@COD_TIPO_REQUISICION", model.COD_TIPO_REQUISICION);
            //        cmd.Parameters.AddWithValue("@COD_CARGO", model.COD_CARGO);
            //        cmd.Parameters.AddWithValue("@NOMBRE_CARGO", "Cargo");
            //        cmd.Parameters.AddWithValue("@ORDEN", model.ORDEN);
            //        cmd.Parameters.AddWithValue("@COD_CECO", model.COD_CECO);
            //        cmd.Parameters.AddWithValue("@NOMBRE_CECO", "CECO");
            //        cmd.Parameters.AddWithValue("@OBSERVACION", model.OBSERVACION ?? "");
            //        cmd.Parameters.AddWithValue("@COD_TIPO_DOCUMENTO", model.COD_TIPO_DOCUMENTO);
            //        cmd.Parameters.AddWithValue("@NUMERO_DOCUMENTO_EMPLEADO", model.NUMERO_DOCUMENTO_EMPLEADO);
            //        cmd.Parameters.AddWithValue("@NOMBRE_EMPLEADO", model.LOGIN_EMPLEADO ?? "");
            //        cmd.Parameters.AddWithValue("@FECHA_INICIO", model.FECHA_INICIO);
            //        cmd.Parameters.AddWithValue("@FECHA_FIN", model.FECHA_FIN);
            //        cmd.Parameters.AddWithValue("@COD_GERENCIA", model.COD_GERENCIA);
            //        cmd.Parameters.AddWithValue("@NOMBRE_GERENCIA", model.NOMBRE_GERENCIA ?? "");
            //        cmd.Parameters.AddWithValue("@COD_SOCIEDAD", model.COD_SOCIEDAD);
            //        cmd.Parameters.AddWithValue("@NOMBRE_SOCIEDAD", model.NOMBRE_SOCIEDAD ?? "");
            //        cmd.Parameters.AddWithValue("@COD_EQUIPO_VENTAS", model.COD_EQUIPO_VENTAS);
            //        cmd.Parameters.AddWithValue("@NOMBRE_EQUIPO_VENTAS", model.NOMBRE_EQIPO_VENTAS ?? "");
            //        cmd.Parameters.AddWithValue("@COD_CATEGORIA_ED", model.COD_CATEGORIA_ED);
            //        cmd.Parameters.AddWithValue("@NOMBRE_CATEGORIA_ED", model.NOMBRE_CATEGORIA ?? "");
            //        cmd.Parameters.AddWithValue("@CARGO_CRITICO", model.CARGO_CRITICO);
            //        cmd.Parameters.AddWithValue("@POSICION", model.POSICION);
            //        cmd.Parameters.AddWithValue("@SALARIO_FIJO", model.SALARIO_FIJO);
            //        cmd.Parameters.AddWithValue("@PORCENTAJE_SALARIO_FIJO", model.PORCENTAJE_SALARIO_FIJO);
            //        cmd.Parameters.AddWithValue("@SALARIO_VARIABLE", model.SALARIO_VARIABLE);
            //        cmd.Parameters.AddWithValue("@PORCENTAJE_SALARIO_VARIABLE", model.PORCENTAJE_SALARIO_VARIABLE);
            //        cmd.Parameters.AddWithValue("@SOBREREMUNERACION", model.SOBREREMUNERACION);
            //        cmd.Parameters.AddWithValue("@EXTRA_FIJA", model.EXTRA_FIJA);
            //        cmd.Parameters.AddWithValue("@RECARGO_NOCTURNO", model.RECARGO_NOCTURNO);
            //        cmd.Parameters.AddWithValue("@MEDIO_TRANSPORTE", model.MEDIO_TRANSPORTE);
            //        cmd.Parameters.AddWithValue("@SALARIO_TOTAL", model.SALARIO_TOTAL);
            //        cmd.Parameters.AddWithValue("@BONO_ANUAL", model.BONO_ANUAL);
            //        cmd.Parameters.AddWithValue("@NUMERO_SALARIOS", model.NUMERO_SALARIOS);
            //        cmd.Parameters.AddWithValue("@COD_NIVEL_RIESGO_ARL", model.COD_NIVEL_RIESGO_ARL);
            //        cmd.Parameters.AddWithValue("@COD_JORNADA_LABORAL", model.COD_JORNADA_LABORAL);
            //        cmd.Parameters.AddWithValue("@HORARIO_LABORAL_DESDE", model.HORARIO_LABORAL_DESDE);
            //        cmd.Parameters.AddWithValue("@HORARIO_LABORAL_HASTA", model.HORARIO_LABORAL_HASTA);
            //        cmd.Parameters.AddWithValue("@COD_DIA_LABORAL_DESDE", model.COD_DIA_LABORAL_DESDE);
            //        cmd.Parameters.AddWithValue("@COD_DIA_LABORAL_HASTA", model.COD_DIA_LABORAL_HASTA);
            //        cmd.Parameters.AddWithValue("@PORCENTAJE_SOBREREMUNERACION", model.PORCENTAJE_SOBREREMUNERACION);
            //        cmd.Parameters.AddWithValue("@MESES_GARANTIZADOS", model.MESES_GARANTIZADOS);
            //        cmd.Parameters.AddWithValue("@COD_TIPO_SALARIO", model.COD_TIPO_SALARIO);
            //        cmd.Parameters.AddWithValue("@FACTOR_PRESTACIONAL", model.FACTOR_PRESTACIONAL);
            //        cmd.Parameters.AddWithValue("@INGRESO_PROM_MENSUAL", model.INGRESO_PROM_MENSUAL);
            //        cmd.Parameters.AddWithValue("@INGRESO_PROM_ANUAL", model.INGRESO_PROM_ANUAL);
            //        cmd.Parameters.AddWithValue("@MERCADO", model.MERCADO ?? "");
            //        cmd.Parameters.AddWithValue("@COD_CATEGORIA", model.COD_CATEGORIA);
            //        cmd.Parameters.AddWithValue("@PUNTO_MEDIO_80", model.PUNTO_MEDIO_80);
            //        cmd.Parameters.AddWithValue("@PUNTO_MEDIO_100", model.PUNTO_MEDIO_100);
            //        cmd.Parameters.AddWithValue("@PUNTO_MEDIO_120", model.PUNTO_MEDIO_120);
            //        cmd.Parameters.AddWithValue("@POSICIONAMIENTO", model.POSICIONAMIENTO);
            //        cmd.Parameters.AddWithValue("@USUARIO", model.USUARIO_CREACION??"");
            //        cmd.Parameters.AddWithValue("@COD_ESTADO", model.COD_ESTADO_REQUISICION);

            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //    }
            //}




            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {



                db.INSERTAR_REQUISICION(model.COD_TIPO_NECESIDAD, model.COD_TIPO_REQUISICION, model.COD_CARGO, "Cargo", model.ORDEN ?? "", model.COD_CECO, "Ceco", model.OBSERVACION ?? "", model.COD_TIPO_DOCUMENTO, model.NUMERO_DOCUMENTO_EMPLEADO ?? "", "model.NOMBRE_EMPLEADO", model.FECHA_INICIO, model.FECHA_FIN, model.COD_GERENCIA, model.NOMBRE_GERENCIA ?? "", model.COD_SOCIEDAD, model.NOMBRE_SOCIEDAD ?? "", model.COD_EQUIPO_VENTAS, model.NOMBRE_EQIPO_VENTAS ?? "", model.COD_CATEGORIA_ED, "model.LIST_NOMBRE_CATEGORIA_ED", model.CARGO_CRITICO, model.POSICION ?? "", model.SALARIO_FIJO, model.PORCENTAJE_SALARIO_FIJO, model.SALARIO_VARIABLE, model.PORCENTAJE_SALARIO_VARIABLE, model.SOBREREMUNERACION, model.EXTRA_FIJA, model.RECARGO_NOCTURNO, model.MEDIO_TRANSPORTE, model.SALARIO_TOTAL, model.BONO_ANUAL, model.NUMERO_SALARIOS, model.COD_NIVEL_RIESGO_ARL, model.COD_JORNADA_LABORAL, Convert.ToInt32(model.HORARIO_LABORAL_DESDE), Convert.ToInt32(model.HORARIO_LABORAL_HASTA),model.COD_DIA_LABORAL_HASTA,model.COD_DIA_LABORAL_DESDE, Convert.ToInt32(model.PORCENTAJE_SOBREREMUNERACION), model.MESES_GARANTIZADOS, model.COD_TIPO_SALARIO, model.FACTOR_PRESTACIONAL.ToString() ?? "", model.INGRESO_PROM_MENSUAL, model.INGRESO_PROM_ANUAL, model.MERCADO ?? "", model.COD_CATEGORIA, model.PUNTO_MEDIO_80, model.PUNTO_MEDIO_100, model.PUNTO_MEDIO_120, model.POSICIONAMIENTO.ToString() ?? "", model.USUARIO_CREACION ?? "", model.COD_ESTADO_REQUISICION);
                //db.INSERTAR_REQUISICION(model.COD_TIPO_NECESIDAD, model.COD_TIPO_REQUISICION, model.COD_CARGO, model.NOMBRE_CARGO, model.ORDEN, model.COD_CECO, model.NOMBRE_CECO, model.OBSERVACION, model.COD_TIPO_DOCUMENTO, model.NUMERO_DOCUMENTO_EMPLEADO, model.NOMBRE_EMPLEADO, model.FECHA_INICIO, model.FECHA_FIN, model.COD_GERENCIA, model.NOMBRE_GERENCIA, model.COD_SOCIEDAD, model.NOMBRE_SOCIEDAD, model.COD_EQUIPO_VENTAS, model.NOMBRE_EQIPO_VENTAS, model.COD_CATEGORIA_ED, model.LIST_NOMBRE_CATEGORIA_ED, model.CARGO_CRITICO, model.POSICION, model.SALARIO_FIJO, model.PORCENTAJE_SALARIO_FIJO, model.SALARIO_VARIABLE, model.PORCENTAJE_SALARIO_VARIABLE, model.SOBREREMUNERACION, model.EXTRA_FIJA, model.RECARGO_NOCTURNO, model.MEDIO_TRANSPORTE, model.SALARIO_TOTAL, model.BONO_ANUAL, model.NUMERO_SALARIOS, model.COD_NIVEL_RIESGO_ARL, model.COD_JORNADA_LABORAL, model.HORARIO_LABORAL_DESDE, model.HORARIO_LABORAL_HASTA, model.PORCENTAJE_SOBREREMUNERACION, model.MESES_GARANTIZADOS, model.COD_TIPO_SALARIO, model.FACTOR_PRESTACIONAL, model.INGRESO_PROM_MENSUAL, model.INGRESO_PROM_ANUAL, model.MERCADO, model.COD_CATEGORIA, model.PUNTO_MEDIO_80, model.PUNTO_MEDIO_100, model.PUNTO_MEDIO_120, model.POSICIONAMIENTO, model.USUARIO_CREACION, model.COD_ESTADO_REQUISICION);
                //    //INSERTAR_REQUISICION(int cOD_TIPO_NECESIDAD, int, List < SelectListItem > nOMBRE_CARGO, string oRDEN, int cOD_CECO, List < SelectListItem > nOMBRE_CECO, string oBSERVACION, , string nUMERO_DOCUMENTO_EMPLEADO, List < SelectListItem > nOMBRE_EMPLEADO, DateTime fECHA_INICIO, DateTime fECHA_FIN, int cOD_GERENCIA, string nOMBRE_GERENCIA, int cOD_SOCIEDAD, string nOMBRE_SOCIEDAD, int cOD_EQUIstring nOMBRE_EQIPO_VENTAS, int cOD_CATEGORIA_ED, List < SelectListItem > lIST_NOMBRE_CATEGORIA_ED, bool cARGO_CRITICO, string pOSICION, decimal sALARIO_FIJO, decimal pORCENTAJE_SALARIO_FIJO, decimal sALARIO_VARIABLE, decimal sOBREREMUNERACION, decimal eXTRA_FIJA, decimal rECARGO_NOCTURNO, decimal mEDIO_TRANSPORTE, decimal decimal bONO_ANUAL, int nUMERO_SALARIOS, int cOD_NIVEL_RIESGO_ARL, int cOD_JORNADA_LABORAL, string hORARIO_LABORAL_DESDE, string hORARIO_LABORAL_HASTA, decimal pORCENTAJE_SOBREREMUNERACION, int mESES_GARANTIZADOS, int cOD_TIPO_SALARIO, decimal fACTOR_PRESTACIONAL, decimal iNGRESO_PROM_MENSUAL, decimal iNGRESO_PROM_ANUAL, string mERCADO, int cOD_CATEGORIA, deci, decimal pUNTO_MEDIO_100, decimal pUNTO_MEDIO_120, decimal pOSICIONAMIENTO, string uSUARIO_CREACION, int cOD_ESTADO_REQUISICION)
                //    ////lst = consulta.Select(x => new TIPO_NECESIDADViewModel()
                //    //{
                //    //    COD_TIPO_NECESIDAD = x.COD_TIPO_NECESIDAD,
                //    //    NOMBRE_NECESIDAD = x.NOMBRE_NECESIDAD
                //    //}).ToList();
            }
            return "Exitoso";
        }
    }
}
