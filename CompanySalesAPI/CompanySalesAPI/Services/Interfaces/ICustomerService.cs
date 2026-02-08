using CompanySalesAPI.Models.DTOs;

namespace CompanySalesAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDetailsDto?> GetCustomerProfileAsync(int customerId);
    }
}
