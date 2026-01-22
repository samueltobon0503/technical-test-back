namespace CleanArch.Application.DataBase.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
