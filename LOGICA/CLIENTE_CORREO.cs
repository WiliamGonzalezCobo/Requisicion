using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPOSITORIOS;
using MODELO_DATOS;
using LOGICA.MODELO_LOGICA;
using REPOSITORIOS.TRAZA_LOG;
using log4net;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Globalization;

namespace LOGICA
{
    public class CLIENTE_CORREO
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private ICONFIGURACION_CORREOS_REP _REPOSITORIO;
		public CLIENTE_CORREO()
		{
			_REPOSITORIO = new REPOSITORIOS.CONFIGURACION_CORREOS_REP(new CONTEXTO());
		}
		//ESTA SOBRECARGA PERMITE PRUBAS AUTOMATICAS POR PROBLEMAS CON MANEJO DE 
		public CLIENTE_CORREO(String CADENA_CONEXION)
		{
			_REPOSITORIO = new REPOSITORIOS.CONFIGURACION_CORREOS_REP(new CONTEXTO(CADENA_CONEXION));
		}


		public CORREOS CONSULTAR(decimal _COD_CORREO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR CORREOS por COD_CORREO: " + _COD_CORREO);
                log.Info("CODIGO : LGCO1, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGCO1", log.Logger.Name, "CONSULTAR", INFO));
                HILO.Start();


                return _REPOSITORIO.CONSULTAR_CORREO_POR_COD_CORREO(_COD_CORREO);


            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGCO1,  Método CONSULTAR CORREOS por _COD_RETIRO : {0}, {1}  ", _COD_CORREO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGCO1" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }


        public TIPOS_CORREOS CONSULTAR_TIPO(decimal _COD_TIPO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR TIPO DE CORREOS POR COD_TIPO : " + _COD_TIPO);
                log.Info("CODIGO : LGCO3, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGCO3", log.Logger.Name, "CONSULTAR_TIPO", INFO));
                HILO.Start();


                return _REPOSITORIO.CONSULTAR_TIPO_CORREO_POR_CODIGO(_COD_TIPO);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGCO3,  Método CONSULTAR TIPO DE CORREOS POR COD_TIPO : {0}, {1} ", _COD_TIPO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGCO3" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }


        public IEnumerable<PLANTILLAS_CORREOS> CONSULTAR_PLANTILLA(decimal _COD_CORREO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR PLANITILLA DE CORREOS POR COD_CORREO : " + _COD_CORREO);
                log.Info("CODIGO : LGCO5, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGCO5", log.Logger.Name, "CONSULTAR_PLANTILLA", INFO));
                HILO.Start();


                return _REPOSITORIO.CONSULTAR_PLANTILLAS_POR_COD_CORREO(_COD_CORREO);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGCO5,  Método CONSULTAR PLANITILLA DE CORREOS POR COD_CORREO : {0}, {1}  ", _COD_CORREO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGCO5" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }

        public IEnumerable<CORREOS_DESTINOS> CONSULTAR_DESTINO(decimal _COD_CORREO)
        {
            try
            {
                string INFO = ("Iniciando Método CONSULTAR DESTINO CORREO POR COD_CORREO : " + _COD_CORREO);
                log.Info("CODIGO : LGCO6, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGCO6", log.Logger.Name, "CONSULTAR_DESTINO", INFO));
                HILO.Start();

                return _REPOSITORIO.CONSULTAR_DESTINOS_POR_COD_CORREO(_COD_CORREO);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGCO6,  CONSULTAR DESTINO CORREO POR COD_CORREO : {0},{1}  ", _COD_CORREO, ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGCO6" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }
        }

        /*insertar un nuevo registro*/
        public void CREA_CORREO()
        {
            try
            {
                string INFO = ("Iniciando Método CREA_CORREO  ");
                log.Info("CODIGO : LGCO7, " + INFO);
                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGCO7", log.Logger.Name, "CREA_CORREO", INFO));
                HILO.Start();

                string _USUARIO = "SYSTEM";
                string SERVIDOR = "10.100.1.16";
                string CUENTA_CORREO = "gestionhumana@eltiempo.com";
                string CONTRASENA = " ";

                CORREO_CONFIGURACION_MODELO _CODIFICACION_CORREO = SALTO(CONTRASENA);
                ENCRIPTAR_MODELO _ENCRIPTAR = ENCRIPTAR(_CODIFICACION_CORREO.TEXTO_SALTO);

                CORREOS CORREO = new CORREOS();
                CORREO.COD_CORREO = 0;
                CORREO.COD_TIPO_CORREO = 1;
                CORREO.SERVIDOR_SMTP = SERVIDOR;
                CORREO.CUENTA_CORREO = CUENTA_CORREO;
                CORREO.CUENTA = CUENTA_CORREO;
                CORREO.SALTO = Convert.ToBase64String(_CODIFICACION_CORREO.SALT);
                CORREO.IV = _ENCRIPTAR.IV_TEXTO;
                CORREO.CONTRASENA = _ENCRIPTAR.ENCRIPTACION_TEXTO;
                CORREO.ES_HTML = true;
                CORREO.USA_SSL = true;
                CORREO.ESTADO = 1;
                CORREO.COD_USUARIO_CREA = _USUARIO;
                CORREO.FECHA_CREA = DateTime.Now;
                CORREO.COD_USUARIO_MODIFICA = _USUARIO;
                CORREO.FECHA_MODIFICA = DateTime.Now;

                _REPOSITORIO.CREAR_CORREO(CORREO);
                _REPOSITORIO.GUARDAR();

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGCO7,  CONSULTAR DESTINO CORREO POR COD_CORREO en la linea :  {0}  ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGCO7" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }


        }


        private CORREO_CONFIGURACION_MODELO SALTO(string CONTRASENA)
        {
            int NUMERO = Convert.ToInt32(CONTRASENA.Length);
            byte[] SALT = GENERAR_SALTO(NUMERO);
            byte[] TEXTO_SALTO = COMPUTAR_HASH(CONTRASENA, SALT);
            CORREO_CONFIGURACION_MODELO CORREO_CODIFICACION = new CORREO_CONFIGURACION_MODELO();
            CORREO_CODIFICACION.SALT = SALT;
            CORREO_CODIFICACION.TEXTO_SALTO = TEXTO_SALTO;
            return CORREO_CODIFICACION;
        }



        /*METODO PARA ENVIAR CORREO*/
        public void ENVIO_CORREO(CORREO_CONFIGURACION_MODELO _DATO_CORREO)
        {

            try
            {
                string INFO = ("Iniciando Método ENVIO_CORREO ");
                log.Info("CODIGO : LGCLC8," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGCLC8", log.Logger.Name, "ENVIO_CORREO", INFO));
                HILO.Start();


                string CORREO_DESTINO = string.Empty;
                foreach (CORREOS_DESTINOS_MODELO DESTINOS in _DATO_CORREO.DESTINOS)
                {
                    CORREO_DESTINO = CORREO_DESTINO + DESTINOS.CORREO + ",";
                }
                CORREO_DESTINO = CORREO_DESTINO.Substring(0, (CORREO_DESTINO.Length) - 1);


                string DATOS_HTML = string.Empty;

                foreach (PLANTILLAS_CORREOS_MODELO PLANTILLA in _DATO_CORREO.PLANTILLAS)
                {
                    DATOS_HTML = PLANTILLA.PLANTILLA;
                }


				/*para cambiar en la plantilla dinamicamente*/
				
				string FECHA ;
				CultureInfo myCIintl = new CultureInfo("es-ES", true);
				if (_DATO_CORREO.RETIRO.FECHA_RETIRO < DateTime.Now)
				{
					FECHA = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", myCIintl.DateTimeFormat);
				}
				else
				{
					FECHA = _DATO_CORREO.RETIRO.FECHA_RETIRO.AddDays(2).ToString("dd 'de' MMMM 'de' yyyy", myCIintl.DateTimeFormat);
				}

				DATOS_HTML = DATOS_HTML.Replace("{SOCIEDAD}", (_DATO_CORREO.SOCIEDAD != null ? _DATO_CORREO.SOCIEDAD : ""));
                DATOS_HTML = DATOS_HTML.Replace("{CEDULA}", _DATO_CORREO.RETIRO.NUMERO_DOCUMENTO);
				DATOS_HTML = DATOS_HTML.Replace("{NOMBRES_APELLIDOS}", _DATO_CORREO.RETIRO.NOMBRE);
                DATOS_HTML = DATOS_HTML.Replace("{FECHA_RETIRO}", _DATO_CORREO.RETIRO.FECHA_RETIRO.ToString("dd/MM/yyyy"));
				DATOS_HTML = DATOS_HTML.Replace("{FECHA_RETIRO_CARTA}", FECHA);
				DATOS_HTML = DATOS_HTML.Replace("{MOTIVO_RETIRO}", _DATO_CORREO.RETIRO.NOMBRE_CAUSA_RETIRO);
                DATOS_HTML = DATOS_HTML.Replace("{CENTRO_COSTOS}", (_DATO_CORREO.CENTRO_COSTO != null ? _DATO_CORREO.CENTRO_COSTO : ""));
				DATOS_HTML = DATOS_HTML.Replace("{NOMBRE_JEFE}", (_DATO_CORREO.NOMBRE_JEFE != null ? _DATO_CORREO.NOMBRE_JEFE : ""));
				DATOS_HTML = DATOS_HTML.Replace("{GENERA_VACANTE}", (_DATO_CORREO.RETIRO.GENERA_VACANTE == true ? "Si" : "No"));
                DATOS_HTML = DATOS_HTML.Replace("{CONCEPTO}", "");
                DATOS_HTML = DATOS_HTML.Replace("{VALOR}", "");


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(_DATO_CORREO.SERVIDOR);
                mail.From = new MailAddress(_DATO_CORREO.CUENTA_CORREO);
                mail.Bcc.Add(CORREO_DESTINO);
                mail.Subject = _DATO_CORREO.ASUNTO;
                mail.Body = DATOS_HTML;// 
                mail.IsBodyHtml = _DATO_CORREO.ES_HTML;
                SmtpServer.Port = Convert.ToInt32(_DATO_CORREO.PUERTO);//  587; definir traer desde base de datos
                SmtpServer.Credentials = new System.Net.NetworkCredential(_DATO_CORREO.CUENTA_CORREO, _DATO_CORREO.CONTRASENA);//CREDENCIALES
                                                                                                                               // SmtpServer.EnableSsl = true;
                SmtpServer.EnableSsl = _DATO_CORREO.USA_SSL;
                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGCLC8  recuperando ENVIO_CORREO en la linea : {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGCLC8" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }


        }


        //martinezluir agregado

        public void ENVIO_CORREO_REQUISICIONES(CORREO_CONFIGURACION_REQUISICION _DATO_CORREO)
        {

            try
            {
                string INFO = ("Iniciando Método ENVIO_CORREO ");
                log.Info("CODIGO : LGCLC8," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGCLC8", log.Logger.Name, "ENVIO_CORREO", INFO));
                HILO.Start();

                string DATOS_HTML = string.Empty;

                foreach (PLANTILLAS_CORREOS_MODELO PLANTILLA in _DATO_CORREO.PLANTILLAS)
                {
                    DATOS_HTML = PLANTILLA.PLANTILLA;
                }

                DATOS_HTML = DATOS_HTML.Replace("{COD_REQUISICION}", _DATO_CORREO.COD_REQUISICION.ToString());
                DATOS_HTML = DATOS_HTML.Replace("{TIPO_REQUISICION}", _DATO_CORREO.TIPO_REQUISICION);
                DATOS_HTML = DATOS_HTML.Replace("{CARGO}", _DATO_CORREO.CARGO);
                DATOS_HTML = DATOS_HTML.Replace("{CENTRO_COSTO}", (_DATO_CORREO.CENTRO_COSTO != null ? _DATO_CORREO.CENTRO_COSTO : ""));


                string CORREO_DESTINO = string.Empty;
                foreach (CORREOS_DESTINOS_MODELO DESTINOS in _DATO_CORREO.DESTINOS)
                {
                    CORREO_DESTINO = DESTINOS.CORREO;
                    DATOS_HTML = DATOS_HTML.Replace("{LINK_TRAMITAR}", _DATO_CORREO.LINK_TRAMITAR+ "&COD_ASPNETUSER_CONTROLLER="+DESTINOS.COD_ASPNETUSER_CONTROLLER);
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(_DATO_CORREO.SERVIDOR);
                    mail.From = new MailAddress(_DATO_CORREO.CUENTA_CORREO);
                    mail.Bcc.Add(CORREO_DESTINO);
                    mail.Subject = _DATO_CORREO.ASUNTO;
                    mail.Body = DATOS_HTML;// 
                    mail.IsBodyHtml = _DATO_CORREO.ES_HTML;
                    SmtpServer.Port = Convert.ToInt32(_DATO_CORREO.PUERTO);//  587; definir traer desde base de datos
                    SmtpServer.Credentials = new System.Net.NetworkCredential(_DATO_CORREO.CUENTA_CORREO, _DATO_CORREO.CONTRASENA);//CREDENCIALES
                                                                                                                                   // SmtpServer.EnableSsl = true;
                    SmtpServer.EnableSsl = _DATO_CORREO.USA_SSL;
                    //martinezluir comentado porque no se consique el servidor desde fuera de la red de el tiempo
                    SmtpServer.Send(mail);
                }
               

             

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGCLC8  recuperando ENVIO_CORREO en la linea : {0}", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGCLC8" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }


        }



        //----------------------------------------------------------------------------------------------///

        private byte[] GENERAR_SALTO(int byteCount)
        {
            try
            {
                //Use cryptographically strong random number generator
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] salt = new byte[byteCount];
                rng.GetBytes(salt);
                return salt;
                //return Convert.ToBase64String(salt);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static byte[] COMPUTAR_HASH(string plainText,
                             byte[] saltBytes)
        {
            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            return plainTextWithSaltBytes;

        }


        /*quitar salto*/
        //public static string  QUITAR_SALTO(string TEXTO_SALTO, int TAMANO_SALTO)
        public string QUITAR_SALTO(string TEXTO_SALTO, int SALTO)
        {
            try
            {
                string INFO = ("Iniciando Método QUITAR_SALTO ");
                log.Info("CODIGO : LGCLC9," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGCLC9", log.Logger.Name, "QUITAR_SALTO", INFO));
                HILO.Start();


                string CONTRASENA = TEXTO_SALTO.Substring(0, SALTO);
                return CONTRASENA;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGCLC9  recuperando QUITAR_SALTO en la linea {0}  ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGCLC9" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }


        //----------------------------------------------------------------------------------------------///

        private ENCRIPTAR_MODELO ENCRIPTAR(byte[] SALTO_TEXTO)
        {
            RijndaelManaged cipher = CREAR_CIFRADO();
            cipher.GenerateIV();
            // Mostrar el IV en la página (se usará para descifrar, normalmente se envía en claro junto con el texto cifrado)
            byte[] IVVALUE = cipher.IV;
            string IV_TEXTO = Convert.ToBase64String(IVVALUE);

            // Crear el encriptador, convertirlo en bytes y encriptar.
            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plaintext = SALTO_TEXTO;
            byte[] cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);
            // Convertir a base64 para mostrar
            string ENCRIPTACION_TEXTO = Convert.ToBase64String(cipherText);

            ENCRIPTAR_MODELO _ENCRIPTAR = new ENCRIPTAR_MODELO();

            _ENCRIPTAR.IV_TEXTO = IV_TEXTO;
            _ENCRIPTAR.ENCRIPTACION_TEXTO = ENCRIPTACION_TEXTO;

            return _ENCRIPTAR;
        }





        private RijndaelManaged CREAR_CIFRADO()
        {
            RijndaelManaged cipher = new RijndaelManaged();

            cipher.KeySize = 256;
            cipher.BlockSize = 256;
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Mode = CipherMode.CBC;
            // Lee la clave del archivo de configuración
            byte[] key = HEXTOBYTEARRAY("892C8E496E1E33355E858B327BC238A939B7601E96159F9E9CAD0519BA5055CD");
            cipher.Key = key;

            return cipher;
        }

        public static byte[] HEXTOBYTEARRAY(string hexString)
        {
            if (0 != (hexString.Length % 2))
            {
                throw new ApplicationException("Hex string must be multiple of 2 in length");
            }
            int byteCount = hexString.Length / 2;
            byte[] byteValues = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                byteValues[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return byteValues;
        }

        /*METODO PARA DESENCRIPTAR*/
        public string DESENCRIPTAR(byte[] IV_TEXTO, string ENCRIPTACION_TEXTO)
        {
            try
            {

                string INFO = ("Iniciando Método DESENCRIPTAR ");
                log.Info("CODIGO : LGCLC10," + INFO);

                Thread HILO = new Thread(() => TRAZA.DEPURAR_TRAZA("LGCLC10", log.Logger.Name, "DESENCRIPTAR", INFO));
                HILO.Start();
                RijndaelManaged cipher = CREAR_CIFRADO();
                cipher.IV = IV_TEXTO;//IV_TEXTO
                //Create the decryptor, convert from base64 to bytes, decrypt
                ICryptoTransform cryptTransform = cipher.CreateDecryptor();
                byte[] cipherText = Convert.FromBase64String(ENCRIPTACION_TEXTO);//TEXTO ENCRIPTADO QUE SERA EL TEXTO SALTO
                byte[] plainText = cryptTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);
                string TEXTO_DESENCRIPTADO = Encoding.UTF8.GetString(plainText);//DEVUELVA EL TEXTO PLANO DESENCRIPTADO 
                return TEXTO_DESENCRIPTADO;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("CODIGO : LGCLC9  recuperando DESENCRIPTAR en la linea {0}  ", ex.StackTrace);
                ex.HelpLink = (ex.HelpLink == "" || ex.HelpLink == null ? "LGCLC10" : ex.HelpLink);
                Thread HILO = new Thread(() => ERROR.ERROR_TRAZA(ex.HelpLink, log.Logger.Name, ex.TargetSite.Name, ex.StackTrace));
                HILO.Start();

                throw ex;
            }

        }

    }
}
