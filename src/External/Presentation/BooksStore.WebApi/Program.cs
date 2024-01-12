using BooksStore.Application;
using BooksStore.Domain.Entities;
using BooksStore.Infrastructure.Shared;
using BooksStore.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services.AddMongo("mongodb://root:rrrr@localhost:27017", "BooksStore").AddMongoRepository<Book>("books");

    // Add services to the container.
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddPersistenceServices(builder.Configuration);


    builder.Services.AddControllers();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("all", builder =>
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
    });

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
