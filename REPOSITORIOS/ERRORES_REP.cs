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

namespace REPOSITORIOS
{
  public  class ERRORES_REP:IERRORES_REP,IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private CONTEXTO CONTEXTODATOS;

        public ERRORES_REP(CONTEXTO _CONTEXTO)
        {
            CONTEXTODATOS = _CONTEXTO;
        }


        public void GUARDA_ERROR(ERRORES ERROR)
        {     
            try
            {
                log.Info("CODIGO : ERE1, Iniciando Método GUARDA_ERROR");
                CONTEXTODATOS.ERRORES.Add(ERROR);
                //log.Info("CODIGO : ER1, Finalizado con éxito Método GUARDA_ERROR");

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : ERE1,  Método GUARDA_ERROR-GUARDAR ", ex.StackTrace);
            }
        }
        
                     
        public void GUARDAR()
        {
            try
            {
                log.Info("CODIGO : ERE2, Iniciando Método GUARDA_ERROR-GUARDAR");
                CONTEXTODATOS.SaveChanges();
                //log.Info("CODIGO : ERE2, Finalizado con éxito Método GUARDA_ERROR-GUARDAR");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : ERE2,  Método GUARDA_ERROR-GUARDAR ", ex.StackTrace);
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


    public  interface IERRORES_REP
    {
        void GUARDA_ERROR(ERRORES _ERROR);
        void GUARDAR();
     }

}
