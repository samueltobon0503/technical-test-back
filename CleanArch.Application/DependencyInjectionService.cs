using AutoMapper;
using CleanArch.Application.Configuration;
using CleanArch.Application.DataBase.Category.Commands.CreateCategory;
using CleanArch.Application.DataBase.Category.Queries.GetAllCategories;
using CleanArch.Application.DataBase.WorkTask.Commands.CreateWorkTask;
using CleanArch.Application.DataBase.WorkTask.Commands.UpdateWorkTask;
using CleanArch.Application.DataBase.WorkTask.Queries.GetAllWorkTasks;
using CleanArch.Application.DataBase.WorkTask.Queries.GetWorkTaskById;
using CleanArch.Application.Validators.Category;
using CleanArch.Application.Validators.WorkTask;
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

            #region Category
            services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            services.AddTransient<IGetAllCategoriesQuery, GetAllCategoriesQuery>();
            #endregion

            #region WorkTask
            services.AddTransient<ICreateWorkTaskCommand, CreateWorkTaskCommand>();
            services.AddTransient<IUpdateWorkTaskCommand, UpdateWorkTaskCommand>();
            services.AddTransient<IGetAllWorkTasksQuery, GetAllWorkTasksQuery>();
            services.AddTransient<IGetWorkTaskByIdQuery, GetWorkTaskByIdQuery>();
            #endregion

            #region Validatorsd
            services.AddScoped<IValidator<CreateCategoryModel>, CreateCategoryValidator>();
            services.AddScoped<IValidator<CreateWorkTaskModel>, CreateWorkTaskValidator>();
            services.AddScoped<IValidator<UpdateWorkTaskModel>, UpdateWorkTaskValidator>();
            #endregion

            return services;
        }
    }
}