using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Application.Exceptions;
using AbsaPhoneBook.Domain.Entities;
using AutoMapper;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Features.Entries.Commands.UpdateEntry
{
    public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommand>
    {
        private readonly IAsyncRepository<Entry> _entryRepository;
        private readonly IMapper _mapper;

        public UpdateEntryCommandHandler(IMapper mapper, IAsyncRepository<Entry> entryRepository)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
        }

        public async Task<Unit> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
        {

            var entryToUpdate = await _entryRepository.GetByIdAsync(request.EntryId);

            if (entryToUpdate == null)
            {
                throw new NotFoundException(nameof(Entry), request.EntryId);
            }

            var validator = new UpdateEntryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, entryToUpdate, typeof(UpdateEntryCommand), typeof(Entry));

            await _entryRepository.UpdateAsync(entryToUpdate);

            return Unit.Value;
        }
    }
}