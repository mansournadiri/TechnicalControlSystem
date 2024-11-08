using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Persistence.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }
        public virtual DbSet<VerificationCode> VerificationCodes { get; set; }

        public virtual DbSet<Lookup> Lookups { get; set; }

        public virtual DbSet<Party> Parties { get; set; }

        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VerificationCode>(entity =>
            {
                entity.ToTable("VerificationCode", "SYS3");
                entity.Property(e => e.verificationId).ValueGeneratedNever().HasColumnName("verificationId");
                entity.HasKey(e => e.verificationId).HasName("PK_HSE_VerificationCode");

            });
            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.HasKey(e => e.LookupId).HasName("PK_SYS_Lookup");

                entity.ToTable("Lookup", "SYS3");

                entity.Property(e => e.LookupId)
                    .ValueGeneratedNever()
                    .HasColumnName("LookupID");
                entity.Property(e => e.DisplayOrderDateTime).HasColumnType("datetime");
                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.HasKey(e => e.PartyId).HasName("PK_BSE_Party");

                entity.ToTable("Party", "BSE");

                entity.Property(e => e.PartyId)
                    .ValueGeneratedNever()
                    .HasColumnName("PartyID");
                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.ActivityType).HasMaxLength(50);
                entity.Property(e => e.Alias).HasMaxLength(50);
                entity.Property(e => e.BirthDate).HasColumnType("datetime");
                entity.Property(e => e.CompanyCode).HasMaxLength(20);
                entity.Property(e => e.CompanyName).HasMaxLength(100);
                entity.Property(e => e.CompanyNameEn)
                    .HasMaxLength(100)
                    .HasColumnName("CompanyName_EN");
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.Property(e => e.EconomicCode).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.FatherName).HasMaxLength(50);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.FirstNameEn)
                    .HasMaxLength(50)
                    .HasColumnName("FirstName_EN");
                entity.Property(e => e.FullName)
                    .HasMaxLength(101)
                    .HasComputedColumnSql("(case [Type] when (0) then ([FirstName]+N' ')+[LastName] else [CompanyName] end)", false);
                entity.Property(e => e.FullNameEn)
                    .HasMaxLength(101)
                    .HasComputedColumnSql("(case [Type] when (0) then ([FirstName_EN]+N' ')+[LastName_EN] else [CompanyName_EN] end)", false)
                    .HasColumnName("FullName_EN");
                entity.Property(e => e.Guid)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("GUID");
                entity.Property(e => e.IssuanceDate).HasColumnType("datetime");
                entity.Property(e => e.LastModificationDate).HasColumnType("datetime");
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.LastNameEn)
                    .HasMaxLength(50)
                    .HasColumnName("LastName_EN");
                entity.Property(e => e.MarriageDate).HasColumnType("datetime");
                entity.Property(e => e.Mobile).HasMaxLength(20);
                entity.Property(e => e.NationalId)
                    .HasMaxLength(20)
                    .HasColumnName("NationalID");
                entity.Property(e => e.Nationality).HasMaxLength(20);
                entity.Property(e => e.Tel).HasMaxLength(20);
                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Website).HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK_BSE_User");

                entity.ToTable("User", "BSE");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");
                entity.Property(e => e.AppLoginDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("AppLogin_DateTime");
                entity.Property(e => e.AppLoginUpdateDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("AppLogin_Update_DateTime");
                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date");
                entity.Property(e => e.guid)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("GUID");
                entity.Property(e => e.Ip).HasColumnName("IP");
                entity.Property(e => e.Ipvalid).HasColumnName("IPValid");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modify_Date");
                entity.Property(e => e.PasswordHistory).HasColumnName("Password_History");
                entity.Property(e => e.PasswordIsChanged).HasDefaultValue(true);
                entity.Property(e => e.RemoveDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Remove_DateTime");
                entity.HasQueryFilter(x => !x.IsDeleted);
            });
        }
    }
}
