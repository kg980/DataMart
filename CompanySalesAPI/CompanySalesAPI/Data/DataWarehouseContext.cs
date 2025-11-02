using System.Collections.Generic;
using System.Reflection;
using CompanySalesAPI.Models;
using CompanySalesAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Data
{
    public class DataWarehouseContext : DbContext
    {
        public DataWarehouseContext(DbContextOptions<DataWarehouseContext> options) : base(options)
        {
        }


        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Sale> Sales { get; set; }

        // Question: Is this a standard approach? My reasoning:
        // Centralizing all my Model column name mismatches here with FluentAPI instead of using attributes.
        //      i.e. SalesAmount prop maps to "sales_amount" column in the SQL database.
        // Separation of concerns -> in the context of my project, my Models are accessing these columns,
        // but perhaps the same Models can be used in another context,
        // so I dont want to map their attributes to column names in the Model itself.
        // However, this looks pretty awful.
        // for projects with many models probs nicer to see the column mappings in the model actually so you dont have to cross-reference
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Keyless entities mapped to SQL views (views dont have keys)
            modelBuilder.Entity<Customer>().HasNoKey();
            modelBuilder.Entity<Product>().HasNoKey();
            modelBuilder.Entity<Sale>().HasNoKey();

            // customer mappings
            modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Customer>().Property(c => c.CustomerKey).HasColumnName("customer_key");
            modelBuilder.Entity<Customer>().Property(c => c.CustomerNumber).HasColumnName("customer_number");
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<Customer>().Property(c => c.LastName).HasColumnName("last_name");
            modelBuilder.Entity<Customer>().Property(c => c.Country).HasColumnName("country");
            modelBuilder.Entity<Customer>().Property(c => c.BirthDate).HasColumnName("birthdate");
            modelBuilder.Entity<Customer>().Property(c => c.CreateDate).HasColumnName("create_date");
            modelBuilder.Entity<Customer>().Property(c => c.MaritalStatus).HasColumnName("marital_status");
            modelBuilder.Entity<Customer>().Property(c => c.Gender).HasColumnName("gender");

            modelBuilder.Entity<Customer>()
                .Property(c => c.MaritalStatus)
                .HasConversion(
                    v => v.ToString(), // enum → string
                    v => Enum.Parse<MaritalStatus>(v) // string → enum
                );

            modelBuilder.Entity<Customer>()
                .Property(c => c.Gender)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<Gender>(v)
                );

            // one customer -> many sales mapping (new prop in customer model)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(c => c.CustomerId);
                //.OnDelete(DeleteBehavior.Cascade); // link sale w/ customer by id and on delete customer, delete their sales too.




            // product mappings
            modelBuilder.Entity<Product>().Property(p => p.ProductKey).HasColumnName("product_key");
            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<Product>().Property(p => p.ProductNumber).HasColumnName("product_number");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("product_name");
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("category_id");
            modelBuilder.Entity<Product>().Property(p => p.Category).HasColumnName("category");
            modelBuilder.Entity<Product>().Property(p => p.Subcategory).HasColumnName("subcategory");
            modelBuilder.Entity<Product>().Property(p => p.Maintenance).HasColumnName("maintenance");
            modelBuilder.Entity<Product>().Property(p => p.Cost).HasColumnName("cost");
            modelBuilder.Entity<Product>().Property(p => p.ProductLine).HasColumnName("product_line");
            modelBuilder.Entity<Product>().Property(p => p.StartDate).HasColumnName("start_date");

            modelBuilder.Entity<Product>()
                .Property(p => p.Maintenance)
                .HasConversion(
                    v => v ? "Yes" : "No", // bool → string
                    v => v == "Yes"        // string → bool
                );

            // sale mappings
            modelBuilder.Entity<Sale>().Property(s => s.OrderNumber).HasColumnName("order_number");
            modelBuilder.Entity<Sale>().Property(s => s.ProductKey).HasColumnName("product_key");
            modelBuilder.Entity<Sale>().Property(s => s.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Sale>().Property(s => s.OrderDate).HasColumnName("order_date");
            modelBuilder.Entity<Sale>().Property(s => s.ShippingDate).HasColumnName("shipping_date");
            modelBuilder.Entity<Sale>().Property(s => s.DueDate).HasColumnName("due_date");
            modelBuilder.Entity<Sale>().Property(s => s.SalesAmount).HasColumnName("sales_amount");
            modelBuilder.Entity<Sale>().Property(s => s.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<Sale>().Property(s => s.Price).HasColumnName("price");

        }

    }
}


