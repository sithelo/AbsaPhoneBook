
using AbsaPhoneBook.Application.Application.Responses;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Commands.CreatePhonebook
{
    public class CreatePhonebookCommandResponse: BaseResponse
    {
        public CreatePhonebookCommandResponse(): base()
        {

        }

        public CreatePhonebookDto Phonebook { get; set; }
    }
}