namespace CleanArch.Application.DataBase.Category.Queries.GetAllCategories
{
    public interface IGetAllCategoriesQuery
    {
        Task<List<GetAllCategoriesModel>> Execute();
    }
}
