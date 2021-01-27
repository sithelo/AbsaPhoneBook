using AbsaPhoneBook.Application.Features.Entries.Commands.CreateEntry;
using AbsaPhoneBook.Application.Features.Entries.Commands.UpdateEntry;
using AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesList;
using AbsaPhoneBook.Application.Features.Entries.Queries.GetEntriesListWithPagination;
using AbsaPhoneBook.Application.Features.Entries.Queries.GetEntryDetail;
using AbsaPhoneBook.Application.Features.Phonebooks.Queries.GetPhonebooksList;
using AbsaPhoneBook.Application.Features.Phonebooks.Queries.GetPhonebooksListWithEntries;
using AbsaPhoneBook.Domain.Entities;
using AutoMapper;

namespace AbsaPhoneBook.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // CreateMap<Entry, EntryListVm>().ReverseMap();
            CreateMap<Entry, EntryDetailVm>().ReverseMap();
            CreateMap<Entry, PhonebookEntryDto>().ReverseMap();
            CreateMap<Entry, UpdateEntryCommand>().ReverseMap();
            CreateMap<Entry, CreateEntryCommand>().ReverseMap();

            CreateMap<Phonebook, PhonebookDto>();
            CreateMap<Phonebook, PhonebookListVm>();
            CreateMap<Entry, EntryListWithPaginationVm>();
            CreateMap<Entry, EntryListVm>();

            // CreateMap<Phonebook, PhonebookEntryListVm>();
        }
    }
}
