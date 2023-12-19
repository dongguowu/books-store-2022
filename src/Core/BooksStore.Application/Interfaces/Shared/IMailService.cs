using BooksStore.Application.DTOs.Mail;

namespace BooksStore.Application.Interfaces.Shared;
public interface IMailService
{
    Task SendAsync(MailRequest request);
}
