namespace VisionStore.Repositories
{
    using Microsoft.Extensions.Options;
    using System.Net;
    using System.Net.Mail;
    using VisionStore.Models;
    using VisionStore.Models.Webgentle.BookStore.Models;

    public class EmailSenderRepository
    {
        private readonly SMTPConfigModel _smtpConfig;
        public EmailSenderRepository(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }
        public void SendEmailSec(string toAddress, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_smtpConfig.SenderAddress);
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
               
                using (SmtpClient smtp = new SmtpClient(_smtpConfig.Host, 587))
                {
                    smtp.Credentials = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }

}
