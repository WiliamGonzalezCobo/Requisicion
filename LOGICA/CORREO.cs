using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using LOGICA.MODELO_LOGICA;
using System.IO;

namespace LOGICA
{
   public class CORREO
    {
        public void ENVIO_CORREO(CORREO_CONFIGURACION_MODELO _DATOS)
        {
            string DATOS_HTML = string.Empty;
            StreamReader lecturaHtml = new StreamReader(HttpContext.Current.Server.MapPath("~/Views/templates/mailing.cshtml"));  /*MAPEA EL HTML DE LA VISTA*/

            //string SERVIDOR = "smtp.10.100.1.16";
            //string CUENTA_CORREO = "gestionhumana@eltiempo.com";
            //string CONTRASENA = "";


            DATOS_HTML = lecturaHtml.ReadToEnd();

                MailMessage mail = new MailMessage();//INSTANCIA LA CLASE NATIVAS DE VISUAL PARA CORREO
                                                   
            var Nombre = "si prueba";
            //DATOS_HTML.Replace("Name", Nombre);
            DATOS_HTML= DATOS_HTML.Replace("{Name}", Nombre);
            // body = reader.ReadToEnd();           
            //body.Replace("[Name]", name);       
            //body.Replace("[url]", url);

            //SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");//SERVIDOR
           // mail.From = new MailAddress("julfue@eltiempo.com");//MI CORREO ELECTRONICO

            SmtpClient SmtpServer = new SmtpClient("10.100.1.16");//SERVIDOR
            mail.From = new MailAddress("gestionhumana@eltiempo.com");//MI CORREO ELECTRONICO
            mail.To.Add(_DATOS.DESTINO);
                mail.Subject = _DATOS.ASUNTO;
                mail.Body = DATOS_HTML;// lecturaHtml.ReadToEnd(); // model.Mesnsaje;
                mail.IsBodyHtml = true;

                ////CODIGO PARA ENVIAR ARCHIVOS CORTOS/////
                //System.Net.Mail.Attachment attachment;
                ////attachment = new System.Net.Mail.Attachment("c:/textfile.txt");//NOMBRE DEL ARCHIVO A ENVIAR
                //attachment = new System.Net.Mail.Attachment("\\\\cesgripro\\ARCHIVOS_H_G\\544584_1.jpg");// RUTA PARA EL ARCHIVO
                //mail.Attachments.Add(attachment);
                //// FIN CODIGO PARA ENVIAR ARCHIVOS CORTOS/////

                SmtpServer.Port =25;//PUERTO
                SmtpServer.Credentials = new System.Net.NetworkCredential("gestionhumana@eltiempo.com","");//CREDENCIALES


           // SmtpServer.Credentials = new System.Net.NetworkCredential("julfue@eltiempo.com","Tecno2019+");//CREDENCIALES


            SmtpServer.EnableSsl = false;
           // SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Send(mail);

        }







    }
}
