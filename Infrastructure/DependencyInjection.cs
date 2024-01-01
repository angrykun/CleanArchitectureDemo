using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

/// <summary>
/// 依赖注入扩展
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// 注入Infrastructure
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}