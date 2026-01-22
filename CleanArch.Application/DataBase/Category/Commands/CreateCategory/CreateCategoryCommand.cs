using AutoMapper;
using CleanArch.Domain.Entities.Category;

namespace CleanArch.Application.DataBase.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateCategoryCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateCategoryModel> Execute(CreateCategoryModel model)
        {
            var entity = _mapper.Map<CategoryEntity>(model);
            await _dataBaseService.Categories.AddAsync(entity);
            await _dataBaseService.SaveAsync();

            return model;
        }
    }
}
