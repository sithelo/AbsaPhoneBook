using AbsaPhoneBook.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsaPhoneBook.Domain.Entities
{
    public class Entry : AuditableEntity
    {
        public Guid EntryId  { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public Guid PhonebookId { get; set; }
        public Phonebook Phonebook { get; set; }

    }
}
