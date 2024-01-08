using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using TodoService.Biz;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Commands;
using TodoService.Infrastructure;
using TodoService.Infrastructure.Settings;

namespace TodoService.Api;

public static class Extensions
{
    public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
        builder.Services.AddSingleton<Serilog.ILogger>(logger);

        return builder;
    }

    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(BusinessLogicAssembly).Assembly));
    }


    public static void AddSettings(this IServiceCollection services)
    {
        services
            .AddOptions<DatabaseSettings>()
            .BindConfiguration(DatabaseSettings.ConfigurationSectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ITodoRepository, PostgresTodoRepository>();
    }

    public static void AddDefaultCors(this IServiceCollection services)
    {
        services.AddCors(options =>
            options.AddDefaultPolicy(policy =>
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
    }

    public static async ValueTask InitDbAsync(this WebApplication app)
    {
        var sender = app.Services.GetRequiredService<ISender>();
        await sender.Send(new InitDbCommand());
    }

    public static WebApplication MapHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");
        app.MapHealthChecks("/liveness", new HealthCheckOptions
        {
            Predicate = r => r.Tags.Contains("live")
        });
        return app;
    }
}