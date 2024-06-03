using Microsoft.Extensions.DependencyInjection;

namespace JDChallenge.Business;

public static class DI
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        var assembly = typeof(DI).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));

        services.AddAutoMapper(typeof(DI));

        return services;
    }
}
