using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPOSITORIOS;
using MODELO_DATOS;
using LOGICA.MODELO_LOGICA;
using REPOSITORIOS.TRAZA_LOG;
using log4net;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using System.Net.Mail;
using System.Web;
using LOGICA;
using MODELO_DATOS.MODELO_REQUISICION;
using UTILS.Settings;

namespace LOGICA
{
    public class NOTIFICACION
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private LOGICA.CLIENTE_CORREO CORREO = new CLIENTE_CORREO();
        private LOGICA.RETIRO RETIRO_LOGICA = new RETIRO();
        private EMPLEADO EMPLEADO_METODO = new EMPLEADO();


        public bool NOTIFICAR(decimal _COD_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método NOTIFICAR por _COD_RETIRO : " + _COD_RETIRO);
                log.Info("CODIGO : LGNT1," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGNT1", log.Logger.Name, "NOTIFICAR", INFO));
                HILO.Start();



                decimal _COD_CORREO = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CodigoCorreoRemitente"]);
                //  decimal _COD_CORREO = 1;

                MODELO_DATOS.RETIROS RETIRO_DATOS = RETIRO_LOGICA.CONSULTAR(Convert.ToInt32(_COD_RETIRO));
                RETIRO_MODELO RETIRO_LOGIA = new RETIRO_MODELO
                {
                    NOMBRE = RETIRO_DATOS.NOMBRE,
                    NUMERO_DOCUMENTO = RETIRO_DATOS.NUMERO_DOCUMENTO,
                    USUARIO = RETIRO_DATOS.USUARIO,
                    NOMBRE_CARGO = RETIRO_DATOS.NOMBRE_CARGO,
                    COD_CARGO = RETIRO_DATOS.COD_CARGO,
                    NOMBRE_CAUSA_RETIRO = RETIRO_DATOS.NOMBRE_CAUSA_RETIRO,
                    FECHA_RETIRO = RETIRO_DATOS.FECHA_RETIRO,
                    GENERA_VACANTE = RETIRO_DATOS.GENERA_VACANTE


                };


                MODELO_DATOS.CORREOS DATOS_CORREO = CORREO.CONSULTAR(_COD_CORREO);

                /*DESENCRIPTAR*/
                byte[] IV_TEXTO = Convert.FromBase64String(DATOS_CORREO.IV);
                string TEXTO_SALTO = CORREO.DESENCRIPTAR(IV_TEXTO, DATOS_CORREO.CONTRASENA);
                byte[] SALT = Convert.FromBase64String(DATOS_CORREO.SALTO);
                string CONTRASENA_CORREO = CORREO.QUITAR_SALTO(TEXTO_SALTO, SALT.Length);
                /*FIN  DESENCRIPTAR*/

                // decimal _COD_CORREO1 = 1;
                List<MODELO_DATOS.CORREOS_DESTINOS> DESTINO_LISTA_DATOS = CORREO.CONSULTAR_DESTINO(_COD_CORREO).ToList();
                List<CORREOS_DESTINOS_MODELO> DESTINO_LISTA = new List<CORREOS_DESTINOS_MODELO>();

                foreach (MODELO_DATOS.CORREOS_DESTINOS TIPO in DESTINO_LISTA_DATOS)
                {
                    DESTINO_LISTA.Add(
                            new CORREOS_DESTINOS_MODELO
                            {
                                CORREO = TIPO.CORREO,
                                ESTADO = TIPO.ESTADO,
                                COD_COREEO_DESTINO = TIPO.COD_CORREO_DESTINO
                            }
                        );
                }


                List<MODELO_DATOS.PLANTILLAS_CORREOS> PLANTILLA_LISTA_DATOS = CORREO.CONSULTAR_PLANTILLA(_COD_CORREO).ToList();
                List<PLANTILLAS_CORREOS_MODELO> PLANTILLA_LISTA = new List<PLANTILLAS_CORREOS_MODELO>();

                foreach (MODELO_DATOS.PLANTILLAS_CORREOS TIPO in PLANTILLA_LISTA_DATOS)
                {
                    PLANTILLA_LISTA.Add(
                            new PLANTILLAS_CORREOS_MODELO
                            {
                                COD_PLANTILLA = TIPO.COD_PLANTILLA,
                                PLANTILLA = TIPO.PLANTILLA,
                                ESTADO = TIPO.ESTADO
                            }
                        );
                }

                List<EMPLEADO_MODELO> EMPLEADO = EMPLEADO_METODO.CONSULTA_EMPLEADO_VALOR_BUSCADO(RETIRO_DATOS.NUMERO_DOCUMENTO);
                /*captura la informacion necesaria para consumir el metodo de correo AsQueryable().FirstOrDefault()*/
                CORREO_CONFIGURACION_MODELO CORREO_LOGICA = new CORREO_CONFIGURACION_MODELO
                {
                    SERVIDOR = DATOS_CORREO.SERVIDOR_SMTP,
                    CUENTA_CORREO = DATOS_CORREO.CUENTA_CORREO,
                    CONTRASENA = CONTRASENA_CORREO,
                    RETIRO = RETIRO_LOGIA,
                    DESTINOS = DESTINO_LISTA,
                    PLANTILLAS = PLANTILLA_LISTA,
                    PUERTO = DATOS_CORREO.PUERTO,
                    ASUNTO = DATOS_CORREO.ASUNTO,
                    USA_SSL = DATOS_CORREO.USA_SSL,
                    ES_HTML = DATOS_CORREO.ES_HTML,
                    ESTADO = DATOS_CORREO.ESTADO,
                    SOCIEDAD = EMPLEADO.AsQueryable().FirstOrDefault().SOCIEDAD,
                    CENTRO_COSTO = EMPLEADO.AsQueryable().FirstOrDefault().CENTRO_COSTO,
                    NOMBRE_JEFE = EMPLEADO.AsQueryable().FirstOrDefault().NOMBRE_JEFE
                };


                CORREO.ENVIO_CORREO(CORREO_LOGICA);

                return true;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGNT1,  Método NOTIFICAR con el COD_RETIRO : {0}, {1} ", _COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGNT1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                return false;
            }
        }


