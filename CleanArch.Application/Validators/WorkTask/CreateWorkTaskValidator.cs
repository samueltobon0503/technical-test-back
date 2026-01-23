using CleanArch.Application.DataBase.WorkTask.Commands.CreateWorkTask;
using FluentValidation;

namespace CleanArch.Application.Validators.WorkTask
{
    public class CreateWorkTaskValidator : AbstractValidator<CreateWorkTaskModel>
    {
        public CreateWorkTaskValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Status).NotNull();
            RuleFor(x => x.DueDate).NotNull().NotEmpty().GreaterThan(DateTime.UtcNow)
                .WithMessage("La fecha debe ser despues de hoy.");
            RuleFor(x => x.CategoryId).NotNull().NotEmpty();
        }
    }
}
