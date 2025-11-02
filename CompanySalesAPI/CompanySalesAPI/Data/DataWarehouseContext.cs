using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Data
{
    public class DataWarehouseContext : DbContext
    {
        public DataWarehouseContext(DbContextOptions<DataWarehouseContext> options) : base(options)
        {
        }

        //protected DataWarehouseContext()
        //{
        //}


        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Sale> Sales { get; set; }

    }
}


