using FluentValidation;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Commands.CreatePhonebook
{
    public class CreatePhonebookCommandValidator : AbstractValidator<CreatePhonebookCommand>
    {
        public CreatePhonebookCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
