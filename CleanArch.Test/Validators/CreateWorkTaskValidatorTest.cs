using CleanArch.Application.DataBase.WorkTask.Commands.CreateWorkTask;
using CleanArch.Application.Validators.WorkTask;
using FluentValidation.TestHelper;

namespace CleanArch.Test.Validators
{
    public class CreateWorkTaskValidatorTest
    {
        private readonly CreateWorkTaskValidator _validator;

        public CreateWorkTaskValidatorTest()
        {
            _validator = new CreateWorkTaskValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenDueDateIsInThePast()
        {
            var model = new CreateWorkTaskModel
            {
                DueDate = DateTime.UtcNow.AddDays(-1)
            };

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.DueDate)
                  .WithErrorMessage("La fecha debe ser despues de hoy.");
        }

        [Fact]
        public void ShouldNotHaveErrorWhenDueDateIsInTheFuture()
        {
            var model = new CreateWorkTaskModel
            {
                DueDate = DateTime.UtcNow.AddDays(1)
            };

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.DueDate);
        }
    }
}
