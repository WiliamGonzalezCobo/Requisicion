using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using G_H_WEB.Models;
using LOGICA;
using Microsoft.AspNet.Identity.Owin;
using MODELO_DATOS.MODELOS_SEGURIDAD;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using log4net;
using REPOSITORIOS.TRAZA_LOG;
using System.Threading;
//using REPOSITORIOS.TRAZA_LOG;

namespace G_H_WEB.Controllers
{
    [Authorize]
    public class RETIROController : Controller
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ERROR_ViewModel ERROR_GENERADO = new ERROR_ViewModel();
        //public ActionResult CONSULTAR(string CONSULTA)
        public ActionResult CONSULTAR(RETIRO_CONSULTA_ViewModel MODELO)
        {
            //RETIRO_CONSULTA_ViewModel MODELO = new RETIRO_CONSULTA_ViewModel();
            string CONSULTA = MODELO.BUSCAR_CONSULTA;
            try
            {
                string INFO = ("Iniciando Método  CONSULTAR");
                log.Info("CODIGO : CTRRE1," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE1", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();

                //string ROL = "";

                //if (User.IsInRole("Jefe"))
                //{
                //    ROL = "Jefe";
                //}

                //if (User.IsInRole("BP"))
                //{
                //    ROL = "BP";
                //}

                //if (User.IsInRole("Proveedor"))
                //{
                //    ROL = "Proveedor";
                //}


                //RETIRO LOGICA_RETIRO = new RETIRO();
                //IEnumerable<RETIRO_ViewModel> RETIROS = LOGICA_RETIRO.CONSULTAR(ROL, CONSULTA, User.Identity.Name).Select(
                //    R => new RETIRO_ViewModel
                //    {
                //        COD_RETIRO = R.COD_RETIRO,
                //        NOMBRE = R.NOMBRE,
                //        CAUSAL = R.NOMBRE_CAUSA_RETIRO,
                //        ESTADO = R.ESTADOS.NOMBRE,
                //        FECHA_SOLICITUD = R.FECHA_CREA.ToString(),
                //        USUARIO = R.USUARIO
                //    });

                //MODELO.BuscarConsulta = CONSULTA;
                //MODELO.RETIROS = RETIROS;
                //bool jefe_var = User.IsInRole("Jefe");

                //log.Info("Finalizado con éxito Método CONSULTAR");

                //return View(MODELO);


                MODELO = CONSULTAR_RETIRO(CONSULTA);
                return View(MODELO);


            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE1,  Método CONSULTAR,  {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
                MODELO.ERROR = ERROR_GENERADO;
                return View(MODELO);


            }
        }


        public RETIRO_CONSULTA_ViewModel CONSULTAR_RETIRO(string CONSULTA)
        {
            RETIRO_CONSULTA_ViewModel MODELO = new RETIRO_CONSULTA_ViewModel();
            try
            {
                string INFO = ("Iniciando Método  CONSULTAR_RETIRO");
                log.Info("CODIGO : CTRRE17," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE17", log.Logger.Name, "CONSULTAR_RETIRO", INFO));
                HILO.Start();
                ROL_USUARIO ROLE_USUARIO = new ROL_USUARIO(User);
                RETIRO LOGICA_RETIRO = new RETIRO();
                IEnumerable<RETIRO_ViewModel> RETIROS = LOGICA_RETIRO.CONSULTAR(ROLE_USUARIO.OBTENER(), CONSULTA, User.Identity.Name).Select(
                    R => new RETIRO_ViewModel
                    {
                        COD_RETIRO = R.COD_RETIRO,
                        NOMBRE = R.NOMBRE,
                        CAUSAL = R.NOMBRE_CAUSA_RETIRO,
                        ESTADO = R.ESTADOS.NOMBRE,
                        FECHA_SOLICITUD = R.FECHA_CREA.ToString("MM/dd/yy HH:MM"),
                        USUARIO = R.USUARIO
                    });

                MODELO.BUSCAR_CONSULTA = CONSULTA;
                MODELO.RETIROS = RETIROS;
                bool jefe_var = User.IsInRole("Jefe");

                log.Info("Finalizado con éxito Método CONSULTAR_RETIRO");
                return MODELO;
            }

            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE17,  Método CONSULTAR_RETIRO,  {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE17" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }

        }

        public ActionResult CONSULTAR_DETALLE(int COD_RETIRO)
        {
            try
            {
                //en qu8e cob esta
                //RouteData.Values["Controller"];

                string INFO = ("Iniciando Método  CONSULTAR_DETALLE con COD_RETIRO: " + COD_RETIRO);
                log.Info("CODIGO : CTRRE2, " + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE2", log.Logger.Name, "CONSULTAR_DETALLE", INFO));
                HILO.Start();

                return View(CONSULTAR(COD_RETIRO));

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE2,  Método CONSULTAR_DETALLE, {0} ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE2" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                RETIRO_EDITA_ViewModel MODELO = new RETIRO_EDITA_ViewModel();
               
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
             
                MODELO.ERROR = ERROR_GENERADO;
                return View(MODELO);

            }
        }

        public ActionResult APROBAR(int ID)//revisar error  ok
        {
            try
            {
                string INFO = (" Iniciando Método  APROBAR con Id:" + ID);
                log.Info("CODIGO : CTRRE3," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE3", log.Logger.Name, "APROBAR", INFO));
                HILO.Start();

                return View(CONSULTAR(ID));
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE3,  Método APROBAR con ID : {0}, {1} ", ID, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE3" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                RETIRO_EDITA_ViewModel MODELO = new RETIRO_EDITA_ViewModel();

                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };

                MODELO.ERROR = ERROR_GENERADO;
                return View(MODELO);
            }
        }

        [HttpPost]
        public ActionResult APROBAR(RETIRO_EDITA_ViewModel MODELO)//VISTA REGRESA MODELO ERROR
        {
            try
            {
                string INFO = ("Iniciando Método  APROBAR ");
                log.Info("CODIGO : CTRRE4, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE3", log.Logger.Name, "APROBAR", INFO));
                HILO.Start();

                LOGICA.RETIRO LOGICA_RETIRO = new LOGICA.RETIRO();
                bool APROBADO;
                APROBADO = LOGICA_RETIRO.APROBAR(MODELO.COD_RETIRO, User.Identity.Name);

                if (APROBADO) { ViewBag.MENSAJE = "El retiro fue aprobado de forma exitosa"; }

                else
                {
                    ViewBag.MENSAJE = "El retiro NO se puede aprobar porque existen soportes sin aprobacion";
                }

                log.Info("CODIGO : CTRRE4, Finalizado Método  APROBAR ");
                MODELO = CONSULTAR(Convert.ToInt32(MODELO.COD_RETIRO));
                return View("APROBAR", MODELO);

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE4,  Método APROBAR , {0}  ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE4" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();             

                MODELO = CONSULTAR((Convert.ToInt32(MODELO.COD_RETIRO)));
             
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
                MODELO.ERROR = ERROR_GENERADO;
                return View(MODELO);
      



            }
        }

        public ActionResult APROBAR_SOPORTE(int COD_SOPORTE, bool APROBADO, int COD_RETIRO)//revisar error
        {
            try
            {
                string INFO = ("Iniciando Método APROBAR_SOPORTE por COD_SOPORTE : " + COD_SOPORTE);
                log.Info("CODIGO : CTRRE5, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE5", log.Logger.Name, "APROBAR_SOPORTE", INFO));
                HILO.Start();

                LOGICA.SOPORTE LOGICA_SOPORTE = new LOGICA.SOPORTE();
                LOGICA_SOPORTE.APROBAR(COD_SOPORTE, APROBADO, User.Identity.Name, COD_RETIRO);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_SOPORTES_APROBADOS", CONSULTAR(COD_RETIRO).SOPORTES);
                }

                return View();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE5,  Método APROBAR_SOPORTE por COD_SOPORTE : {0}, {1}", COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE5" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
                /*devuelve directamente el error al ajax revisar*/
                return PartialView("_ERRORES", ERROR_GENERADO);
            }

        }

        [Authorize(Roles = "Jefe")]
        public ActionResult CREAR(RETIRO_CREA_ViewModel MODELO)  
        //public ActionResult CREAR(string CONSULTA)
        {
            string CONSULTA = MODELO.BuscarConsulta;
            //RETIRO_CREA_ViewModel MODELO = new RETIRO_CREA_ViewModel();
            try
            {



                ERROR_ViewModel ERROR_GENERADO = new ERROR_ViewModel();
                string INFO = ("Iniciando Método CREAR");
                log.Info("CODIGO : CTRRE6, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE6", log.Logger.Name, "CREAR", INFO));
                HILO.Start();

                if (CONSULTA != null)
                {
                    EMPLEADO LOGICA_EMPLEADO = new EMPLEADO();
                    CAUSA_RETIRO LOGICA_CAUSA_RETIRO = new CAUSA_RETIRO();

                    var EMPLEADOS_LISTADO_SERVICIO = LOGICA_EMPLEADO.CONSULTA_EMPLEADO_VALOR_BUSCADO(CONSULTA);
                    List<EMPLEADO_CONSULTA_ViewModel> EMPLEADO_LISTA = new List<EMPLEADO_CONSULTA_ViewModel>();
                    foreach (LOGICA.MODELO_LOGICA.EMPLEADO_MODELO TIPO in EMPLEADOS_LISTADO_SERVICIO)
                    {
                        EMPLEADO_CONSULTA_ViewModel _EMPLEADO = new EMPLEADO_CONSULTA_ViewModel();
                        EMPLEADO_LISTA.Add(
                                new EMPLEADO_CONSULTA_ViewModel
                                {
                                    COD_CARGO = TIPO.COD_CARGO,
                                    COD_EMPLEADO = TIPO.COD_EMPLEADO,
                                    NUMERO_DOCUMENTO = TIPO.NUMERO_DOCUMENTO,
                                    ESTADO = TIPO.ESTADO,
                                    NOMBRE = TIPO.NOMBRE,
                                    USUARIO = TIPO.USUARIO,
                                    NOMBRE_CARGO = TIPO.NOMBRE_CARGO
                                }
                            );
                    }


                    MODELO.EMPLEADOS = EMPLEADO_LISTA;
                    MODELO.BuscarConsulta = CONSULTA;
                    MODELO.CAUSAS_RETIROS = LOGICA_CAUSA_RETIRO.CONSULTAR().Select(CAUSA => new CAUSA_RETIRO_ViewModel { COD_CAUSA_RETIRO = CAUSA.COD_CAUSA_RETIRO, NOMBRE = CAUSA.NOMBRE });
               
                    log.Info("CODIGO : CTRRE6, Finalizado Método  CREAR ");
                    return View(MODELO);
                    //return View();
                }

                return View();

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE6,  Método CREAR, {0} ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE6" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
                MODELO.ERROR = ERROR_GENERADO;
                return View(MODELO);



            }
        }

        [Authorize(Roles = "Jefe")]
        [HttpPost]
        public ActionResult CREAR(DATOS_CREA_RETIRO_ViewModel RETIRO)
        {
            string INFO = ("Iniciando Método CREAR");
            log.Info("CODIGO : CTRRE7," + INFO);

            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE7", log.Logger.Name, "CREAR", INFO));
            HILO.Start();

            LOGICA.RETIRO LOGICA_RETIRO = new LOGICA.RETIRO();
            MODELO_DATOS.RETIROS RETIRO_RESPUESTA = new MODELO_DATOS.RETIROS();
            DATOS_CREA_RETIRO_ViewModel RETIRO_VISTA = new DATOS_CREA_RETIRO_ViewModel();
            ERROR_ViewModel ERROR_GENERADO = new ERROR_ViewModel();
            try
            {
                if (ModelState.IsValid)
                {
                    RETIRO_RESPUESTA = LOGICA_RETIRO.CREAR(RETIRO.NUMERO_DOCUMENTO, RETIRO.COD_CAUSA_RETIRO, RETIRO.FECHA_RETIRO, RETIRO.COMENTARIOS, User.Identity.Name);

                    ERROR_GENERADO.COD_RETIRO = RETIRO_RESPUESTA.COD_RETIRO;
                    ERROR_GENERADO.COD_ERROR = "";

                    log.Info("CODIGO : CTRRE7, Finalizado Método  CREAR ");
                    return PartialView("_ERRORES", ERROR_GENERADO);
                }
                else
                {
                    log.ErrorFormat("CODIGO : CTRRE7,  Método CREAR ", log.Logger.Name);
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    ERROR_GENERADO.COD_RETIRO = 0;
                    ERROR_GENERADO.COD_ERROR = "";
                    ERROR_GENERADO.CAMPOS_INVALIDOS = allErrors;
                    return PartialView("_ERRORES", ERROR_GENERADO);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE7,  Método CREAR, {0} ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE7" : ex.HelpLink);
                Thread HILO1 = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO1.Start();

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
                return PartialView("_ERRORES", ERROR_GENERADO);
            }
        }


        [HttpPost]
        public ActionResult EDITA_RETIRO(DATOS_CREA_RETIRO_ViewModel RETIRO)
        {
            ERROR_ViewModel ERROR_GENERADO = new ERROR_ViewModel();
            try
            {
                string INFO = ("Iniciando Método EDITA_RETIRO");
                log.Info("CODIGO : CTRRE8, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE8", log.Logger.Name, "EDITA_RETIRO", INFO));
                HILO.Start();

                RETIRO LOGICA_RETIRO = new RETIRO();
                LOGICA_RETIRO.ACTUALIZAR(RETIRO.COD_RETIRO, RETIRO.FECHA_RETIRO, RETIRO.COD_CAUSA_RETIRO, false
                 , RETIRO.COMENTARIOS, User.Identity.Name, false);

                log.Info("CODIGO : CTRRE8, Finalizado Método  EDITA_RETIRO ");

                return RedirectToAction("CONSULTAR", "RETIRO");

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE8,  Método EDITA_RETIRO, {0} ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE8" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
                /*devuelve directamente el error al ajax revisar*/
                return PartialView("_ERRORES", ERROR_GENERADO);
            }
        }


        public PartialViewResult CONSULTA_TIPO_SOPORTE(decimal _COD_TIPO_SOPORTE)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTA_TIPO_SOPORTE con COD_TIPO_SOPORTE " + _COD_TIPO_SOPORTE);
                log.Info("CODIGO : CTRRE9, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE9", log.Logger.Name, "CONSULTA_TIPO_SOPORTE", INFO));
                HILO.Start();

