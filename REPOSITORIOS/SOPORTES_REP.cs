using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MODELO_DATOS;
using log4net;
using System.Web;
using System.Threading;
using REPOSITORIOS.TRAZA_LOG;

namespace REPOSITORIOS
{
    public class SOPORTES_REP : ISOPORTES_REP, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private CONTEXTO CONTEXTODATOS;

        public SOPORTES_REP(CONTEXTO _CONTEXTO)
        {
            CONTEXTODATOS = _CONTEXTO;
        }

        /*REALIZAR CONSULTAS INTERNAS PARA COMPLETAR LAS IDENTIDADES*/
        public SOPORTES CONSULTA_POR_CODIGO(decimal COD_SOPORTE)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTA SOPORTE _POR_CODIGO : "+ COD_SOPORTE);
                log.Info("CODIGO : SO1, " + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("SO1", log.Logger.Name, "CONSULTAR _SOPORTE_POR_CODIGO", INFO));
                HILO.Start();
        

                return CONTEXTODATOS.SOPORTES.SqlQuery("RETIROS.CONSULTAR_SOPORTE_POR_COD_SOPORTE  @COD_SOPORTE={0}",
				COD_SOPORTE).SingleOrDefault<SOPORTES>();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : SO1  Método CONSULTA SOPORTE _POR_CODIGO :  {0}, {1} ", COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = "SO1";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

        /* METO PARA QUE RETORNE ASTA LA VISTA PASANDO POR LAS CAPAS */
        public SOPORTES CONSULTA_SOPORTE_POR_CODIGO(Decimal COD_SOPORTE)
        {          
            string INFO = ("Iniciando Método CONSULTA_SOPORTE_POR_CODIGO"+ COD_SOPORTE);
            log.Info("CODIGO : SO2 " + INFO);

            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("SO2", log.Logger.Name, "CONSULTAR_RETIRO_POR_CODIGO", INFO));
            HILO.Start();            

            try
            {
                SOPORTES SOPORTE;
                SOPORTES SOPORTE_RESPUESTA = new SOPORTES();
                SOPORTE = CONSULTA_POR_CODIGO(COD_SOPORTE);

                SOPORTE_RESPUESTA.COD_SOPORTE = SOPORTE.COD_SOPORTE;
                SOPORTE_RESPUESTA.COD_RETIRO = SOPORTE.COD_RETIRO;
                SOPORTE_RESPUESTA.COD_TIPO_SOPORTE = SOPORTE.COD_TIPO_SOPORTE;
                SOPORTE_RESPUESTA.RUTA_SOPORTE = SOPORTE.RUTA_SOPORTE;
                SOPORTE_RESPUESTA.NOMBRE_SOPORTE = SOPORTE.NOMBRE_SOPORTE;
                SOPORTE_RESPUESTA.APROBADO = SOPORTE.APROBADO;
                SOPORTE_RESPUESTA.ESTADO = SOPORTE.ESTADO;
                SOPORTE_RESPUESTA.COD_USUARIO_CREA = SOPORTE.COD_USUARIO_CREA;
                SOPORTE_RESPUESTA.FECHA_CREA = SOPORTE.FECHA_CREA;
                SOPORTE_RESPUESTA.COD_USUARIO_MODIFICA = SOPORTE.COD_USUARIO_MODIFICA;
                SOPORTE_RESPUESTA.FECHA_MODIFICA = SOPORTE.FECHA_MODIFICA;
                SOPORTE_RESPUESTA.TAMANO = SOPORTE.TAMANO;

                log.Info("Finalizado con éxito Método CONSULTA_SOPORTE_POR_CODIGO por COD_RETIRO : " + COD_SOPORTE);
                return SOPORTE_RESPUESTA;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : SO2  Método CONSULTA_SOPORTE_POR_CODIGO por COD_RETIRO : {0}, {1} ", COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" ? "SO2" : ex.HelpLink);

                Thread HILO1 = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO1.Start();

