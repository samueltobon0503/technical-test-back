using AutoMapper;
using CleanArch.Application.Configuration;
using CleanArch.Application.DataBase.Category.Commands.CreateCategory;
using CleanArch.Application.DataBase.Category.Queries.GetAllCategories;
using CleanArch.Application.Validators.Category;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            services.AddTransient<IGetAllCategoriesQuery, GetAllCategoriesQuery>();

            services.AddScoped<IValidator<CreateCategoryModel>, CreateCategoryValidator>();


            return services;
        }
    }
}
