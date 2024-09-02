using System.Net.Mail;
using System.Net;

namespace FluentEmailExample
{
    public static class FluentEmailExtensions
    {
        public static void AddFluentEmail(this IServiceCollection services,
        ConfigurationManager configuration)
        {
            var emailSettings = configuration.GetSection("EmailSettings");

            var defaultFromEmail = emailSettings["DefaultFromEmail"];
            var host = emailSettings["SMTPSetting:Host"];
            var port = emailSettings.GetValue<int>("SMTPSetting:Port");
            var userName = emailSettings["UserName"];
            var password = emailSettings["Password"];

            services.AddFluentEmail(defaultFromEmail)
                .AddSmtpSender(new SmtpClient(host)
                {
                    Port = port,
                    Credentials = new NetworkCredential(userName, password),
                    EnableSsl = true
                })
                .AddRazorRenderer();
        }
    }
}
