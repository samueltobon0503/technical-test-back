namespace CleanArch.Domain.Entities.WorkTask
{
    public class WorkTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }

        public int CategoryId { get; set; }
        public Category.Category Category { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;
    }
}
