
using FluentEmail.Core;

namespace FluentEmailExample
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task Send(EmailData data)
        {
            await _fluentEmail
                    .To(data.To)
                    .Subject(data.Subject)
                    .Body(data.Body)
                    .SendAsync();
        }

        public async Task SendUsingTemplateFile(EmailData data, string template, SuscriptorModel model)
        {
            await _fluentEmail
                    .To(data.To)
                    .Subject(data.Subject)
                    .UsingTemplateFromFile(template, model)
                    .SendAsync();
        }
    }
}
