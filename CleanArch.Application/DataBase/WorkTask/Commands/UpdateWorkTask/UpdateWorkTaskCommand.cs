using AutoMapper;
using CleanArch.Application.Common.Constants;
using CleanArch.Domain.Entities.WorkTask;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.DataBase.WorkTask.Commands.UpdateWorkTask
{
    public class UpdateWorkTaskCommand : IUpdateWorkTaskCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateWorkTaskCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateWorkTaskModel> Execute(UpdateWorkTaskModel model)
        {
            var currentEntity = await _dataBaseService.WorkTasks
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id);

            if (currentEntity == null) throw new KeyNotFoundException(Constants.TASK_NOT_FOUND_ERROR);

            var entityToUpdate = _mapper.Map<WorkTaskEntity>(model);

            try
            {
                _dataBaseService.Entry(entityToUpdate).Property("RowVersion").OriginalValue = model.RowVersion;

                _dataBaseService.WorkTasks.Update(entityToUpdate);
                await _dataBaseService.SaveAsync();

                return model;
            }
            catch (DbUpdateConcurrencyException)
            {

                throw new DbUpdateConcurrencyException(Constants.TASK_ALREADY_MODIFIED_ERROR);
            }
        }
    }
}