                throw ex;
            }

        }

        /*METODO PARA APROBAR LOS SOPORTES*/
        public SOPORTES APROBAR_SOPORTE_POR_CODIGO(decimal COD_SOPORTE, Boolean APROBADO, String USUARIO)
        {
            string INFO = ("Iniciando Método APROBAR_SOPORTE_POR_CODIGO_SOPORTE  " + COD_SOPORTE + "  USUARIO   " + USUARIO);
            log.Info("CODIGO : SO3, " + INFO);
            
            Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("SO3", log.Logger.Name, "APROBAR_SOPORTE_POR_CODIGO", INFO));
            HILO.Start();
            
            try
            {
                return CONTEXTODATOS.SOPORTES.SqlQuery("RETIROS.APROBAR_SOPORTE  @COD_SOPORTE = {0} , @APROBADO = {1}, @COD_USUARIO_MODIFICA = {2}",
                COD_SOPORTE, APROBADO, USUARIO).Select(x =>
                new SOPORTES
                {
                    COD_SOPORTE = x.COD_SOPORTE,
                    COD_RETIRO = x.COD_RETIRO,
                    COD_TIPO_SOPORTE = x.COD_TIPO_SOPORTE,
                    RUTA_SOPORTE = x.RUTA_SOPORTE,
                    NOMBRE_SOPORTE = x.NOMBRE_SOPORTE,
                    APROBADO = x.APROBADO,
                    ESTADO = x.ESTADO,
                    COD_USUARIO_CREA = x.COD_USUARIO_CREA,
                    FECHA_CREA = x.FECHA_CREA,
                    COD_USUARIO_MODIFICA = x.COD_USUARIO_MODIFICA,
                    FECHA_MODIFICA = x.FECHA_MODIFICA,
                    TAMANO = x.TAMANO
                }).SingleOrDefault<SOPORTES>();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : SO3  recuperando el codigo  {0} del usuario {1} en la linea {2} ", COD_SOPORTE, USUARIO, ex.StackTrace);
                ex.HelpLink = "SO3";

                Thread HILO1 = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO1.Start();

                throw ex;
            }
        }

        /*METODO PARA OBTENER EL ARCHIVO DE LA BASE DE DATOS*/
        public SOPORTES OBTENER_ARCHIVO_POR_CODIGO(decimal COD_SOPORTE)
        {
            try
            {
                string INFO = ("Iniciando Método OBTENER_ARCHIVO_POR_CODIGO con el COD_SOPORTE :" + COD_SOPORTE);
                log.Info("CODIGO : SO4, " + INFO);
                
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("SO4", log.Logger.Name, "OBTENER_ARCHIVO_POR_CODIGO", INFO));
                HILO.Start();

                return CONTEXTODATOS.SOPORTES.SqlQuery("RETIROS.OBTENER_ARCHIVO_SOPORTE @COD_SOPORTE= {0}"
                , COD_SOPORTE).Select(x =>
            new SOPORTES
            {
                COD_SOPORTE = x.COD_SOPORTE,
                COD_RETIRO = x.COD_RETIRO,
                COD_TIPO_SOPORTE = x.COD_TIPO_SOPORTE,
                RUTA_SOPORTE = x.RUTA_SOPORTE,
                NOMBRE_SOPORTE = x.NOMBRE_SOPORTE,
                APROBADO = x.APROBADO,
                ESTADO = x.ESTADO,
                COD_USUARIO_CREA = x.COD_USUARIO_CREA,
                FECHA_CREA = x.FECHA_CREA,
                COD_USUARIO_MODIFICA = x.COD_USUARIO_MODIFICA,
                FECHA_MODIFICA = x.FECHA_MODIFICA,
                TAMANO = x.TAMANO
            }).SingleOrDefault<SOPORTES>();

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : SO4  recuperando el codigo en OBTENER_ARCHIVO_POR_CODIGO  {0}  en la linea {1} ", COD_SOPORTE, ex.StackTrace);
                ex.HelpLink = "SO4";

                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }

        /*METODO PARA CREAR SOPORTE*/
        public void CREAR_SOPORTE(SOPORTES SOPORTE)
        {
            try
            {     
                string INFO = ("Iniciando Método CREAR_SOPORTE ");
                log.Info("CODIGO : SO5, " + INFO);
               
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("SO5", log.Logger.Name, "CREAR_SOPORTE", INFO));
                HILO.Start();

                CONTEXTODATOS.SOPORTES.Add(SOPORTE);

                log.Info("Finalizado con éxito Método CREAR_SOPORTE");

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : SO5 recuperando: CREAR_SOPORTE en la linea  {0} ", ex.StackTrace);
                ex.HelpLink = "SO5";

                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }

		/*METODO PARA ACTUALIZAR SOPORTE*/
		public void ACTUALIZAR_SOPORTE(SOPORTES SOPORTE)
        {
            try
            {             
                string INFO =("Iniciando Método ACTUALIZAR_SOPORTE ");
                log.Info("CODIGO : SO6, " + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("SO6", log.Logger.Name, "ACTUALIZAR_SOPORTE", INFO));
                HILO.Start();

                CONTEXTODATOS.Entry(SOPORTE).State = EntityState.Modified;

                log.Info("Finalizado con éxito Método ACTUALIZAR_SOPORTE");

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : SO6  ACTUALIZAR_SOPORTE en la linea  {0} ", ex.StackTrace);
                ex.HelpLink = "SO6";

                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }    
		}

        /* metodo para consultar si es requerido el tiposoporte*/
        public CAUSA_RETIROS_TIPO_SOPORTES CONSULTA_POR_CODIGO_SOPORTE_REQUERIDO(decimal COD_TIPO_SOPORTE, decimal COD_CAUSA_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTA_POR_CODIGO_SOPORTE_REQUERIDO :  " + COD_TIPO_SOPORTE);
                log.Info("CODIGO : SO7, "+ INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("SO7", log.Logger.Name, "CONSULTA_POR_CODIGO_SOPORTE_REQUERIDO", INFO));
                HILO.Start();

                return CONTEXTODATOS.CAUSA_RETIROS_TIPO_SOPORTES.SqlQuery("RETIROS.CONSULTAR_SOPORTE_VERIFICA_REQUERIDO @COD_TIPO_SOPORTE={0},@COD_CAUSA_RETIRO={1}",
                COD_TIPO_SOPORTE, COD_CAUSA_RETIRO)
                //.SingleOrDefault<SOPORTES>();
                .Select(x => 
                            new CAUSA_RETIROS_TIPO_SOPORTES
                            {
                                  COD_CAUSA_RETIRO = x.COD_CAUSA_RETIRO, 
                                  COD_CAUSA_RETIRO_TIPO_SOPORTE = x.COD_CAUSA_RETIRO_TIPO_SOPORTE, 
                                  COD_TIPO_SOPORTE = x.COD_TIPO_SOPORTE , 
                                  COD_USUARIO_CREA = x.COD_USUARIO_CREA, 
                                  COD_USUARIO_MODIFICA = x.COD_USUARIO_MODIFICA, 
                                  ESTADO = x.ESTADO, 
                                  FECHA_CREA = x.FECHA_CREA, 
                                  FECHA_MODIFICA = x.FECHA_MODIFICA, 
                                  REQUERIDO = x.REQUERIDO, 
                                  TIPO_SOPORTES = x.TIPO_SOPORTES
                            }).SingleOrDefault<CAUSA_RETIROS_TIPO_SOPORTES>();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : SO7  recuperando CONSULTA_POR_CODIGO_SOPORTE_REQUERIDO :  {0}, {1}  ", COD_TIPO_SOPORTE, ex.StackTrace);
                ex.HelpLink = "SO7";

                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }


        public void GUARDAR()
        {
            try
            {  
                string INFO = ("Iniciando Método GUARDAR ");
                log.Info("CODIGO : SO8" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("SO8", log.Logger.Name, "GUARDAR", INFO));
                HILO.Start();
                
                CONTEXTODATOS.SaveChanges();

                log.Info("Finalizado con éxito Método GUARDAR");

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : SO8  GUARDAR en la linea  {0} ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "SO8" : ex.HelpLink);
   

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


    public interface ISOPORTES_REP
    {
        SOPORTES CONSULTA_POR_CODIGO(decimal _COD_RETIRO);
        SOPORTES CONSULTA_SOPORTE_POR_CODIGO(decimal _COD_RETIRO);
        SOPORTES APROBAR_SOPORTE_POR_CODIGO(decimal COD_SOPORTE, bool APROBADO, string USUARIO);
        SOPORTES OBTENER_ARCHIVO_POR_CODIGO(decimal COD_SOPORTE);
        void CREAR_SOPORTE(SOPORTES SOPORTE);
		void ACTUALIZAR_SOPORTE(SOPORTES SOPORTE);
        CAUSA_RETIROS_TIPO_SOPORTES CONSULTA_POR_CODIGO_SOPORTE_REQUERIDO( decimal COD_TIPO_SOPORTE, decimal COD_CAUSA_RETIRO);

        void GUARDAR();    
    }
}
