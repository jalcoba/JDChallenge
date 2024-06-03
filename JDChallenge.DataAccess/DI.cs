using JDChallenge.DataAccess.Interfaces;
using JDChallenge.DataAccess.Repositories;
using JDChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JDChallenge.DataAccess;

public static class DI
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DI).Assembly.FullName;

        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? configuration.GetConnectionString("sql_server");
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString, m => m.MigrationsAssembly(assembly)));

        services
            .AddTransient<IEmployeeRepository, EmployeeRepository>()
            .AddTransient<IPermissionRepository, PermissionRepository>()
            .AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();

        return services;
    }
}
