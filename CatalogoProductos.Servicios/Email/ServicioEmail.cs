using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Servicios.Email
{
    public class ServicioEmail
    {
        private const string servidor = "smtp-relay.brevo.com";
        private const int puerto = 587;
        private const string usuario = "97ee2a001@smtp-brevo.com";
        private const string password = "xsmtpsib-18fd09c0632199397340925d0ceeebb181f6cb6c61d9ec90001b8ad3ee31e602-vY1PthZ6JInrR8Uk";
     
        public bool Enviar(string destinatario, string asunto, string cuerpo, bool esHtml = false)
        {

            bool enviado = false;

            try
            {
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("tpweb.grupo9c.promoweb2025@gmail.com", "TUP Programación III - Equipo 9C");
                mensaje.To.Add(destinatario);
                mensaje.Subject = asunto;
                mensaje.Body = cuerpo;
                mensaje.IsBodyHtml = esHtml;

                SmtpClient cliente = new SmtpClient(servidor, puerto);
                cliente.Credentials = new NetworkCredential(usuario, password);
                cliente.EnableSsl = true;
                cliente.Send(mensaje);
                enviado = true;

                return enviado;
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
