using Grocery.common.Model;

namespace SMTPMailing.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailModel emailModel);
    }
}
