using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace EmailApp
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("MeinLiXMVC", "MeinLixMVC@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await client.ConnectAsync("smtp.gmail.com", 465, true);// OUT: SSL: 465 | TLS/STARTTLS: 587   //IN SSL 993 
            await client.AuthenticateAsync("MeinLixMVC@gmail.com", "dadadaBESTpassword");
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }
}