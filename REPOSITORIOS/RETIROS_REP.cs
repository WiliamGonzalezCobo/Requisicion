using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MODELO_DATOS;
using log4net;
using System.Data;
using log4net.Config;
using System.IO;
using System.Security.Cryptography;
using REPOSITORIOS.TRAZA_LOG;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Threading;

namespace REPOSITORIOS
{
    public class RETIROS_REP : IRETIROS_REP, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private CONTEXTO CONTEXTODATOS;
        public RETIROS_REP(CONTEXTO _CONTEXTO)
        {
            CONTEXTODATOS = _CONTEXTO;
        }

       /*BUSCA RETIRO POR EL ROL O POR CUALQUIER  DATO DEL FILTRO SEA USUARIO, NOMBRE, NUMERO DE DOCMENTO */
        public IEnumerable<RETIROS> CONSULTAR_RETIROS( string ROL,string VALOR, string USUARIO)
        {
            string INFO = ("Iniciando Método CONSULTAR_RETIROS");
            log.Info("CODIGO : RE2"+INFO);

            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE2", log.Logger.Name, "CONSULTAR_RETIRO_POR_CODIGO", INFO));
            HILO.Start();

            try
            {
				
			 return CONTEXTODATOS.RETIROS.SqlQuery("RETIROS.CONSULTAR_RETIROS @ROL = {0},@VALOR= {1}, @USUARIO = {2}", ROL, VALOR, USUARIO).ToList().Select(x =>
					new RETIROS
					{
						COD_RETIRO = x.COD_RETIRO,
						NUMERO_DOCUMENTO = x.NUMERO_DOCUMENTO,
						NOMBRE = x.NOMBRE,
						USUARIO = x.USUARIO,
						COD_CARGO = x.COD_CARGO,
						NOMBRE_CARGO = x.NOMBRE_CARGO,
						COD_CAUSA_RETIRO = x.COD_CAUSA_RETIRO,
						NOMBRE_CAUSA_RETIRO = x.NOMBRE_CAUSA_RETIRO,
						FECHA_RETIRO = x.FECHA_RETIRO,
						GENERA_VACANTE = x.GENERA_VACANTE,
						COMENTARIOS = x.COMENTARIOS,
						APROBADO = x.APROBADO,
						COD_ESTADO_RETIRO = x.COD_CAUSA_RETIRO,
						ESTADO = x.ESTADO,
						COD_USUARIO_CREA = x.COD_USUARIO_CREA,
						FECHA_CREA = x.FECHA_CREA,
						COD_USUARIO_MODIFICA = x.COD_USUARIO_MODIFICA,
						FECHA_MODIFICA = x.FECHA_MODIFICA,
						ESTADOS = x.ESTADOS
					}
				   );

			}
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : RE2,  Método CONSULTAR_RETIROS, {0}  ", ex.StackTrace);
                ex.HelpLink = "RE2";
                Thread HILOERROR = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILOERROR.Start();

                throw ex;/*se deja asi hya metodos que lo consumen*/
            }
        }
                          
        /*BUSCA EL RETIRO POR NUMERO DE DOCUMENTO*/
        public RETIROS CONSULTAR_RETIRO_POR_CODIGO( decimal COD_RETIRO)
        {
            string INFO = ("Iniciando Método CONSULTAR_RETIROS por COD_RETIRO con el codigo : " + COD_RETIRO);
            log.Info("CODIGO : RE1, " + INFO);
            
            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE1", log.Logger.Name, "CONSULTAR_RETIRO_POR_CODIGO", INFO));
            HILO.Start();

            SOPORTES_REP SOPORTES = new SOPORTES_REP(CONTEXTODATOS);
            
            try
            {
                RETIROS RETIRO;
                RETIROS RETIRO_RESPUESTA = new RETIROS();
                RETIRO = CONSULTAR_POR_CODIGO(COD_RETIRO);
                RETIRO_RESPUESTA.COD_RETIRO = RETIRO.COD_RETIRO;
                RETIRO_RESPUESTA.NUMERO_DOCUMENTO = RETIRO.NUMERO_DOCUMENTO;
                RETIRO_RESPUESTA.NOMBRE = RETIRO.NOMBRE;
                RETIRO_RESPUESTA.USUARIO = RETIRO.USUARIO;
                RETIRO_RESPUESTA.COD_CARGO = RETIRO.COD_CARGO;
                RETIRO_RESPUESTA.NOMBRE_CARGO = RETIRO.NOMBRE_CARGO;
                RETIRO_RESPUESTA.COD_CAUSA_RETIRO = RETIRO.COD_CAUSA_RETIRO;
                RETIRO_RESPUESTA.NOMBRE_CAUSA_RETIRO = RETIRO.NOMBRE_CAUSA_RETIRO;
                RETIRO_RESPUESTA.FECHA_RETIRO = RETIRO.FECHA_RETIRO;
                RETIRO_RESPUESTA.GENERA_VACANTE = RETIRO.GENERA_VACANTE;
                RETIRO_RESPUESTA.COMENTARIOS = RETIRO.COMENTARIOS;
                RETIRO_RESPUESTA.APROBADO = RETIRO.APROBADO;
                RETIRO_RESPUESTA.COD_ESTADO_RETIRO = RETIRO.COD_CAUSA_RETIRO;
                RETIRO_RESPUESTA.ESTADO = RETIRO.ESTADO;
                RETIRO_RESPUESTA.COD_USUARIO_CREA = RETIRO.COD_USUARIO_CREA;
                RETIRO_RESPUESTA.FECHA_CREA = RETIRO.FECHA_CREA;
                RETIRO_RESPUESTA.COD_USUARIO_MODIFICA = RETIRO.COD_USUARIO_MODIFICA;
                RETIRO_RESPUESTA.FECHA_MODIFICA = RETIRO.FECHA_MODIFICA;
                RETIRO_RESPUESTA.ESTADOS = RETIRO.ESTADOS;
                RETIRO_RESPUESTA.SOPORTES = RETIRO.SOPORTES
                    .Select(SOPORTE => new SOPORTES
                    {
                        COD_SOPORTE = SOPORTE.COD_SOPORTE,
                        COD_RETIRO = SOPORTE.COD_RETIRO,
                        COD_TIPO_SOPORTE = SOPORTE.COD_TIPO_SOPORTE,
                        RUTA_SOPORTE = SOPORTE.RUTA_SOPORTE,
                        NOMBRE_SOPORTE = SOPORTE.NOMBRE_SOPORTE,
                        APROBADO = SOPORTE.APROBADO,
                        ESTADO = SOPORTE.ESTADO,
                        COD_USUARIO_CREA = SOPORTE.COD_USUARIO_CREA,
                        FECHA_CREA = SOPORTE.FECHA_CREA,
                        COD_USUARIO_MODIFICA = SOPORTE.COD_USUARIO_MODIFICA,
                        FECHA_MODIFICA = SOPORTE.FECHA_MODIFICA,
                        TAMANO = SOPORTE.TAMANO,
                        REQUERIDO = SOPORTES.CONSULTA_POR_CODIGO_SOPORTE_REQUERIDO(SOPORTE.COD_TIPO_SOPORTE, RETIRO.COD_CAUSA_RETIRO).REQUERIDO,
                        TIPO_SOPORTES = SOPORTE.TIPO_SOPORTES
                    }).ToArray();

                log.Info("CODIGO : RE1, Finalizado con éxito Método CONSULTAR_RETIROS por COD_RETIRO con el codigo : " + COD_RETIRO);
                return RETIRO_RESPUESTA;

            }
            catch (Exception  ex)
            {
                log.ErrorFormat("CODIGO : RE1  recuperando CONSULTAR_RETIRO_POR_CODIGO :  {0},  {1} ", COD_RETIRO,ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "RE1" : ex.HelpLink);

                Thread HILO1 = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO1.Start();

                throw ex;        
            }           
           
        }      

        public RETIROS CONSULTAR_POR_CODIGO(decimal COD_RETIRO)
        {
            string INFO = ("Iniciando Método CONSULTAR_RETIROS por COD_RETIRO con el codigo : " + COD_RETIRO);
            log.Info("CODIGO : RE3," + INFO);

        
            try
            {

                return CONTEXTODATOS.RETIROS.SqlQuery("RETIROS.CONSULTAR_RETIRO_POR_COD_RETIRO @COD_RETIRO = {0}",
                                                      COD_RETIRO).SingleOrDefault<RETIROS>();
            
            }
            catch (Exception ex)
            {
             
                log.ErrorFormat("CODIGO : RE3  recuperando CONSULTAR_POR_CODIGO : {0} , {1} ", COD_RETIRO, ex.StackTrace);
                ex.HelpLink = "RE3";       

                throw ex;
            }
        }


        /*CREA UN NUEVO REGISTRO DE RETIROS*/
        public void CREAR_RETIRO(RETIROS RETIRO)
        {
            try
            {
                string INFO = ("Finalizado con éxito Método CREAR_RETIRO");
                log.Info("CODIGO : RE4, " + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE4", log.Logger.Name, "CREAR_RETIRO", INFO));
                HILO.Start();
                
                CONTEXTODATOS.RETIROS.Add(RETIRO);

                log.Info("Finalizado con éxito Método CREAR_RETIRO");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : RE4  ejecutando CREAR_RETIRO, en la linea : {0} ", ex.StackTrace);
                ex.HelpLink = "RE4";

                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }

        /*ACTUALIZA RETIRO, PARA EL METODO DE EDITAR*/
        public void ACTUALIZAR_RETIRO(RETIROS RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método ACTUALIZAR_RETIRO");
                log.Info("CODIGO : RE5, " + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE5", log.Logger.Name, "ACTUALIZAR_RETIRO", INFO));
                HILO.Start();

                CONTEXTODATOS.Entry(RETIRO).State = EntityState.Modified;

                log.Info("CODIGO : RE5, Finalizado con éxito Método ACTUALIZAR_RETIRO");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : RE5  ejecutando ACTUALIZAR_RETIRO, en la linea : {0}", ex.StackTrace);
                ex.HelpLink = "RE5";

                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

        public void ELIMINAR_RETIRO(decimal COD_RETIRO)
        {
            try
            {   

                string INFO = ("Iniciando Método ELIMINAR_RETIRO con el COD_RETIRO : " + COD_RETIRO);
                log.Info("CODIGO: RE6,"+ INFO);
                
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE6", log.Logger.Name, "ELIMINAR_RETIRO", INFO));
                HILO.Start();
                
                RETIROS RETIRO_ = CONSULTAR_POR_CODIGO(COD_RETIRO);
                CONTEXTODATOS.RETIROS.Remove(RETIRO_);

                log.Info("CODIGO : RE6, Finalizado con éxito Método ELIMINAR_RETIRO con el COD_RETIRO : " + COD_RETIRO);
 
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : RE6  ELIMINAR_RETIRO por COD_RETIRO : {0}, {1} ", COD_RETIRO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "RE6" : ex.HelpLink); 

                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
        }
   
        public RETIROS APROBAR_RETIRO_POR_CODIGO(decimal COD_RETIRO, bool APROBADO, string USUARIO, string ESTADO_RETIRO)
        {
            string INFO = ("Iniciando Método APROBAR_RETIRO_POR_CODIGO con el COD_RETIRO : " + COD_RETIRO);
            log.Info("CODIGO : RE7, " + INFO);

            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE7", log.Logger.Name, "APROBAR_RETIRO_POR_CODIGO", INFO));
            HILO.Start();

            try
            {                                 

                return CONTEXTODATOS.RETIROS.SqlQuery("RETIROS.APROBAR_RETIRO @COD_RETIRO = {0} , @APROBADO  = {1}, @COD_USUARIO_MODIFICA = {2}, @ESTADO_RETIRO = {3} ",
                COD_RETIRO, APROBADO, USUARIO, ESTADO_RETIRO).Select(x =>
                    new RETIROS
                    {
                        COD_RETIRO = x.COD_RETIRO,
                        NUMERO_DOCUMENTO = x.NUMERO_DOCUMENTO,
                        NOMBRE = x.NOMBRE,
                        USUARIO = x.USUARIO,
                        COD_CARGO = x.COD_CARGO,
                        NOMBRE_CARGO = x.NOMBRE_CARGO,
                        COD_CAUSA_RETIRO = x.COD_CAUSA_RETIRO,
                        NOMBRE_CAUSA_RETIRO = x.NOMBRE_CAUSA_RETIRO,
                        FECHA_RETIRO = x.FECHA_RETIRO,
                        GENERA_VACANTE = x.GENERA_VACANTE,
                        COMENTARIOS = x.COMENTARIOS,
                        APROBADO = x.APROBADO,
                        COD_ESTADO_RETIRO = x.COD_CAUSA_RETIRO,
                        ESTADO = x.ESTADO,
                        COD_USUARIO_CREA = x.COD_USUARIO_CREA,
                        FECHA_CREA = x.FECHA_CREA,
                        COD_USUARIO_MODIFICA = x.COD_USUARIO_MODIFICA,
                        FECHA_MODIFICA = x.FECHA_MODIFICA,
                        ESTADOS = x.ESTADOS
                    }).SingleOrDefault<RETIROS>();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : RE7  APROBAR_RETIRO_POR_CODIGO : {0}, {1} ", COD_RETIRO, ex.StackTrace);
                ex.HelpLink = "RE7";

                Thread HILOERROR = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILOERROR.Start();
                throw ex;
            }
        }


        public IEnumerable<SOPORTES> CONSULTAR_SOPORTES(decimal COD_RETIRO)
        {
            string INFO = ("Iniciando Método CONSULTAR_SOPORTES");
            log.Info("CODIGO : RE8, " + INFO);

            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE8", log.Logger.Name, "CONSULTAR_SOPORTES", INFO));
            HILO.Start();

            try
            {
                return  CONTEXTODATOS.SOPORTES.SqlQuery("RETIROS.CONSULTAR_SOPORTES_RETIRO @COD_RETIRO = {0}"
                                                     , COD_RETIRO).ToList().Select(x =>
                new SOPORTES
                {
                    COD_RETIRO = x.COD_RETIRO,
                    APROBADO = x.APROBADO,
                    COD_SOPORTE = x.COD_SOPORTE, 
                    COD_TIPO_SOPORTE = x.COD_TIPO_SOPORTE, 
                    RUTA_SOPORTE = x.RUTA_SOPORTE,
                    NOMBRE_SOPORTE =   x.NOMBRE_SOPORTE,
                    TAMANO = x.TAMANO,
                    ESTADO = x.ESTADO,
                    COD_USUARIO_CREA = x.COD_USUARIO_CREA,
                    FECHA_CREA = x.FECHA_CREA,
                    COD_USUARIO_MODIFICA = x.COD_USUARIO_MODIFICA,
                    FECHA_MODIFICA = x.FECHA_MODIFICA
                    
                }
               );
                 

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : RE8,  Método CONSULTAR_SOPORTES por COD_RETIRO : {0}, {1} ", ex.StackTrace);
                ex.HelpLink = "RE8";
                Thread HILOERROR = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILOERROR.Start();

                throw ex;
            }
        }


        public bool FINALIZAR_RETIRO(decimal COD_RETIRO,string COD_USUARIO_MODIFICA)
        {
            string INFO = ("Iniciando Método FINALIZAR_RETIRO por COD_RETIRO con el codigo : " + COD_RETIRO);
            log.Info("CODIGO : RE9," + INFO);
            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE7", log.Logger.Name, "APROBAR_RETIRO_POR_CODIGO", INFO));
            HILO.Start();


            try
            {

                RETIROS CONFIRMA= CONTEXTODATOS.RETIROS.SqlQuery("RETIROS.FINALIZAR_RETIRO @COD_RETIRO = {0},@COD_USUARIO_MODIFICA = {1}",
                                                      COD_RETIRO, COD_USUARIO_MODIFICA).SingleOrDefault<RETIROS>();

                return true;
            }
            catch (Exception ex)
            {

                log.ErrorFormat("CODIGO : RE9  recuperando FINALIZAR_RETIRO : {0} , {1} ", COD_RETIRO, ex.StackTrace);
                ex.HelpLink = "RE9";
                Thread HILOERROR = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILOERROR.Start();
              //  throw ex;  si hay un error no envia correo ni cambia estado
                return false;
            }
        }

        /*ACTUALIZA EL CAUSA RETIRO EN TABLA RETIRO POR SI CAMBIA LA CAUSA RETIRO RETIROS.ACTUALIZAR_RETIRO_POR_COD_CAUSA_RETIRO */
        public bool ACTUALIZA_RETIRO_POR_CAUSA_RETIRO(decimal COD_RETIRO, decimal COD_CAUSA_RETIRO,string NOMBRE_CAUSA_RETIRO, string COD_USUARIO_MODIFICA)
        {
            string INFO = ("Iniciando Método FINALIZAR_RETIRO por COD_RETIRO con el codigo : " + COD_RETIRO+  " POR EL USUARIO : "+ COD_USUARIO_MODIFICA);
            log.Info("CODIGO : RE10," + INFO);
            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE7", log.Logger.Name, "APROBAR_RETIRO_POR_CODIGO", INFO));
            HILO.Start();


            try
            {                                                    

                RETIROS CONFIRMA = CONTEXTODATOS.RETIROS.SqlQuery("RETIROS.ACTUALIZAR_RETIRO_POR_COD_CAUSA_RETIRO  @COD_RETIRO = {0}, @COD_CAUSA_RETIRO = {1},@NOMBRE_CAUSA_RETIRO = {2}, @COD_USUARIO_MODIFICA = {3}",
                                                      COD_RETIRO, COD_CAUSA_RETIRO, NOMBRE_CAUSA_RETIRO, COD_USUARIO_MODIFICA).SingleOrDefault<RETIROS>();

                return true;
            }
            catch (Exception ex)
            {

                log.ErrorFormat("CODIGO : RE10  recuperando FINALIZAR_RETIRO : {0} , POR EL USUARIO:  {1}, en la linia  {2} ", COD_RETIRO, COD_USUARIO_MODIFICA, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "RE10" : ex.HelpLink);
                Thread HILOERROR = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILOERROR.Start();

                throw ex;
                //return false;
            }
        }






        /*GUARDA CAMBIOS PARA CREAR Y ACTUALIZAR*/
        public void GUARDAR()
        {
            try
            {
                string INFO = ("Iniciando Método GUARDAR ");
                log.Info("CODIGO : RE9," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("RE9", log.Logger.Name, "GUARDAR", INFO));
                HILO.Start();

                CONTEXTODATOS.SaveChanges();

                log.Info("CODIGO : RE9, Finalizado con éxito Método GUARDAR ");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : RE9,  GUARDAR, {0}  ",  ex.StackTrace);
                ex.HelpLink = "RE9";

                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }

        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    CONTEXTODATOS.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    public interface IRETIROS_REP
    {
        /////////// INICIO PARA METODOS DE RETIRO //////////////////
        IEnumerable<RETIROS> CONSULTAR_RETIROS(string ROL, string VALOR, string USUARIO);
        RETIROS CONSULTAR_RETIRO_POR_CODIGO(decimal COD_RETIRO);
        RETIROS CONSULTAR_POR_CODIGO(decimal COD_RETIRO);
        RETIROS APROBAR_RETIRO_POR_CODIGO(decimal COD_RETIRO, bool APROBADO, string USUARIO, string ESTADO_RETIRO);
        void CREAR_RETIRO(RETIROS RETIRO);
        void ELIMINAR_RETIRO(decimal COD_RETIROd);
        void ACTUALIZAR_RETIRO(RETIROS RETIRO);
        bool FINALIZAR_RETIRO(decimal COD_RETIRO, string COD_USUARIO_MODIFICA);
        IEnumerable<SOPORTES> CONSULTAR_SOPORTES(decimal COD_RETIRO);
        bool ACTUALIZA_RETIRO_POR_CAUSA_RETIRO(decimal COD_RETIRO, decimal COD_CAUSA_RETIRO, string NOMBRE_CAUSA_RETIRO, string COD_USUARIO_MODIFICA);


        void GUARDAR();


    }
}
