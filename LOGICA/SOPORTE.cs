using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPOSITORIOS;
using MODELO_DATOS;
using LOGICA.MODELO_LOGICA;
using Newtonsoft.Json.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using log4net;
using REPOSITORIOS.TRAZA_LOG;
using System.Threading;

namespace LOGICA
{
    public class SOPORTE
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      
        private LOGICA.RETIRO RETIRO_LOGICA = new RETIRO();

		private ISOPORTES_REP _REPOSITORIO;
		public SOPORTE()
		{
			_REPOSITORIO = new REPOSITORIOS.SOPORTES_REP(new CONTEXTO());
		}
		//ESTA SOBRECARGA PERMITE PRUBAS AUTOMATICAS POR PROBLEMAS CON MANEJO DE 
		public SOPORTE(String CADENA_CONEXION)
		{
			_REPOSITORIO = new REPOSITORIOS.SOPORTES_REP(new CONTEXTO(CADENA_CONEXION));
		}

		public SOPORTES CONSULTAR(decimal _COD_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR por _COD_RETIRO : "+ _COD_RETIRO);
                log.Info("CODIGO : LGSO1," + INFO);
               
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE1", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();
                
                return _REPOSITORIO.CONSULTA_SOPORTE_POR_CODIGO(_COD_RETIRO);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGSO1,  Método CONSULTAR por _COD_RETIRO : {0}, {1}", _COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGSO1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }
        
        public Boolean APROBAR(decimal _COD_SOPORTE, Boolean _APROBADO, String _USUARIO,int COD_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método APROBAR por _COD_SOPORTE : " + _COD_SOPORTE);
                log.Info("CODIGO : LGSO2," + INFO);
           
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE2", log.Logger.Name, "APROBAR", INFO));
                HILO.Start();
               

                _REPOSITORIO.APROBAR_SOPORTE_POR_CODIGO(_COD_SOPORTE, _APROBADO, _USUARIO);
                _REPOSITORIO.GUARDAR();


                //pregunte si siene soportes
    
                TIPO_SOPORTE LOGICA_TIPO_SOPORTE = new TIPO_SOPORTE();//PREGUNTAR SI ES REQUERIDO
                IEnumerable<MODELO_DATOS.TIPO_SOPORTES> TIPOS_SOPORTES;
                TIPOS_SOPORTES = null;
                IRETIROS_REP _REPOSITORIO_RETIRO = new RETIROS_REP(new CONTEXTO());


                if (_REPOSITORIO_RETIRO.CONSULTAR_SOPORTES(COD_RETIRO).Where(SOPORTE => SOPORTE.APROBADO == false).ToList().Count > 0)
                {
                    RETIROS RETIRO = _REPOSITORIO_RETIRO.CONSULTAR_RETIRO_POR_CODIGO(COD_RETIRO);//.ESTADOS.NOMBRE;
                    string ESTADO_RETIRO = RETIRO.ESTADOS.NOMBRE;
                   decimal _COD_CAUSA_RETIRO= RETIRO.COD_ESTADO_RETIRO;

                    bool REQUERIDO= _REPOSITORIO.CONSULTA_SOPORTE_POR_CODIGO(COD_RETIRO).REQUERIDO;

                    if (ESTADO_RETIRO == "Documentos Aprobados")
                    {            
                        var d = _REPOSITORIO_RETIRO.CONSULTAR_SOPORTES(COD_RETIRO).Where(SOPORTE => SOPORTE.APROBADO == false).ToArray();

                        TIPOS_SOPORTES = LOGICA_TIPO_SOPORTE.CONSULTAR(_COD_CAUSA_RETIRO).ToList();
                        /*validar cuando son requeridos */
                        if (TIPOS_SOPORTES.Where(T => T.COD_TIPO_SOPORTE == d[0].COD_TIPO_SOPORTE && T.REQUERIDO == true).ToList().Count > 0)
                        {
                            _REPOSITORIO_RETIRO.APROBAR_RETIRO_POR_CODIGO(COD_RETIRO, _APROBADO, _USUARIO, ESTADO_RETIRO);
                            _REPOSITORIO_RETIRO.GUARDAR();
                        }
                    }
             
                }

                return true;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGSO2,  Método APROBAR por _COD_SOPORTE :  {0}, {1} ", _COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGSO2" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

        public SOPORTES CREAR(decimal _COD_RETIRO, decimal _COD_TIPO_SOPORTE,string _NOMBRE_SOPORTE, 
                               string _USUARIO ,System.Web.HttpPostedFileBase _ARCHIVO)

        {
            try
            {
                string INFO = ("Iniciando Método CREAR por _COD_RETIRO : " + _COD_RETIRO);
                log.Info("CODIGO : LGSO3," + INFO);
                
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE3", log.Logger.Name, "CREAR", INFO));
                HILO.Start();


                var _NOMBRE_SOPORTE_COD = _COD_RETIRO.ToString() + "_" + HashSHA(Path.GetFileName(_NOMBRE_SOPORTE));
                SOPORTES SOPORTE = new SOPORTES();
                string _RUTA_SOPORTE = System.Configuration.ConfigurationManager.AppSettings["Ruta_Descarga_archivos"].ToString();

                string RUTA_ARCHIVO = _RUTA_SOPORTE + _NOMBRE_SOPORTE_COD + Path.GetExtension(_NOMBRE_SOPORTE);

                SOPORTE.COD_RETIRO = _COD_RETIRO;
                SOPORTE.COD_TIPO_SOPORTE = _COD_TIPO_SOPORTE;
                SOPORTE.RUTA_SOPORTE = RUTA_ARCHIVO;
                SOPORTE.NOMBRE_SOPORTE = _NOMBRE_SOPORTE;
                SOPORTE.APROBADO = false;
                SOPORTE.ESTADO = 0;
                SOPORTE.COD_USUARIO_CREA = _USUARIO;
                SOPORTE.FECHA_CREA = DateTime.Now;
                SOPORTE.COD_USUARIO_MODIFICA = _USUARIO;
                SOPORTE.FECHA_MODIFICA = DateTime.Now;
                SOPORTE.TAMANO = (_ARCHIVO.ContentLength / 1024).ToString() + "k";
                _REPOSITORIO.CREAR_SOPORTE(SOPORTE);
                _REPOSITORIO.GUARDAR();
                _ARCHIVO.SaveAs(RUTA_ARCHIVO);
                return SOPORTE;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGSO3,  Método CREAR por _COD_RETIRO : {0}, {1} ", _COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGSO3" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }


		public SOPORTES ACTUALIZAR(decimal _COD_SOPORTE, string _NOMBRE_SOPORTE,
							string _USUARIO, System.Web.HttpPostedFileBase _ARCHIVO)
		{
            try
            {
                string INFO = ("Iniciando Método ACTUALIZAR por _COD_SOPORTE : " + _COD_SOPORTE);
                log.Info("CODIGO : LGSO4," + INFO);
                
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE3", log.Logger.Name, "ACTUALIZAR", INFO));
                HILO.Start();

                SOPORTES SOPORTE = _REPOSITORIO.CONSULTA_POR_CODIGO(_COD_SOPORTE);
                if (SOPORTE != null)
                {
                    decimal _COD_RETIRO = SOPORTE.COD_RETIRO;
                    var _NOMBRE_SOPORTE_COD = _COD_RETIRO.ToString() + "_" + HashSHA(Path.GetFileName(_NOMBRE_SOPORTE)) + Path.GetExtension(_NOMBRE_SOPORTE);
                    string _RUTA_SOPORTE = System.Configuration.ConfigurationManager.AppSettings["Ruta_Descarga_archivos"].ToString();
                    string RUTA_ARCHIVO = _RUTA_SOPORTE + _NOMBRE_SOPORTE_COD;
                    SOPORTE.RUTA_SOPORTE = RUTA_ARCHIVO;
                    SOPORTE.NOMBRE_SOPORTE = _NOMBRE_SOPORTE;
                    SOPORTE.TAMANO = (_ARCHIVO.ContentLength / 1024).ToString() + "k";
                    SOPORTE.COD_USUARIO_MODIFICA = _USUARIO;
                    SOPORTE.FECHA_MODIFICA = DateTime.Now;
                    _REPOSITORIO.ACTUALIZAR_SOPORTE(SOPORTE);
                    _REPOSITORIO.GUARDAR();
                    _ARCHIVO.SaveAs(RUTA_ARCHIVO);
                    return SOPORTE;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGSO4,  Método ACTUALIZAR por _COD_SOPORTE : {0}, {1} ", _COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGSO4" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

		public bool RETIRAR(decimal _COD_SOPORTE, string _USUARIO)
		{
            try
            {
                string INFO = ("Iniciando Método RETIRAR por _COD_SOPORTE : " + _COD_SOPORTE);
                log.Info("CODIGO : LGSO5," + INFO);
                
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE5", log.Logger.Name, "RETIRAR", INFO));
                 HILO.Start();


                SOPORTES SOPORTE = _REPOSITORIO.CONSULTA_POR_CODIGO(_COD_SOPORTE);
                if (SOPORTE != null)
                {
                    //SOPORTES SOPORTE_REQUERIDO = _REPOSITORIO.CONSULTA_POR_CODIGO_SOPORTE_REQUERIDO(_COD_SOPORTE, SOPORTE.COD_TIPO_SOPORTE, SOPORTE.RETIROS.COD_CAUSA_RETIRO);

                    decimal _COD_RETIRO = SOPORTE.COD_RETIRO;
                    SOPORTE.RUTA_SOPORTE = "";
                    SOPORTE.NOMBRE_SOPORTE = "";
                    SOPORTE.TAMANO = "";
                    SOPORTE.COD_USUARIO_MODIFICA = _USUARIO;
                    SOPORTE.FECHA_MODIFICA = DateTime.Now;
                    //SOPORTE.REQUERIDO = SOPORTE_REQUERIDO.REQUERIDO;
                    _REPOSITORIO.ACTUALIZAR_SOPORTE(SOPORTE);
                    _REPOSITORIO.GUARDAR();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGSO5,  Método RETIRAR por _COD_SOPORTE : {0}, {1}", _COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGSO5" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }


		private  string HashSHA(string value)
        {
            try
            {
                string INFO = ("Iniciando Método HashSHA : ");
                log.Info("CODIGO : LGSO7," + INFO);
                
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE7", log.Logger.Name, "HashSHA", INFO));
                HILO.Start();

                var sha1 = SHA1.Create();
                var inputBytes = System.Text.Encoding.ASCII.GetBytes(value);
                var hash = sha1.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                for (var i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {

                log.ErrorFormat("CODIGO : LGSO7,  Método HashSHA, {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGSO7" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }       
        }

        public SOPORTE_MODELO CONSULTA_ARCHIVO(decimal _COD_SOPORTE)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTA_ARCHIVO por _COD_SOPORTE : " + _COD_SOPORTE);
                log.Info("CODIGO : LGSO6," + INFO);
                
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGRE6", log.Logger.Name, "CONSULTA_ARCHIVO", INFO));
                HILO.Start();

                SOPORTES _SOPORTE = new SOPORTES();
                _SOPORTE = _REPOSITORIO.OBTENER_ARCHIVO_POR_CODIGO(_COD_SOPORTE);
                SOPORTE_MODELO SOPORTE = new SOPORTE_MODELO();
                SOPORTE.ARCHIVO = System.IO.File.ReadAllBytes(_SOPORTE.RUTA_SOPORTE);
                SOPORTE.NOMBRE = _SOPORTE.NOMBRE_SOPORTE;
                return SOPORTE;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGSO6,  Método CONSULTA_ARCHIVO por _COD_SOPORTE : {0}, {1} ", _COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGSO6" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }


    }
}




