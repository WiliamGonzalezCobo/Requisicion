using LOGICA.INTERFAZREQUISICION;
using MODELO_DATOS.MODELO_REQUISICION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPOSITORIOS;
using System.Web.Mvc;
using REPOSITORIOS.REQUISICION_ENTITY;

namespace LOGICA.REQUISICION_LOGICA
{
    public class REQUISICION_REP : IREQUISICION
    {
        public List<REQUISICIONViewModel> ConsultarTodos()
        {
            // para ver
            List<REQUISICIONViewModel> lst = new List<REQUISICIONViewModel>();

            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                var consulta = db.CONSULTAR_REQUISICIONES_JEFE();
                foreach (var item in consulta)
                {
                    REQUISICIONViewModel obj = new REQUISICIONViewModel();
                    SelectListItem listItem = new SelectListItem();
                    obj.COD_CARGO = Convert.ToInt32(item.COD_CARGO);
                    obj.EMAIL_USUARIO_CREACION = item.EMAIL_USUARIO_CREACION;
                    obj.FECHA_CREACION = item.FECHA_CREACION.ToString();
                    listItem.Text = item.NOMBRE_CARGO;
                    listItem.Value = item.COD_CARGO.ToString();
                    obj.NOMBRE_CARGO = new List<SelectListItem>();
                    obj.NOMBRE_CARGO.Add(listItem);
                    obj.NOMBRE_ESTADO_REQUISICION = item.NOMBRE_ESTADO;
                    obj.NOMBRE_TIPO_REQUISICION = item.NOMBRE_REQUISICION;
                    obj.USUARIO_CREACION = item.USUARIO_CREACION;
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public void Crear(REQUISICIONViewModel model)
        {
            using (var db = new GESTION_HUMANA_HITSSEntities2())
            {
                //db.insertar_requisicion();
            }
        }
    }
}
