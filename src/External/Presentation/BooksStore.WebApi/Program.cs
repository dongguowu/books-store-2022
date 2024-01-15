using BooksStore.Application;
using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using BooksStore.Infra.Data.Context;
using BooksStore.Infrastructure.Shared;
using BooksStore.Persistence;
using MediatR;

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
