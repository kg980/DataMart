using CompanySalesAPI.Models.DTOs;
using CompanySalesAPI.Repositories;
using CompanySalesAPI.Repositories.Interfaces;
using CompanySalesAPI.Services.Interfaces;

namespace CompanySalesAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISalesRepository _salesRepository;

        public CustomerService(ICustomerRepository repository, ISalesRepository salesRepository)
        {
            _customerRepository = repository;
            _salesRepository = salesRepository;
        }

        public async Task<CustomerProfileDto?> GetCustomerProfileAsync(int customerId)
        {
            var details = await _customerRepository.GetCustomerDetailsAsync(customerId);

            if (details == null)
                return null;

            var allSales = await _salesRepository.GetSalesForCustomer(customerId);
            var totalSales = await _salesRepository.GetTotalItemsSoldToCustomer(customerId);
            var totalSpent = await _salesRepository.GetTotalSpentForCustomer(customerId);

            var firstOrder = await _salesRepository.GetFirstOrderDate(customerId);
            var lastOrder = await _salesRepository.GetLastOrderDate(customerId);

            var detailsDto = new CustomerDetailsDto
            {
                CustomerId = details.CustomerId,
                CustomerNumber = details.CustomerNumber,
                FirstName = details.FirstName,
                LastName = details.LastName,
                FullName = details.FullName,
                Country = details.Country,
                MaritalStatus = details.MaritalStatus,
                Gender = details.Gender,
                BirthDate = details.BirthDate
            };

            return new CustomerProfileDto
            {
                CustomerDetails = detailsDto,
                Sales = allSales,
                TotalItemsBought = totalSales,
                TotalSpending = totalSpent,
                FirstOrderDate = firstOrder,
                LastOrderDate = lastOrder
            };
        }
    }
}


/*

    public class CustomerDetailsDto
    {
        public long CustomerId { get; set; }
        public required string CustomerNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public required string FullName { get; set; }
        public required string Country { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

    }

 
     public class CustomerProfileDto
    {
        public required CustomerDetailsDto CustomerDetails { get; set; }
        public List<SaleDto>? Sales { get; set; } // can be nullable because customer might be new with 0 orders
        public int TotalSalesCount { get; set; }
        public int TotalSpending { get; set; }
        public DateTime FirstOrderDate { get; set; }
        public DateTime LastOrderDate { get; set; }
    }
 */