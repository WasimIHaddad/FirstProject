using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FirstProject.Models
{
    public partial class restaurantdbContext : DbContext
    {
        public bool IgnoreFilter { get; set; }
        public restaurantdbContext()
        {
        }

        public restaurantdbContext(DbContextOptions<restaurantdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customermenu> Customermenus { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Restaurantmenu> Restaurantmenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;port=3306;user=root;password=1997;database=restaurantdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Customermenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customermenu");

                entity.HasIndex(e => new { e.RestaurantMenuId, e.CustomerId }, "custom_menuId_idx");

                entity.HasIndex(e => e.CustomerId, "customer_menuId_idx");

                entity.Property(e => e.CustomerId).HasColumnType("int unsigned");

                entity.Property(e => e.RestaurantMenuId).HasColumnType("int unsigned");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customerkey");

                entity.HasOne(d => d.RestaurantMenu)
                    .WithMany()
                    .HasForeignKey(d => d.RestaurantMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("menukey");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("restaurant");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Restaurantmenu>(entity =>
            {
                entity.ToTable("restaurantmenu");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.RestaurantId, "resturantmenuId_idx");

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.MealName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PriceInNis).HasColumnType("decimal(10,0)");

                entity.Property(e => e.PriceInUsd).HasColumnType("decimal(10,0)");

                entity.Property(e => e.RestaurantId).HasColumnType("int unsigned");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Restaurantmenus)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("resturantmenuid");
            });
            modelBuilder.Entity<Restaurant>().HasQueryFilter(a => !a.Archived|| IgnoreFilter);
            modelBuilder.Entity<Restaurantmenu>().HasQueryFilter(a => !a.Archived || IgnoreFilter);
            modelBuilder.Entity<Customer>().HasQueryFilter(a => !a.Archived || IgnoreFilter);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
