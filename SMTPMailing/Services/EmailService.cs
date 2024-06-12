using Grocery.common.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SMTPMailing.Services;

namespace CT.Email.Service
{
    public class EmailService : IEmailService
    {
        private readonly SMTPConfigModel _smtpconfigmodel;
        public EmailService(IOptions<SMTPConfigModel> options)
        {
            _smtpconfigmodel = options.Value;
        }
        public async Task SendEmailAsync(EmailModel mailRequest)
        {
            string ccEmail = "gehlotaditya0109@gmail.com";
            string bccEmail = "ashutoshdoorwar1@gmail.com";

            var mail = new MimeMessage();
            mail.Sender = MailboxAddress.Parse(_smtpconfigmodel.Email);

            mail.To.Add(MailboxAddress.Parse(mailRequest.To));
            mail.Subject = mailRequest.Subject;
            mail.Cc.Add(MailboxAddress.Parse(ccEmail));
            mail.Bcc.Add(MailboxAddress.Parse(bccEmail));

            var builder = new BodyBuilder();

            builder.HtmlBody = mailRequest.Body;
            mail.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            smtp.Connect(_smtpconfigmodel.Host, _smtpconfigmodel.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_smtpconfigmodel.Email, _smtpconfigmodel.Password);
            await smtp.SendAsync(mail);
            smtp.Disconnect(true);
        }
    }
}