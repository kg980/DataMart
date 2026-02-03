using CompanySalesAPI.Models.DTOs;
using CompanySalesAPI.Repositories.Interfaces;
using CompanySalesAPI.Services.Interfaces;

namespace CompanySalesAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerProfileDto> GetCustomerProfileAsync(int customerId)
        {
            return await _repository.GetCustomerProfileAsync(customerId);
        }
    }

}
