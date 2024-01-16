using BooksStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksStore.Persistence.Configurations;

public class BookConfiguration
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Price)
            .HasColumnType("decimal(18,2)");
    }
}
