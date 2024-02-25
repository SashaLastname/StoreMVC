using System;
using System.Collections.Generic;
using StoreDomain.Models;
using Microsoft.EntityFrameworkCore;

//namespace StoreDomain.Models;
namespace StoreInfrastructure.Models;
public partial class DbstoreContext : DbContext
{
    public DbstoreContext()
    {
    }

    public DbstoreContext(DbContextOptions<DbstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VRU3SB3\\SQLEXPRESS;Database=DBStore;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK_ADMIN");

            entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");
            entity.Property(e => e.EMail)
                .HasMaxLength(20)
                .HasColumnName("E_mail");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(10);
            entity.Property(e => e.Possition).HasMaxLength(50);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.IdCart).HasName("PK_CART");

            entity.Property(e => e.IdCart).HasColumnName("Id_Cart");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cart_fk0");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cart_fk1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK_CATEGORY");

            entity.Property(e => e.IdCategory).HasColumnName("Id_Category");
            entity.Property(e => e.CategoryTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK_USER");

            entity.Property(e => e.IdCustomer).HasColumnName("Id_Customer");
            entity.Property(e => e.Adress).HasMaxLength(255);
            entity.Property(e => e.EMail)
                .HasMaxLength(10)
                .HasColumnName("E_mail");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(10);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK_ORDER");

            entity.Property(e => e.IdOrder).HasColumnName("Id_Order");
            entity.Property(e => e.AdminId).HasColumnName("Admin_id");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.Status).HasMaxLength(1);

            entity.HasOne(d => d.Admin).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("Order_fk1");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_fk0");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.IdItem).HasName("PK_ORDER_ITEM");

            entity.ToTable("Order_Items");

            entity.Property(e => e.IdItem)
                .ValueGeneratedNever()
                .HasColumnName("Id_Item");
            entity.Property(e => e.OrderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Order_id");
            entity.Property(e => e.OrderItemQuantity).HasColumnName("Order_item_quantity");
            entity.Property(e => e.PriceUnit)
                .HasColumnType("money")
                .HasColumnName("Price_unit");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Order_Item");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Order_Item");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK_PRODUCT");

            entity.Property(e => e.IdProduct).HasColumnName("Id_Product");
            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product_fk0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
