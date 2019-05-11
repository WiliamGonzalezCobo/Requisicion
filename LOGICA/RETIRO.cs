using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPOSITORIOS;
using MODELO_DATOS;
using LOGICA.MODELO_LOGICA;
using Newtonsoft.Json.Linq;
using REPOSITORIOS.TRAZA_LOG;
using log4net;
using System.Threading;

namespace LOGICA
{

    public class RETIRO
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        bool VALIDA_LOG = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["Valida_Metodo_Depuracion_Log"]);

		private IRETIROS_REP _REPOSITORIO;
		public RETIRO()
		{
			_REPOSITORIO = new REPOSITORIOS.RETIROS_REP(new CONTEXTO());
		}
		//ESTA SOBRECARGA PERMITE PRUBAS AUTOMATICAS POR PROBLEMAS CON MANEJO DE 
		public RETIRO(String CADENA_CONEXION)
		{
			_REPOSITORIO = new REPOSITORIOS.RETIROS_REP(new CONTEXTO(CADENA_CONEXION));
		}

		private EMPLEADO EMPLEADO_METODO = new EMPLEADO();
        private CAUSA_RETIRO CAUSA_RETIRO_METODO = new CAUSA_RETIRO();

        public IEnumerable<RETIROS> CONSULTAR(string _ROL, String _VALOR, string _USUARIO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR");
                log.Info("CODIGO : LGRE1," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE1", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();

			

                return _REPOSITORIO.CONSULTAR_RETIROS(_ROL, _VALOR, _USUARIO).ToList();
            }
            catch (Exception ex)
            {

                log.ErrorFormat("CODIGO : LGRE1,  Método CONSULTAR, {0} ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGRE1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }
        public RETIROS CONSULTAR(int _COD_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR por _COD_RETIRO: " + _COD_RETIRO);
                log.Info("CODIGO : LGRE2, " + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE2", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();

                return _REPOSITORIO.CONSULTAR_RETIRO_POR_CODIGO(_COD_RETIRO);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGRE2,  Método CONSULTAR por _COD_RETIRO : {0}, {1}  ", _COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGRE2" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

        public RETIROS CREAR(string _NUMERO_DOCUMENTO, decimal _COD_CAUSA_RETIRO,
                             DateTime _FECHA_RETIRO, string _COMENTARIOS, string _USUARIO)
        {
            try
            {
                string INFO = ("Iniciando Método CREAR, del empleado con numero de documento : " + _NUMERO_DOCUMENTO);
                log.Info("CODIGO : LGRE3, " + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE3", log.Logger.Name, "CREAR", INFO));
                HILO.Start();


                EMPLEADO_MODELO _EMPLEADO = EMPLEADO_METODO.CONSULTA_EMPLEADO(_NUMERO_DOCUMENTO);
                CAUSA_RETIRO_MODELO _CAUSA = CAUSA_RETIRO_METODO.CONSULTAR(_COD_CAUSA_RETIRO);

                RETIROS RETIRO = new RETIROS();
                RETIRO.NUMERO_DOCUMENTO = _NUMERO_DOCUMENTO;
                RETIRO.NOMBRE = _EMPLEADO.NOMBRE;
                RETIRO.USUARIO = (_EMPLEADO.USUARIO == null) ? ". " : _EMPLEADO.USUARIO;
                RETIRO.COD_CARGO = _EMPLEADO.COD_CARGO;
                RETIRO.NOMBRE_CARGO = _EMPLEADO.NOMBRE_CARGO;
                RETIRO.COD_CAUSA_RETIRO = _COD_CAUSA_RETIRO;
                RETIRO.NOMBRE_CAUSA_RETIRO = _CAUSA.NOMBRE;
                RETIRO.FECHA_RETIRO = _FECHA_RETIRO;
                RETIRO.GENERA_VACANTE = false;
                RETIRO.COMENTARIOS = _COMENTARIOS;
                RETIRO.APROBADO = false;
                RETIRO.COD_ESTADO_RETIRO = 1;
                RETIRO.ESTADO = 1;
                RETIRO.COD_USUARIO_CREA = _USUARIO;
                RETIRO.FECHA_CREA = DateTime.Now;
                RETIRO.COD_USUARIO_MODIFICA = _USUARIO;
                RETIRO.FECHA_MODIFICA = DateTime.Now;
                _REPOSITORIO.CREAR_RETIRO(RETIRO);
                _REPOSITORIO.GUARDAR();

                log.Info("CODIGO : LGRE3, Finalizado con éxito Método CREAR, del empleado con numero de documento : " + _NUMERO_DOCUMENTO);

                return RETIRO;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGRE3,  Método  CREAR del empleado con numero de documento : {0}, {1}  ", _NUMERO_DOCUMENTO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGRE3" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }


        }
        public RETIROS ACTUALIZAR(decimal _COD_RETIRO, DateTime _FECHA_RETIRO, decimal _COD_CAUSA_RETIRO,
                               bool _GENERA_VACANTE, string _COMENTARIOS, string _COD_USUARIO_MODIFICA, bool ESBP)
        {
            try
            {
                string INFO = ("Iniciando Método ACTUALIZAR, por _COD_RETIRO : " + _COD_RETIRO);
                log.Info("CODIGO : LGRE4," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE4", log.Logger.Name, "ACTUALIZAR", INFO));
                HILO.Start();


                CAUSA_RETIRO_MODELO _CAUSA = CAUSA_RETIRO_METODO.CONSULTAR(_COD_CAUSA_RETIRO);
                RETIROS RETIRO = _REPOSITORIO.CONSULTAR_POR_CODIGO(_COD_RETIRO);
                if (RETIRO != null)
                {
                    RETIRO.COD_CAUSA_RETIRO = _COD_CAUSA_RETIRO;
                    RETIRO.NOMBRE_CAUSA_RETIRO = _CAUSA.NOMBRE;
                    RETIRO.FECHA_RETIRO = _FECHA_RETIRO;
                    RETIRO.GENERA_VACANTE = _GENERA_VACANTE;
                    RETIRO.COMENTARIOS = _COMENTARIOS;
                    RETIRO.FECHA_MODIFICA = DateTime.Now;
                    RETIRO.COD_USUARIO_MODIFICA = _COD_USUARIO_MODIFICA;
                    RETIRO.SOPORTES = null;
                    if (ESBP)
                    {
                        RETIRO.COD_ESTADO_RETIRO = 3;

                    }
                    _REPOSITORIO.ACTUALIZAR_RETIRO(RETIRO);
                    _REPOSITORIO.GUARDAR();

                    if (ESBP)
                    {
                        NOTIFICACION NOTIFICA_CORREO = new NOTIFICACION();
                        bool VALIDA_RESPUESTA = NOTIFICA_CORREO.NOTIFICAR(Convert.ToDecimal(_COD_RETIRO));
                        if (VALIDA_RESPUESTA)
                        {
                            if (_REPOSITORIO.FINALIZAR_RETIRO(_COD_RETIRO, _COD_USUARIO_MODIFICA)) { }                         
                        }
                    }

                    log.Info("Finalizado con éxito Método ACTUALIZAR, por _COD_RETIRO : " + _COD_RETIRO);

                    return RETIRO;
                }
                else
                {
                    log.Info("Finalizado con éxito Método ACTUALIZAR, por _COD_RETIRO : " + _COD_RETIRO);
                    return null;
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGRE4,  Método  ACTUALIZAR con el COD_RETIRO : {0}, {1}  ", _COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGRE4" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }

        }

        public Boolean CANCELAR(decimal _COD_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método CANCELAR, por _COD_RETIRO : " + _COD_RETIRO);
                log.Info("CODIGO : LGRE5," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE5", log.Logger.Name, "CANCELAR", INFO));
                HILO.Start();

                _REPOSITORIO.ELIMINAR_RETIRO(_COD_RETIRO);
                _REPOSITORIO.GUARDAR();

                log.Info("Finalizado con éxito Método CANCELAR, por _COD_RETIRO : " + _COD_RETIRO);

                return true;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGRE5,  Método  CANCELAR con el COD_RETIRO : {0}, {1}  ", _COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGRE5" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                //return false
                throw ex;
            }
        }
        public Boolean APROBAR(decimal _COD_RETIRO, String _USUARIO)
        {
            try
            {
                string INFO = ("Iniciando Método APROBAR, por _COD_RETIRO : " + _COD_RETIRO);
                log.Info("CODIGO : LGRE6," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE6", log.Logger.Name, "APROBAR", INFO));
                HILO.Start();


                bool _APROBADO = false;
                // decimal _COD_ESTADO = 0;

                TIPO_SOPORTE LOGICA_TIPO_SOPORTE = new TIPO_SOPORTE();//PREGUNTAR SI ES REQUERIDO
                IEnumerable<MODELO_DATOS.TIPO_SOPORTES> TIPOS_SOPORTES;

                TIPOS_SOPORTES = null;


                string ESTADO_RETIRO = (_REPOSITORIO.CONSULTAR_RETIRO_POR_CODIGO(_COD_RETIRO).ESTADOS.NOMBRE);



                if (_REPOSITORIO.CONSULTAR_SOPORTES(_COD_RETIRO).Where(SOPORTE => SOPORTE.APROBADO == false).ToList().Count > 0)
                {
                    log.Info("CODIGO : LGRE6, Finalizado con éxito Método APROBAR, por _COD_RETIRO : " + _COD_RETIRO);

                    if (ESTADO_RETIRO == "Documentos Aprobados")

                    {         /*codigo cuando el soporte no es requerido aprobar*/
                        decimal _COD_CAUSA_RETIRO = CONSULTAR(Convert.ToInt32(_COD_RETIRO)).COD_CAUSA_RETIRO;

                        var TIENE_SOPORTE_REQUERIDO = _REPOSITORIO.CONSULTAR_SOPORTES(_COD_RETIRO).Where(SOPORT => SOPORT.APROBADO == false).ToArray();
                        TIPOS_SOPORTES = LOGICA_TIPO_SOPORTE.CONSULTAR(_COD_CAUSA_RETIRO).ToList();
                        /*si faltan soportes requeridos */
                        if (TIPOS_SOPORTES.Where(T => T.COD_TIPO_SOPORTE == TIENE_SOPORTE_REQUERIDO[0].COD_TIPO_SOPORTE && T.REQUERIDO == true).ToList().Count > 0)
                        { 
                        _REPOSITORIO.APROBAR_RETIRO_POR_CODIGO(_COD_RETIRO, _APROBADO, _USUARIO, ESTADO_RETIRO);
                        _REPOSITORIO.GUARDAR();


                    }
                    //return false;
                }
                return false;
            }
                else
                {
                    if (ESTADO_RETIRO == "Documentos Aprobados")

                    {
                        ESTADO_RETIRO = "Registrado";
                    }

                        _REPOSITORIO.APROBAR_RETIRO_POR_CODIGO(_COD_RETIRO, _APROBADO, _USUARIO, ESTADO_RETIRO);
                _REPOSITORIO.GUARDAR();


                log.Info("CODIGO : LGRE6, Finalizado con éxito Método APROBAR, por _COD_RETIRO : " + _COD_RETIRO);

                return true;
            }
        }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGRE6,  Método  APROBAR con el COD_RETIRO : {0}, {1} " , _COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGRE6" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
        HILO.Start();

                throw ex;
            }

       }



        public Boolean ACTUALIZAR(decimal _COD_RETIRO,decimal _COD_CAUSA_RETIRO,string _USUARIO)
        {
            try
            {
                string INFO = ("Iniciando Método ACTUALIZAR para  ACTUALIZA_RETIRO_POR_CAUSA_RETIRO , por _COD_RETIRO : " + _COD_RETIRO +" por el USUARIO : "+ _USUARIO);
                log.Info("CODIGO : LGRE5," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE5", log.Logger.Name, "CANCELAR", INFO));
                HILO.Start();

                CAUSA_RETIRO_MODELO _CAUSA = CAUSA_RETIRO_METODO.CONSULTAR(_COD_CAUSA_RETIRO);

                _REPOSITORIO.ACTUALIZA_RETIRO_POR_CAUSA_RETIRO(_COD_RETIRO, _COD_CAUSA_RETIRO,_CAUSA.NOMBRE,_USUARIO);
       

                log.Info("Finalizado con éxito Método ACTUALIZAR para  ACTUALIZA_RETIRO_POR_CAUSA_RETIRO , por _COD_RETIRO : " + _COD_RETIRO + " por el USUARIO : " + _USUARIO);

                return true;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGRE5,  Método  ACTUALIZAR para  ACTUALIZA_RETIRO_POR_CAUSA_RETIRO , por _COD_RETIRO  : {0}, por el USUARIO : {1} ,{2}   ", _COD_RETIRO,_USUARIO ,  ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGRE5" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
               // return false;
                
            }
        }




      

    }
}
