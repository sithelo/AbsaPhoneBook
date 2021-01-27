using AbsaPhoneBook.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsaPhoneBook.Domain.Entities
{
    public class Phonebook : AuditableEntity
    {
        public Guid PhonebookId { get; set; }
        public string Name { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}
