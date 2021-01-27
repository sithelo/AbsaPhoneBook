using System;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Commands.CreatePhonebook
{
    public class CreatePhonebookDto
    {
        public Guid PhonebookId { get; set; }
        public string Name { get; set; }
    }
}