        public Boolean NOFICICACION_REQUISICIONES(REQUISICIONViewModel _REQUSICION, String _LINK_TRAMITAR, string ID_USUARIO) {
            try
            {
                string INFO = ("Iniciando Método NOTIFICAR por _COD_REQUISICION : " + _REQUSICION.COD_REQUISICION);
                log.Info("CODIGO : LGNTR2," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGNT1", log.Logger.Name, "NOTIFICAR", INFO));
                HILO.Start();

                Boolean RESUTADO = false;
                int _COD_CORREO = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CodigoCorreoRemitenteRequisiciones"]);
                MODELO_DATOS.CORREOS DATOS_CORREO = CORREO.CONSULTAR(_COD_CORREO);

                /*DESENCRIPTAR*/
                byte[] IV_TEXTO = Convert.FromBase64String(DATOS_CORREO.IV);
                string TEXTO_SALTO = CORREO.DESENCRIPTAR(IV_TEXTO, DATOS_CORREO.CONTRASENA);
                byte[] SALT = Convert.FromBase64String(DATOS_CORREO.SALTO);
                string CONTRASENA_CORREO = CORREO.QUITAR_SALTO(TEXTO_SALTO, SALT.Length);
                /*FIN  DESENCRIPTAR*/
                List<CORREOS_DESTINOS> DESTINO_LISTA_DATOS = CORREO.CONSULTAR_DESTINO(_COD_CORREO).ToList().Where(x => x.COD_ASPNETUSER_JEFE == ID_USUARIO).ToList();
                List<CORREOS_DESTINOS_MODELO> DESTINO_LISTA = new List<CORREOS_DESTINOS_MODELO>();

                foreach (CORREOS_DESTINOS TIPO in DESTINO_LISTA_DATOS)
                {
                    DESTINO_LISTA.Add(
                            new CORREOS_DESTINOS_MODELO
                            {
                                CORREO = TIPO.CORREO,
                                ESTADO = TIPO.ESTADO,
                                COD_COREEO_DESTINO = TIPO.COD_CORREO_DESTINO,
                                COD_ASPNETUSER_CONTROLLER=TIPO.COD_ASPNETUSER_CONTROLLER
                            }
                        );
                }
                List<PLANTILLAS_CORREOS> PLANTILLA_LISTA_DATOS = CORREO.CONSULTAR_PLANTILLA(_COD_CORREO).ToList();
                List<PLANTILLAS_CORREOS_MODELO> PLANTILLA_LISTA = new List<PLANTILLAS_CORREOS_MODELO>();

                foreach (PLANTILLAS_CORREOS TIPO in PLANTILLA_LISTA_DATOS)
                {
                    PLANTILLA_LISTA.Add(
                            new PLANTILLAS_CORREOS_MODELO
                            {
                                COD_PLANTILLA = TIPO.COD_PLANTILLA,
                                PLANTILLA = TIPO.PLANTILLA,
                                ESTADO = TIPO.ESTADO
                            }
                        );
                }
                string TIPO_REQUISICION = "";
                if (SettingsManager.CodTipoReqIncapacidad == _REQUSICION.COD_TIPO_REQUISICION)
                    TIPO_REQUISICION = SettingsManager.TextoIncapacidad;
                if (SettingsManager.CodTipoReqLicencia == _REQUSICION.COD_TIPO_REQUISICION)
                    TIPO_REQUISICION = SettingsManager.TextoLicencia;
                if (SettingsManager.CodTipoReqPresupuestada == _REQUSICION.COD_TIPO_REQUISICION)
                    TIPO_REQUISICION = SettingsManager.TextoPresupuestada;
                if (SettingsManager.CodTipoReqNoPresupuestada == _REQUSICION.COD_TIPO_REQUISICION)
                    TIPO_REQUISICION = SettingsManager.TextoNoPresupuestada;
                if (_REQUSICION.ES_MODIFICACION) {
                    if (SettingsManager.CodTipoReqPresupuestada == _REQUSICION.COD_TIPO_REQUISICION)
                    {
                        TIPO_REQUISICION = SettingsManager.TextoPresupuestadaModificacion;
                    }
                    if (SettingsManager.CodTipoReqNoPresupuestada == _REQUSICION.COD_TIPO_REQUISICION)
                    {
                        TIPO_REQUISICION = SettingsManager.TextoNoPresupuestadaModificacion;
                    }
                }


                CORREO_CONFIGURACION_REQUISICION CORREO_LOGICA = new CORREO_CONFIGURACION_REQUISICION
                {
                    SERVIDOR = DATOS_CORREO.SERVIDOR_SMTP,
                    CUENTA_CORREO = DATOS_CORREO.CUENTA_CORREO,
                    CONTRASENA = CONTRASENA_CORREO,
                    DESTINOS = DESTINO_LISTA,
                    PLANTILLAS = PLANTILLA_LISTA,
                    PUERTO = DATOS_CORREO.PUERTO,
                    ASUNTO = DATOS_CORREO.ASUNTO,
                    USA_SSL = DATOS_CORREO.USA_SSL,
                    ES_HTML = DATOS_CORREO.ES_HTML,
                    ESTADO = DATOS_CORREO.ESTADO,
                    CARGO = _REQUSICION.NOMBRE_CARGO,
                    CENTRO_COSTO = _REQUSICION.NOMBRE_CECO,
                    LINK_TRAMITAR = _LINK_TRAMITAR,
                    COD_REQUISICION=_REQUSICION.COD_REQUISICION,
                    TIPO_REQUISICION = TIPO_REQUISICION
                };

               CORREO.ENVIO_CORREO_REQUISICIONES(CORREO_LOGICA);

                return RESUTADO;
            }
            catch (Exception ex) {
                log.ErrorFormat("CODIGO : LGNTR2,  Método NOTIFICAR con el COD_RETIRO : {0}, {1} ", _REQUSICION.COD_REQUISICION, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGNT1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                return false;
            }
        }

    }
}
