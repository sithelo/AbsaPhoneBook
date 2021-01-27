using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsaPhoneBook.Application.Features.Phonebooks.Queries.GetPhonebooksListWithEntries
{
    public class GetPhonebooksListWithEntriesQuery: IRequest<List<PhonebookEntryListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
