namespace CleanArch.Application.DataBase.WorkTask.Queries.GetWorkTaskById
{
    public interface IGetWorkTaskByIdQuery
    {
        Task<GetWorkTaskByIdModel> Execute(Guid workTaskId);
    }
}
