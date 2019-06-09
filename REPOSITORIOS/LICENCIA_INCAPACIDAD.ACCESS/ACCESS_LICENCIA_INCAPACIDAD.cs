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

            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {



                db.INSERTAR_REQUISICION(model.COD_TIPO_NECESIDAD
                                        , model.COD_TIPO_REQUISICION
                                        , model.COD_CARGO
                                        , model.NOMBRE_CARGO
                                        , model.ORDEN ?? ""
                                        , model.COD_CECO
                                        , model.NOMBRE_CECO
                                        , model.OBSERVACION ?? ""
                                        , model.COD_TIPO_DOCUMENTO
                                        , model.NUMERO_DOCUMENTO_EMPLEADO ?? ""
                                        , model.NOMBRE_EMPLEADO
                                        , model.FECHA_INICIO
                                        , model.FECHA_FIN
                                        , model.COD_GERENCIA
                                        , model.NOMBRE_GERENCIA ?? ""
                                        , model.COD_SOCIEDAD
                                        , model.NOMBRE_SOCIEDAD ?? ""
                                        , model.COD_EQUIPO_VENTAS
                                        , model.NOMBRE_EQIPO_VENTAS ?? ""
                                        , model.COD_CATEGORIA_ED
                                        , model.NOMBRE_CATEGORIA_ED
                                        , model.CARGO_CRITICO
                                        , model.POSICION ?? ""
                                        , model.SALARIO_FIJO
                                        , model.PORCENTAJE_SALARIO_FIJO
                                        , model.SALARIO_VARIABLE
                                        , model.PORCENTAJE_SALARIO_VARIABLE
                                        , model.SOBREREMUNERACION
                                        , model.EXTRA_FIJA
                                        , model.RECARGO_NOCTURNO
                                        , model.MEDIO_TRANSPORTE
                                        , model.SALARIO_TOTAL
                                        , model.BONO_ANUAL
                                        , model.NUMERO_SALARIOS
                                        , model.COD_NIVEL_RIESGO_ARL
                                        , model.COD_JORNADA_LABORAL
                                        , model.NOMBRE_JORNADA_LABORAL
                                        , model.COD_HORARIO_LABORAL_DESDE
                                        , model.HORARIO_LABORAL_DESDE
                                        , model.COD_HORARIO_LABORAL_HASTA
                                        , model.HORARIO_LABORAL_HASTA
                                        , model.COD_DIA_LABORAL_DESDE
                                        , model.DIA_LABORAL_DESDE
                                        , model.COD_DIA_LABORAL_HASTA
                                        , model.DIA_LABORAL_HASTA
                                        , model.PORCENTAJE_SOBREREMUNERACION
                                        , model.MESES_GARANTIZADOS
                                        , model.COD_TIPO_SALARIO
                                        , model.NOMBRE_TIPO_SALARIO
                                        , model.FACTOR_PRESTACIONAL.ToString() ?? ""
                                        , model.INGRESO_PROM_MENSUAL
                                        , model.INGRESO_PROM_ANUAL
                                        , model.COD_MERCADO
                                        , model.MERCADO ?? ""
                                        , model.COD_CATEGORIA
                                        , model.PUNTO_MEDIO_80
                                        , model.PUNTO_MEDIO_100
                                        , model.PUNTO_MEDIO_120
                                        , model.POSICIONAMIENTO.ToString() ?? ""
                                        , model.USUARIO_CREACION ?? ""
                                        , model.COD_ESTADO_REQUISICION
                                        ,model.ES_MODIFICACION
                                        ,model.COD_CORREO_CONTROLLER);

            }
            return "Exitoso";
        }
    }
}
