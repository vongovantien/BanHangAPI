using BanHangAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Data
{
    public class MyDBContext : IdentityDbContext<ApplicationUser>
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Categories");
                e.HasKey(s => s.CategoryID);
                e.HasIndex(s => s.CategoryName).IsUnique();
                e.Property(s => s.CategoryID).ValueGeneratedOnAdd();
                e.Property(s => s.CategoryName).IsRequired();
                e.HasMany(s => s.Products).WithOne(s => s.Category).HasForeignKey(s => s.CategoryID);
            });


            modelBuilder.Entity<Customer>(e =>
            {
                e.ToTable("Customers");
                e.HasKey(s => s.CustomerID);
                e.Property(s => s.CustomerID).ValueGeneratedOnAdd();
                e.HasMany(s => s.Orders).WithOne(s => s.Customer).HasForeignKey(s => s.CustomerID);
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Products");
                e.HasKey(s => s.ProductID);
                e.Property(s => s.ProductID).ValueGeneratedOnAdd();
                e.Property(s => s.UnitPrice).HasColumnType("decimal(18,4)");
                e.Property(s => s.ProductName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("Employees");
                e.HasKey(s => s.EmployeeID);
                e.Property(s => s.EmployeeID).ValueGeneratedOnAdd();
                e.Property(s => s.EmplployeeName).IsRequired().HasMaxLength(50);
                e.HasMany(s => s.Orders).WithOne(s => s.Employee).HasForeignKey(s => s.EmployeeID);
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.HasKey(s => s.OrderID);
                e.Property(s => s.OrderID).ValueGeneratedOnAdd();
                e.Property(s => s.OrderDate).HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetails");
                e.HasKey(s => new { s.ProductID, s.OrderID });
                e.Property(s => s.UnitPrice).HasColumnType("decimal(18,4)");
                e.HasOne(s => s.Order)
                    .WithMany(s => s.OrderDetails)
                    .HasForeignKey(s => s.OrderID)
                    .HasConstraintName("FK_OrderDetail_Order");
                e.HasOne(s => s.Product)
                    .WithMany(s => s.OrderDetails)
                    .HasForeignKey(s => s.ProductID)
                    .HasConstraintName("FK_OrderDetail_Product");
            });
            modelBuilder.Entity<Supplier>(e =>
            {
                e.ToTable("Suppliers");
                e.HasKey(s => s.SupplierID);
                e.Property(s => s.SupplierID).ValueGeneratedOnAdd();
                e.Property(s => s.SuplierName).HasMaxLength(50);
                e.HasMany(s => s.Products).WithOne(s => s.Supplier).HasForeignKey(s => s.SupplierID);
            });
            modelBuilder.Entity<Document>(e =>
            {
                e.ToTable("Document");
                e.Property(e => e.FileName).HasMaxLength(500).IsUnicode(false);
                e.Property(e => e.ContentType).HasMaxLength(100).IsUnicode(false);
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set;}
        public DbSet<Document> Documents { get; set; }
    }
}
