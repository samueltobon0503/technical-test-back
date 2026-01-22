using CleanArch.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using FluentValidation;

namespace CleanArch.Application.Validators.User
{
    public class GetUserByUserNameAndPasswordValidator : AbstractValidator<(string,string)>
    {
        public GetUserByUserNameAndPasswordValidator()
        {
            RuleFor(x => x.Item1).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Item2).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}
