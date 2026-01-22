namespace CleanArch.Domain.Entities.Category
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<WorkTask.WorkTaskEntity> WorkTasks { get; set; } = new List<WorkTask.WorkTaskEntity>();
    }
}
