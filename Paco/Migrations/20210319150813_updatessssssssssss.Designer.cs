﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Paco.Repositories.Database;

namespace Paco.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210319150813_updatessssssssssss")]
    partial class updatessssssssssss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.1.21102.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Paco.Entities.Models.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ManagedSystemGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManagedSystemGroupId");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4"),
                            ConcurrencyStamp = "aa6b91cf-6b3a-412d-810f-f3fd3555d446",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("248f87b1-6382-4c82-95e3-feb6824dcbe2"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "34acbb54-9ae3-4742-af3c-89de44e306e0",
                            Email = "asd@asd.asd",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ASD@ASD.ASD",
                            NormalizedUserName = "ASD@ASD.ASD",
                            PasswordHash = "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU",
                            TwoFactorEnabled = false,
                            UserName = "asd@asd.asd"
                        });
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b62db8cf-e416-4f90-a3f0-263f03e35c45"),
                            UserId = new Guid("248f87b1-6382-4c82-95e3-feb6824dcbe2"),
                            RoleId = new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4")
                        });
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Paco.Entities.Models.LogRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LogEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageTemplate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceContext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("TimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("LogRecords");
                });

            modelBuilder.Entity("Paco.Entities.Models.ManagedSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Distribution")
                        .HasColumnType("int");

                    b.Property<string>("Hostname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InteractionReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastAccessed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NeedsInteraction")
                        .HasColumnType("bit");

                    b.Property<int>("PackageActions")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SshPrivateKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemFingerprint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatesFetchedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ManagedSystems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa33052b-e176-4e55-873b-11cb99a9362d"),
                            Distribution = 0,
                            Hostname = "none.test.test",
                            Login = "test",
                            Name = "PermNone",
                            NeedsInteraction = false,
                            PackageActions = 0,
                            Password = "test",
                            SystemFingerprint = "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53"
                        },
                        new
                        {
                            Id = new Guid("ee290dc1-d530-4fce-9c4c-dcf586ea3924"),
                            Distribution = 0,
                            Hostname = "multiple.test.test",
                            Login = "test",
                            Name = "PermMultiple",
                            NeedsInteraction = false,
                            PackageActions = 0,
                            Password = "test",
                            SystemFingerprint = "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53"
                        });
                });

            modelBuilder.Entity("Paco.Entities.Models.ManagedSystemGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ManagedSystemGroups");
                });

            modelBuilder.Entity("Paco.Entities.Models.ManagedSystemManagedSystemGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagedSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagedSystemGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "ManagedSystemId", "ManagedSystemGroupId");

                    b.HasIndex("ManagedSystemGroupId");

                    b.HasIndex("ManagedSystemId");

                    b.ToTable("ManagedSystemManagedSystemGroups");
                });

            modelBuilder.Entity("Paco.Entities.Models.RoleManagedSystemGroupPermissions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagedSystemGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<short>("Permissions")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "RoleId", "ManagedSystemGroupId");

                    b.HasIndex("ManagedSystemGroupId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleManagedSystemGroupPermissions");
                });

            modelBuilder.Entity("Paco.Entities.Models.RoleManagedSystemPermissions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagedSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<short>("Permissions")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "RoleId", "ManagedSystemId");

                    b.HasIndex("ManagedSystemId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleManagedSystemPermissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("524392ff-6a23-43bd-9804-af5799ec2a45"),
                            RoleId = new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4"),
                            ManagedSystemId = new Guid("aa33052b-e176-4e55-873b-11cb99a9362d"),
                            Permissions = (short)0
                        },
                        new
                        {
                            Id = new Guid("68fe8784-defe-49ea-a7e9-2f00ba764b41"),
                            RoleId = new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4"),
                            ManagedSystemId = new Guid("ee290dc1-d530-4fce-9c4c-dcf586ea3924"),
                            Permissions = (short)7
                        });
                });

            modelBuilder.Entity("Paco.Entities.Models.Updating.ScheduledAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ManagedSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ScheduledActionStatus")
                        .HasColumnType("int");

                    b.Property<int>("ScheduledActionType")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScheduledAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManagedSystemId");

                    b.ToTable("ScheduledActions");
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.Role", b =>
                {
                    b.HasOne("Paco.Entities.Models.ManagedSystemGroup", null)
                        .WithMany("Roles")
                        .HasForeignKey("ManagedSystemGroupId");
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.RoleClaim", b =>
                {
                    b.HasOne("Paco.Entities.Models.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.UserClaim", b =>
                {
                    b.HasOne("Paco.Entities.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.UserLogin", b =>
                {
                    b.HasOne("Paco.Entities.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.UserRole", b =>
                {
                    b.HasOne("Paco.Entities.Models.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paco.Entities.Models.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.UserToken", b =>
                {
                    b.HasOne("Paco.Entities.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paco.Entities.Models.ManagedSystemManagedSystemGroup", b =>
                {
                    b.HasOne("Paco.Entities.Models.ManagedSystemGroup", "ManagedSystemGroup")
                        .WithMany("ManagedSystemManagedSystemGroups")
                        .HasForeignKey("ManagedSystemGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paco.Entities.Models.ManagedSystem", "ManagedSystem")
                        .WithMany("ManagedSystemManagedSystemGroups")
                        .HasForeignKey("ManagedSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManagedSystem");

                    b.Navigation("ManagedSystemGroup");
                });

            modelBuilder.Entity("Paco.Entities.Models.RoleManagedSystemGroupPermissions", b =>
                {
                    b.HasOne("Paco.Entities.Models.ManagedSystemGroup", "ManagedSystemGroup")
                        .WithMany("RoleManagedSystemGroupPermissions")
                        .HasForeignKey("ManagedSystemGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paco.Entities.Models.Identity.Role", "Role")
                        .WithMany("RoleManagedSystemGroupPermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManagedSystemGroup");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Paco.Entities.Models.RoleManagedSystemPermissions", b =>
                {
                    b.HasOne("Paco.Entities.Models.ManagedSystem", "ManagedSystem")
                        .WithMany("RoleManagedSystemPermissions")
                        .HasForeignKey("ManagedSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paco.Entities.Models.Identity.Role", "Role")
                        .WithMany("RoleManagedSystemPermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManagedSystem");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Paco.Entities.Models.Updating.ScheduledAction", b =>
                {
                    b.HasOne("Paco.Entities.Models.ManagedSystem", "ManagedSystem")
                        .WithMany("ScheduledActions")
                        .HasForeignKey("ManagedSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManagedSystem");
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.Role", b =>
                {
                    b.Navigation("RoleManagedSystemGroupPermissions");

                    b.Navigation("RoleManagedSystemPermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Paco.Entities.Models.Identity.User", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Paco.Entities.Models.ManagedSystem", b =>
                {
                    b.Navigation("ManagedSystemManagedSystemGroups");

                    b.Navigation("RoleManagedSystemPermissions");

                    b.Navigation("ScheduledActions");
                });

            modelBuilder.Entity("Paco.Entities.Models.ManagedSystemGroup", b =>
                {
                    b.Navigation("ManagedSystemManagedSystemGroups");

                    b.Navigation("RoleManagedSystemGroupPermissions");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
