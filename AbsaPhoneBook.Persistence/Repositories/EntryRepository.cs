
using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Persistence.Repositories
{
    public class EntryRepository : BaseRepository<Entry>, IEntryRepository
    {
        public EntryRepository(AbsaDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEntryNameUnique(string name)
        {
            var matches =  _dbContext.Entries.Any(e => e.Name.Equals(name));
            return Task.FromResult(matches);
        }
       
    }
}
