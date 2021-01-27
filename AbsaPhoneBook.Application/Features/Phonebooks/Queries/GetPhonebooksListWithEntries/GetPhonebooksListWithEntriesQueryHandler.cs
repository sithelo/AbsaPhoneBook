using AbsaPhoneBook.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Queries.GetPhonebooksListWithEntries
{
    public class GetPhonebooksListWithEntriesQueryHandler: IRequestHandler<GetPhonebooksListWithEntriesQuery, List<PhonebookEntryListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IPhonebookRepository _phonebookRepository;
        public GetPhonebooksListWithEntriesQueryHandler(IMapper mapper, IPhonebookRepository phonebookRepository)
        {
            _mapper = mapper;
            _phonebookRepository = phonebookRepository;
        }
        public async Task<List<PhonebookEntryListVm>> Handle(GetPhonebooksListWithEntriesQuery request, CancellationToken cancellationToken)
        {
            var list = await _phonebookRepository.GetPhonebooksWithEntries(request.IncludeHistory);
            return _mapper.Map<List<PhonebookEntryListVm>>(list);
        }
    }
}
