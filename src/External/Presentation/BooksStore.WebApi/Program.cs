using BooksStore.WebApi.Middleware;
using BooksStore.WebApi.Settings;

var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services.AddMongo("mongodb://root:rrrr@localhost:27017", "BooksStore").AddMongoRepository<Book>("books");

    // Add services to the container.
    builder.Services.AddContainer(builder);


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
