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
  public  class DEPURACION_REP: IDEPURACION_REP, IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private CONTEXTO CONTEXTODATOS;

        public DEPURACION_REP(CONTEXTO _CONTEXTO)
        {
            CONTEXTODATOS = _CONTEXTO;
        }


        public void GUARDA_DEPURARCION(DEPURARCION DEPURAR)
        {
            try
            {
                log.Info("CODIGO : DET1, Iniciando Método GUARDA_DEPURARCION");
                CONTEXTODATOS.DEPURARCION.Add(DEPURAR);

               // CONTEXTODATOS.Entry(ERROR).State = EntityState.Modified;
                //log.Info("CODIGO : DETR1,Finalizado con éxito Método GUARDA_DEPURARCION");

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : DET1,  Método GUARDA_DEPURARCION-GUARDAR, {0} ", ex.StackTrace);
            }
        }

                     
        public void GUARDAR()
        {
            try
            {
                log.Info("CODIGO : DET2, Iniciando Método GUARDA_DEPURARCION-GUARDAR");
                CONTEXTODATOS.SaveChanges();
                //log.Info("CODIGO : DETR2, Finalizado con éxito Método GUARDA_ERROR-GUARDAR");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : DET2,  Método GUARDA_DEPURARCION-GUARDAR,{0} ", ex.StackTrace);
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


    public  interface IDEPURACION_REP
    {

        void GUARDA_DEPURARCION(DEPURARCION DEPURAR);
        void GUARDAR();
     }

}
