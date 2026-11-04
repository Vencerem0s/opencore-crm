using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenCore.Application.Common.Interface;
using OpenCore.Domain.Tasks.Repository;
using OpenCore.Infrastructure.Persistence;
using OpenCore.Infrastructure.Persistence.Tasks.Repository;

namespace OpenCore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<OpenCoreDbContext>(options => 
                options
                    .UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention());
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<OpenCoreDbContext>());

        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}
