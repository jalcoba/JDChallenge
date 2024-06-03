using JDChallenge.DataAccess.Interfaces;
using JDChallenge.DataAccess.Repositories;
using JDChallenge.Services.Interfaces;
using JDChallenge.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JDChallenge.Services;

public static class DI
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient<IEmployeesService, EmployeeService>()
            .AddTransient<IPermissionService, PermissionService>()
            .AddTransient<IPermissionTypeService, PermissionTypeService>();

        var elesticsearchServer = Environment.GetEnvironmentVariable("ELASTICSEARCH_SERVER");
        elesticsearchServer ??= configuration.GetSection("ELASTICSEARCH_SERVER").Value;
        services.AddSingleton<IElasticsearchService>(new ElasticsearchService(elesticsearchServer));

        var kafkaServer = Environment.GetEnvironmentVariable("KAFKA_SERVER");
        kafkaServer ??= configuration.GetSection("KAFKA_SERVER").Value;
        services.AddSingleton<IKafkaProducer>(new KafkaProducer(kafkaServer));
        
        return services;
    }
}