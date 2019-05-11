using LOGICA.INTERFAZREQUISICION;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION_ENTITY;
using System.Collections.Generic;

namespace LOGICA.REQUISICION_LOGICA
{
    public class REQUISICIONTIPO : IREQUISICIONTIPO
    {
        public List<TIPO_NECESIDADViewModel> ConsultarTodos()
        {

            List<TIPO_NECESIDADViewModel> lst = new List<TIPO_NECESIDADViewModel>();

            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                var consulta = db.CONSULTAR_TIPOS_NECESIDAD();
                foreach (var item in consulta)
                {
                    TIPO_NECESIDADViewModel obj = new TIPO_NECESIDADViewModel();
                    obj.COD_TIPO_NECESIDAD = item.COD_TIPO_NECESIDAD;
                    obj.NOMBRE_NECESIDAD = item.NOMBRE_NECESIDAD;
                    lst.Add(obj);
                }
            }
            return lst;

        }

        private TIPO_NECESIDADViewModel MapApp(REQUISICION_TIPO_NECESIDAD tbl)
        {

            return new TIPO_NECESIDADViewModel()
            {
                COD_TIPO_NECESIDAD = tbl.COD_TIPO_NECESIDAD,
                NOMBRE_NECESIDAD = tbl.NOMBRE_NECESIDAD
            };

        }
    }
}
