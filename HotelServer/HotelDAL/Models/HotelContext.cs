using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelDAL.Models
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<RoomToGuest> RoomToGuests { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rivka\\Desktop\\project\\good\\HotelServer\\HotelDAL\\DB\\HotelDB.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64D84082B826");

                entity.Property(e => e.EmailAddress).HasMaxLength(80);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber1).HasMaxLength(15);

                entity.Property(e => e.PhoneNumber2).HasMaxLength(50);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageContent)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MessageDatetime).HasColumnType("datetime");

                entity.Property(e => e.RequestOrResponse).HasMaxLength(50);

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.Messages)
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__Messages__UserId__4BAC3F29");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__25869641");
            });

            modelBuilder.Entity<RoomToGuest>(entity =>
            {
                entity.ToTable("RoomToGuest");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Qr)
                    .HasMaxLength(100)
                    .HasColumnName("QR");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.RoomToGuests)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoomToGue__Order__2D27B809");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__Schedule__7944C81078B79799");

                entity.ToTable("Schedule");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Time).HasColumnType("time(0)");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
