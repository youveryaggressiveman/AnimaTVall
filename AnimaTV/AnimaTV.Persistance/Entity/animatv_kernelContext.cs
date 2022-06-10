using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AnimaTV.Persistance.Entity
{
    public partial class animatv_kernelContext : DbContext
    {
        public animatv_kernelContext()
        {
        }

        public animatv_kernelContext(DbContextOptions<animatv_kernelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payer> Payers { get; set; }
        public virtual DbSet<PayerOfUserSubscription> PayerOfUserSubscriptions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SubscrationType> SubscrationTypes { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<TermSubscription> TermSubscriptions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserOfSubscription> UserOfSubscriptions { get; set; }
        public virtual DbSet<UserOfVideo> UserOfVideos { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=32-5\\SQLEXPRESS;Database=animatv_kernel;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Payer>(entity =>
            {
                entity.ToTable("Payer");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.CardholderName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PayerOfUserSubscription>(entity =>
            {
                entity.HasKey(e => new { e.PayerId, e.UserOfSubscriptionId })
                    .HasName("PK__PayerOfU__A265338B569D9973");

                entity.ToTable("PayerOfUserSubscription");

                entity.Property(e => e.PayerId)
                    .HasMaxLength(50)
                    .HasColumnName("PayerID");

                entity.Property(e => e.UserOfSubscriptionId)
                    .HasMaxLength(50)
                    .HasColumnName("UserOfSubscriptionID");

                entity.HasOne(d => d.Payer)
                    .WithMany(p => p.PayerOfUserSubscriptions)
                    .HasForeignKey(d => d.PayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PayerOfUs__Payer__3C69FB99");

                entity.HasOne(d => d.UserOfSubscription)
                    .WithMany(p => p.PayerOfUserSubscriptions)
                    .HasForeignKey(d => d.UserOfSubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PayerOfUs__UserO__3D5E1FD2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SubscrationType>(entity =>
            {
                entity.ToTable("SubscrationType");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("Subscription");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.RightId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RightID");

                entity.Property(e => e.SubscrationTypeId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SubscrationTypeID");

                entity.Property(e => e.TermSubscriptionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TermSubscriptionID");

                entity.HasOne(d => d.SubscrationType)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.SubscrationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscript__Subsc__32E0915F");

                entity.HasOne(d => d.TermSubscription)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.TermSubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscript__TermS__33D4B598");
            });

            modelBuilder.Entity<TermSubscription>(entity =>
            {
                entity.ToTable("TermSubscription");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.AddressId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("AddressID");

                entity.Property(e => e.Avatar).HasColumnType("image");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIrstName");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rate)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RoleID");

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RoleID__267ABA7A");
            });

            modelBuilder.Entity<UserOfSubscription>(entity =>
            {
                entity.ToTable("UserOfSubscription");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.SubscriptionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SubscriptionID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.UserOfSubscriptions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOfSub__Subsc__398D8EEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOfSubscriptions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOfSub__UserI__38996AB5");
            });

            modelBuilder.Entity<UserOfVideo>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.VideoId })
                    .HasName("PK__UserOfVi__AC269D88D2E1C8C7");

                entity.ToTable("UserOfVideo");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.Property(e => e.VideoId)
                    .HasMaxLength(50)
                    .HasColumnName("VideoID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOfVideos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOfVid__UserI__2B3F6F97");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.UserOfVideos)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOfVid__Video__2C3393D0");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Video");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
