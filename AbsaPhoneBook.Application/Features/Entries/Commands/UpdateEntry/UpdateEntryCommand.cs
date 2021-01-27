using MediatR;
using System;

namespace AbsaPhoneBook.Application.Features.Entries.Commands.UpdateEntry
{
    public class UpdateEntryCommand: IRequest
    {
        public Guid EntryId { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public Guid PhonebookId { get; set; }
    }
}
