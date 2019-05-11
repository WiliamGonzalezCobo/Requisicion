using G_H_WEB.Models;
using log4net;
using LOGICA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using REPOSITORIOS.TRAZA_LOG;

namespace G_H_WEB.Controllers
{
    [Authorize]
    public class SOLICITUDController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ERROR_ViewModel ERROR_GENERADO = new ERROR_ViewModel();
        // GET: SOLICITUD
        public ActionResult CONSULTAR(SOLICITUD_CONSULTA_ViewModel SOLICITUD)//string VISTA,string CONTROLER)
        {
            //SOLICITUD_CONSULTA_ViewModel SOLICITUD = new SOLICITUD_CONSULTA_ViewModel();
            //SOLICITUD.BUSCARSOLICITUD = CONSULTA;
            string CONSULTA = SOLICITUD.BUSCARSOLICITUD;

            try
            {
                string INFO = ("Iniciando Método  CONSULTAR SOLICITUD");
                log.Info("CODIGO : CTRSL1," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRSL1", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();

                ROL_USUARIO ROLE_USUARIO = new ROL_USUARIO(User);
                RETIRO LOGICA_RETIRO = new RETIRO();
          

			IEnumerable<SOLICITUD_ViewModel> SOLICITUDES = LOGICA_RETIRO.CONSULTAR(ROLE_USUARIO.OBTENER(), CONSULTA, User.Identity.Name).Select(
                S => new SOLICITUD_ViewModel
                {
                    COD_RETIRO = S.COD_RETIRO,
                    NOMBRE = S.NOMBRE,
                    CAUSAL = S.NOMBRE_CAUSA_RETIRO,
                    ESTADO = S.ESTADOS.NOMBRE,
                    FECHA_SOLICITUD = S.FECHA_CREA.ToString("MM/dd/yy HH:MM"),
                    USUARIO = S.USUARIO
                });
                SOLICITUD.SOLICITUDES = SOLICITUDES;

                return View(SOLICITUD);

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRSL1,  Método CONSULTAR SOLICITUD,  {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRSL1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
 

                ERROR_GENERADO = new ERROR_ViewModel
                {
                    COD_ERROR = ex.HelpLink,
                    DETALLE = ""
                };
                SOLICITUD.ERROR = ERROR_GENERADO;
                return View(SOLICITUD);
                //throw ex;
            }

        }
    }
}