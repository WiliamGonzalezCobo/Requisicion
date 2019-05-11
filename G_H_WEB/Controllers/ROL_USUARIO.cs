using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using G_H_WEB.Models;
using log4net;
using LOGICA;
using Microsoft.AspNet.Identity.Owin;
using MODELO_DATOS.MODELOS_SEGURIDAD;
using REPOSITORIOS.TRAZA_LOG;

namespace G_H_WEB.Controllers
{
	public class ROL_USUARIO : Controller
	{

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        System.Security.Principal.IPrincipal USUARIO;
		public ROL_USUARIO(System.Security.Principal.IPrincipal _USUARIO)
		{
			USUARIO = _USUARIO;
		}

		public String OBTENER()
		{
            try
            {
                string INFO = ("Iniciando Método  OBTENER ROL ");
                log.Info("CODIGO : CTRUS1, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRRE2", log.Logger.Name, "OBTENER", INFO));
                HILO.Start();

                string ROL = "";
                if (USUARIO.IsInRole("Jefe"))
                {
                    ROL = "Jefe," + ROL;
                }

                if (USUARIO.IsInRole("BP"))
                {
                    ROL = "BP," + ROL;
                }

                if (USUARIO.IsInRole("Proveedor"))
                {
                    ROL = "Proveedor," + ROL;
                }
                return ROL;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRUS1,  Método OBTENER ROL, {0} ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRUS1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

	}
}