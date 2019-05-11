using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION.ACCESS;
using REPOSITORIOS.REQUISICION_ENTITY;

namespace LOGICA.REQUISICION_LOGICA
{
    public class LOGICA_REQUISICION
    {


        public List<SelectListItem> CONSULTAR_TIPOS_NECESIDAD(){
            return  new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x=> new SelectListItem() {
                Text= x.NOMBRE_NECESIDAD,
                Value=x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_ESTADOS() {
            return new ACCES_REQUISICION().CONSULTAR_ESTADOS_ACCESS().Select(x=> new SelectListItem() {
                Text = x.NOMBRE_ESTADO,
                Value = x.COD_ESTADO_REQUISICION.ToString()
            }).ToList();
        }


        public List<SelectListItem> CONSULTAR_TIPOS_REQUISICION()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_REQUISICION_ACCESS().Select(x => new SelectListItem(){
                Text = x.NOMBRE_REQUISICION,
                Value = x.COD_TIPO_REQUISICION.ToString()
            }).ToList();
        }
    }
}
