using System;

namespace AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesList
{
    public class EntryListVm
    {
        public Guid EntryId { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
    }
}
