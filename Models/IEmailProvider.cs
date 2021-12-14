using SendGrid;
using SendGrid.Helpers.Mail;

namespace InternetPcPartDatabase.Models
{
    public interface IEmailProvider
    {
        Task SendEmailAsync(string to, string from, string subject, string content, string htmlMessage);
    }

    public class EmailProvider_SendGrid : IEmailProvider
    {
        private readonly IConfiguration configuration;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EmailProvider_SendGrid(IConfiguration config)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            configuration = config;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        }
        public async Task SendEmailAsync(string to, string from, string subject, string content, string htmlMessage)
        {
            var apiKey = configuration.GetSection("SEND_GRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);
            var message = new SendGridMessage()
            {
             From = new EmailAddress("gojem73112@terasd.com", "IPCDB"),
             Subject = "Sending Email with SendGrid",
             PlainTextContent = "It's easy to do derp",
             HtmlContent = "<strong> and easy to do anywhere</strong>"
            };
            message.AddTo(new EmailAddress("mattlyman12@gmail.com", "Matt Lyman"));
            var response = await client.SendEmailAsync(message);
        }
    }
}
