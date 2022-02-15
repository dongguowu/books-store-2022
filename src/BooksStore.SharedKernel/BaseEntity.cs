namespace BooksStore.SharedKernel;

public abstract class BaseEntity
{

  public static readonly int LENGTH_OF_ID = 21;
  public string Id { get; set; } = RandomString(LENGTH_OF_ID);
  public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

  public static string RandomString(int length)
  {
    var random = new Random();
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[random.Next(s.Length)]).ToArray());
  }
}
