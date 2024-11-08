﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241107180453_UpdatePartyTable")]
    partial class UpdatePartyTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Lookup", b =>
                {
                    b.Property<long>("LookupId")
                        .HasColumnType("bigint")
                        .HasColumnName("LookupID");

                    b.Property<bool?>("CanDelete")
                        .HasColumnType("bit");

                    b.Property<bool?>("CanEdit")
                        .HasColumnType("bit");

                    b.Property<int?>("Code")
                        .HasColumnType("int");

                    b.Property<bool?>("CompleteProcessing")
                        .HasColumnType("bit");

                    b.Property<string>("CustomClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DeclineAccess")
                        .HasColumnType("bit");

                    b.Property<bool?>("Disable")
                        .HasColumnType("bit");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DisplayOrderDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("ExtraText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("FaildProcessing")
                        .HasColumnType("bit");

                    b.Property<bool?>("OnProcessing")
                        .HasColumnType("bit");

                    b.Property<bool?>("PermitNeed")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("LookupId");

                    b.ToTable("Lookup", "SYS3");
                });

            modelBuilder.Entity("Domain.Entity.Party", b =>
                {
                    b.Property<long>("PartyId")
                        .HasColumnType("bigint")
                        .HasColumnName("PartyID");

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("ActivityType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<long?>("BirthPlaceRef")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CompanyIdentity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CompanyNameEn")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CompanyName_EN");

                    b.Property<int?>("CompanyType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<long?>("Creator")
                        .HasColumnType("bigint");

                    b.Property<string>("EconomicCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("EducationDegree")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FatherName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstNameEn")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName_EN");

                    b.Property<string>("FullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(101)
                        .HasColumnType("nvarchar(101)")
                        .HasComputedColumnSql("(case [Type] when (0) then ([FirstName]+N' ')+[LastName] else [CompanyName] end)", false);

                    b.Property<string>("FullNameEn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(101)
                        .HasColumnType("nvarchar(101)")
                        .HasColumnName("FullName_EN")
                        .HasComputedColumnSql("(case [Type] when (0) then ([FirstName_EN]+N' ')+[LastName_EN] else [CompanyName_EN] end)", false);

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GUID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime?>("IssuanceDate")
                        .HasColumnType("datetime");

                    b.Property<long?>("IssuancePlaceRef")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastModificationDate")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifier")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastNameEn")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName_EN");

                    b.Property<int?>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("MarriageDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NationalId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NationalID");

                    b.Property<string>("Nationality")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Tel")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Website")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PartyId")
                        .HasName("PK_BSE_Party");

                    b.ToTable("Party", "BSE");
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<string>("AppBearerToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("AppLogin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("AppLoginDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("AppLogin_DateTime");

                    b.Property<DateTime?>("AppLoginUpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("AppLogin_Update_DateTime");

                    b.Property<string>("AppMacLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrowserData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CookieData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Creation_Date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("Creator")
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IP");

                    b.Property<string>("Ipvalid")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IPValid");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<int?>("Modifier")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Modify_Date");

                    b.Property<long>("PartyRef")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHistory")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password_History");

                    b.Property<bool?>("PasswordIsChanged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool?>("Remove")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("Remove_DateTime");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GUID")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("UserId")
                        .HasName("PK_Co_Users");

                    b.ToTable("User", "BSE");
                });
#pragma warning restore 612, 618
        }
    }
}
