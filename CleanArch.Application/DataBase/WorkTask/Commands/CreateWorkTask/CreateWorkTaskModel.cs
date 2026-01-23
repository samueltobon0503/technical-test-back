namespace CleanArch.Application.DataBase.WorkTask.Commands.CreateWorkTask
{
    public class CreateWorkTaskModel
    {
        public string Title { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
    }
}
