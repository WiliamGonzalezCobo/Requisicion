using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MODELO_DATOS.MODELOS_SEGURIDAD;
using REPOSITORIOS.TRAZA_LOG;

namespace REPOSITORIOS.SEGURIDAD
{
    public class USUARIOS_REP : IUSUARIO_REP, IDisposable
	{
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        UserManager<APPLICATIONUSER> userManager;

		public USUARIOS_REP()
			: this(new UserManager<APPLICATIONUSER>(new UserStore<APPLICATIONUSER>(new ApplicationDbContext())))
		{
		}

		public USUARIOS_REP(UserManager<APPLICATIONUSER> userManager)
		{
			UserManager = userManager;
		}

		public UserManager<APPLICATIONUSER> UserManager { get; private set; }

        public async Task<APPLICATIONUSER> VALIDAR_USUARIO(String _USUARIO)
        {
            try
            {
                string INFO = ("Iniciando Método  VALIDAR_USUARIO USUARIO : "+ _USUARIO);
                log.Info("CODIGO : CU1," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CU1", log.Logger.Name, "VALIDAR_USUARIO", INFO));
                HILO.Start();

                APPLICATIONUSER user = await UserManager.FindAsync(_USUARIO, _USUARIO);
                APPLICATIONUSER usuario = UserManager.Users.Where(x => x.UserName == _USUARIO).First();
                return usuario;
                //if (user != null)
                //{
                //	//await SignInAsync(user, false);
                //	return "AUTORIZADO";
                //}
                //else
                //{
                //	return "Invalid username or password.";
                //}

            }

            //private async Task SignInAsync(APPLICATIONUSER user, bool isPersistent)
            //{
            //	AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            //	var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            //	AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
            //}


            //private IAuthenticationManager AuthenticationManager
            //{
            //	get
            //	{
            //		return HttpContext.GetOwinContext().Authentication;
            //	}
            //}

            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CU1,  Método VALIDAR_USUARIO USUARIO : {0},{1}",_USUARIO, ex.StackTrace);
                ex.HelpLink = "CU1";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }














        public async Task<IdentityResult> CREAR_USUARIO(String _USUARIO)
		{
            try
            {
                string INFO = ("Iniciando Método  CREAR_USUARIO USUARIO : " + _USUARIO);
                log.Info("CODIGO : CU2," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("CU2", log.Logger.Name, "CREAR_USUARIO", INFO));
                HILO.Start();

                var user = new APPLICATIONUSER() { UserName = _USUARIO };
                IdentityResult result = await UserManager.CreateAsync(user, _USUARIO);
                return result;
                //if (result.Succeeded)
                //{
                //return "CREADO";
                //}
                //else
                //{
                ////AddErrors(result);
                //return "ERROR CREANDO";
                //}

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : CU2,  Método CREAR_USUARIO USUARIO : {0},{1}", _USUARIO, ex.StackTrace);
                ex.HelpLink = "CU2";
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
					//CONTEXTODATOS.Dispose();
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


	public interface IUSUARIO_REP
	{
		Task<APPLICATIONUSER> VALIDAR_USUARIO(String _USUARIO);

		Task<IdentityResult> CREAR_USUARIO(String _USUARIO);
	}
}
