using BooksStore.Application.DTOs.Mail;
using BooksStore.Application.DTOs.Settings;
using BooksStore.Application.Interfaces.Shared;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BooksStore.Infrastructure.Shared.Services;

public class SendGridEmailSender : IEmailSender
{
    public SendGridEmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public EmailSettings _emailSettings { get; }


    public async Task<bool> SendEmail(EmailMessage email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress { Email = _emailSettings.FromAddress, Name = _emailSettings.FromName };

        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(message);

        return response.IsSuccessStatusCode;
    }
}
