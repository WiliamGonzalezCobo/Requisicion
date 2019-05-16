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
        public List<TIPO_NECESIDADViewModel> CONSULTAR_TIPOS_NECESIDAD_ACCESS(){
            List<TIPO_NECESIDADViewModel> lst = null;
            using (var db = new GESTION_HUMANA_HITSSEntities2()){
                ObjectResult<CONSULTAR_TIPOS_NECESIDAD_Result> consulta = db.CONSULTAR_TIPOS_NECESIDAD();
                lst = consulta.Select(x => new TIPO_NECESIDADViewModel(){
                    COD_TIPO_NECESIDAD = x.COD_TIPO_NECESIDAD,
                    NOMBRE_NECESIDAD = x.NOMBRE_NECESIDAD
                }).ToList();
            }
            return lst;
        }

        public List<ESTADOViewModel> CONSULTAR_ESTADOS_ACCESS() {
            List<ESTADOViewModel> lst = null;
            using (var db = new GESTION_HUMANA_HITSSEntities2()){
                ObjectResult<CONSULTAR_ESTADOS_Result> consulta = db.CONSULTAR_ESTADOS();
                lst = consulta.Select(x => new ESTADOViewModel(){
                    COD_ESTADO_REQUISICION = x.COD_ESTADO_REQUISICION,
                    NOMBRE_ESTADO = x.NOMBRE_ESTADO
                }).ToList();
            }
            return lst;
        }

        public List<TIPOViewModel> CONSULTAR_TIPOS_REQUISICION_ACCESS() {
            List<TIPOViewModel> lst = null;
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                ObjectResult<CONSULTAR_TIPOS_REQUISICION_Result> consulta = db.CONSULTAR_TIPOS_REQUISICION();
                lst = consulta.Select(x => new TIPOViewModel(){
                    COD_TIPO_REQUISICION = x.COD_TIPO_REQUISICION,
                    NOMBRE_REQUISICION = x.NOMBRE_REQUISICION
                }).ToList();
            }
           
            return lst;
        }

        public List<REQUISICIONViewModel> CONSULTAR_REQUISICIONES_ACCESS(){
            List<REQUISICIONViewModel> lst = null;
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                ObjectResult<CONSULTAR_REQUISICIONES_JEFE_Result> consulta = db.CONSULTAR_REQUISICIONES_JEFE();
                lst = consulta.Select(x => new REQUISICIONViewModel()
                {
                    COD_REQUISICION = x.COD_TIPO_REQUISICION??0,
                    COD_CARGO = x.COD_CARGO??0,
                    NOMBRE_CARGO_STR = x.NOMBRE_CARGO,
                    EMAIL_USUARIO_CREACION = x.EMAIL_USUARIO_CREACION,
                    USUARIO_CREACION = x.USUARIO_CREACION,
                    NOMBRE_TIPO_REQUISICION = x.NOMBRE_REQUISICION,
                    NOMBRE_ESTADO_REQUISICION = "Verificada BP",// esto falta
                    FECHA_CREACION = x.FECHA_CREACION.Value.ToLongDateString(),
                    COD_TIPO_REQUISICION =x.COD_TIPO_REQUISICION??0
                }).ToList();
            }

            return lst;
        }
            public Boolean INSERTAR_REQUISICION(REQUISICIONViewModel _modelo,string usuario)
        {

            try{
                using (var db = new GESTION_HUMANA_HITSSEntities2()) {

                    db.INSERTAR_REQUISICION(
                         _modelo.COD_TIPO_NECESIDAD,
                         _modelo.COD_TIPO_REQUISICION,
                         _modelo.COD_CARGO,
                         _modelo.NOMBRE_CARGO_STR,
                         _modelo.ORDEN,
                         _modelo.COD_CECO,
                         _modelo.NOMBRE_CECO_STR,
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
                         _modelo.CATEGORIA_ED_NOMBRE,
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
                          1, // _modelo.HORARIO_LABORAL_DESDE EN BASE DE DATOS ES ENTERO
                          2, // _modelo.HORARIO_LABORAL_HASTA EN BASE DE DATOS ES ENTERO
                          _modelo.COD_DIA_LABORAL_DESDE,
                         _modelo.COD_DIA_LABORAL_HASTA,
                         1,  //PORCENTAJE_SOBREREMUNERACION es entero 
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
                   );
                }
                return true;
            }
            catch (SqlException ex) {
                var error = ex;
                return false;
            }

            
        }
    }
}
