using CompanySalesAPI.Data;
using CompanySalesAPI.Models;
using CompanySalesAPI.Models.DTOs;
using CompanySalesAPI.Models.Helpers;
using CompanySalesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly DataWarehouseContext _context;
        
        public SalesRepository(DataWarehouseContext context)
        {
            _context = context;
        }
        // The constructor can also look like this shorthand:
        // public SalesRepository(DataWarehouseContext context) => _context = context;

        public async Task<DateTime?> GetFirstOrderDate(int customerId)
        {
            return await _context.Sales
                .Where(s => s.CustomerId == customerId)
                .OrderBy(s => s.OrderDate)
                .Select(s => s.OrderDate)
                .FirstOrDefaultAsync();

        }

        public async Task<DateTime?> GetLastOrderDate(int customerId)
        {
            return await _context.Sales
                .Where(s => s.CustomerId == customerId)
                .OrderByDescending(s => s.OrderDate)
                .Select(s => s.OrderDate)
                .FirstOrDefaultAsync();
        }

        public Task GetSalesForCustomer(int customerId)
        {
            throw new NotImplementedException();
        }


        public async Task<List<CustomerSalesAggregate>> GetTopCustomersBySalesAsync(int count)
        {// makes a list of customers ordered by most sales, takes top x customers
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

        public async Task<int> GetTotalSalesForCustomer(int customerId)
        {// get total num of sales for specific customer
            return await _context.Sales
                .Where(s => s.CustomerId == customerId)
                .CountAsync();

        } 

        public async Task<int> GetTotalSpentForCustomer(int customerId)
        {// get total spendings for specific customer
            return await _context.Sales
                .Where(s => s.CustomerId == customerId)
                .SumAsync(s => s.SalesAmount);
        } 

        Task<List<SaleDto>> ISalesRepository.GetSalesForCustomer(int customerId)
        {
            //return _context.Sales
            //    .Where(s => s.CustomerId == customerId)
            //    .ToListAsync();
            return _context.Sales
                .Where(s => s.CustomerId == customerId)
                .Select(s => new SaleDto
                {
                    OrderNumber = s.OrderNumber,
                    ProductKey = s.ProductKey,
                    CustomerId = s.CustomerId,
                    OrderDate = s.OrderDate,
                    ShippingDate = s.ShippingDate,
                    DueDate = s.DueDate,
                    SalesAmount = s.SalesAmount,
                    Quantity = s.Quantity,
                    Price = s.Price
                })
                .ToListAsync();
        }
    }
}


// Tests:
//What if user requests more users than are in the db for example?