using BooksStore.Application.Interfaces.Shared;

namespace BooksStore.Infrastructure.Shared.Services;

public class SystemDateTimeService : IDateTimeService
{
    public DateTime NowUtc => DateTime.UtcNow;
}
