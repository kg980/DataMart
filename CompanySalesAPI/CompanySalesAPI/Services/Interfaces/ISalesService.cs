using CompanySalesAPI.Models.DTOs;

namespace CompanySalesAPI.Services.Interfaces
{
    public interface ISalesService
    {
        Task<List<TopCustomerDto>> GetTopCustomersAsync(int count);

    }
}
