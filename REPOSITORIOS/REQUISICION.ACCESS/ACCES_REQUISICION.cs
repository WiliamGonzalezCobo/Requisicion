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
    }
}
