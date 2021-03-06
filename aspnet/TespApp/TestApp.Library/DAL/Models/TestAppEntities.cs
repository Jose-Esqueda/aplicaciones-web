using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestApp.Library.DAL.Models
{
    public partial class TestAppEntities : DbContext
    {
        public TestAppEntities()
        {
        }

        public TestAppEntities(DbContextOptions<TestAppEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomFiles> CustomFiles { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CustomFiles>(entity =>
            {
                entity.HasKey(e => e.customfile_id);

                entity.Property(e => e.created_at)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.description)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.is_active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.path)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.person_id);

                entity.Property(e => e.created_at)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.first_names)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.is_active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.last_names)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.user_id);

                entity.Property(e => e.created_at)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.first_names)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.is_active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.last_names)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
