using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class KodlamaIoDevsContext : DbContext
    {
        protected IConfiguration _configuration { get; set; }
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }

        public KodlamaIoDevsContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }
    }
}
