using AutoMapper;
using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Application.Exceptions;
using AbsaPhoneBook.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Features.Entries.Queries.GetEntryDetail
{
    public class GetEntryDetailQueryHandler : IRequestHandler<GetEntryDetailQuery, EntryDetailVm>
    {
        private readonly IAsyncRepository<Entry> _entryRepository;
        private readonly IAsyncRepository<Phonebook> _phonebookRepository;
        private readonly IMapper _mapper;

        public GetEntryDetailQueryHandler(IMapper mapper, IAsyncRepository<Entry> entryRepository, IAsyncRepository<Phonebook> phonebookRepository)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
            _phonebookRepository = phonebookRepository;
        }

        public async Task<EntryDetailVm> Handle(GetEntryDetailQuery request, CancellationToken cancellationToken)
        {
            var @entry = await _entryRepository.GetByIdAsync(request.Id);
            var entryDetailDto = _mapper.Map<EntryDetailVm>(@entry);
            
            var phonebook = await _phonebookRepository.GetByIdAsync(@entry.PhonebookId);

            if (phonebook == null)
            {
                throw new NotFoundException(nameof(Entry), request.Id);
            }
            entryDetailDto.PhonebookName = phonebook.Name;
            //entryDetailDto.PhonebookName = _mapper.Map<PhonebookDto>(phonebook);
         //   entryDetailDto.Phonebook = _mapper.Map<PhonebookDto>(phonebook);

            return entryDetailDto;
        }
    }
}
