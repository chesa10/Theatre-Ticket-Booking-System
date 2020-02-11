using FluentValidation;
using TheatreTicketBookingSystem.Models;

namespace TheatreTicketBookingSystem.ValidateModel
{
    public class ValidatePerson : AbstractValidator<Person>
    {
        public ValidatePerson()
        {
            RuleFor(person => person.Name).NotEmpty().WithMessage("Must not be empty").MaximumLength(100).SetValidator(new IsNameValidValidate());
            RuleFor(person => person.Email).NotNull().EmailAddress().MaximumLength(250).SetValidator(new IsEmailValidValidate());
            RuleFor(person => person.Date).NotEmpty().SetValidator(new IsDateValidValidate());
        }
    }
}