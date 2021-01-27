using AbsaPhoneBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Contracts.Persistence
{
    public interface IEntryRepository : IAsyncRepository<Entry>
    {
        Task<bool> IsEntryNameUnique(string name);
    }
}
