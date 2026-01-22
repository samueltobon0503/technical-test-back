namespace CleanArch.Application.DataBase.Category.Commands.CreateCategory
{
    public interface ICreateCategoryCommand
    {
        Task<CreateCategoryModel> Execute(CreateCategoryModel model);
    }
}
