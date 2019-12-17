using BookStore.Services.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class MailService : IMailService
    {
        public MailService()
        {

        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Credentials
            var credentials = new NetworkCredential("virichhb8@gmail.com", "369874125illyavirych");
            // Mail message
            var mail = new MailMessage()
            {
                From = new MailAddress("virichhb8@gmail.com"),
                Subject = subject,
                Body = message
            };
            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(email));
            // Smtp client
            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };

            client.Send(mail);
        }
    }
}
