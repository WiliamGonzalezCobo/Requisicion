using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOGICA.REQUISICION_LOGICA;
using MODELO_DATOS.MODELO_REQUISICION;

namespace G_H_WEB.Controllers
{
    [Authorize]
    public class REQUISICION_PRESUPUESTADAController : Controller
    {
        // GET: REQUISICION_PRESUPUESTADA
        public ActionResult Index(int? _idReq)
        {
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            try
            {
                if (_idReq.HasValue)
                {
                    model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value);
                }
                model = CargarCombos(model);

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(REQUISICIONViewModel model, string submitButton)
        {
            try
            {
                switch (submitButton)
                {
                    case "Crear Requisición":
                        Crear(model);
                        break;
                    case "Aprobar":
                        Aprobar(model);
                        break;
                    case "Rechazar":
                        Rechazar(model);
                        break;
                    case "Enviar":
                        Enviar(model);
                        break;
                    case "Modificar":
                        Modificar(model);
                        break;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void Crear(REQUISICIONViewModel model)
        {
        }
        public void Aprobar(REQUISICIONViewModel model)
        {
        }
        public void Rechazar(REQUISICIONViewModel model)
        {
        }
        public void Enviar(REQUISICIONViewModel model)
        {
        }
        public void Modificar(REQUISICIONViewModel model)
        {
        }

        private REQUISICIONViewModel CargarCombos(REQUISICIONViewModel model)
        {
            model.LIST_NOMBRE_CECO = new LOGICA_REQUISICION().CONSULTAR_CECOS();
            model.LIST_NOMBRE_TIPO_NECESIDAD = new LOGICA_REQUISICION().CONSULTAR_TIPOS_NECESIDAD();
            model.LIST_NOMBRE_CARGO = new LOGICA_REQUISICION().CONSULTAR_CARGOS();
            model.LIST_NOMBRE_GERENCIA = new LOGICA_REQUISICION().CONSULTAR_GERENCIAS();
            model.LIST_NOMBRE_TIPO_CONTRATO = new LOGICA_REQUISICION().CONSULTAR_CONTRATOS();
            model.LIST_NOMBRE_SOCIEDAD = new LOGICA_REQUISICION().CONSULTAR_SOCIEDADES();
            model.LIST_NOMBRE_EQIPO_VENTAS = new LOGICA_REQUISICION().CONSULTAR_EQUIPOS_VENTAS();
            model.LIST_NOMBRE_CIUDAD_TRABAJO = new LOGICA_REQUISICION().CONSULTAR_CIUDADES_TRABAJO();
            model.LIST_NOMBRE_UBICACION_FISICA = new LOGICA_REQUISICION().CONSULTAR_UBICACIONES_FISICAS();
            model.LIST_NIVEL_RIESGO_ARL = new LOGICA_REQUISICION().CONSULTAR_RIESGOS_ARL();
            model.LIST_NOMBRE_CATEGORIA_ED = new LOGICA_REQUISICION().CONSULTAR_CATEGORIAS_ED();
            model.LIST_NOMBRE_JORNADA_LABORAL = new LOGICA_REQUISICION().CONSULTAR_JORNADAS_LABORALES();
            model.LIST_NOMBRE_TIPO_SALARIO = new LOGICA_REQUISICION().CONSULTAR_TIPOS_SALARIOS();
            model.LIST_NOMBRE_CATEGORIA = new LOGICA_REQUISICION().CONSULTAR_CATEGORIAS();
            model.LIST_DIA_LABORAL_DESDE = new LOGICA_REQUISICION().CONSULTAR_DIAS_LABORALES();
            model.LIST_DIA_LABORAL_HASTA = new LOGICA_REQUISICION().CONSULTAR_DIAS_LABORALES();
            return model;
        }



    }
}