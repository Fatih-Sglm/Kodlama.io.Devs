﻿// <auto-generated />
using System;
using Kodlama.io.Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    [DbContext(typeof(KodlamaIoDevsContext))]
    [Migration("20221008200132_Inıt-Mig")]
    partial class InıtMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Security.Entities.EmailAuthenticator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("ActivationKey")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ActivationKey");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit")
                        .HasColumnName("IsVerified");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailAuthenticators", (string)null);
                });

            modelBuilder.Entity("Core.Security.Entities.OperationClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("40dc9be9-7a32-45e8-b6ed-f4c768829d85"),
                            CreateDate = new DateTime(2022, 10, 8, 23, 1, 32, 364, DateTimeKind.Local).AddTicks(1777),
                            Name = "CreateProgramingLanguageCommand"
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.OtpAuthenticator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit")
                        .HasColumnName("IsVerified");

                    b.Property<byte[]>("SecretKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("SecretKey");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OtpAuthenticators", (string)null);
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreatedByIp");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2")
                        .HasColumnName("Expires");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReasonRevoked");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReplacedByToken");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2")
                        .HasColumnName("Revoked");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RevokedByIp");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Token");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Core.Security.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("26c2c16b-ce63-4ed9-b09f-962306f88fce"),
                            CreateDate = new DateTime(2022, 10, 8, 23, 1, 32, 364, DateTimeKind.Local).AddTicks(1819),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("int")
                        .HasColumnName("AuthenticatorType");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsMailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("IsMailConfirmed");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProfileLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<Guid?>("DeveloperId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DeveloperId");

                    b.Property<Guid>("ProfileTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProfileTypeId");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProfileUrl");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("ProfileTypeId");

                    b.ToTable("ProfileLinks", (string)null);
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProfileType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<string>("PType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProfileType");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.HasKey("Id");

                    b.ToTable("ProfileTypes", (string)null);
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.HasKey("Id");

                    b.ToTable("Programing_Languages", (string)null);
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.Technology", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Create_Date");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<Guid>("ProgramingLanguageId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProgramingLanguageId");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Update_Date");

                    b.HasKey("Id");

                    b.HasIndex("ProgramingLanguageId");

                    b.ToTable("Technologies", (string)null);
                });

            modelBuilder.Entity("OperationClaimRole", b =>
                {
                    b.Property<Guid>("OperationClaimsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolesClaimsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OperationClaimsId", "RolesClaimsId");

                    b.HasIndex("RolesClaimsId");

                    b.ToTable("OperationClaimRole");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RoleUsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleUsersId", "UserRoleId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.AppUser", b =>
                {
                    b.HasBaseType("Core.Security.Entities.User");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.Developer", b =>
                {
                    b.HasBaseType("Core.Security.Entities.User");

                    b.HasDiscriminator().HasValue("Developer");
                });

            modelBuilder.Entity("Core.Security.Entities.EmailAuthenticator", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.OtpAuthenticator", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProfileLink", b =>
                {
                    b.HasOne("Kodlama.io.Devs.Domain.Entities.Developer", "Developer")
                        .WithMany("ProfileLinks")
                        .HasForeignKey("DeveloperId");

                    b.HasOne("Kodlama.io.Devs.Domain.Entities.ProfileType", "ProfileType")
                        .WithMany("ProfileLinks")
                        .HasForeignKey("ProfileTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("ProfileType");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.Technology", b =>
                {
                    b.HasOne("Kodlama.io.Devs.Domain.Entities.ProgramingLanguage", "ProgramingLanguage")
                        .WithMany("Technologies")
                        .HasForeignKey("ProgramingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramingLanguage");
                });

            modelBuilder.Entity("OperationClaimRole", b =>
                {
                    b.HasOne("Core.Security.Entities.OperationClaim", null)
                        .WithMany()
                        .HasForeignKey("OperationClaimsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesClaimsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Core.Security.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("RoleUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProfileType", b =>
                {
                    b.Navigation("ProfileLinks");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Navigation("Technologies");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.Developer", b =>
                {
                    b.Navigation("ProfileLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
