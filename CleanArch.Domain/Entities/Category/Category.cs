namespace CleanArch.Domain.Entities.Category
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<WorkTask.WorkTask> WorkTasks { get; set; } = new List<WorkTask.WorkTask>();
    }
}
