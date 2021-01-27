using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Domain.Entities;
using AutoMapper;

using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Features.Entries.Commands.CreateEntry
{
    public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Guid>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEntryCommandHandler> _logger;


        public CreateEntryCommandHandler(IMapper mapper, IEntryRepository entryRepository, ILogger<CreateEntryCommandHandler> logger)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEntryCommandValidator(_entryRepository);
            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @entry = _mapper.Map<Entry>(request);

            @entry = await _entryRepository.AddAsync(@entry);
            

            return @entry.EntryId;
        }
    }
}