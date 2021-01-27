

using MediatR;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Commands.CreatePhonebook
{
    public class CreatePhonebookCommand : IRequest<CreatePhonebookCommandResponse>
    {
        public string Name { get; set; }
    }
}
