namespace CleanArch.Application.DataBase.WorkTask.Commands.UpdateWorkTask
{
    public interface IUpdateWorkTaskCommand
    {
        Task<UpdateWorkTaskModel> Execute(UpdateWorkTaskModel model);
    }
}
