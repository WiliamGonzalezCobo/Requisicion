using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REPOSITORIOS;
using REPOSITORIOS.SEGURIDAD;
using MODELO_DATOS.MODELOS_SEGURIDAD;
using LOGICA.MODELO_LOGICA;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.DirectoryServices;
using log4net;
using System.Threading;
using REPOSITORIOS.TRAZA_LOG;

namespace LOGICA.SEGURIDAD
{
    public class USUARIO
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IUSUARIO_REP _REPOSITORIO = new USUARIOS_REP();
    
        private async Task<APPLICATIONUSER> VALIDAR(string _USUARIO)
        {
            try
            {
                string INFO = ("Iniciando Método  VALIDAR USUARIO, USUARIO : " + _USUARIO);
                log.Info("CODIGO : LGUS1," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGUS1", log.Logger.Name, "VALIDAR", INFO));
                HILO.Start();

                APPLICATIONUSER USUARIO = await _REPOSITORIO.VALIDAR_USUARIO(_USUARIO.ToUpper());

                if (USUARIO == null)
                {
                    return null;
                }
                else
                {
                    return USUARIO;
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGUS1,  Método VALIDA USUARIO, USUARIO : {0}, {1} ", _USUARIO, ex.StackTrace);
                ex.HelpLink = "LGUS1";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
        }

        public async Task<Boolean> CREAR(string _USUARIO)
        {
            try
            {
                string INFO = ("Iniciando Método  CREAR USUARIO, USUARIO : " + _USUARIO);
                log.Info("CODIGO : LGUS2," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGUS1", log.Logger.Name, "CREAR", INFO));
                HILO.Start();

                IdentityResult USUARIO = await _REPOSITORIO.CREAR_USUARIO(_USUARIO);
                if (USUARIO == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGUS2,  Método CREAR USUARIO, USUARIO : {0}, {1} ", _USUARIO, ex.StackTrace);
                ex.HelpLink = "LGUS2";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
        }


        public async Task<APPLICATIONUSER> AUTENTICAR(string USUARIO, string PASSWORD)
        {
            try
            {
                string INFO = ("Iniciando Método  AUTENTICAR USUARIO, USUARIO : " + USUARIO);
                log.Info("CODIGO : LGUS3," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGUS1", log.Logger.Name, "AUTENTICAR", INFO));
                HILO.Start();

                AUTENTICA_DIRECTORIO_MODELO _AUTENTICA = ESTA_AUTENTICADO(USUARIO, PASSWORD);

                if (_AUTENTICA.SUCCESS==true)
                {
                    APPLICATIONUSER AUTENTICA_USUARIO_BASE_DATOS = await VALIDAR(USUARIO);
                    if (AUTENTICA_USUARIO_BASE_DATOS != null)
                    {
                        return AUTENTICA_USUARIO_BASE_DATOS;
                    }
                    else
                    {
                        return null;
                    }

                }
                else if (_AUTENTICA.ERROR!=null)
                {
                    return null;
                }

                return null;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGUS3,  Método AUTENTICAR USUARIO, USUARIO : {0}, {1} ", USUARIO, ex.StackTrace);
                ex.HelpLink = "LGUS3";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
        }

        //public async Task<AUTENTICA_DIRECTORIO_MODELO> ESTA_AUTENTICADO(string USUARIO, string CONTRASENA)
        public AUTENTICA_DIRECTORIO_MODELO ESTA_AUTENTICADO(string USUARIO, string CONTRASENA)
        {
            try
            {
                string INFO = ("Iniciando Método  ESTA_AUTENTICADO EN DIRECTORIO ACTIVO USUARIO, USUARIO : " + USUARIO);
                log.Info("CODIGO : LGUS4," + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGUS1", log.Logger.Name, "ESTA_AUTENTICADO", INFO));
                HILO.Start();

                AUTENTICA_DIRECTORIO_MODELO _AUTENTICA = new AUTENTICA_DIRECTORIO_MODELO();

				
				string DOMINIO_SERVIDOR = "LDAP://" + ((System.Configuration.ConfigurationManager.AppSettings["Dominio_Directorio_Activo"]) == null ? "CEET" : System.Configuration.ConfigurationManager.AppSettings["Dominio_Directorio_Activo"]);

				_AUTENTICA.SUCCESS = false;

                try
                {
                    DirectoryEntry ENTRADA = new DirectoryEntry(DOMINIO_SERVIDOR, USUARIO, CONTRASENA);
                    object OBJETO_NATIVO = ENTRADA.NativeObject;
                    _AUTENTICA.SUCCESS = true;
                }
                catch (DirectoryServicesCOMException cex)
                {//NO AUTENTICADO; RAZÓN POR LA CUAL ESTÁ EN CEX
                    _AUTENTICA.ERROR = cex.Message;
                }
                catch (Exception ex)
                {   //NO AUTENTICADO DEBIDO A ALGUNA OTRA EXCEPCIÓN [ESTO ES OPCIONAL]
                    _AUTENTICA.ERROR = ex.Message;
                }
                return _AUTENTICA;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGUS4,  Método ESTA_AUTENTICADO EN DIRECTORIO ACTIVO USUARIO : {0}, {1} ", USUARIO, ex.StackTrace);
                ex.HelpLink = "LGUS4";
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();
                throw ex;
            }
        }





    }
}
