namespace CompanySalesAPI.Models.DTOs
{
    public class CustomerProfileDto
    {
        public required CustomerDetailsDto CustomerDetails { get; set; }
        public List<SaleDto>? Sales { get; set; } // can be nullable because customer might be new with 0 orders
        public int TotalSalesCount { get; set; }
        public int TotalSpending { get; set; }
        public DateTime FirstOrderDate { get; set; }
        public DateTime LastOrderDate { get; set; }
    }
}
