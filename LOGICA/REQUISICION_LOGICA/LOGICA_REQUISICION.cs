using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MODELO_DATOS.MODELO_REQUISICION;
using REPOSITORIOS.REQUISICION.ACCESS;

namespace LOGICA.REQUISICION_LOGICA
{
    public class LOGICA_REQUISICION
    {

        private REQUISICIONViewModel objReqModel = null;

        public List<SelectListItem> CONSULTAR_TIPOS_NECESIDAD()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_ESTADOS()
        {
            return new ACCES_REQUISICION().CONSULTAR_ESTADOS_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_ESTADO,
                Value = x.COD_ESTADO_REQUISICION.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_CECOS()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_EQUIPOS_VENTAS()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_RIESGOS_ARL()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_CATEGORIAS_ED()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_SOCIEDADES()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_CONTRATOS()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_GERENCIAS()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_UBICACIONES_FISICAS()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_JORNADAS_LABORALES() {
            List<SelectListItem> jornadas = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Tiempo Parcial", Value="1"},
                new SelectListItem() { Text="Tiempo Completo", Value="2"},
                new SelectListItem() { Text="Medio Tiempo", Value="3"}
            };
            return jornadas;
        }

        public List<SelectListItem> CONSULTAR_DIAS_LABORALES()
        {
            List<SelectListItem> DIAS = new List<SelectListItem>()
            {
                new SelectListItem() {Text="1", Value="1"},
                new SelectListItem() { Text="2", Value="2"},
                new SelectListItem() { Text="3", Value="3"}
            };
            return DIAS;
        }

        public List<SelectListItem> CONSULTAR_CIUDADES_TRABAJO()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_CATEGORIAS()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_TIPOS_SALARIOS()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_CARGOS()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_NECESIDAD_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_NECESIDAD,
                Value = x.COD_TIPO_NECESIDAD.ToString()
            }).ToList();
        }

        public List<SelectListItem> CONSULTAR_TIPOS_REQUISICION()
        {
            return new ACCES_REQUISICION().CONSULTAR_TIPOS_REQUISICION_ACCESS().Select(x => new SelectListItem()
            {
                Text = x.NOMBRE_REQUISICION,
                Value = x.COD_TIPO_REQUISICION.ToString()
            }).ToList();
        }

        public List<REQUISICIONViewModel> SOLICITAR_REQUISICIONES(FILTROREQUISICION _filtro)
        {
            string filtroDb = _filtro.filtro.ToLower() == "Activos" ? "" : _filtro.filtro;
            List<REQUISICIONViewModel> modelo = new List<REQUISICIONViewModel>();
            for (int i = 0; i < 2; i++)
            {
                REQUISICIONViewModel item = new REQUISICIONViewModel();
                item.COD_REQUISICION = i;
                item.COD_CARGO = 20738780;
                item.NOMBRE_CARGO = "Ingeniero Desarrollo";
                item.EMAIL_USUARIO_CREACION = "martinezluir@globalhitss.com";
                item.USUARIO_CREACION = "Luis David Martinez Rojas" + i;
                item.NOMBRE_TIPO_REQUISICION = "Presupuestada";
                item.NOMBRE_ESTADO_REQUISICION = "Registrada";
                item.FECHA_CREACION = DateTime.Now.AddDays(-i).ToShortDateString();
                item.COD_TIPO_REQUISICION = 2;

                modelo.Add(item);
            }
            modelo.Add(new REQUISICIONViewModel()
            {
                COD_REQUISICION = 3,
                COD_CARGO = 758913,
                NOMBRE_CARGO = "Ingeniero Desarrollo",
                EMAIL_USUARIO_CREACION = "martinezluir@globalhitss.com",
                USUARIO_CREACION = "Luis David Martinez Rojas 3",
                NOMBRE_TIPO_REQUISICION = "No Presupuestada",
                NOMBRE_ESTADO_REQUISICION = "Verificada BP",
                FECHA_CREACION = DateTime.Now.ToShortDateString(),
                COD_TIPO_REQUISICION = 2
            });
            modelo.Add(new REQUISICIONViewModel()
            {
                COD_REQUISICION = 123456789,
                COD_CARGO = 758913,
                NOMBRE_CARGO = "Ingeniero Desarrollo",
                EMAIL_USUARIO_CREACION = "martinezluir@globalhitss.com",
                USUARIO_CREACION = "Luis David Martinez Rojas",
                NOMBRE_TIPO_REQUISICION = "No Presupuestada",
                NOMBRE_ESTADO_REQUISICION = "Verificada BP",
                FECHA_CREACION = DateTime.Now.ToShortDateString(),
                COD_TIPO_REQUISICION = 2
            });
            modelo.Add(new REQUISICIONViewModel()
            {
                COD_REQUISICION = 4,
                COD_CARGO = 758913,
                NOMBRE_CARGO = "Ingeniero Desarrollo",
                NOMBRE_TIPO_REQUISICION = "No Presupuestada",
                NOMBRE_ESTADO_REQUISICION = "Verificada BP",
                FECHA_CREACION = DateTime.Now.ToShortDateString(),
                EMAIL_USUARIO_CREACION = "williamFabian@globalhitss.com",
                USUARIO_CREACION = "Luis David Martinez Rojas",
                COD_TIPO_REQUISICION = 1
            });


            return modelo;
        }

        public REQUISICIONViewModel BUSCAR_REQUISICIONES(int idRequsicion)
        {
            try
            {
                objReqModel = new ACCES_REQUISICION().CONSULTAR_REQUISICION_X_ID(idRequsicion);
            }
            catch (Exception ex)
            {
                COD_TIPO_NECESIDAD = 2,
                COD_CARGO =1,
                ORDEN = "orden2",
                COD_CECO = 456,
                COD_REQUISICION = 123456789,
                COD_TIPO_REQUISICION = 2
            });

            listReq.Add(new REQUISICIONViewModel()
            {
                COD_TIPO_NECESIDAD = 2,
                COD_CARGO = 1,
                ORDEN = "orden2",
                COD_CECO = 456,
                COD_REQUISICION = 3,
                COD_TIPO_REQUISICION = 2
            });


            return listReq.Find(x => x.COD_REQUISICION.Equals(idRequsicion));
        }

        public Boolean INSERTAR_REQUISICION_LOGICA(REQUISICIONViewModel _modelo, string usuario) {
            return new ACCES_REQUISICION().INSERTAR_REQUISICION(_modelo, usuario);
        }
     }
}
