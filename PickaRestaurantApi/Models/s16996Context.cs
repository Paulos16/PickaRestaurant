using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PickaRestaurantApi.Models
{
    public partial class s16996Context : DbContext
    {
        public s16996Context()
        {
        }

        public s16996Context(DbContextOptions<s16996Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<DeliveryDriver> DeliveryDriver { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }
        public virtual DbSet<PizzaTopping> PizzaTopping { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }
        public virtual DbSet<TypeOfBread> TypeOfBread { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16996;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdministrator)
                    .HasName("Administrator_pk");

                entity.Property(e => e.IdAdministrator)
                    .HasColumnName("id_administrator")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(900)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeliveryDriver>(entity =>
            {
                entity.HasKey(e => e.IdDeliveryDriver)
                    .HasName("Delivery_Driver_pk");

                entity.ToTable("Delivery_Driver");

                entity.Property(e => e.IdDeliveryDriver)
                    .HasColumnName("id_delivery_driver")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(900)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.IdDiscount)
                    .HasName("Discount_pk");

                entity.Property(e => e.IdDiscount)
                    .HasColumnName("id_discount")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(900)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("Order_pk");

                entity.Property(e => e.IdOrder)
                    .HasColumnName("id_order")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcceptedTime)
                    .HasColumnName("accepted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.AdministratorIdAdministrator).HasColumnName("Administrator_id_administrator");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasColumnName("customer_address")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerContact)
                    .IsRequired()
                    .HasColumnName("customer_contact")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDriverIdDeliveryDriver).HasColumnName("Delivery_Driver_id_delivery_driver");

                entity.Property(e => e.DeliveryTime)
                    .HasColumnName("delivery_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DiscountIdDiscount).HasColumnName("Discount_id_discount");

                entity.Property(e => e.RestaurantIdRestaurant).HasColumnName("Restaurant_id_restaurant");

                entity.HasOne(d => d.AdministratorIdAdministratorNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AdministratorIdAdministrator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Administrator");

                entity.HasOne(d => d.DeliveryDriverIdDeliveryDriverNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DeliveryDriverIdDeliveryDriver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Delivery_Driver");

                entity.HasOne(d => d.DiscountIdDiscountNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DiscountIdDiscount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Discount");

                entity.HasOne(d => d.RestaurantIdRestaurantNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.RestaurantIdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Restaurant");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("id_pizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsStandard).HasColumnName("is_standard");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfBreadName)
                    .IsRequired()
                    .HasColumnName("Type_Of_Bread_name")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.HasOne(d => d.TypeOfBreadNameNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.TypeOfBreadName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Type_Of_Bread");
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.OrderIdOrder })
                    .HasName("Pizza_Order_pk");

                entity.ToTable("Pizza_Order");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_id_pizza");

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_id_order");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Order_Order");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Order_Pizza");
            });

            modelBuilder.Entity<PizzaTopping>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.ToppingIdTopping })
                    .HasName("Pizza_Topping_pk");

                entity.ToTable("Pizza_Topping");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_id_pizza");

                entity.Property(e => e.ToppingIdTopping).HasColumnName("Topping_id_topping");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaTopping)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Topping_Pizza");

                entity.HasOne(d => d.ToppingIdToppingNavigation)
                    .WithMany(p => p.PizzaTopping)
                    .HasForeignKey(d => d.ToppingIdTopping)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Topping_Topping");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.IdRestaurant)
                    .HasName("Restaurant_pk");

                entity.Property(e => e.IdRestaurant)
                    .HasColumnName("id_restaurant")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasColumnName("contact_number")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(900)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.HasKey(e => e.IdTopping)
                    .HasName("Topping_pk");

                entity.Property(e => e.IdTopping)
                    .HasColumnName("id_topping")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasMaxLength(900)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeOfBread>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("Type_Of_Bread_pk");

                entity.ToTable("Type_Of_Bread");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });
        }
    }
}
