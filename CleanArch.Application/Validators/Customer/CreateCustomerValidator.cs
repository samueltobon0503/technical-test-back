using CleanArch.Application.DataBase.Customer.Commands.CreateCustomer;
using FluentValidation;

namespace CleanArch.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().MaximumLength(8);
        }
    }
}
