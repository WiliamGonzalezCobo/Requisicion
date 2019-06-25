﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G_H_WEB.Logica_Session;
using G_H_WEB.Models;
using log4net;
using LOGICA.REQUISICION_LOGICA;
using Microsoft.AspNet.Identity;
using MODELO_DATOS.MODELO_REQUISICION;
using MODELO_DATOS.MODELO_REQUISICION.LISTAS_API;
using REPOSITORIOS.TRAZA_LOG;
using UTILS.Settings;

namespace G_H_WEB.Controllers
{
    [CustAuthFilter]
    public class REQUISICION_PRESUPUESTADAController : Controller
    {
        private LOG_CENTRALIZADO logCentralizado = new LOG_CENTRALIZADO(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));

        public ActionResult Consultar(int? _idReq, int? _idTipo, string link_controler = "", string COD_ASPNETUSER_CONTROLLER = "")
        {
            if (TempData["ErrorPost"] != null)
            {
                ViewBag.Error = (ERROR_GENERAL_ViewModel)TempData["ErrorPost"];
            }




            if (COD_ASPNETUSER_CONTROLLER != "") { Session["COD_ASPNETUSER_CONTROLLER"] = COD_ASPNETUSER_CONTROLLER; }
            REQUISICIONViewModel model = new REQUISICIONViewModel();
            try
            {
                logCentralizado.INICIANDO_LOG("CTR_REQ_PRE1", "Consultar");
                if (_idReq.HasValue)
                {
                    string _USER = User.Identity.GetUserId() ?? Session["COD_ASPNETUSER_CONTROLLER"].ToString();
                    model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_idReq.Value, link_controler, _USER);
                    if (model == null)
                    {
                        ViewBag.ReqModificada = false;
                        Session.Remove("COD_ASPNETUSER_CONTROLLER");
                        return RedirectToAction("ConsultarRequisiciones", "REQUISICION");
                    }
                    else
                    {
                        ViewBag.ReqModificada = true;
                    }
                    if (User.IsInRole(SettingsManager.PerfilBp) && (!model.COD_ESTADO_REQUISICION.Equals(SettingsManager.EstadoDevueltaRRHH) && !model.COD_ESTADO_REQUISICION.Equals(SettingsManager.EstadoDevueltaUSC))) {
                        model = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES_BP(model) ?? new REQUISICIONViewModel();
                    }
                }
                else
                {
                    ViewBag.ReqModificada = false;
                }

                if (_idReq != null)
                {
                    List<TRAZA_BOTONES_VISIBLES> _listaCampos = new LOGICA_REQUISICION().CONSULTAR_CAMPOS_TRAZAS_VISIBLES(_idReq.Value);
                    ViewBag.traza = _listaCampos;
                    ViewBag.ReqModificada = true;
                }
                else
                {
                    ViewBag.ReqModificada = false;
                }

                model = new LOGICA_REQUISICION().LLENAR_CONTROLES(model);

                // Esto es para el POP UP
                List<SelectListItem> listacargos = model.LIST_NOMBRE_CARGO;
                RESPUESTA_POP_UP fromPost = TempData["resultado"] as RESPUESTA_POP_UP;
                // este filtro se debe hacer sobre la lista NOMBRE_CARGO y no sobre necesidad 
                if (fromPost != null && fromPost.RESULTADO == true && fromPost.COD_CARGO != 0)
                    fromPost.NOMBRE_COD_CARGO = listacargos.Where(x => x.Value == fromPost.COD_CARGO.ToString()).First().Text;
                //Logica para el POP UP
                ViewBag.resultadoInsertExitosoOno = fromPost != null ? !fromPost.RESULTADO.Equals(0) : false;
                ViewBag.resultadoPopUpNoJefe = fromPost;
                ViewBag.Busca_USUARIOS = new LOGICA_REQUISICION().CONSULTAR_EMPLEADOS();
                logCentralizado.FINALIZANDO_LOG("CTR_REQ_PRE1", "Consultar");
                ViewBag.PERMISOS_CONTROLLER = link_controler;

                if (TempData["listadoErroresModelo"] != null)
                {
                    model.LIST_VALIDACION_ERRORES = (List<VALIDACION_ERRORES_ViewModel>)TempData["listadoErroresModelo"];
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTR_REQ_PRE1", "Consultar", ex),
                    DETALLE = "error al cargar requisicion presupuestada"
                };
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Procesar(REQUISICIONViewModel modelDatos, string submitButton, int? _idTipo)
        {
            try
            {
                VALIDACION_MODEL_REQUISICION valModelReq = new VALIDACION_MODEL_REQUISICION(
                    User.IsInRole(SettingsManager.PerfilJefe),
                    User.IsInRole(SettingsManager.PerfilController),
                    User.IsInRole(SettingsManager.PerfilBp),
                    User.IsInRole(SettingsManager.PerfilRRHH),
                    User.IsInRole(SettingsManager.PerfilUSC)
                    );

                logCentralizado.INICIANDO_LOG("CTR_REQ_PRE2", "Procesar");
                string _User = "";
                int _resultadoIdReguisicion = 0;
                modelDatos.COD_TIPO_REQUISICION = SettingsManager.CodTipoReqPresupuestada;

                modelDatos.USUARIO_CREACION = User.Identity.Name;
                modelDatos.USUARIO_MODIFICACION = User.Identity.Name;
                REQUISICIONViewModel listas = new REQUISICIONViewModel();
                // llena los combos
                modelDatos = new LOGICA_REQUISICION().LLENAR_CONTROLES(modelDatos);
                // saca los valores de los combos
                modelDatos = new LOGICA_REQUISICION().CONSULTAR_VALORES_LISTAS_POR_CODIGO(modelDatos);

                //INICIO Esta logica es para el POP UP----------
                RESPUESTA_POP_UP npc = new RESPUESTA_POP_UP();
                // FIN

                //Valida si los datos del modelo son validos para almacenar en la base de datos
                modelDatos.LIST_VALIDACION_ERRORES = valModelReq.ValidarModelo(modelDatos, modelDatos.COD_TIPO_REQUISICION, submitButton);
                if (modelDatos.LIST_VALIDACION_ERRORES.Count <= 0)
                {
                    switch (submitButton)
                    {
                        case "CREAR REQUISICIÓN":
                            _resultadoIdReguisicion = new LOGICA_REQUISICION().INSERTAR_REQUISICION(modelDatos, User.Identity.GetUserId());
                            if (modelDatos.COD_REQUISICION == 0)
                                npc.METODO = "Crear";
                            else
                                npc.METODO = "Modificar";

                            break;
                        case "APROBAR REQUISICIÓN":

                            if (User.IsInRole(SettingsManager.PerfilRRHH) || User.IsInRole(SettingsManager.PerfilUSC))
                            {
                                Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZAR_REQUISICION(modelDatos));
                                _resultadoIdReguisicion = modelDatos.COD_REQUISICION;
                            }
                            else
                            {
                                _User = User.Identity.GetUserId() ?? Session["COD_ASPNETUSER_CONTROLLER"].ToString();
                                _resultadoIdReguisicion = new LOGICA_REQUISICION().APROBAR_REQUISICION_LOGICA(modelDatos.COD_REQUISICION, _User, modelDatos.OBSERVACION);
                            }

                            npc.METODO = "Aprobar";
                            break;
                        case "ENVIAR RESPUESTA":
                            modelDatos.OBSERVACION = string.Format("Motivo Rechazo: {0}", modelDatos.OBSERVACION);
                            _resultadoIdReguisicion = new LOGICA_REQUISICION().REQUISICION_RECHAZAR_LOGICA(modelDatos.COD_REQUISICION, modelDatos.OBSERVACION, User.Identity.Name);
                            npc.METODO = "Rechazar";
                            break;
                        case "Enviar Requisición":
                            Cambios_campos(modelDatos, modelDatos.COD_REQUISICION);
                            Convert.ToInt32(new LOGICA_REQUISICION().ACTUALIZAR_REQUISICION(modelDatos));
                            _resultadoIdReguisicion = modelDatos.COD_REQUISICION;

                            npc.METODO = "Enviar";
                            break;
                        case "DEVOLVER REQUISICIÓN":
                            _User = User.Identity.GetUserId() ?? Session["COD_ASPNETUSER_CONTROLLER"].ToString();
                            _resultadoIdReguisicion = Convert.ToInt32(new LOGICA_REQUISICION().REQUISICION_MODIFICAR_LOGICA(modelDatos.COD_REQUISICION, modelDatos.OBSERVACION, _User));
                            npc.METODO = "Modificar";

                            break;
                    }
                }
                else
                {
                    TempData["listadoErroresModelo"] = modelDatos.LIST_VALIDACION_ERRORES;
                }

                //INICIO Esta logica es para el POP UP----------
                npc.COD_REQUISICION_CREADA = _resultadoIdReguisicion;
                npc.COD_CARGO = modelDatos.COD_CARGO;
                npc.RESULTADO = !_resultadoIdReguisicion.Equals(0);
                TempData["resultado"] = npc;


                //FIN Esta logica es para el POP UP----------
                logCentralizado.FINALIZANDO_LOG("CTR_REQ_PRE2", "Procesar");
                if (Session["COD_ASPNETUSER_CONTROLLER"] != null)
                {
                    Session.Remove("COD_ASPNETUSER_CONTROLLER");
                    return RedirectToAction("Consultar", "REQUISICION_PRESUPUESTADA", new { link_controler = "mostrar resultado" });
                }
                return RedirectToAction("Consultar");
            }
            catch (Exception ex)
            {
                TempData["ErrorPost"] = new ERROR_GENERAL_ViewModel()
                {
                    COD_ERROR = logCentralizado.CAPTURA_EXCEPCION("CTR_REQ_PRE2", "Procesar", ex),
                    DETALLE = "error al procesar la requisicion"
                };
                return RedirectToAction("Consultar");
            }
        }

