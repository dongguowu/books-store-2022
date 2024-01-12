using BooksStore.Application.DTOs.Mail;
using BooksStore.Application.DTOs.Settings;
using BooksStore.Application.Interfaces.Shared;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BooksStore.Infrastructure.Shared.Services;

public class SMTPMailService : IMailService
{
    public SMTPMailService(IOptions<EmailSettings> mailSettings, ILogger<SMTPMailService> logger)
    {
        EmailSettings = mailSettings.Value;
        _logger = logger;
    }

    public EmailSettings EmailSettings { get; }
    public ILogger<SMTPMailService> _logger { get; }

    public async Task SendAsync(EmailMessage request)
    {
        try
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(request.From ?? EmailSettings.FromAddress);
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(EmailSettings.Host, EmailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(EmailSettings.UserName, EmailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
    }
}
