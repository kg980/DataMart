using CompanySalesAPI.Data;
using CompanySalesAPI.Models;
using CompanySalesAPI.Models.Helpers;
using CompanySalesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly DataWarehouseContext _context;
        private readonly List<Customer> _customers; // save data. Create customer method -> create customer model -> add to this list

        public SalesRepository(DataWarehouseContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerSalesAggregate>> GetTopCustomersBySalesAsync(int count)
        {
            return await _context.Sales
                .GroupBy(s => s.CustomerId)
                .Select(g => new CustomerSalesAggregate
                {
                    CustomerId = g.Key,
                    TotalSales = g.Sum(s => s.SalesAmount)
                })
                .OrderByDescending(x => x.TotalSales)
                .Take(count)
                .ToListAsync();
        }


    }
}


// Tests:
//What if user requests more users than are in the db for example?