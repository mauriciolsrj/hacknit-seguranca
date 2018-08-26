using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GuardaDigital.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return configSendGridasync(message);
        }

        private async Task configSendGridasync(IdentityMessage message)
        {
            var apiKey = ConfigurationManager.AppSettings["sendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("contato@GD.com", "Nano");
            var subject = message.Subject;
            var to = new EmailAddress(message.Destination);
            var plainTextContent = message.Body;
            var htmlContent = message.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            if (client != null)
            {
                await client.SendEmailAsync(msg);
            }
            else
            {
                Trace.TraceError("Erro ao enviar o e-mail");
                await Task.FromResult(0);
            }
        }
    }
}