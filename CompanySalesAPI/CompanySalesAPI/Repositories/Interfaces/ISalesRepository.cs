using CompanySalesAPI.Data;
using CompanySalesAPI.Models;
using CompanySalesAPI.Models.DTOs;
using CompanySalesAPI.Models.Helpers;

namespace CompanySalesAPI.Repositories.Interfaces
{
    public interface ISalesRepository
    {
        Task<DateTime?> GetFirstOrderDate(int customerId);
        Task<DateTime?> GetLastOrderDate(int customerId);
        Task<List<SaleDto>> GetSalesForCustomer(int customerId);
        Task<List<CustomerSalesAggregate>> GetTopCustomersBySalesAsync(int count);
        Task<int> GetTotalSalesForCustomer(int customerId); // check if this is same thing as above?
        Task<int> GetTotalSpentForCustomer(int customerId);
    }
}
