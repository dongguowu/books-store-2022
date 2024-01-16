using BooksStore.Application.DTOs.Mail;

namespace BooksStore.Application.Interfaces.Shared;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}
