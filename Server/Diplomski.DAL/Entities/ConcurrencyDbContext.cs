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

        public virtual DbSet<Exerciser> Exerciser { get; set; } = null!;
        public virtual DbSet<Trainer> Trainer { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<VTrainerExerciserUk> VTrainerExerciserUk { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exerciser>(entity =>
            {
                entity.HasIndex(e => e.UserId, "UC_Exerciser_UserId")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.EmergencyContactFullName).HasMaxLength(100);

                entity.Property(e => e.EmergencyContactPhoneNumber).HasMaxLength(20);

                entity.Property(e => e.MessageForCoaches).HasMaxLength(1000);

                entity.Property(e => e.UpdatedAt).HasColumnType("date");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.HasIndex(e => e.UserId, "UC_Trainer_UserId")
                    .IsUnique();

                entity.Property(e => e.Bio).HasMaxLength(1000);

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UC_User_Email")
                    .IsUnique();

                entity.HasIndex(e => e.ExerciserId, "UC_User_ExerciserId")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UC_User_PhoneNumber")
                    .IsUnique();

                entity.HasIndex(e => e.TrainerId, "UC_User_TrainerId")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(40);

                entity.Property(e => e.Password).HasMaxLength(64);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.ProfilePhotoUrl).HasMaxLength(255);

                entity.Property(e => e.SecretCode).HasMaxLength(6);

                entity.Property(e => e.SecretCodeExpiry).HasColumnType("date");

                entity.Property(e => e.UpdatedAt).HasColumnType("date");

                entity.Property(e => e.Username).HasMaxLength(75);

                entity.HasOne(d => d.Exerciser)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.ExerciserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_Exerciser");

                entity.HasOne(d => d.Trainer)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_Trainer");
            });

            modelBuilder.Entity<VTrainerExerciserUk>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_TrainerExerciser_UK");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
