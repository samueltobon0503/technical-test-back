using CleanArch.External.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services)
        {
            services.AddHostedService<OverdueTaskWorker>();
            return services;
        }
    }
}
