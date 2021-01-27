using FluentValidation;
using AbsaPhoneBook.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Features.Entries.Commands.CreateEntry
{
    public class CreateEntryCommandValidator : AbstractValidator<CreateEntryCommand>
    {
        private readonly IEntryRepository _entryRepository;
        public CreateEntryCommandValidator(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

          
            RuleFor(e => e)
                .MustAsync(EntryNameUnique)
                .WithMessage("An entry with the same name and date already exists.");

        }

        private async Task<bool> EntryNameUnique(CreateEntryCommand e, CancellationToken token)
        {
            return !(await _entryRepository.IsEntryNameUnique(e.Name));
        }
    }
}
