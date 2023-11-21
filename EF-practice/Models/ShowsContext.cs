using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF_practice.Models
{
    public partial class ShowsContext : DbContext
    {
        public ShowsContext()
        {
        }

        public ShowsContext(DbContextOptions<ShowsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=Shows; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Idevent)
                    .HasName("PK__Event__97E9D4914E7D1592");

                entity.ToTable("Event");

                entity.Property(e => e.Idevent)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEvent");

                entity.Property(e => e.DateEvent).HasColumnType("date");

                entity.Property(e => e.NameEvent)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceEvent)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Idticket)
                    .HasName("PK__Tickets__E6F3419B8BDAA8E6");

                entity.Property(e => e.Idticket)
                    .ValueGeneratedNever()
                    .HasColumnName("IDTicket");

                entity.Property(e => e.Idevent).HasColumnName("IDEvent");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdeventNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Idevent)
                    .HasConstraintName("FK__Tickets__IDEvent__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
