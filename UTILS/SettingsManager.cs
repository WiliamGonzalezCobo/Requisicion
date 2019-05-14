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
            get { return GetSettings("Urlapi"); }
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
