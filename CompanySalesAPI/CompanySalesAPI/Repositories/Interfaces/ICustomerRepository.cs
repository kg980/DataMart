
using CompanySalesAPI.Models;
using CompanySalesAPI.Models.DTOs;

namespace CompanySalesAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersByIdsAsync(List<int> customerIds); // i get a list of ids, and i return their corresponding records.

        Task<CustomerProfileDto> GetCustomerProfileAsync(int customerId);
    }
}
