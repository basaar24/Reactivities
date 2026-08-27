using API.Middlewares;
using Application.Activities.Queries;
using Application.Activities.Validators;
using Application.Core;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API;

public static class Program
{
    public static async Task Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddCors();
        AddDbContext(builder);
        AddApplicationServices(builder);
        AddMiddlewareServices(builder);

        builder.Services.AddOpenApiDocument(cfg =>
        {
            cfg.DocumentName = "Reactivities";
            cfg.Title = "Reactivities V1";
            cfg.Version = "1.0.0";
        });

        WebApplication app = builder.Build();

        ConfigureMiddleware(app);

        using IServiceScope scope = app.Services.CreateScope();
        IServiceProvider services = scope.ServiceProvider;

        try
        {
            AppDbContext context = services.GetRequiredService<AppDbContext>();
            UserManager<User> userManager = services.GetRequiredService<UserManager<User>>();
            await context.Database.MigrateAsync();
            await DbInitializer.SeedDataAsync(context, userManager);
        }
        catch (Exception ex)
        {
            ILogger logger = services.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(Program));
            logger.LogError(ex, "Error while seeding the database");
        }

        app.UseOpenApi();
        app.UseSwaggerUi();
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
        builder.Services.AddIdentityApiEndpoints<User>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>();
    }

    // Registers custom middleware classes with the DI container.
    private static void AddMiddlewareServices(WebApplicationBuilder builder) => builder.Services.AddTransient<ExceptionMiddleware>();

    // Configures the HTTP request pipeline order.
    private static void ConfigureMiddleware(WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseCors(options => options
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000", "https://localhost:3000"));

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapGroup("api").MapIdentityApi<User>();
    }
}