                TIPO_SOPORTE LOGICA_TIPO_SOPORTE = new TIPO_SOPORTE();
                IEnumerable<MODELO_DATOS.TIPO_SOPORTES> TIPOS_SOPORTES;
                TIPOS_SOPORTES = null;

                TIPOS_SOPORTES = LOGICA_TIPO_SOPORTE.CONSULTAR(_COD_TIPO_SOPORTE);//.
                List<SOPORTES_RETIRO_ViewModel> TIPO_SOPORTE_LISTA = new List<SOPORTES_RETIRO_ViewModel>();

                foreach (MODELO_DATOS.TIPO_SOPORTES TIPO in TIPOS_SOPORTES)
                {
                    SOPORTES_RETIRO_ViewModel SOPORTE = new SOPORTES_RETIRO_ViewModel();

                    if (SOPORTE != null)
                    {
                        TIPO_SOPORTE_LISTA.Add(
                            new SOPORTES_RETIRO_ViewModel
                            {
                                COD_RETIRO = 0,
                                COD_SOPORTE = 0,
                                COD_TIPO_SOPORTE = TIPO.COD_TIPO_SOPORTE,
                                NOMBRE_SOPORTE = "",
                                NOMBRE_TIPO_SOPORTE = TIPO.NOMBRE,
                                REQUERIDO = TIPO.REQUERIDO,
                                TAMANO = ""
                            });
                    }
                    else
                    {
                        return PartialView("_SOPORTES_NUEVO");
                    }
                }
                return PartialView("_SOPORTES_CREADO", TIPO_SOPORTE_LISTA);


            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE9,  Método CONSULTA_TIPO_SOPORTE con COD_TIPO_SOPORTE : {0}, {1}  ", _COD_TIPO_SOPORTE, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE9" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                //ViewBag.MENSAJE_ERROR = ex.HelpLink;
                //return null;

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };

                return PartialView("_ERRORES", ERROR_GENERADO);
            }
        }


        public ActionResult EDITAR(int COD_RETIRO,string NOMBRE_VISTA)
        {
            RETIRO_EDITA_ViewModel MODELO = new RETIRO_EDITA_ViewModel();
            try
            {
                string INFO = ("Iniciando Método EDITAR con COD_RETIRO " + COD_RETIRO);
                log.Info("CODIGO : CTRRE10, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE10", log.Logger.Name, "EDITAR", INFO));
                HILO.Start();

                MODELO = CONSULTAR(COD_RETIRO);
			
                MODELO.NOMBRE_VISTA = NOMBRE_VISTA;

                    return View(MODELO);
            }

            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE10,  Método EDITAR con COD_RETIRO : {0}, {1} ", COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE10" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

              
                MODELO.ESTADO = null;
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };

                MODELO.ERROR = ERROR_GENERADO;
                return View(MODELO);
            }

        }


        private RETIRO_EDITA_ViewModel CONSULTAR(int COD_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR con COD_RETIRO " + COD_RETIRO);
                log.Info("CODIGO : CTRRE11, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE11", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();

                CAUSA_RETIRO LOGICA_CAUSA_RETIRO = new CAUSA_RETIRO();
                RETIRO LOGICA_RETIRO = new RETIRO();

                MODELO_DATOS.RETIROS RETIRO = LOGICA_RETIRO.CONSULTAR(COD_RETIRO);
                RETIRO_EDITA_ViewModel EDITA = new RETIRO_EDITA_ViewModel
                {
                    COD_RETIRO = RETIRO.COD_RETIRO,
                    GENERA_VACANTE = RETIRO.GENERA_VACANTE,
                    NOMBRE = RETIRO.NOMBRE,
                    DOCUMENTO = RETIRO.NUMERO_DOCUMENTO,
                    USUARIO = RETIRO.USUARIO,
                    CARGO = RETIRO.NOMBRE_CARGO,
                    COMENTARIOS = RETIRO.COMENTARIOS,
                    COD_CAUSA_RETIRO = RETIRO.COD_CAUSA_RETIRO,
                    NOMBRE_CAUSA_RETIRO = RETIRO.NOMBRE_CAUSA_RETIRO,
                    FECHA_RETIRO = RETIRO.FECHA_RETIRO.ToShortDateString(),
                    CAUSAS_RETIROS = LOGICA_CAUSA_RETIRO.CONSULTAR().Select(CAUSA => new CAUSA_RETIRO_ViewModel { COD_CAUSA_RETIRO = CAUSA.COD_CAUSA_RETIRO, NOMBRE = CAUSA.NOMBRE }),
                    ESTADO = RETIRO.ESTADOS.NOMBRE

                };

                List<SOPORTES_RETIRO_ViewModel> TEMPORAL = new List<SOPORTES_RETIRO_ViewModel>();

                foreach (var SOPORTE in RETIRO.SOPORTES)
                {
                    TEMPORAL.Add(new SOPORTES_RETIRO_ViewModel
                    {
                        COD_SOPORTE = SOPORTE.COD_SOPORTE,
                        NOMBRE_SOPORTE = SOPORTE.NOMBRE_SOPORTE,
                        COD_TIPO_SOPORTE = SOPORTE.COD_TIPO_SOPORTE,
                        NOMBRE_TIPO_SOPORTE = SOPORTE.TIPO_SOPORTES.NOMBRE,
                        TAMANO = SOPORTE.TAMANO,
                        COD_RETIRO = RETIRO.COD_RETIRO,
                        APROBADO = SOPORTE.APROBADO,
                        REQUERIDO = SOPORTE.REQUERIDO,
                        ESTADO = EDITA.ESTADO,


                    });
                }

                EDITA.SOPORTES = TEMPORAL;

                TIPO_SOPORTE LOGICA_TIPO_SOPORTE = new TIPO_SOPORTE();
                IEnumerable<MODELO_DATOS.TIPO_SOPORTES> TIPOS_SOPORTES;
                TIPOS_SOPORTES = LOGICA_TIPO_SOPORTE.CONSULTAR(RETIRO.COD_CAUSA_RETIRO);

                List<SOPORTES_RETIRO_ViewModel> SOPORTES = new List<SOPORTES_RETIRO_ViewModel>();

                foreach (MODELO_DATOS.TIPO_SOPORTES TIPO in TIPOS_SOPORTES)
                {
                    SOPORTES_RETIRO_ViewModel SOPORTE = new SOPORTES_RETIRO_ViewModel();
                    SOPORTE = EDITA.SOPORTES.Where(S => S.COD_TIPO_SOPORTE == TIPO.COD_TIPO_SOPORTE).SingleOrDefault<SOPORTES_RETIRO_ViewModel>();
                    if (SOPORTE == null)
                    {
                        SOPORTES.Add(
                            new SOPORTES_RETIRO_ViewModel
                            {
                                COD_RETIRO = EDITA.COD_RETIRO,
                                COD_SOPORTE = 0,
                                COD_TIPO_SOPORTE = TIPO.COD_TIPO_SOPORTE,
                                NOMBRE_SOPORTE = "",
                                NOMBRE_TIPO_SOPORTE = TIPO.NOMBRE,
                                TAMANO = "",
                                APROBADO = false,
                                REQUERIDO = TIPO.REQUERIDO,
                                ESTADO = EDITA.ESTADO
                            });
                    }
                    else
                    {
                        SOPORTES.Add(
                            new SOPORTES_RETIRO_ViewModel
                            {
                                COD_RETIRO = SOPORTE.COD_RETIRO,
                                COD_SOPORTE = SOPORTE.COD_SOPORTE,
                                COD_TIPO_SOPORTE = SOPORTE.COD_TIPO_SOPORTE,
                                NOMBRE_SOPORTE = SOPORTE.NOMBRE_SOPORTE,
                                NOMBRE_TIPO_SOPORTE = SOPORTE.NOMBRE_TIPO_SOPORTE,
                                TAMANO = SOPORTE.TAMANO,
                                APROBADO = SOPORTE.APROBADO,
                                REQUERIDO = SOPORTE.REQUERIDO,
                                ESTADO = EDITA.ESTADO
                            });
                    }
                }

                EDITA.SOPORTES = SOPORTES;
                return EDITA;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE11,  Método CONSULTAR con COD_RETIRO : {0}, {1}  ", COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE11" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ;// devuleelve el error en la parte que lo llama
            }
        }


        [HttpPost]
        public ActionResult EDITAR(RETIRO_EDITA_ViewModel MODELO)/*revisar error*/
        {

            try
            {
                //throw new Exception("No negative number please!");
                string INFO = ("Iniciando Método EDITAR ");
                log.Info("CODIGO : CTRRE12, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE12", log.Logger.Name, "EDITAR", INFO));
                HILO.Start();

                if (ModelState.IsValid)
                {
                    CAUSA_RETIRO LOGICA_CAUSA_RETIRO = new CAUSA_RETIRO();
                    RETIRO LOGICA_RETIRO = new RETIRO();
                    bool ESBP = false;
                    if (User.IsInRole("BP"))
                    {
                        ESBP = true;//aqui va la validacion
                    }
                    if (User.IsInRole("BP") && User.IsInRole("Jefe") && MODELO.ESTADO == "Registrado")
                    {
                        ESBP = false;
                    }
                    LOGICA_RETIRO.ACTUALIZAR(MODELO.COD_RETIRO, Convert.ToDateTime(MODELO.FECHA_RETIRO), MODELO.COD_CAUSA_RETIRO, MODELO.GENERA_VACANTE
                        , MODELO.COMENTARIOS, User.Identity.Name, ESBP);

                    return RedirectToAction("CONSULTAR");

                }
                else
                {
                    log.ErrorFormat("CODIGO : CTRRE12,  Método EDITAR ", log.Logger.Name);
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

                    ERROR_GENERADO = new ERROR_ViewModel
                    {
                        COD_ERROR = "CTRRE12",
                        CAMPOS_INVALIDOS = allErrors
                    };
                    MODELO.ERROR = ERROR_GENERADO;
                    return View(MODELO);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE12,  Método EDITAR, {0} ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE12" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                 MODELO = CONSULTAR((Convert.ToInt32(MODELO.COD_RETIRO)));
                MODELO.ESTADO = null;
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };

                MODELO.ERROR = ERROR_GENERADO;
                return View(MODELO);

            }

        }
        [HttpGet]//FileResult
        public ActionResult CONSULTAR_SOPORTE(decimal COD_SOPORTE)/*revisar error*/
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR_SOPORTE con el COD_SOPORTE: " + COD_SOPORTE);
                log.Info("CODIGO : CTRRE13, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE13", log.Logger.Name, "CONSULTAR_SOPORTE", INFO));
                HILO.Start();
                //throw new Exception();
                LOGICA.SOPORTE LOGICA_SOPORTE = new LOGICA.SOPORTE();
                LOGICA.MODELO_LOGICA.SOPORTE_MODELO SOPORTE = LOGICA_SOPORTE.CONSULTA_ARCHIVO(COD_SOPORTE);
                return File(SOPORTE.ARCHIVO, System.Net.Mime.MediaTypeNames.Application.Octet, SOPORTE.NOMBRE);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE13,  Método CONSULTAR_SOPORTE con el COD_SOPORTE : {0}, {1} ", COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE13" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                //RETIRO_EDITA_ViewModel MODELO = new RETIRO_EDITA_ViewModel();
                 ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
                return View("ERROR_ARCHIVO", ERROR_GENERADO);/*mejorear la vista*/
            }
        }

        [HttpPost]
        public ActionResult EDITAR_SOPORTE(int COD_RETIRO, Decimal COD_SOPORTE, int COD_TIPO_SOPORTE, string VISTA, int COD_CAUSA_RETIRO)
        {
            try
            {
               // COD_RETIRO = 352;
                string INFO = ("Iniciando Método EDITAR_SOPORTE con el COD_RETIRO: " + COD_RETIRO);
                log.Info("CODIGO : CTRRE14, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE14", log.Logger.Name, "EDITAR_SOPORTE", INFO));
                HILO.Start();

                foreach (string Archivo in Request.Files)
                {
                    var ArchivoCargado = Request.Files[Archivo];
                    if (ArchivoCargado != null && ArchivoCargado.ContentLength > 0)
                    {
                        SOPORTE LOGICA_SOPORTE = new SOPORTE();
                        String NOMBRE_SOPORTE = Path.GetFileName(ArchivoCargado.FileName);
                        /*recupera cod_causa_retiro que corresponde al retiro */
                        decimal COD_CAUSA_RETIRO_CONSULTA = CONSULTAR(COD_RETIRO).COD_CAUSA_RETIRO;//cambiar metodo

                        /*COMPARA EL COD_CAUSA RETIRO Y SI NO SON IGUALES EJECUTA PROCESO DE ACTUALIZACION AL NUEVO Y ELIMINA LOS SOPORTES */
                        if (COD_CAUSA_RETIRO != COD_CAUSA_RETIRO_CONSULTA)
                        {
                            RETIRO LOGICA_RETIRO = new RETIRO();
                            if (!LOGICA_RETIRO.ACTUALIZAR(COD_RETIRO, COD_CAUSA_RETIRO, User.Identity.Name))
                            {
                                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                ERROR_GENERADO = new ERROR_ViewModel
                                {
                                    COD_ERROR =" CTRRE14",
                                    DETALLE = ""
                                };
                                return PartialView("_ERRORES", ERROR_GENERADO);
                            }
                        }

						
                        if (COD_SOPORTE == 0)
                        {
                            LOGICA_SOPORTE.CREAR(COD_RETIRO, COD_TIPO_SOPORTE, NOMBRE_SOPORTE, User.Identity.Name, ArchivoCargado);
                        }
                        else
                        {
                            LOGICA_SOPORTE.ACTUALIZAR(COD_SOPORTE, NOMBRE_SOPORTE, User.Identity.Name, ArchivoCargado);
                        }

                    }
                }
                if (Request.IsAjaxRequest())
                {
                    return PartialView(VISTA, CONSULTAR(COD_RETIRO).SOPORTES);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE14,  Método EDITAR_SOPORTE con el COD_RETIRO : {0}, {1}  ", COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE14" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
                return PartialView("_ERRORES", ERROR_GENERADO);

                //return View();
            }

            return View();
        }

        public ActionResult RETIRAR_SOPORTE(decimal COD_SOPORTE, decimal COD_RETIRO, string VISTA)
        {
            try
            {
                string INFO = ("Iniciando Método RETIRAR_SOPORTE con el COD_SOPORTE: " + COD_SOPORTE);
                log.Info("CODIGO : CTRRE15, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE15", log.Logger.Name, "RETIRAR_SOPORTE", INFO));
                HILO.Start();

                LOGICA.SOPORTE LOGICA_SOPORTE = new LOGICA.SOPORTE();
                if (LOGICA_SOPORTE.RETIRAR(COD_SOPORTE, User.Identity.Name))
                {

                    return PartialView(VISTA, CONSULTAR(Convert.ToInt32(COD_RETIRO)).SOPORTES);
                    //return RedirectToAction("EDITAR", new { COD_RETIRO = COD_RETIRO });
                }
                else
                {
                    //agregar mensaje de error que indique que no se logro retirar el soporte
                    return PartialView(VISTA, CONSULTAR(Convert.ToInt32(COD_RETIRO)).SOPORTES);
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE15,  Método RETIRAR_SOPORTE con el COD_RETIRO : {0}, {1} ", COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE15" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };

                return PartialView("_ERRORES", ERROR_GENERADO);
            }


        }
        public ActionResult CANCELAR(int COD_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método CANCELAR con el COD_SOPORTE: " + COD_RETIRO);
                log.Info("CODIGO : CTRRE16," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE16", log.Logger.Name, "CANCELAR", INFO));
                HILO.Start();

                LOGICA.RETIRO LOGICA_RETIRO = new LOGICA.RETIRO();
                if (LOGICA_RETIRO.CANCELAR(COD_RETIRO))
                {
                    return RedirectToAction("CONSULTAR", "RETIRO");
                }
                else
                {
                    return RedirectToAction("CONSULTAR", "RETIRO");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRRE16,  Método CANCELAR con el COD_SOPORTE : {0}, {1} ", COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRRE16" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                //throw;

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };

                return PartialView("_ERRORES", ERROR_GENERADO);
            }

            //AGREGAR MANEJO DE EXCEPTIONS Y 
        }

        public ActionResult ERROR_ARCHIVO()
        {
            return View();
        }

    }
}