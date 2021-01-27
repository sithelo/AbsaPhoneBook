using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Domain.Entities;
using AutoMapper;

using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Commands.CreatePhonebook
{
    public class CreatePhonebookCommandHandler : IRequestHandler<CreatePhonebookCommand, CreatePhonebookCommandResponse>
    {
        private readonly IAsyncRepository<Phonebook> _phonebookRepository;
        private readonly IMapper _mapper;

        public CreatePhonebookCommandHandler(IMapper mapper, IAsyncRepository<Phonebook> phonebookRepository)
        {
            _mapper = mapper;
            _phonebookRepository = phonebookRepository;
        }

        public async Task<CreatePhonebookCommandResponse> Handle(CreatePhonebookCommand request, CancellationToken cancellationToken)
        {
            var createPhonebookCommandResponse = new CreatePhonebookCommandResponse();

            var validator = new CreatePhonebookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createPhonebookCommandResponse.Success = false;
                createPhonebookCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createPhonebookCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createPhonebookCommandResponse.Success)
            {
                var phonebook = new Phonebook() { Name = request.Name };
                phonebook = await _phonebookRepository.AddAsync(phonebook);
                createPhonebookCommandResponse.Phonebook = _mapper.Map<CreatePhonebookDto>(phonebook);
            }

            return createPhonebookCommandResponse;
        }
    }
}
