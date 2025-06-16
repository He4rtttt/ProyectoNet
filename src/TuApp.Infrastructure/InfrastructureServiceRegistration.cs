using System.Data;
using Hangfire;
using Hangfire.MySql;
using TuApp.Application.Interfaces;
using TuApp.Domain.Interfaces;
using TuApp.Infrastructure.Data;
using TuApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TuApp.Application.Jobs;
using TuApp.Domain.Services;
using TuApp.Infrastructure.Jobs;
using TuApp.Infrastructure.Repositories;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace TuApp.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configuración de Entity Framework Core (MySQL)
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        // Configuración de Hangfire
        var hangfireConnectionString = configuration.GetConnectionString("HangfireConnection") 
                                    ?? configuration.GetConnectionString("DefaultConnection");

        services.AddHangfire(config => 
        {
            var storageOptions = new MySqlStorageOptions
            {
                TablesPrefix = "Hangfire",
                QueuePollInterval = TimeSpan.FromSeconds(15),
                JobExpirationCheckInterval = TimeSpan.FromHours(1),
                CountersAggregateInterval = TimeSpan.FromMinutes(5),
                PrepareSchemaIfNecessary = true,
                DashboardJobListLimit = 50000,
                TransactionTimeout = TimeSpan.FromMinutes(1),
                TransactionIsolationLevel = (IsolationLevel?)System.Data.IsolationLevel.ReadCommitted
            };
            
            config.UseStorage(new MySqlStorage(hangfireConnectionString, storageOptions));
        });

        services.AddHangfireServer(options => 
        {
            options.ServerName = "TuApp.Hangfire";
            options.Queues = new[] { "default" };
        });
        
        // Registro de Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Registro de repositorios
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IUserRolesRepository, UserRolesRepository>();
        services.AddScoped<IRolesRepository, RolesRepository>();

        // Servicios de infraestructura
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IBackgroundJobService, BackgroundJobService>();
        services.AddScoped<ITicketStatusReportService, TicketStatusReportService>();
        services.AddScoped<ICleanOldTicketsJob, CleanOldTicketsJob>();

        
        
        return services;
    }
}