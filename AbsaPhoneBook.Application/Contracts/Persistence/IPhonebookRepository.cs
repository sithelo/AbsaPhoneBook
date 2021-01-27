
using AbsaPhoneBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Contracts.Persistence
{
    public interface IPhonebookRepository : IAsyncRepository<Phonebook>
    {
        Task<List<Phonebook>> GetPhonebooksWithEntries(bool includePassedEntries);
    }
}
