namespace FluentEmailExample
{
    public interface IEmailService
    {
        Task Send(EmailData data);
        Task SendUsingTemplateFile(EmailData data, string template, SuscriptorModel model);
    }
}
