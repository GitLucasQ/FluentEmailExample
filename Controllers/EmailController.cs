using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentEmailExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SendSampleEmail()
        {
            EmailData data = new()
            {
                To = "email_destination@mail.com",
                Subject = "test",
                Body = "correo de prueba",
            };

            await _emailService.Send(data);

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SendEmailUsingTemplate()
        {
            SuscriptorModel model = new()
            {
                Name = "Luis Reyes",
                Email = "email_destination@mail.com",
                SuscriptionType = "Platinum"
            };

            EmailData data = new()
            {
                To = model.Email,
                Subject = "Suscripción a newsletter"
            };

            var template = $"{Directory.GetCurrentDirectory()}/email_template.cshtml";

            await _emailService.SendUsingTemplateFile(data, template, model);

            return Ok();
        }
    }
}
