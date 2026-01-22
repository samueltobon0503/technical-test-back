using AutoMapper;
using CleanArch.Application.DataBase.User.Commands.UpdateUser;
using CleanArch.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.DataBase.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUserPasswordCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == model.UserId);
            if (entity == null)
                return false;

            entity.Password = model.Password;
            return await _dataBaseService.SaveAsync();
        }
    }
}
