namespace CompanySalesAPI.Models.DTOs
{
    public class SaleDto
    {
        public required string OrderNumber { get; set; }
        public int ProductKey { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal SalesAmount { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}

/*
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
 */