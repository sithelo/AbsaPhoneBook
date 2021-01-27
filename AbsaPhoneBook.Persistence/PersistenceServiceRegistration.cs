using AbsaPhoneBook.Application.Contracts.Persistence;
using AbsaPhoneBook.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AbsaPhoneBook.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AbsaDbContext>(options =>
            //options.UseSqlite("Data Source=absa.db"));
            options.UseSqlServer(configuration.GetConnectionString("AbsaConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IPhonebookRepository, PhonebookRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();

            return services;
        }
    }
}
