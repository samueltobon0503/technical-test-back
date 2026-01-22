using CleanArch.Application.DataBase.Booking.Commands.CreateBooking;
using FluentValidation;

namespace CleanArch.Application.Validators.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidator()
        {

            RuleFor(x => x.Code).NotNull().NotEmpty().Length(8);
            RuleFor(x => x.Type).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.UserId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
