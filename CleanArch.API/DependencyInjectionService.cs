using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CleanArch.API
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clean Architecture API",
                    Description = "API to show a correct way to apply clean architecture in the technical test"
                });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
            });

            return services;
        }
    }
}
