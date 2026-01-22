using CleanArch.Application.External.ApplicationInsights;
using CleanArch.Application.External.GetTokenJwt;
using CleanArch.Application.External.SendGridEmail;
using CleanArch.External.ApplicationInsights;
using CleanArch.External.GetTokenJwt;
using CleanArch.External.SendGridEmail;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace CleanArch.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
            services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKeyJwt"])),
                    ValidIssuer = configuration["IssuerJwt"],
                    ValidAudience = configuration["AundienceJwt"]
                };
            });

            services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
            {
                ConnectionString = configuration["ApplicationInsightsConnectionString"]
            });

            services.AddSingleton<IInsertApplicationInsightsService, InsertApplicationInsightsService>();
            return services;
        }
    }
}
