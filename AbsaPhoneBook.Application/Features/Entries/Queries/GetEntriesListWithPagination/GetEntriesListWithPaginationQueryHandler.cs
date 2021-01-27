using AutoMapper;
using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbsaPhoneBook.Application.Models;
using AbsaPhoneBook.Application.Mappings;

namespace AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesListWithPagination
{
    public class GetEntriesListWithPaginationQueryHandler : IRequestHandler<GetEntriesListWithPaginationQuery, List<EntryListWithPaginationVm>>
    {
        private readonly IAsyncRepository<Entry> _entryRepository;
        private readonly IMapper _mapper;

        public GetEntriesListWithPaginationQueryHandler(IMapper mapper, IAsyncRepository<Entry> entryRepository)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
        }

        public async Task<List<EntryListWithPaginationVm>> Handle(GetEntriesListWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var allPaginatedEntries = await _entryRepository.GetPagedReponseAsync(s => s.Name.Contains(request.search), request.page, request.size);
            // var allEntries = (await _entryRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<EntryListWithPaginationVm>>(allPaginatedEntries);
            //var testAll = allPaginatedEntries.ProjectTo<EntryListWithPaginationVm>(_mapper.ConfigurationProvider)
           // return await allPaged.AsQueryable().PaginatedListAsync(request.page, request.size);
        }
    }
}
