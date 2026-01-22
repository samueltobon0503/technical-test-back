using AutoMapper;
using CleanArch.Application.DataBase.Category.Commands.CreateCategory;
using CleanArch.Application.DataBase.Category.Queries.GetAllCategories;
using CleanArch.Domain.Entities.Category;

namespace CleanArch.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryEntity, GetAllCategoriesModel>().ReverseMap();
            CreateMap<CategoryEntity, CreateCategoryModel>().ReverseMap();
        }
    }
}
