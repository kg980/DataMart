namespace CompanySalesAPI.Models.DTOs
{
    public class CustomerProfileDto
    {
        public required CustomerDetailsDto CustomerDetails { get; set; }
        //public List<SaleDto>? Sales { get; set; } // can be nullable because customer might be new with 0 orders
        public List<SaleDto> Sales { get; set; } = new(); // return empty if no sales, can be empty but shouldnt be null.

        public decimal TotalSpending { get; set; }
        public int TotalItemsBought { get; set; }
        
        // TODO: public int TotalOrdersCount { get; set; }
        public DateTime? FirstOrderDate { get; set; }
        public DateTime? LastOrderDate { get; set; }
    }
}
