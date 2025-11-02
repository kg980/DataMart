namespace CompanySalesAPI.Models.DTOs
{
    public class TopCustomerDto
    {
        public long CustomerId { get; set; }
        public string CustomerNumber { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public decimal TotalSales { get; set; }
    }

}
