using AbsaPhoneBook.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesListWithPagination
{
    public class GetEntriesListWithPaginationQuery: IRequest<List<EntryListWithPaginationVm>>
    {
        public string search { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}
