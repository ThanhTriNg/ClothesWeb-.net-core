using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class ClothesWebContext : DbContext
    {
        public ClothesWebContext()
        {
        }

        public ClothesWebContext(DbContextOptions<ClothesWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Clothe> Clothes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<OderDetail> OderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ShippingMode> ShippingModes { get; set; }
        public virtual DbSet<ShippingRate> ShippingRates { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=ThanhTri;user Id=sa;password=1;database=ClothesWeb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryDetails).HasMaxLength(500);

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Clothe>(entity =>
            {
                entity.HasKey(e => e.ClothesId);

                entity.Property(e => e.ClothesId).HasColumnName("ClothesID");

                entity.Property(e => e.ClothesDescription).HasMaxLength(999);

                entity.Property(e => e.ClothesName).HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Clothes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Clothes_Category");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName).HasMaxLength(50);
            });

            modelBuilder.Entity<OderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ClothesId });

                entity.ToTable("OderDetail");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ClothesId).HasColumnName("ClothesID");

                entity.Property(e => e.Odcost).HasColumnName("ODCost");

                entity.Property(e => e.Scqty).HasColumnName("SCQty");

                entity.HasOne(d => d.Clothes)
                    .WithMany(p => p.OderDetails)
                    .HasForeignKey(d => d.ClothesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OderDetail_Clothes");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OderDetail_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Scid).HasColumnName("SCID");

                entity.Property(e => e.Smid).HasColumnName("SMID");

                entity.Property(e => e.Srfee).HasColumnName("SRFee");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Smid)
                    .HasConstraintName("FK_Order_ShippingMode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ReviewsId);

                entity.Property(e => e.ReviewsId).HasColumnName("ReviewsID");

                entity.Property(e => e.ClothesId).HasColumnName("ClothesID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GuestName).HasMaxLength(50);

                entity.Property(e => e.ReviewsContent).HasMaxLength(1000);

                entity.HasOne(d => d.Clothes)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ClothesId)
                    .HasConstraintName("FK_Reviews_Clothes1");
            });

            modelBuilder.Entity<ShippingMode>(entity =>
            {
                entity.HasKey(e => e.Smid);

                entity.ToTable("ShippingMode");

                entity.Property(e => e.Smid).HasColumnName("SMID");

                entity.Property(e => e.SmmaxDelay).HasColumnName("SMMaxDelay");

                entity.Property(e => e.Smmode)
                    .HasMaxLength(50)
                    .HasColumnName("SMMode");
            });

            modelBuilder.Entity<ShippingRate>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.Smid });

                entity.ToTable("ShippingRate");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Smid).HasColumnName("SMID");

                entity.Property(e => e.Srfee).HasColumnName("SRFee");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ShippingRates)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShippingRate_Location");

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.ShippingRates)
                    .HasForeignKey(d => d.Smid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShippingRate_ShippingMode");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => new { e.Scid, e.ClothesId });

                entity.ToTable("ShoppingCart");

                entity.Property(e => e.Scid).HasColumnName("SCID");

                entity.Property(e => e.ClothesId).HasColumnName("ClothesID");

                entity.Property(e => e.Scqty).HasColumnName("SCQty");

                entity.HasOne(d => d.Clothes)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.ClothesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__Cloth__4E88ABD4");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.UserAddress).HasMaxLength(500);

                entity.Property(e => e.UserEmail).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPassword).HasMaxLength(50);

                entity.Property(e => e.UserPhone).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
