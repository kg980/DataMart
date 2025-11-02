
using CompanySalesAPI.Models;

namespace CompanySalesAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersByIdsAsync(List<int> customerIds); // i get a list of ids, and i return their corresponding records.
    }
}
