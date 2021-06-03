using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.Clases;

namespace UTN.WinForms.Correo
{
    class SendEmail
    {
        public void enviar(string correoAenviar)
        {
            XML obj = new XML();

            MailMessage mensaje = new MailMessage();
            mensaje.IsBodyHtml = true;
            mensaje.Subject = "XML respectivo del boleto";
            mensaje.Body = "Este mensaje le hace llegar el documento XML en el cual se encuentra la informacion del ultimo boleto comprado";
            mensaje.From = new MailAddress("ksgsendemails@gmail.com");
            mensaje.To.Add(correoAenviar);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("ksgsendemails@gmail.com", "ksg12345");
            smtp.EnableSsl = true;
            Attachment attachment = new Attachment(obj.Ruta);
            mensaje.Attachments.Add(attachment);
            smtp.Send(mensaje);
        }

        public bool EsMailValido(string email)
        {
            try
            {
                return System.Text.RegularExpressions.Regex.IsMatch(email, @"^(([^<>()[\]\\.,;:\s@\""]+"
                                                    + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                                    + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                                    + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                                    + @"[a-zA-Z]{2,}))$");
            }
            catch (Exception e)
            {
                throw new ApplicationException("validar email", e);
            }
        }
    }
}
