using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.DataBase.WorkTask.Queries.GetAllWorkTasks
{
    public class GetAllWorkTasksQuery : IGetAllWorkTasksQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllWorkTasksQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllWorkTasksModel>> Execute()
        {
            var listEntity = await _dataBaseService.WorkTasks.Include(c => c.Category).ToListAsync();
            return _mapper.Map<List<GetAllWorkTasksModel>>(listEntity);
        }
    }
}
