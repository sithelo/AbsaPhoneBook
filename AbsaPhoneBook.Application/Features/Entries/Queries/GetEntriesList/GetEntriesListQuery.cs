using MediatR;
using System.Collections.Generic;

namespace AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesList
{
    public class GetEntriesListQuery: IRequest<List<EntryListVm>>
    {
        public string search { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}
