using CleanArch.Application.DataBase;
using CleanArch.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(configuration["SQLConnectionstring"]));

            services.AddScoped<IDataBaseService, DataBaseService>();
            return services;
        }
    }
}
