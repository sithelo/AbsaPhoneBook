
using AbsaPhoneBook.Domain.Entities;
using AbsaPhoneBook.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Persistence
{
    public class AbsaDbContext: DbContext
    {
       
        public AbsaDbContext(DbContextOptions<AbsaDbContext> options)
           : base(options)
        {
        }


        public DbSet<Entry> Entries { get; set; }
        public DbSet<Phonebook> Phonebooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AbsaDbContext).Assembly);

            //seed data, added through migrations
            var personalGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var workGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var businessGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var leisureGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Phonebook>().HasData(new Phonebook
            {
                PhonebookId = personalGuid,
                Name = "Personal"
            });
            modelBuilder.Entity<Phonebook>().HasData(new Phonebook
            {
                PhonebookId = workGuid,
                Name = "Work"
            });
            modelBuilder.Entity<Phonebook>().HasData(new Phonebook
            {
                PhonebookId = businessGuid,
                Name = "Business"
            });
            modelBuilder.Entity<Phonebook>().HasData(new Phonebook
            {
                PhonebookId = leisureGuid,
                Name = "Leisure"
            });

            modelBuilder.Entity<Entry>().HasData(new Entry
            {
                EntryId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "John Bedfordview",
                Phonenumber = "07189898989",
               
                PhonebookId = personalGuid
            });

            modelBuilder.Entity<Entry>().HasData(new Entry
            {
                EntryId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Name = "Peter NorthCliff",
                Phonenumber = "0723333333",

                PhonebookId = personalGuid
            });

            modelBuilder.Entity<Entry>().HasData(new Entry
            {
                EntryId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "Kensington Cape",
                Phonenumber = "07155555555",

                PhonebookId = personalGuid
            });

            modelBuilder.Entity<Entry>().HasData(new Entry
            {
                EntryId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                Name = "Spanish guitar hits with Manuel",
                Phonenumber = "0712222222",

                PhonebookId = workGuid
            });

            modelBuilder.Entity<Entry>().HasData(new Entry
            {
                EntryId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                Name = "City Stadium",
                Phonenumber = "0747777777",

                PhonebookId = workGuid
            });

            modelBuilder.Entity<Entry>().HasData(new Entry
            {
                EntryId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                Name = "James Work",
              
                PhonebookId = workGuid
            });

           
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
