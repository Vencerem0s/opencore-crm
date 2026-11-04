using Microsoft.Extensions.DependencyInjection;
using OpenCore.Application.Tasks.Handler;

namespace OpenCore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateTaskHandler>();
        return services;
    }
}
