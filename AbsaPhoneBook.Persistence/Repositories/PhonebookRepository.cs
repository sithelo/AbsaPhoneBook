using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Persistence.Repositories
{
    public class PhonebookRepository : BaseRepository<Phonebook>, IPhonebookRepository
    {
        public PhonebookRepository(AbsaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Phonebook>> GetPhonebooksWithEntries(bool includePassedEntries)
        {
            var allPhonebooks = await _dbContext.Phonebooks.Include(x => x.Entries).ToListAsync();
            if(!includePassedEntries)
            {
                allPhonebooks.ForEach(p => p.Entries.ToList().RemoveAll(c => c.LastModifiedDate < DateTime.Today));
            }
            return allPhonebooks;
        }
    }
}
