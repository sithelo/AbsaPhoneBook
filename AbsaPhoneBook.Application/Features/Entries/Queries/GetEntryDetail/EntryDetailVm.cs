using System;

namespace AbsaPhoneBook.Application.Features.Entries.Queries.GetEntryDetail
{
    public class EntryDetailVm
    {
        public Guid EntryId { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public Guid PhonebookId { get; set; }

        public string PhonebookName { get; set; }
       // public PhonebookDto Phonebook { get; set; }
    }
}
