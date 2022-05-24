using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Diplomski.DAL.Entities
{
    public partial class ConcurrencyDbContext : DbContext
    {
        public ConcurrencyDbContext()
        {
        }

        public ConcurrencyDbContext(DbContextOptions<ConcurrencyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bundle> Bundle { get; set; } = null!;
        public virtual DbSet<Package> Package { get; set; } = null!;
        public virtual DbSet<Session> Session { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bundle>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasColumnType("date");

                entity.HasOne(d => d.Exerciser)
                    .WithMany(p => p.Bundle)
                    .HasForeignKey(d => d.ExerciserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bundle_Exerciser");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Bundle)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bundle_Package");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("date");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.DateAndTime).HasColumnType("date");

                entity.Property(e => e.Location).HasMaxLength(250);

                entity.Property(e => e.UpdateAt).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UC_User_Email")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UC_User_PhoneNumber")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(40);

                entity.Property(e => e.Password).HasMaxLength(64);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.SecretCode).HasMaxLength(6);

                entity.Property(e => e.SecretCodeExpiry).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("date");

                entity.Property(e => e.Username).HasMaxLength(75);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
