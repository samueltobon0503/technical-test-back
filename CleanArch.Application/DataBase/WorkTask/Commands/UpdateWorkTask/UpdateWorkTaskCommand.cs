using AutoMapper;
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

            if (currentEntity == null) throw new KeyNotFoundException("La tarea no existe");

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
               
                throw new Exception("El registro ha sido modificado por otro usuario. Por favor recargue para ver los cambios recientes.");
            }
        }
    }
}
