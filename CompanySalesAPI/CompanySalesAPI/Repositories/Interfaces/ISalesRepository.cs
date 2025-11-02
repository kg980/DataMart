using CompanySalesAPI.Data;
using CompanySalesAPI.Models.Helpers;

namespace CompanySalesAPI.Repositories.Interfaces
{
    public interface ISalesRepository
    {
        Task<List<CustomerSalesAggregate>> GetTopCustomersBySalesAsync(int count);
    }
}
