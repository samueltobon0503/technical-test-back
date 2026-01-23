using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.DataBase.WorkTask.Queries.GetWorkTaskById
{
    public class GetWorkTaskByIdQuery : IGetWorkTaskByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetWorkTaskByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetWorkTaskByIdModel> Execute(Guid workTaskId)
        {
            var entity = await _dataBaseService.WorkTasks.Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == workTaskId);
            return _mapper.Map<GetWorkTaskByIdModel>(entity);
        }
    }
}
