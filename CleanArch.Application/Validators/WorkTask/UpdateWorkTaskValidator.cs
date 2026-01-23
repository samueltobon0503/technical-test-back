using CleanArch.Application.DataBase.WorkTask.Commands.CreateWorkTask;
using CleanArch.Application.DataBase.WorkTask.Commands.UpdateWorkTask;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Validators.WorkTask
{
    public class UpdateWorkTaskValidator: AbstractValidator<UpdateWorkTaskModel>
    {
        public UpdateWorkTaskValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Status).NotNull();
            RuleFor(x => x.DueDate).NotNull().NotEmpty();
            RuleFor(x => x.CategoryId).NotNull().NotEmpty();
            RuleFor(x => x.RowVersion).NotNull().NotEmpty();
        }
    }
}
