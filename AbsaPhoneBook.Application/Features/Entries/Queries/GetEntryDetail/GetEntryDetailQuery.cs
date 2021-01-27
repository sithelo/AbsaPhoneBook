using MediatR;
using System;

namespace AbsaPhoneBook.Application.Features.Entries.Queries.GetEntryDetail
{
    public class GetEntryDetailQuery: IRequest<EntryDetailVm>
    {
        public Guid Id { get; set; }
    }
}
