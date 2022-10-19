using Core.Domain.Base;
using Core.Domain.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class KodlamaIoDevsContext : DbContext
    {
        public KodlamaIoDevsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ProfileLink> ProfileLinks { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
        public DbSet<Role> Roles { get; set; }



        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is not IEntity entity) continue;
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
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLanguage>(p =>
            {
                p.ToTable("Programing_Languages");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");
                p.Property(x => x.Name).HasColumnName("Name");
                p.HasMany(x => x.Technologies);
            });

            modelBuilder.Entity<OtpAuthenticator>(p =>
            {
                p.ToTable("OtpAuthenticators");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");
                p.Property(x => x.UserId).HasColumnName("UserId");
                p.Property(x => x.SecretKey).HasColumnName("SecretKey");
                p.Property(x => x.IsVerified).HasColumnName("IsVerified");
                p.HasOne(x => x.User);
            });

            modelBuilder.Entity<EmailAuthenticator>(p =>
            {
                p.ToTable("EmailAuthenticators");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");
                p.Property(x => x.UserId).HasColumnName("UserId");
                p.Property(x => x.ActivationKey).HasColumnName("ActivationKey");
                p.Property(x => x.IsVerified).HasColumnName("IsVerified");
                p.HasOne(x => x.User);
            });

            modelBuilder.Entity<RefreshToken>(p =>
            {
                p.ToTable("RefreshTokens");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");

                p.Property(x => x.UserId).HasColumnName("UserId");
                p.Property(x => x.Token).HasColumnName("Token");
                p.Property(x => x.Expires).HasColumnName("Expires");
                p.Property(x => x.CreatedByIp).HasColumnName("CreatedByIp");
                p.Property(x => x.Revoked).HasColumnName("Revoked");
                p.Property(x => x.RevokedByIp).HasColumnName("RevokedByIp");
                p.Property(x => x.ReplacedByToken).HasColumnName("ReplacedByToken");
                p.Property(x => x.ReasonRevoked).HasColumnName("ReasonRevoked");
                p.HasOne(x => x.User).WithMany(x => x.RefreshTokens);
            });

            modelBuilder.Entity<Technology>(p =>
            {
                p.ToTable("Technologies");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");
                p.Property(x => x.Name).HasColumnName("Name");
                p.Property(x => x.ProgramingLanguageId).HasColumnName("ProgramingLanguageId");
                p.HasOne(x => x.ProgramingLanguage);
            });

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Email).HasColumnName("Email");
                p.Property(x => x.Status).HasColumnName("Status");
                p.Property(x => x.AuthenticatorType).HasColumnName("AuthenticatorType");
                p.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
                p.Property(x => x.IsMailConfirmed).HasColumnName("IsMailConfirmed");
                p.HasMany(x => x.RefreshTokens).WithOne(x => x.User);
                p.HasMany(x => x.UserRole).WithMany(x => x.RoleUsers);
            });

            modelBuilder.Entity<ProfileLink>(p =>
            {
                p.ToTable("ProfileLinks");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");
                p.Property(x => x.ProfileTypeId).HasColumnName("ProfileTypeId");
                p.Property(x => x.ProfileUrl).HasColumnName("ProfileUrl");
                p.Property(x => x.DeveloperId).HasColumnName("DeveloperId");
                p.HasOne(x => x.ProfileType);
                p.HasOne(x => x.Developer);
            });

            modelBuilder.Entity<ProfileType>(p =>
            {
                p.ToTable("ProfileTypes");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");
                p.Property(x => x.PType).HasColumnName("ProfileType");
                p.HasMany(x => x.ProfileLinks);
            });

            modelBuilder.Entity<Developer>(p =>
            {
                p.HasMany(x => x.ProfileLinks);
            });
            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");
                p.Property(x => x.Name).HasColumnName("Name");
                p.HasMany(x => x.RolesClaims);
            });

            modelBuilder.Entity<Role>(p =>
            {
                p.ToTable("Roles");
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UpdateDate).HasColumnName("Update_Date");
                p.Property(x => x.CreateDate).HasColumnName("Create_Date");
                p.Property(x => x.Name).HasColumnName("Name");
                p.HasMany(x => x.OperationClaims).WithMany(x => x.RolesClaims);
                p.HasMany(x => x.RoleUsers).WithMany(x => x.UserRole);
            });

            OperationClaim operationClaim = new()
            {
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "CreateProgramingLanguageCommand",
            };

            Role role = new()
            {
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "Admin",
            };

            modelBuilder.Entity<Role>().HasData(role);
            modelBuilder.Entity<OperationClaim>().HasData(operationClaim);
        }
    }
}