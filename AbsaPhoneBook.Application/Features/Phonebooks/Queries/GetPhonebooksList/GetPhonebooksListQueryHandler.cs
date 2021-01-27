using AutoMapper;
using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Queries.GetPhonebooksList
{
    public class GetPhonebooksListQueryHandler : IRequestHandler<GetPhonebooksListQuery, List<PhonebookListVm>>
    {
        private readonly IAsyncRepository<Phonebook> _phonebookRepository;
        private readonly IMapper _mapper;

        public GetPhonebooksListQueryHandler(IMapper mapper, IAsyncRepository<Phonebook> phonebookRepository)
        {
            _mapper = mapper;
            _phonebookRepository = phonebookRepository;
        }

        public async Task<List<PhonebookListVm>> Handle(GetPhonebooksListQuery request, CancellationToken cancellationToken)
        {
            var allPhonebooks = (await _phonebookRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<PhonebookListVm>>(allPhonebooks);
        }
    }
}
