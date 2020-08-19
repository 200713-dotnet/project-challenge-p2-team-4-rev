using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Perspective.Storing
{
    public partial class PerspectiveContext : DbContext
    {
        public PerspectiveContext()
        {
        }

        public PerspectiveContext(DbContextOptions<PerspectiveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catagory> Catagory { get; set; }
        public virtual DbSet<CatagoryRoomJunction> CatagoryRoomJunction { get; set; }
        public virtual DbSet<CatagoryUserJunction> CatagoryUserJunction { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MessageJunction> MessageJunction { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<TopicList> TopicList { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WaitList> WaitList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=perspectivedb.database.windows.net;database=Perspective;user id=sqladmin;password=Password1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>(entity =>
            {
                entity.Property(e => e.CatagoryId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CatagoryRoomJunction>(entity =>
            {
                entity.HasKey(e => e.CatagoryRoomId)
                    .HasName("PK__Catagory__41B1116E482078E8");

                entity.Property(e => e.CatagoryRoomId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.CatagoryRoomJunction)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CatagoryR__Catag__693CA210");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.CatagoryRoomJunction)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CatagoryR__RoomI__68487DD7");
            });

            modelBuilder.Entity<CatagoryUserJunction>(entity =>
            {
                entity.HasKey(e => e.CatagoryUserId)
                    .HasName("PK__Catagory__0BCD617D01646CE9");

                entity.Property(e => e.CatagoryUserId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.CatagoryUserJunction)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CatagoryU__Catag__656C112C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CatagoryUserJunction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CatagoryU__UserI__6477ECF3");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId).ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(250);

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MessageJunction>(entity =>
            {
                entity.Property(e => e.MessageJunctionId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MessageJunction)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MessageJu__Messa__71D1E811");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.MessageJunction)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MessageJu__RoomI__6FE99F9F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MessageJunction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MessageJu__UserI__70DDC3D8");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Topic).HasMaxLength(50);
            });

            modelBuilder.Entity<TopicList>(entity =>
            {
                entity.Property(e => e.TopicListId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.TopicList)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TopicList__Catag__74AE54BC");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WaitList>(entity =>
            {
                entity.Property(e => e.WaitListId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.WaitList)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WaitList__Catago__6D0D32F4");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.WaitList)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WaitList__RoomId__6C190EBB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
