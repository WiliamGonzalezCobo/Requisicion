using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MODELO_DATOS;
using log4net;
using System.Threading;
using REPOSITORIOS.TRAZA_LOG;

namespace REPOSITORIOS
{
    public  class TIPO_SOPORTES_REP: ITIPO_SOPORTES_REP, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private CONTEXTO CONTEXTODATOS;

        public TIPO_SOPORTES_REP(CONTEXTO _CONTEXTO)
        {
            CONTEXTODATOS = _CONTEXTO;
        }

        /*METODO PARA CONSULTAR EL TIPO DE RETIRO PARA RETIROS SI ES OBLIGATORIO */
        public IEnumerable<TIPO_SOPORTES> CONSULTA_TIPO_RETIRO(decimal COD_CAUSA_RETIRO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTA_TIPO_RETIRO");
                log.Info("CODIGO : TI1" + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("TI1", log.Logger.Name, "CONSULTA_TIPO_RETIRO", INFO));
                HILO.Start();              

                return CONTEXTODATOS.CAUSA_RETIROS_TIPO_SOPORTES.SqlQuery("RETIROS.CONSULTAR_TIPO_RETIRO  @COD_CAUSA_RETIRO={0}"
                                                                        , COD_CAUSA_RETIRO).ToList().Select(x =>

                    new TIPO_SOPORTES
                    {
                        COD_TIPO_SOPORTE = x.COD_TIPO_SOPORTE,
                        NOMBRE = x.TIPO_SOPORTES.NOMBRE,
                        ESTADO = x.ESTADO,
                        COD_USUARIO_CREA = x.COD_USUARIO_CREA,
                        FECHA_CREA = x.FECHA_CREA,
                        COD_USUARIO_MODIFICA = x.COD_USUARIO_MODIFICA,
                        FECHA_MODIFICA = x.FECHA_MODIFICA,
                        REQUERIDO = x.REQUERIDO
                    }
                    );
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : TI1  recuperando el codigo  de la consuta tipo retiro : {0}, {1} ", COD_CAUSA_RETIRO, ex.StackTrace);
                ex.HelpLink = "TI1";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }


        /*GUARDA CAMBIOS PARA CREAR Y ACTUALIZAR*/
        public void GUARDAR()
        {
            CONTEXTODATOS.SaveChanges();
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

    public interface ITIPO_SOPORTES_REP
    {
       IEnumerable<TIPO_SOPORTES> CONSULTA_TIPO_RETIRO(decimal COD_CAUSA_RETIRO);
       void GUARDAR();
    }
}
