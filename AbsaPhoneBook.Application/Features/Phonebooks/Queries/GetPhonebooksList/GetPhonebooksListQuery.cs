using MediatR;
using System.Collections.Generic;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Queries.GetPhonebooksList
{
    public class GetPhonebooksListQuery : IRequest<List<PhonebookListVm>>
    {
    }
}
