using AutoMapper;
using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesList
{
    public class GetEntriesListQueryHandler : IRequestHandler<GetEntriesListQuery, List<EntryListVm>>
    {
        private readonly IAsyncRepository<Entry> _entryRepository;
        private readonly IMapper _mapper;

        public GetEntriesListQueryHandler(IMapper mapper, IAsyncRepository<Entry> entryRepository)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
        }

        public async Task<List<EntryListVm>> Handle(GetEntriesListQuery request, CancellationToken cancellationToken)
        {
            var allEntries = (await _entryRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<EntryListVm>>(allEntries);
        }
    }
}
