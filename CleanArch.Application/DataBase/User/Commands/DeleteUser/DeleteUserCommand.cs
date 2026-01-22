using AutoMapper;
using CleanArch.Application.DataBase.User.Commands.CreateUser;
using CleanArch.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public DeleteUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<bool> Execute(int userId)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == userId);
            if (entity == null)
                return false;

            _dataBaseService.User.Remove(entity);
            await _dataBaseService.SaveAsync();

            return true;
        }
    }
}
