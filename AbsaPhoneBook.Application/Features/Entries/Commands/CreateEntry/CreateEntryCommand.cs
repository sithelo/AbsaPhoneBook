using MediatR;
using System;

namespace AbsaPhoneBook.Application.Features.Entries.Commands.CreateEntry
{
    public class CreateEntryCommand: IRequest<Guid>
    {
        public string Name { get; set; }
        public string Phonenumber { get; set; }

        public Guid PhonebookId { get; set; }
       
    }
}
