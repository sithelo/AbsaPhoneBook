using System;
using System.Collections.Generic;
using System.Text;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Queries.GetPhonebooksListWithEntries
{
    public class PhonebookEntryListVm
    {
        public Guid PhoneBookId { get; set; }
        public string Name { get; set; }
        public ICollection<PhonebookEntryDto> Entries { get; set; }
    }
}
