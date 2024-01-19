using BooksStore.Application;
using BooksStore.Infrastructure.Shared;
using BooksStore.Persistence;
using BooksStore.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services.AddMongo("mongodb://root:rrrr@localhost:27017", "BooksStore").AddMongoRepository<Book>("books");

    // Add services to the container.
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddEfPersistenceServices(builder.Configuration);


    builder.Services.AddControllers();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("all", corsPolicyBuilder =>
            corsPolicyBuilder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseMiddleware<ExceptionMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("all");
    app.MapControllers();
    app.Run();
}
