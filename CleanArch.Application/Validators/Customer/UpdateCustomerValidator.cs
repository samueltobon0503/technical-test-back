using CleanArch.Application.DataBase.Customer.Commands.UpdateCustomer;
using FluentValidation;

namespace CleanArch.Application.Validators.Customer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().MaximumLength(8);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().MaximumLength(8);
        }
    }
}
