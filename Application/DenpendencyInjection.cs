using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

/// <summary>
/// 依赖注入扩展
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// 注入Application
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services
            .AddMediatR(configuration => { configuration.RegisterServicesFromAssembly(assembly); });
        
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}