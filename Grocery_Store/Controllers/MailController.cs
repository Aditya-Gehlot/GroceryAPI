using Grocery.services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Grocery.common.Model;
using SMTPMailing.Services;
using Microsoft.AspNetCore.Authorization;

namespace Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public MailController(IEmailService emailService)
        {

            _emailService = emailService;
        }

        [Authorize]
        [HttpPost("MailPost")]
        public async Task<IActionResult> SendEmail(EmailModel emailModel)
        {
            var mailrequest = new EmailModel();
            mailrequest.To = emailModel.To;
            mailrequest.Subject = emailModel.Subject;
            mailrequest.Body = emailModel.Body;

            await _emailService.SendEmailAsync(mailrequest);
            return Ok();
        }



        //private string Getresponse()
        //{
        //    var response = "<h1>\"This is body of mail!!\"</h1>";
        //    return response;
        //}
    }
}
