using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO_DATOS;
using log4net;
using REPOSITORIOS.TRAZA_LOG;
using System.Threading;

namespace REPOSITORIOS
{

    public class CONFIGURACION_CORREOS_REP : ICONFIGURACION_CORREOS_REP, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private CONTEXTO CONTEXTODATOS;
        public CONFIGURACION_CORREOS_REP(CONTEXTO _CONTEXTO)
        {
            CONTEXTODATOS = _CONTEXTO;
        }


        public IEnumerable<CORREOS> CONSULTAR_CORREOS()
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTA_TIPO_RETIRO");
                log.Info("CODIGO : COFCO1" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("COFCO1", log.Logger.Name, "CONSULTAR_CORREOS", INFO));
                HILO.Start();

                return CONTEXTODATOS.CORREOS.SqlQuery(" CONFIGURACIONES.CONSULTAR_CORREO").ToList().Select(CORREO =>
                    new CORREOS
                    {
                        COD_CORREO = CORREO.COD_CORREO,
                        COD_TIPO_CORREO = CORREO.COD_TIPO_CORREO,
                        SERVIDOR_SMTP = CORREO.SERVIDOR_SMTP,
                        CUENTA_CORREO = CORREO.CUENTA_CORREO,
                        CUENTA = CORREO.CUENTA,
                        SALTO = CORREO.SALTO,
                        IV = CORREO.IV,
                        CONTRASENA = CORREO.CONTRASENA,
                        ES_HTML = CORREO.ES_HTML,
                        USA_SSL = CORREO.USA_SSL,
                        ESTADO = CORREO.ESTADO,
                        COD_USUARIO_CREA = CORREO.COD_USUARIO_CREA,
                        FECHA_CREA = CORREO.FECHA_CREA,
                        COD_USUARIO_MODIFICA = CORREO.COD_USUARIO_MODIFICA,
                        FECHA_MODIFICA = CORREO.FECHA_MODIFICA,
                        PUERTO=CORREO.PUERTO,
                        ASUNTO=CORREO.ASUNTO
                    });

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : COFCO1  recuperando la CONSULTAR_CORREOS en la linea  {0} ", ex.StackTrace);
                ex.HelpLink = "COFCO1";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

        public CORREOS CONSULTAR_CORREO_POR_COD_CORREO(decimal COD_CORREO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR_CORREO_POR_COD_CORREO por COD_CORREO : "+ COD_CORREO);
                log.Info("CODIGO : COFCO2" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("COFCO2", log.Logger.Name, "CONSULTAR_CORREO_POR_COD_CORREO", INFO));
                HILO.Start();


                return CONTEXTODATOS.CORREOS.SqlQuery("CONFIGURACIONES.CONSULTAR_CORREO_POR_COD_CORREO @COD_CORREO={0}", COD_CORREO).Select(CORREO =>
                    new CORREOS
                    {
                        COD_CORREO = CORREO.COD_CORREO,
                        COD_TIPO_CORREO = CORREO.COD_TIPO_CORREO,
                        SERVIDOR_SMTP = CORREO.SERVIDOR_SMTP,
                        CUENTA_CORREO = CORREO.CUENTA_CORREO,
                        CUENTA = CORREO.CUENTA,
                        SALTO = CORREO.SALTO,
                        IV = CORREO.IV,
                        CONTRASENA = CORREO.CONTRASENA,
                        ES_HTML = CORREO.ES_HTML,
                        USA_SSL = CORREO.USA_SSL,
                        ESTADO = CORREO.ESTADO,
                        COD_USUARIO_CREA = CORREO.COD_USUARIO_CREA,
                        FECHA_CREA = CORREO.FECHA_CREA,
                        COD_USUARIO_MODIFICA = CORREO.COD_USUARIO_MODIFICA,
                        FECHA_MODIFICA = CORREO.FECHA_MODIFICA,
                        PUERTO = CORREO.PUERTO,
                        ASUNTO = CORREO.ASUNTO
                    }).SingleOrDefault<CORREOS>();

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : COFCO2  recuperando  CONSULTAR_CORREO_POR_COD_CORREO po el COD_CORREO : {0}, {1}", COD_CORREO, ex.StackTrace);
                ex.HelpLink = "COFCO2";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }



