using System;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Queries.GetPhonebooksListWithEntries
{
    public class PhonebookEntryDto
    {
        public Guid EntryId { get; set; }
        public string Name { get; set; }
        public Guid PhonebookId { get; set; }    }
}