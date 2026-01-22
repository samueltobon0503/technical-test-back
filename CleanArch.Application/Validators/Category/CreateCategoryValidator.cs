using CleanArch.Application.DataBase.Category.Commands.CreateCategory;
using FluentValidation;

namespace CleanArch.Application.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(200);
        }
    }
}
