using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Perspective.Storing
{
    public partial class PerspectiveDBContext : DbContext
    {
        public PerspectiveDBContext()
        {
        }

        public PerspectiveDBContext(DbContextOptions<PerspectiveDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catagory> Catagory { get; set; }
        public virtual DbSet<CatagoryUserJunction> CatagoryUserJunction { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<TopicList> TopicList { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRoomJunction> UserRoomJunction { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=perspectivedb.database.windows.net;database=PerspectiveDB;user id=sqladmin;password=Password1234;");
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

            modelBuilder.Entity<CatagoryUserJunction>(entity =>
            {
                entity.HasKey(e => e.CatagoryUserId)
                    .HasName("PK__Catagory__0BCD617D94DF3021");

                entity.Property(e => e.CatagoryUserId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.CatagoryUserJunction)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CatagoryU__Catag__66603565");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CatagoryUserJunction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CatagoryU__UserI__656C112C");
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

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__RoomId__74AE54BC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__UserId__75A278F5");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Topic).HasMaxLength(50);

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room__CatagoryId__60A75C0F");
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
                    .HasConstraintName("FK__TopicList__Catag__6E01572D");
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

            modelBuilder.Entity<UserRoomJunction>(entity =>
            {
                entity.HasKey(e => e.UserRoomId)
                    .HasName("PK__UserRoom__152B95B6BCA32974");

                entity.Property(e => e.UserRoomId).ValueGeneratedNever();

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.UserRoomJunction)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRoomJ__RoomI__71D1E811");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoomJunction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRoomJ__UserI__70DDC3D8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
