using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class KodlamaIoDevsContext : DbContext
    {
        protected IConfiguration _configuration { get; set; }
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ProfileLink> ProfileLinks { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public KodlamaIoDevsContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is not Entity entity) continue;
                var now = DateTime.Now;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreateDate = now;
                        break;

                    case EntityState.Modified:
                        entry.State = EntityState.Modified;
                        entity.UpdateDate = now;
                        break;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>(p => p.ToTable("User"));
            //modelBuilder.Entity<Developer>(p => p.ToTable("Developer"));
            //modelBuilder.Entity<ProgramingLanguage>(p =>
            //{
            //    p.ToTable("Programing_Language");
            //    p.Property(x => x.Id).HasColumnName("Id");
            //    p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
            //    p.Property(x => x.CreateDate).HasColumnName("Create_Date");
            //    p.Property(x => x.Name).HasColumnName("Name");
            //});

            //modelBuilder.Entity<Technology>(p =>
            //{
            //    p.ToTable("Technology");
            //    p.Property(x => x.Id).HasColumnName("Id");
            //    p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
            //    p.Property(x => x.CreateDate).HasColumnName("Create_Date");
            //    p.Property(x => x.Name).HasColumnName("Name");

            //    p.Property(x => x.ProgramingLanguageId).HasColumnName("Programing_LanguageId");
            //    p.Property(x => x.ProgramingLanguage);
            //});

            //modelBuilder.Entity<Developer>(p =>
            //{
            //    p.ToTable("Technology");
            //    p.Property(x => x.ProfileLinks);
            //});

            //modelBuilder.Entity<User>(p =>
            //{
            //    p.ToTable("User");
            //    p.Property(x => x.Id).HasColumnName("Id");
            //    p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
            //    p.Property(x => x.CreateDate).HasColumnName("Create_Date");


            //    p.Property(x => x.FirstName).HasColumnName("FirstName");
            //    p.Property(x => x.LastName).HasColumnName("LastName");
            //    p.Property(x => x.Email).HasColumnName("Email");
            //    p.Property(x => x.Status).HasColumnName("Status");
            //    p.Property(x => x.AuthenticatorType).HasColumnName("AuthenticatorType");
            //    p.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
            //    p.Property(x => x.PasswordHash).HasColumnName("PasswordHash");  
            //    p.Property(x => x.RefreshTokens);
            //    p.Property(x => x.UserOperationClaims);

            //});



            base.OnModelCreating(modelBuilder);
        }
    }
}