        private void Cambios_campos(REQUISICIONViewModel aGuardar, int _cod_requisicion)
        {


            try
            {
                logCentralizado.INICIANDO_LOG("CTR_REQ_PRE3", "Cambios_campos");
                Boolean _cambio = false;
                TRAZA_BOTONES_VISIBLES traza = new TRAZA_BOTONES_VISIBLES();
                List<TRAZA_BOTONES_VISIBLES> trazas = new List<TRAZA_BOTONES_VISIBLES>();
                REQUISICIONViewModel datosCargo = new REQUISICIONViewModel();
                string _USER = User.Identity.GetUserId() ?? Session["COD_ASPNETUSER_CONTROLLER"].ToString();
                datosCargo = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES(_cod_requisicion, "", _USER) ?? new REQUISICIONViewModel();
                datosCargo = new LOGICA_REQUISICION().BUSCAR_REQUISICIONES_BP(datosCargo) ?? new REQUISICIONViewModel();

                if (datosCargo.NOMBRE_CATEGORIA_ED != aGuardar.NOMBRE_CATEGORIA_ED)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "NOMBRE_CATEGORIA_ED";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.SALARIO_FIJO != aGuardar.SALARIO_FIJO)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "SALARIO_FIJO";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.PORCENTAJE_SALARIO_FIJO != aGuardar.PORCENTAJE_SALARIO_FIJO)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "PORCENTAJE_SALARIO_FIJO";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.SALARIO_VARIABLE != aGuardar.SALARIO_VARIABLE)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "SALARIO_VARIABLE";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.PORCENTAJE_SALARIO_VARIABLE != aGuardar.PORCENTAJE_SALARIO_VARIABLE)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "PORCENTAJE_SALARIO_VARIABLE";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.SOBREREMUNERACION != aGuardar.SOBREREMUNERACION)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "SOBREREMUNERACION";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.EXTRA_FIJA != aGuardar.EXTRA_FIJA)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "EXTRA_FIJA";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.RECARGO_NOCTURNO != aGuardar.RECARGO_NOCTURNO)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "RECARGO_NOCTURNO";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.MEDIO_TRANSPORTE != aGuardar.MEDIO_TRANSPORTE)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "MEDIO_TRANSPORTE";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.SALARIO_TOTAL != aGuardar.SALARIO_TOTAL)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "SALARIO_TOTAL";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.BONO_ANUAL != aGuardar.BONO_ANUAL)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "BONO_ANUAL";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }
                if (datosCargo.NUMERO_SALARIOS != aGuardar.NUMERO_SALARIOS)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "NUMERO_SALARIO";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                //if (datosCargo.COD_NIVEL_RIESGO_ARL != aGuardar.COD_NIVEL_RIESGO_ARL)
                //{
                //    traza = new TRAZA_BOTONES_VISIBLES();
                //    traza.COD_REQUISICION = _cod_requisicion;
                //    traza.CAMPOS = "COD_NIVEL_RIESGO";
                //    traza.TRAZA = "true";
                //    _cambio = true;
                //    trazas.Add(traza);
                //}

                if (datosCargo.HORARIO_LABORAL_DESDE != aGuardar.HORARIO_LABORAL_DESDE)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "HORARIO_LABORAL_DESDE";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.HORARIO_LABORAL_HASTA != aGuardar.HORARIO_LABORAL_HASTA)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "HORARIO_LABORAL_HASTA";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.DIA_LABORAL_DESDE != aGuardar.DIA_LABORAL_DESDE)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "DIA_LABORAL_DESDE";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }


                if (datosCargo.DIA_LABORAL_HASTA != aGuardar.DIA_LABORAL_HASTA)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "DIA_LABORAL_HASTA";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.PORCENTAJE_SOBREREMUNERACION != aGuardar.PORCENTAJE_SOBREREMUNERACION)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "PORCENTAJE_SOBREREMUNERACION";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.MESES_GARANTIZADOS != aGuardar.MESES_GARANTIZADOS)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "MESES_GARANTIZADOS";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.FACTOR_PRESTACIONAL != aGuardar.FACTOR_PRESTACIONAL)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "FACTOR_PRESTACIONAL";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.COD_TIPO_SALARIO != aGuardar.COD_TIPO_SALARIO)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "COD_TIPO_SALARIO";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }



                if (datosCargo.NOMBRE_TIPO_SALARIO != aGuardar.NOMBRE_TIPO_SALARIO && datosCargo.NOMBRE_TIPO_SALARIO != null)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "NOMBRE_TIPO_SALARIO";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.INGRESO_PROM_MENSUAL != aGuardar.INGRESO_PROM_MENSUAL)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "INGRESO_PROM_MENSUAL";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.INGRESO_PROM_ANUAL != aGuardar.INGRESO_PROM_ANUAL)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "INGRESO_PROM_ANUAL";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.MERCADO != aGuardar.MERCADO)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "MERCADO";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                if (datosCargo.NOMBRE_CATEGORIA != aGuardar.NOMBRE_CATEGORIA)
                {
                    traza = new TRAZA_BOTONES_VISIBLES();
                    traza.COD_REQUISICION = _cod_requisicion;
                    traza.CAMPOS = "CATRGORIA";
                    traza.TRAZA = "true";
                    _cambio = true;
                    trazas.Add(traza);
                }

                //if (datosCargo.NIVEL_RIESGO_ARL != aGuardar.NIVEL_RIESGO_ARL)
                //{
                //    traza = new TRAZA_BOTONES_VISIBLES();
                //    traza.COD_REQUISICION = _cod_requisicion;
                //    traza.CAMPOS = "NOMBRE_ARL";
                //    traza.TRAZA = "true";
                //    _cambio = true;
                //    trazas.Add(traza);
                //}

                if (_cambio == true)
                {
                    new LOGICA_REQUISICION().INSERTAR_CAMPOS_TRAZAS_VISIBLES(trazas);
                }
                logCentralizado.FINALIZANDO_LOG("CTR_REQ_PRE3", "Cambios_campos");
            }
            catch (Exception ex)
            {
                logCentralizado.CAPTURA_EXCEPCION("CTR_REQ_PRE3", "Cambios_campos", ex);
                throw ex;
            }
        }
    }
}