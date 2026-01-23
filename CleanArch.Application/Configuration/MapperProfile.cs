using AutoMapper;
using CleanArch.Application.DataBase.Category.Commands.CreateCategory;
using CleanArch.Application.DataBase.Category.Queries.GetAllCategories;
using CleanArch.Application.DataBase.WorkTask.Commands.CreateWorkTask;
using CleanArch.Application.DataBase.WorkTask.Commands.UpdateWorkTask;
using CleanArch.Application.DataBase.WorkTask.Queries.GetAllWorkTasks;
using CleanArch.Application.DataBase.WorkTask.Queries.GetWorkTaskById;
using CleanArch.Domain.Dto;
using CleanArch.Domain.Entities.Category;
using CleanArch.Domain.Entities.WorkTask;

namespace CleanArch.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryEntity, GetAllCategoriesModel>().ReverseMap();
            CreateMap<CategoryEntity, CreateCategoryModel>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<WorkTaskEntity, CreateWorkTaskModel>().ReverseMap();
            CreateMap<WorkTaskEntity, UpdateWorkTaskModel>().ReverseMap();

            CreateMap<WorkTaskEntity, GetAllWorkTasksModel>();
            CreateMap<WorkTaskEntity, GetWorkTaskByIdModel>();
            
        }
    }
}
