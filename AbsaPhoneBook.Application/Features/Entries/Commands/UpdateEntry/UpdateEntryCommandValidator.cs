using FluentValidation;

namespace AbsaPhoneBook.Application.Features.Entries.Commands.UpdateEntry
{
    public class UpdateEntryCommandValidator : AbstractValidator<UpdateEntryCommand>
    {
        public UpdateEntryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Phonenumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} must not exceed 15 characters.");
        }
    }
}
