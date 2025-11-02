using CompanySalesAPI.Models.DTOs;
using CompanySalesAPI.Repositories.Interfaces;
using CompanySalesAPI.Services.Interfaces;

namespace CompanySalesAPI.Services
{
    public class SalesService(ISalesRepository salesRepository, ICustomerRepository customerRepository) : ISalesService
    {
        // TODO: Put Customer Repository into Customer Service, and call the customer service to fetch that particular data.
        private readonly ISalesRepository _salesRepository = salesRepository;
        private readonly ICustomerRepository _customerRepository = customerRepository; // NAUGHTY NAUGHTY

        public async Task<List<TopCustomerDto>> GetTopCustomersAsync(int count) // alternative: use Result pattern
        {
            // get top sales, then extract customers from that
            var topSales = await _salesRepository.GetTopCustomersBySalesAsync(count);
            var customerIds = topSales.Select(x => x.CustomerId).ToList();
            var customers = await _customerRepository.GetCustomersByIdsAsync(customerIds);

            if(customers == null)
            {
                Console.WriteLine("No customers found."); // TODO: improve logging
                return new List<TopCustomerDto>();
            }
            // map result to my DTO (need to make an IENumerable, then convert it .ToList() to meet the method return type & make it usable by the API
            // mapping some selection, 's', to some IEnumerable, then converting ToList :) 
            var result = topSales.Select(s => 
            {
                var customer = customers.FirstOrDefault(customers => customers.CustomerId == s.CustomerId);
                return new TopCustomerDto
                {
                    CustomerId = s.CustomerId,
                    CustomerNumber = customer!.CustomerNumber, // ! to say I know for sure customer always has to exist. ignore warn.
                    FullName = $"{customer.FirstName} {customer.LastName}",
                    Country = customer.Country,
                    TotalSales = s.TotalSales
                };

            }).ToList();

            return result;
        }
    }
}
