using API.Middlewares;
using Application.Activities.Queries;
using Application.Activities.Validators;
using Application.Core;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddCors();
        AddDbContext(builder);
        AddApplicationServices(builder);
        AddMiddlewareServices(builder);

        var app = builder.Build();

        ConfigureMiddleware(app);

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
            await DbInitializer.SeedData(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(Program));
            logger.LogError(ex, "Error while seeding the database");
        }

        app.Run();
    }

    // Registers the EF Core SQLite database context.
    private static void AddDbContext(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    }

    // Registers MediatR handlers, validation pipeline, and AutoMapper.
    private static void AddApplicationServices(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(mediatr =>
        {
            mediatr.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>();
            mediatr.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        builder.Services.AddScoped<IActivityMapper, ActivityMapper>();
        builder.Services.AddValidatorsFromAssemblyContaining<CreateActivityValidator>();
    }

    // Registers custom middleware classes with the DI container.
    private static void AddMiddlewareServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ExceptionMiddleware>();
    }

    // Configures the HTTP request pipeline order.
    private static void ConfigureMiddleware(WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseCors(options => options
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000", "https://localhost:3000"));
        app.MapControllers();
    }
}
