using CompanySalesAPI.Models.DTOs;

namespace CompanySalesAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerProfileDto> GetCustomerProfileAsync(int customerId);
    }
}
