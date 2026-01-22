using AutoMapper;
using CleanArch.Application.DataBase.User.Queries.GetUserById;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.DataBase.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordQuery : IGetUserByUserNameAndPasswordQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByUserNameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string password)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.FirstName == userName && x.Password == password);
            return _mapper.Map<GetUserByUserNameAndPasswordModel>(entity);
        }
    }
}
