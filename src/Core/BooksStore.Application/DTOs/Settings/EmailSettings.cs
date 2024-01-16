namespace BooksStore.Application.DTOs.Settings;

public class EmailSettings
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 443;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string ApiKey { get; set; } = string.Empty;
    public string FromAddress { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
}
