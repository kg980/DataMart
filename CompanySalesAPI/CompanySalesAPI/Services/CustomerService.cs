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

        public async Task<CustomerDetailsDto?> GetCustomerProfileAsync(int customerId)
        {
            var profile = await _customerRepository.GetCustomerDetailsAsync(customerId);

            if (profile == null)
                return null;

            var allSales = await _salesRepository.GetSalesForCustomer(customerId);
            var totalSales = await _salesRepository.GetTotalSalesForCustomer(customerId);
            var totalSpent = await _salesRepository.GetTotalSpentForCustomer(customerId);

            var firstOrder = await _salesRepository.GetFirstOrderDate(customerId);
            var lastOrder = await _salesRepository.GetLastOrderDate(customerId);

            // TODO:
            // construct & return profile dto
            // -> can then load it into a view model for presentation layer

        }
    }

}
