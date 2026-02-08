using CompanySalesAPI.Data;
using CompanySalesAPI.Models;
using CompanySalesAPI.Models.DTOs;
using CompanySalesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Repositories
{
    public class CustomerRepository(DataWarehouseContext context) : ICustomerRepository
    {
        private readonly DataWarehouseContext _context = context;

        public async Task<List<Customer>> GetCustomersByIdsAsync(List<int> customerIds)
        {
            return await _context.Customers
                .Where(c => customerIds.Contains(c.CustomerId))
                .ToListAsync();

        }

        public async Task<CustomerDetailsDto?> GetCustomerDetailsAsync(int id)
        {
            return await _context.Customers
                .Where(c => c.CustomerId == id)
                .Select(c => new CustomerDetailsDto
                {
                    CustomerId = c.CustomerId,
                    CustomerNumber = c.CustomerNumber,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FullName = c.FirstName + " " + c.LastName,
                    Country = c.Country,
                    MaritalStatus = c.MaritalStatus,
                    Gender = c.Gender,
                    BirthDate = c.BirthDate
                }).SingleOrDefaultAsync();
        }


    }
}


/*
 Question:
What happens if multiple classes inherit ICustomerRepository. Which implementation will my Service constructor get?
 */

