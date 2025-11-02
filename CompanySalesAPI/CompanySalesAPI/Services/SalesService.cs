using CompanySalesAPI.Models.DTOs;
using CompanySalesAPI.Repositories.Interfaces;
using CompanySalesAPI.Services.Interfaces;

namespace CompanySalesAPI.Services
{
    public class SalesService : ISalesService
    {

        private readonly ISalesRepository _salesRepository;
        private readonly ICustomerRepository _customerRepository;

        public SalesService(ISalesRepository salesRepository, ICustomerRepository customerRepository)
        {
            _salesRepository = salesRepository;
            _customerRepository = customerRepository;
        }

        public async Task<List<TopCustomerDto>> GetTopCustomersAsync(int count)
        {
            // get top sales, then extract customers from that
            var topSales = await _salesRepository.GetTopCustomersBySalesAsync(count);
            var customerIds = topSales.Select(x => x.CustomerId).ToList();
            var customers = await _customerRepository.GetCustomersByIdsAsync(customerIds);

            // map result to my DTO (need to make an IENumerable, then convert it .ToList() to meet the method return type & make it usable by the API
            // mapping some selection, 's', to some IEnumerable, then converting ToList :) 
            var result = topSales.Select(s => 
            {
                var customer = customers.FirstOrDefault(customers => customers.CustomerId == s.CustomerId);
                return new TopCustomerDto
                {
                    CustomerId = s.CustomerId,
                    CustomerNumber = customer.CustomerNumber,
                    FullName = $"{customer.FirstName} {customer.LastName}",
                    Country = customer.Country,
                    TotalSales = s.TotalSales
                };

            }).ToList();

            return result;
        }
    }
}
