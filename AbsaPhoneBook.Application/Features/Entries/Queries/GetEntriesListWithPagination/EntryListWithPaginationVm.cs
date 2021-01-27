using System;

namespace AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesListWithPagination
{
    public class EntryListWithPaginationVm
    {
        public Guid EntryId { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
    }
}
