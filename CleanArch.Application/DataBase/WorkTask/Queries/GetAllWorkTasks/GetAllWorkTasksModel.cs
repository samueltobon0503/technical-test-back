using CleanArch.Domain.Dto;

namespace CleanArch.Application.DataBase.WorkTask.Queries.GetAllWorkTasks
{
    public class GetAllWorkTasksModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Domain.Enum.TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;
    }
}
