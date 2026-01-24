namespace CleanArch.Application.DataBase.WorkTask.Commands.UpdateWorkTask
{
    public class UpdateWorkTaskModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Domain.Enum.TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
