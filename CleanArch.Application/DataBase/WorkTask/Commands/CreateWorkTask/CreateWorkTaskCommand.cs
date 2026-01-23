using AutoMapper;
using CleanArch.Application.DataBase.WorkTask.Commands.CreateWorkTask;
using CleanArch.Domain.Entities.WorkTask;

namespace CleanArch.Application.DataBase.Category.Commands.CreateCategory
{
    public class CreateWorkTaskCommand : ICreateWorkTaskCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateWorkTaskCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateWorkTaskModel> Execute(CreateWorkTaskModel model)
        {
            var entity = _mapper.Map<WorkTaskEntity>(model);
            await _dataBaseService.WorkTasks.AddAsync(entity);
            await _dataBaseService.SaveAsync();

            return model;
        }
    }
}
