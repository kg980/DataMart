using CompanySalesAPI.Data;
using CompanySalesAPI.Models;
using CompanySalesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataWarehouseContext _context;
        public CustomerRepository(DataWarehouseContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersByIdsAsync(List<int> customerIds)
        {
            return await _context.Customers
                .Where(c => customerIds.Contains(c.CustomerId))
                .ToListAsync();

        }
    }
}


/*
 Question:
What happens if multiple classes inherit ICustomerRepository. Which implementation will my Service constructor get?
 */