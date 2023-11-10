using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CRUDFootball.Models;

namespace CRUDFootball.Data
{
    public partial class FootballDbContext : DbContext
    {
        public FootballDbContext()
        {
        }

        public FootballDbContext(DbContextOptions<FootballDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-4APQKSQU\\SQLSERVEREXPRESS; Database=football_db; Trusted_Connection=True; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK__Players__Positio__398D8EEE");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
