using Bookify.Api.Extensions;
using Bookify.Application;
using Bookify.Infrastructure;
namespace Bookify.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.ApplyMigrations();

            // REMARK: Uncomment if you want to seed initial data.
            // app.SeedData();
        }

        app.UseHttpsRedirection();

        app.UseCustomExceptionHandler();

        app.MapControllers();

        app.Run();
    }
}
