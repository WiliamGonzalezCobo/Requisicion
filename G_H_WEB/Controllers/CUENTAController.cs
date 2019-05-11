using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MODELO_DATOS.MODELOS_SEGURIDAD;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using REPOSITORIOS.TRAZA_LOG;
using G_H_WEB.Models;
using log4net;
using System.Threading;

namespace G_H_WEB.Controllers
{
    public class CUENTAController : Controller
    {
        private LOGICA.SEGURIDAD.USUARIO VALIDA = new LOGICA.SEGURIDAD.USUARIO();
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CUENTAController()
				  : this(new UserManager<APPLICATIONUSER>(new UserStore<APPLICATIONUSER>(new ApplicationDbContext())))
		{
		}

		public CUENTAController(UserManager<APPLICATIONUSER> userManager)
        {
            try
            {
                string INFO = ("Iniciando Método  CUENTAController");
                log.Info("CODIGO : CTRCU1," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRCU1", log.Logger.Name, "CUENTAController", INFO));
                HILO.Start();

                UserManager = userManager;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRCU1,  Método CUENTAController,  {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRCU1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
        }

		public UserManager<APPLICATIONUSER> UserManager { get; private set; }

		// GET: Cuenta
		public ActionResult VALIDAR()
        {
            try
            {
                string INFO = ("Iniciando Método  VALIDAR USUARIOS BASE DE DATOS");
                log.Info("CODIGO : CTRCU2," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRCU2", log.Logger.Name, "VALIDAR", INFO));
                HILO.Start();

                if (User.Identity.IsAuthenticated)
                {
                   return RedirectToAction("CONSULTAR", "SOLICITUD");
                }

                return View();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRCU2,  Método VALIDAR USUARIOS BASE DE DATOS,  {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRCU2" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
        }
        [HttpPost]
        public async Task<ActionResult> VALIDAR(CUENTA_VALIDAR_ViewModel VALIDAR)
        {

            try
            {
                string INFO = ("Iniciando Método  VALIDAR USUARIOS DIRECTORIO ACTIVO");
                log.Info("CODIGO : CTRCU3," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRCU3", log.Logger.Name, "VALIDAR", INFO));
                HILO.Start();

                if (ModelState.IsValid)
                {
                    String USUARIO = VALIDAR.Usuario.ToUpper();
                    String CONTRASENA = VALIDAR.Contraseña;            

                    var RESPUESTA_DIRECTORIO = await VALIDA.AUTENTICAR(USUARIO, CONTRASENA);

                    if (RESPUESTA_DIRECTORIO != null)
                    {
                        await SIGNINASYNC(RESPUESTA_DIRECTORIO, false);
                     
                        return RedirectToAction("CONSULTAR", "SOLICITUD");
                    }
                    else
                    {
                        ViewBag.MensajeAlerta = "El usuario y/o contraseña son incorrectos";
                        return View();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRCU3,  Método VALIDAR USUARIOS DIRECTORIO ACTIVO,  {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRCU3" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
        }
        	

		private async Task  SIGNINASYNC(APPLICATIONUSER user, bool isPersistent)
		{
            try
            {
                string INFO = ("Iniciando Método  SIGNINASYNC,  USUARIO : " + user);
                log.Info("CODIGO : CTRCU4," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRCU3", log.Logger.Name, "SIGNINASYNC", INFO));
                HILO.Start();

                AUTHENTICATIONMANAGER.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AUTHENTICATIONMANAGER.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRCU4,  Método SIGNINASYNC, USUARIO : {0}, {1}", user, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRCU4" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
        }
		
		public ActionResult SALIR()
        {
            try
            {
                string INFO = ("Iniciando Método  SALIR");
                log.Info("CODIGO : CTRCU5," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CTRCU5", log.Logger.Name, "SALIR", INFO));
                HILO.Start();

                AUTHENTICATIONMANAGER.SignOut();
                return RedirectToAction("VALIDAR", "CUENTA");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CTRCU5,  Método SALIR, {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "CTRCU5" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }

        }
        private IAuthenticationManager AUTHENTICATIONMANAGER
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}