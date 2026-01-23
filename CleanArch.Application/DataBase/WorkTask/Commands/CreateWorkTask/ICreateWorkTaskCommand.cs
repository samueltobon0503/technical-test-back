namespace CleanArch.Application.DataBase.WorkTask.Commands.CreateWorkTask
{
    public interface ICreateWorkTaskCommand
    {
        Task<CreateWorkTaskModel> Execute(CreateWorkTaskModel model);
    }
}
