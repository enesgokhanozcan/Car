using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Car.DB.Entities;

#nullable disable

namespace Car.DB.Entities.DataContext
{
    public partial class CarContext : DbContext
    {
        public CarContext()
        {
        }

        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Car;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CaseType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FuelType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Iuser).HasColumnName("IUser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.Uuser).HasColumnName("UUser");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Category");

                entity.HasOne(d => d.IuserNavigation)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.Iuser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_User");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Iuser).HasColumnName("IUser");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.Uuser).HasColumnName("UUser");

                entity.HasOne(d => d.IuserNavigation)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.Iuser)
                    .HasConstraintName("FK_Category_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("IDatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Iuser).HasColumnName("IUser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Udatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("UDatetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uuser).HasColumnName("UUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
