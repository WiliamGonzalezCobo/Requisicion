using System;
using System.Configuration;
namespace UTILS.Settings
{
    /// <summary>
    /// Clase que administra los Settings del WebCofig de la aplicacion Web
    /// </summary>
    public class SettingsManager
    {
        #region Public Methods

        public static string PerfilJefe
        {
            get { return GetSettings("PerfilJefe"); }
        }

        public static string PerfilController
        {
            get { return GetSettings("PerfilController"); }
        }

        public static string PerfilBp
        {
            get { return GetSettings("PerfilBp"); }
        }

        public static string PerfilUSC
        {
            get { return GetSettings("PerfilUSC"); }
        }

        public static string PerfilRRHH
        {
            get { return GetSettings("PerfilRRHH"); }
        }

        public static string Urlapi
        {
            get { return GetSettings("URL_WEB_API"); }
        }
        public static string ApiUsuario
        {
            get { return GetSettings("ApiUsuario"); }
        }

        public static string ApiPassword
        {
            get { return GetSettings("ApiPassword"); }
        }
        public static int CodTipoReqPresupuestada
        {
            get { return Convert.ToInt32(GetSettings("CodTipoReqPresupuestada")); }
        }

        public static int CodTipoReqNoPresupuestada
        {
            get { return Convert.ToInt32(GetSettings("CodTipoReqNoPresupuestada")); }
        }

        public static int CodTipoReqIncapacidad
        {
            get { return Convert.ToInt32(GetSettings("CodTipoReqIncapacidad")); }
        }

        public static int CodTipoReqLicencia
        {
            get { return Convert.ToInt32(GetSettings("CodTipoReqLicencia")); }
        }
        public static int CodTipoReqModificacion
        {
            get { return Convert.ToInt32(GetSettings("CodTipoReqModificacion")); }
        }

        public static int EstadoAporbadoController
        {
            get { return Convert.ToInt32(GetSettings("EstadoAporbadoController")); }
        }

        public static int EstadoDevueltaRRHH
        {
            get { return Convert.ToInt32(GetSettings("EstadoDevueltaRRHH")); }
        }

        public static int EstadoDevueltaUSC
        {
            get { return Convert.ToInt32(GetSettings("EstadoDevueltaUSC")); }
        }
        public static int EstadoDevueltaController
        {
            get { return Convert.ToInt32(GetSettings("EstadoDevueltaController")); }
        }
        public static int EstadoAprobadoJefe
        {
            get { return Convert.ToInt32(GetSettings("EstadoAprobadoJefe")); }
        }

        public static int CodigoCorreoPlantilla {
            get { return Convert.ToInt32(GetSettings("CodigoCorreoPlantilla")); }
        }

        public static string DominioParaController {
            get { return GetSettings("DominioParaController"); }
        }

        public static string TextoBtnRechazar
        {
            get { return GetSettings("TextoBtnRechazar"); }
        }
        #endregion

        #region Private Methods

        private static string GetSettings(string key)
        {
            return string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]) ? "" : ConfigurationManager.AppSettings[key].ToString();
        }

        #endregion
    }
}