        public IEnumerable<TIPOS_CORREOS> CONSULTAR_TIPOS_CORREOS()
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR_TIPOS_CORREOS " );
                log.Info("CODIGO : COFCO3" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("COFCO3", log.Logger.Name, "CONSULTAR_TIPOS_CORREOS", INFO));
                HILO.Start();


                return CONTEXTODATOS.TIPOS_CORREOS.SqlQuery("CONFIGURACIONES.CONSULTAR_TIPO_CORREO").ToList().Select(TIPO_CORREO =>
                    new TIPOS_CORREOS
                    {
                        COD_TIPO_CORREO = TIPO_CORREO.COD_TIPO_CORREO,
                        NOMBRE = TIPO_CORREO.NOMBRE,
                        ESTADO = TIPO_CORREO.ESTADO,
                        COD_USUARIO_CREA = TIPO_CORREO.COD_USUARIO_CREA,
                        FECHA_CREA = TIPO_CORREO.FECHA_CREA,
                        COD_USUARIO_MODIFICA = TIPO_CORREO.COD_USUARIO_MODIFICA,
                        FECHA_MODIFICA = TIPO_CORREO.FECHA_MODIFICA
                    });

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : COFCO3  recuperando  CONSULTAR_TIPOS_CORREOS  en la linea : {0}", ex.StackTrace);
                ex.HelpLink = "COFCO3";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }
        public TIPOS_CORREOS CONSULTAR_TIPO_CORREO_POR_CODIGO(decimal COD_TIPO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR_TIPO_CORREO_POR_CODIGO por COD_TIPO : " + COD_TIPO);
                log.Info("CODIGO : COFCO4" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("COFCO4", log.Logger.Name, "CONSULTAR_TIPO_CORREO_POR_CODIGO", INFO));
                HILO.Start();


                return CONTEXTODATOS.TIPOS_CORREOS.SqlQuery("CONFIGURACIONES.CONSULTAR_TIPO_CORREO_PO_COD_TIPO @COD_TIPO={0}").Select(TIPO_CORREO =>
                    new TIPOS_CORREOS
                    {
                        COD_TIPO_CORREO = TIPO_CORREO.COD_TIPO_CORREO,
                        NOMBRE = TIPO_CORREO.NOMBRE,
                        ESTADO = TIPO_CORREO.ESTADO,
                        COD_USUARIO_CREA = TIPO_CORREO.COD_USUARIO_CREA,
                        FECHA_CREA = TIPO_CORREO.FECHA_CREA,
                        COD_USUARIO_MODIFICA = TIPO_CORREO.COD_USUARIO_MODIFICA,
                        FECHA_MODIFICA = TIPO_CORREO.FECHA_MODIFICA
                    }).SingleOrDefault<TIPOS_CORREOS>();

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : COFCO4  recuperando  CONSULTAR_TIPO_CORREO_POR_CODIGO por COD_TIPO : {0},{1}", COD_TIPO, ex.StackTrace);
                ex.HelpLink = "COFCO4";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

        public IEnumerable<PLANTILLAS_CORREOS> CONSULTAR_PLANTILLAS_POR_COD_CORREO(decimal COD_CORREO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR_CORREO_POR_COD_CORREO,  COD_CORREO : " + COD_CORREO);
                log.Info("CODIGO : COFCO5" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("COFCO5", log.Logger.Name, "CONSULTAR_PLANTILLAS_POR_COD_CORREO", INFO));
                HILO.Start();


                return CONTEXTODATOS.PLANTILLAS_CORREOS.SqlQuery("CONFIGURACIONES.CONSULTAR_PLANTILLAS_POR_COD_CORREO @COD_CORREO={0}", COD_CORREO).ToList().Select(x =>
                    new PLANTILLAS_CORREOS
                    {
                        COD_PLANTILLA = x.COD_PLANTILLA,
                        COD_CORREO = x.COD_CORREO,
                        PLANTILLA = x.PLANTILLA,
                        ESTADO = x.ESTADO,
                        COD_USUARIO_CREA = x.COD_USUARIO_CREA,
                        FECHA_CREA = x.FECHA_CREA,
                        COD_USUARIO_MODIFICA = x.COD_USUARIO_MODIFICA,
                        FECHA_MODIFICA = x.FECHA_MODIFICA
                        
                    });
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : COFCO5  recuperando  CONSULTAR_TIPO_CORREO_POR_CODIGO,  COD_CORREO : {0},{1}", COD_CORREO, ex.StackTrace);
                ex.HelpLink = "COFCO5";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

        public IEnumerable<CORREOS_DESTINOS> CONSULTAR_DESTINOS_POR_COD_CORREO(decimal COD_CORREO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR_DESTINOS_POR_COD_CORREO, COD_CORREO : " + COD_CORREO);
                log.Info("CODIGO : COFCO6" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("COFCO2", log.Logger.Name, "CONSULTAR_DESTINOS_POR_COD_CORREO", INFO));
                HILO.Start();


                return CONTEXTODATOS.CORREOS_DESTINOS.SqlQuery("CONFIGURACIONES.CONSULTAR_DESTINOS_POR_COD_CORREO @COD_CORREO={0}", COD_CORREO).ToList().Select(x =>
                    new CORREOS_DESTINOS
                    {
                        COD_CORREO_DESTINO = x.COD_CORREO_DESTINO,
                        COD_CORREO = x.COD_CORREO,
                        CORREO = x.CORREO,
                        ESTADO = x.ESTADO,
                        COD_USUARIO_CREA = x.COD_USUARIO_CREA,
                        FECHA_CREA = x.FECHA_CREA,
                        COD_USUARIO_MODIFICA = x.COD_USUARIO_MODIFICA,
                        FECHA_MODIFICA = x.FECHA_MODIFICA
                    });

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : COFCO6  recuperando  CONSULTAR_DESTINOS_POR_COD_CORREO,  COD_CORREO : {0},{1}", COD_CORREO, ex.StackTrace);
                ex.HelpLink = "COFCO6";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

        public void CREAR_CORREO(CORREOS CORREO)
        {
            try
            {
                string INFO = ("Iniciando Método CREAR_CORREO ");
                log.Info("CODIGO : COFCO7" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("COFCO7", log.Logger.Name, "CREAR_CORREO", INFO));
                HILO.Start();

                CONTEXTODATOS.CORREOS.Add(CORREO);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : COFCO7  GUARDAR en la linea  {0} ", ex.StackTrace);
                ex.HelpLink = "COFCO7";

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
                log.Info("CODIGO : COFCO8" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("COFCO8", log.Logger.Name, "GUARDAR", INFO));
                HILO.Start();


                CONTEXTODATOS.SaveChanges();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : COFCO8  GUARDAR en la linea  {0} ", ex.StackTrace);
                ex.HelpLink = "COFCO8";

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


    public interface ICONFIGURACION_CORREOS_REP
    {
      IEnumerable<CORREOS> CONSULTAR_CORREOS();
        CORREOS CONSULTAR_CORREO_POR_COD_CORREO(decimal COD_CORREO);
       IEnumerable<TIPOS_CORREOS> CONSULTAR_TIPOS_CORREOS();
        TIPOS_CORREOS CONSULTAR_TIPO_CORREO_POR_CODIGO(decimal COD_TIPO);
        IEnumerable<PLANTILLAS_CORREOS> CONSULTAR_PLANTILLAS_POR_COD_CORREO(decimal COD_CORREO);
        IEnumerable<CORREOS_DESTINOS> CONSULTAR_DESTINOS_POR_COD_CORREO(decimal COD_CORREO);
        void CREAR_CORREO(CORREOS CORREO);
        void GUARDAR();
    }
}
