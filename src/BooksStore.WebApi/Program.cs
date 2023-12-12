using BooksStore.Core.BookAggregate;
using BooksStore.Infra.MongoDB;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddMongo("mongodb://root:rrrr@localhost:27017", "BooksStore").AddMongoRepository<Book>("books");

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

